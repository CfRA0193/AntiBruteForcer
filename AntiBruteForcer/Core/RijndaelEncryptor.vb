Imports System.IO
Imports System.Security.Cryptography

Public NotInheritable Class RijndaelEncryptor
    Implements IDisposable
    Private Const _blockSize = 32 '256 bit
    Private _IV() As Byte
    Private _decryptor As ICryptoTransform
    Private _encryptor As ICryptoTransform
    Private _hash256 As SHA256Managed
    Private _hash512 As SHA512Managed
    Private _key() As Byte
    Private _rijndael As RijndaelManaged

    Public Sub New()
    End Sub

    Public Sub New(password() As Byte, Optional iterations As Integer = 1)
        Initialize(password, iterations)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Clear() : GC.SuppressFinalize(Me)
    End Sub

    Private _isInitialized As Boolean
    Public Property IsInitialized() As Boolean
        Get
            Return _isInitialized
        End Get
        Private Set(value As Boolean)
            _isInitialized = value
        End Set
    End Property

    Private Sub Hash(data() As Byte, iterations As Integer, ByRef key() As Byte, ByRef IV() As Byte)
        Dim hash512Buff() As Byte = _hash512.ComputeHash(data)
        Dim hash256Buff() As Byte = _hash256.ComputeHash(data)
        For i = 1 To iterations - 1
            hash512Buff = _hash512.ComputeHash(hash512Buff)
            hash256Buff = _hash256.ComputeHash(hash256Buff)
        Next
        key = _hash256.ComputeHash(hash512Buff)
        IV = _hash256.ComputeHash(hash256Buff)
    End Sub

    Public Sub Initialize(password() As Byte, Optional iterations As Integer = 1)
        Clear()
        Hash(password, iterations, _key, _IV)
        _rijndael.Mode = CipherMode.CBC
        _rijndael.KeySize = (_key.Length << 3)
        _rijndael.BlockSize = _rijndael.KeySize
        _rijndael.Key = _key
        _rijndael.IV = _IV
        _encryptor = _rijndael.CreateEncryptor()
        _decryptor = _rijndael.CreateDecryptor()
        IsInitialized = True
    End Sub

    Public Sub Clear()
        IsInitialized = False
        ClearArray(_key)
        ClearArray(_IV)
        If _hash256 IsNot Nothing Then _hash256.Clear()
        If _hash512 IsNot Nothing Then _hash512.Clear()
        If _rijndael IsNot Nothing Then _rijndael.Clear()
        _hash256 = New SHA256Managed()
        _hash512 = New SHA512Managed()
        _rijndael = New RijndaelManaged() With {.Padding = PaddingMode.None}
    End Sub

    Public Function WrapStream(stream As Stream, encryptionMode As Boolean) As Stream
        If Not IsInitialized Then
            Throw New Exception("RijndaelEncryptor is not initialized!")
        End If
        Return If(encryptionMode, New CryptoStream(stream, _encryptor, CryptoStreamMode.Write), New CryptoStream(stream, _decryptor, CryptoStreamMode.Read))
    End Function

    Public Shared Function Encode(data As Byte(), key() As Byte, Optional paddingValue As Boolean = True) As Byte()
        If Not (key IsNot Nothing AndAlso key.Length <> 0) Then
            key = New Byte() {0}
        End If
        Dim scw As New RijndaelEncryptor(key)
        Dim outputStream = New MemoryStream()
        Dim outputCryptoStream = scw.WrapStream(outputStream, True)
        Dim paddingLength = _blockSize - (data.Length Mod _blockSize)
        Dim padding = New Byte(paddingLength - 1) {}
        Dim rng As New RNGCryptoServiceProvider() : rng.GetBytes(padding)
        outputCryptoStream.Write(data, 0, data.Length)
        outputCryptoStream.Write(padding, 0, padding.Length)
        CType(outputCryptoStream, CryptoStream).FlushFinalBlock()
        Dim paddingByte = ((CByte(paddingLength) << 3) And &HF8) Or (DateTime.Now.Ticks And &H7)
        outputCryptoStream.Flush()
        If paddingValue Then outputStream.WriteByte(paddingByte)
        outputStream.Flush() : outputStream.Seek(0, SeekOrigin.Begin)
        Dim outputBlocksCount = CInt(Math.Ceiling(data.Length / _blockSize))
        Dim outputData = outputStream.GetBuffer() : Array.Resize(outputData, (outputBlocksCount * _blockSize) + If(paddingValue, 1, 0))
        Return outputData
    End Function

    Public Shared Function Decode(inputData As Byte(), key() As Byte, Optional paddingValue As Boolean = True) As Byte()
        If Not (key IsNot Nothing AndAlso key.Length <> 0) Then
            key = New Byte() {0}
        End If
        Dim scw As New RijndaelEncryptor(key)
        Dim data = If(paddingValue, New Byte(inputData.Length - 2) {}, New Byte(inputData.Length - 1) {})
        Array.Copy(inputData, data, data.Length)
        Dim outputStream = New MemoryStream(data)
        Dim inputStream = scw.WrapStream(outputStream, False)
        Dim dataStream As New MemoryStream()
        inputStream.CopyTo(dataStream)
        dataStream.Flush() : dataStream.Seek(0, SeekOrigin.Begin)
        Dim decBytesWithPadding = dataStream.GetBuffer() : Array.Resize(decBytesWithPadding, CInt(dataStream.Length))
        Dim paddingLength = If(paddingValue, (CByte(inputData(inputData.Length - 1)) >> 3) And &H1F, 0)
        Dim decBytes = New Byte((decBytesWithPadding.Length - paddingLength) - 1) {}
        Array.Copy(decBytesWithPadding, decBytes, decBytes.Length)
        Return decBytes
    End Function

    Private Shared Sub ClearArray(Of T)(array() As T)
        If array Is Nothing Then Return
        System.Array.Clear(array, 0, array.Length)
    End Sub
End Class
