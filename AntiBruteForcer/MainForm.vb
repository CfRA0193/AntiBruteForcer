﻿Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports Jebtek.RdRand
Imports Scrypt

Public Class MainForm
    Private _salt As New List(Of Byte)
    Private _distrMap As Long()
    Private _saltTitle As String = "AntiBruteForcer ENCRYPTED SALT"
    Private _keyTitle As String = "AntiBruteForcer KEY"
    Private _saltBlockSize As Integer = 20
    Private _nIters As Integer = 262144
    Private _deriveBlocksCount As Integer = 10
    Private _messageWidth = 16
    Private _rdRand As Boolean = False

    Private Function Hash1600(bytesToHash As Byte(), Optional paddingLength As Integer = 0) As Byte()
        Dim HR As New List(Of Byte)
        Dim H1 As New SHA512Managed    '512 bit
        Dim H2 As New SHA384Managed    '384 bit
        Dim H3 As New SHA256Managed    '256 bit
        Dim H4 As New SHA1Managed      '160 bit
        Dim H5 As New RIPEMD160Managed '160 bit
        Dim H6 As New MD5CryptoServiceProvider() '128 bit
        '---------------------------------------
        HR.AddRange(H1.ComputeHash(bytesToHash))
        HR.AddRange(H2.ComputeHash(bytesToHash))
        HR.AddRange(H3.ComputeHash(bytesToHash))
        HR.AddRange(H4.ComputeHash(bytesToHash))
        HR.AddRange(H5.ComputeHash(bytesToHash))
        HR.AddRange(H6.ComputeHash(bytesToHash))
        '---------------------------------------
        Dim padding = New Byte(paddingLength - 1) {}
        Dim rng As New RNGCryptoServiceProvider() : rng.GetBytes(padding)
        HR.AddRange(padding)
        '---------------------------------------
        Return HR.ToArray()
    End Function

    Private Sub UpdateEncryptedSalt(e As MouseEventArgs)
        _salt.AddRange(Encoding.UTF8.GetBytes(e.X.ToString()))
        _salt.AddRange(Encoding.UTF8.GetBytes(e.Y.ToString()))
        _salt.AddRange(Encoding.UTF8.GetBytes(Date.Now.Ticks.ToString()))
        _salt.AddRange(Guid.NewGuid().ToByteArray())
        If _rdRand Then _salt.AddRange(RdRandom.GenerateBytes(256 / 8))
        Dim saltHash = Hash1600(_salt.ToArray(), 32)
        _salt.Clear() : _salt.AddRange(saltHash)
        '----------------------------------------------------------------
        Dim salt1 = _salt.ToArray()
        Dim saltEnc1 = RijndaelEncryptor.Encode(salt1, Encoding.UTF8.GetBytes(_saltPasswordTextBox.Text))
        Dim saltBase64Enc = Base64Sync.Encode(saltEnc1, _saltTitle, _messageWidth)
        Dim saltEnc2 = Base64Sync.Decode(saltBase64Enc, _saltTitle, _messageWidth)
        For i = 0 To saltEnc1.Length - 1
            If saltEnc1(i) <> saltEnc2(i) Then
                Throw New Exception("saltEnc1 <> saltEnc2")
                Exit For
            End If
        Next
        Dim salt2 = RijndaelEncryptor.Decode(saltEnc2, Encoding.UTF8.GetBytes(_saltPasswordTextBox.Text))
        _saltPasswordTextBox.BackColor = Color.LightSkyBlue
        For i = 0 To salt1.Length - 1
            If salt1(i) <> salt2(i) Then
                Throw New Exception("salt1 <> salt2")
                Exit For
            End If
        Next
        _encryptedSaltRichTextBox.Text = Encoding.UTF8.GetString(saltBase64Enc)
    End Sub

    Private Sub _deriveKeyButton_Click(sender As Object, e As EventArgs) Handles _deriveKeyButton.Click
        Try
            _saltGenerationCheckBox.Checked = False : _keyRichTextBox.Text = "Started to derive key..." + vbCrLf
            If Not _saltDecryptionCheckBox.Checked Then UpdateEncryptedSalt(e)
            _saltPasswordTextBox.Text = _saltPasswordTextBox.Text.Trim()
            _masterPasswordTextBox.Text = _masterPasswordTextBox.Text.Trim()
            Application.DoEvents()
            Dim password = Encoding.UTF8.GetBytes(_masterPasswordTextBox.Text)
            Dim salt = New List(Of Byte)(RijndaelEncryptor.Decode(Base64Sync.Decode(Encoding.UTF8.GetBytes(_encryptedSaltRichTextBox.Text), _saltTitle, _messageWidth), Encoding.UTF8.GetBytes(_saltPasswordTextBox.Text)))
            Dim resultKey = New List(Of Byte)
            For i = 0 To _deriveBlocksCount - 1
                Dim saltBlock = New Byte(_saltBlockSize - 1) {} : salt.CopyTo((_saltBlockSize * i), saltBlock, 0, _saltBlockSize)
                Dim keyBlockS = ScryptEncoder.CryptoScrypt(password, saltBlock, _nIters, 16, 1) '256 bit, 512 Mb RAM!
                Dim keyBlockR = New Rfc2898DeriveBytes(password, saltBlock, _nIters).GetBytes(_saltBlockSize) '160 bit
                Dim hmacA = New HMACSHA1(keyBlockS) : Dim keyBlockA = hmacA.ComputeHash(keyBlockR)
                Dim hmacB = New HMACSHA256(keyBlockR) : Dim keyBlockB = hmacB.ComputeHash(keyBlockS)
                resultKey.AddRange(keyBlockA)
                Dim saltEnc = New MemoryStream(RijndaelEncryptor.Encode(salt.ToArray(), keyBlockB, False))
                salt = New List(Of Byte)(saltEnc.ToArray())
                _keyRichTextBox.AppendText(((_deriveBlocksCount - 1) - i).ToString()) : Application.DoEvents()
            Next
            Dim result As Byte() = Nothing
            If _128bitKeyCheckBox.Checked Or _256bitKeyCheckBox.Checked Then
                Dim H3 As New SHA256Managed
                Dim shortKey = New MemoryStream(H3.ComputeHash(resultKey.ToArray()))
                If _128bitKeyCheckBox.Checked Then shortKey.SetLength(12) Else shortKey.SetLength(24)
                result = shortKey.ToArray()
            Else
                result = resultKey.ToArray()
            End If
            With _keyRichTextBox
                .ClearUndo()
                .Clear()
                .Text = Encoding.UTF8.GetString(Base64Sync.Encode(result, _keyTitle, _messageWidth))
            End With
        Catch
            MessageBox.Show("Can't derive key!")
        End Try
    End Sub

    Private Sub _encryptedSaltCopyButton_Click(sender As Object, e As EventArgs) Handles _encryptedSaltCopyButton.Click
        Try
            Dim saltSb = New StringBuilder()
            For Each s In _encryptedSaltRichTextBox.Lines
                saltSb.Append(s) : saltSb.Append(ControlChars.CrLf)
            Next
            Clipboard.SetText(saltSb.ToString())
            _encryptedSaltRichTextBox.ClearUndo() : _encryptedSaltRichTextBox.Clear()
        Catch ex As Exception
            MessageBox.Show("Can't copy encrypted salt to clipboard!")
        End Try
    End Sub

    Private Sub _keyCopyButton_Click(sender As Object, e As EventArgs) Handles _keyCopyButton.Click
        Try
            Dim keySb = New StringBuilder()
            For i = 1 To _keyRichTextBox.Lines.Length - 2
                keySb.Append(_keyRichTextBox.Lines(i).Replace(vbCr, String.Empty))
            Next
            Clipboard.SetText(keySb.ToString())
            _keyRichTextBox.ClearUndo() : _keyRichTextBox.Clear()
        Catch ex As Exception
            MessageBox.Show("Can't copy key to clipboard!")
        End Try
    End Sub

    Private Sub _saltDecryptionCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _saltDecryptionCheckBox.CheckedChanged
        If _saltDecryptionCheckBox.Checked Then
            With _saltGenerationCheckBox
                .Checked = False
                .Enabled = False
            End With
            _IntelInsidePictureBox.Visible = False
            _encryptedSaltRichTextBox.Clear()
        Else
            With _saltGenerationCheckBox
                .Enabled = True
                .Checked = True
            End With
            _IntelInsidePictureBox.Visible = True
        End If
    End Sub

    Private Sub UpdateEncryptedSalt(sender As Object, e As MouseEventArgs)
        If _saltGenerationCheckBox.Checked Then
            UpdateEncryptedSalt(e)
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title.ToString() + " [" + My.Application.Info.Version.ToString() + "]"
        Dim rdRandomGeneratorAvailable = False
        Try
            rdRandomGeneratorAvailable = RdRandom.GeneratorAvailable()
        Catch
        End Try
        If rdRandomGeneratorAvailable Then
            _IntelInsidePictureBox.Visible = True : _rdRand = True
        Else
            _IntelInsidePictureBox.Visible = False
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _encryptedSaltRichTextBox.ClearUndo() : _encryptedSaltRichTextBox.Clear()
        _saltPasswordTextBox.ClearUndo() : _saltPasswordTextBox.Clear()
        _keyRichTextBox.ClearUndo() : _keyRichTextBox.Clear()
        _masterPasswordTextBox.ClearUndo() : _masterPasswordTextBox.Clear()
        '------------------------------------------------------------------
        Clipboard.Clear()
    End Sub

    '------------------------------------------------------------------------------------------------------------------------

    Private Sub _128bitKeyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _128bitKeyCheckBox.CheckedChanged
        If _128bitKeyCheckBox.Checked Then _256bitKeyCheckBox.Checked = False
    End Sub

    Private Sub _256bitKeyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _256bitKeyCheckBox.CheckedChanged
        If _256bitKeyCheckBox.Checked Then _128bitKeyCheckBox.Checked = False
    End Sub

    Private Sub MainForm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _encryptedSaltRichTextBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _encryptedSaltRichTextBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _saltPasswordTextBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _saltPasswordTextBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _saltPasswordTextBoxLabel_MouseMove(sender As Object, e As MouseEventArgs) Handles _saltPasswordTextBoxLabel.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _saltDecryptionCheckBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _saltDecryptionCheckBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _keyRichTextBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _keyRichTextBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _masterPasswordTextBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _masterPasswordTextBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _masterPasswordTextBoxLabel_MouseMove(sender As Object, e As MouseEventArgs) Handles _masterPasswordTextBoxLabel.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _128bitKeyCheckBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _128bitKeyCheckBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _256bitKeyCheckBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _256bitKeyCheckBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _saltGenerationCheckBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _saltGenerationCheckBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _IntelInsidePictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles _IntelInsidePictureBox.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _DRNGLabel_MouseMove(sender As Object, e As MouseEventArgs)
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _deriveKeyButton_MouseMove(sender As Object, e As MouseEventArgs) Handles _deriveKeyButton.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _encryptedSaltCopyButton_MouseMove(sender As Object, e As MouseEventArgs) Handles _encryptedSaltCopyButton.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _keyCopyButton_MouseMove(sender As Object, e As MouseEventArgs) Handles _keyCopyButton.MouseMove
        UpdateEncryptedSalt(sender, e)
    End Sub

    Private Sub _saltGenerationCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _saltGenerationCheckBox.CheckedChanged
        If _saltGenerationCheckBox.Checked Then _keyRichTextBox.Text = String.Empty
    End Sub
End Class