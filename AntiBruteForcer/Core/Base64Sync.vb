Imports System.IO
Imports System.Text

Public Module Base64Sync
    Private Const _baseBlock64Size As Integer = 4
    Private Const _padSymbol As Char = "="c
    Private Const _syncSymbol As Char = ControlChars.Lf
    Private Const _syncSymbol2 As Char = ControlChars.CrLf
    Private Const _title As String = "Base64Sync"
    Private Const _pageMarker As String = ":::::Base64Sync PAGE MARKER:::::"
    Private Const _rowsToPageMarkerCounter As Integer = 32
    Private Const _dotPageNumPadding As Integer = 4

    Public Function GetBase64HashSet(Optional isExtended As Boolean = False) As HashSet(Of Byte)
        Dim base64HashSet = New HashSet(Of Byte)()
        For Each c As Char In "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
            base64HashSet.Add(AscW(c))
        Next
        If isExtended Then base64HashSet.Add(AscW(_padSymbol))
        Return base64HashSet
    End Function

    Public Function GetBase64String(source As String, Optional isExtended As Boolean = False) As String
        Dim base64 As HashSet(Of Byte) = GetBase64HashSet(isExtended)
        Dim clean = New StringBuilder()
        For Each c As Char In source
            If base64.Contains(AscW(c)) Then clean.Append(ChrW(AscW(c)))
        Next
        Return clean.ToString()
    End Function

    Private Function GetPadding(dataLen As Integer, blockSize As Integer) As Integer
        Return (blockSize - dataLen Mod blockSize) Mod blockSize
    End Function

    Public Function Encode(binary As Byte(), Optional title As String = _title, Optional messageWidth As Integer = 16) As Byte()
        Dim syncBlockSize As Integer = _baseBlock64Size * messageWidth
        Dim header = GetHeader(title, syncBlockSize)
        Dim footer = GetFooter(title, syncBlockSize)
        Dim rawBase64 As String = Convert.ToBase64String(binary)
        If (rawBase64.IndexOf(header) <> -1) OrElse (rawBase64.IndexOf(footer) <> -1) OrElse (rawBase64.IndexOf(_pageMarker) <> -1) Then Throw New Exception("Base64 text collision!")
        Dim base64 = New StringBuilder()
        base64.Append(header)
        Dim symbolsRecorded As Integer = 0
        Dim rowsToPageMarkerCounter As Integer = _rowsToPageMarkerCounter
        Dim pageNumCounter As Integer = 1
        Dim pageNum_ = New StringBuilder()
        For i As Integer = 0 To rawBase64.Length - syncBlockSize Step syncBlockSize
            base64.Append(rawBase64.Substring(i, syncBlockSize) + _syncSymbol)
            symbolsRecorded += syncBlockSize
            rowsToPageMarkerCounter -= 1
            If rowsToPageMarkerCounter = 0 Then
                rowsToPageMarkerCounter = _rowsToPageMarkerCounter
                pageNum_.Clear()
                pageNum_.Append(_pageMarker)
                Dim iterNum As Integer = 0
                Do While (pageNum_.ToString() + pageNumCounter.ToString()).Length + _dotPageNumPadding < syncBlockSize
                    iterNum += 1
                    If iterNum > 1 Then pageNum_.Append("/")
                    pageNum_.Append(pageNumCounter.ToString())
                Loop
                Do While (pageNum_.ToString() + ":").Length <= syncBlockSize
                    pageNum_.Append(":")
                Loop
                base64.Append(pageNum_)
                base64.Append(_syncSymbol)
                pageNumCounter += 1
            End If
        Next
        Dim remainSymbolsCount As Integer = rawBase64.Length - symbolsRecorded
        Dim remainSymbols As String = rawBase64.Substring(symbolsRecorded, remainSymbolsCount)
        If remainSymbols.Length <> 0 Then
            base64.Append(remainSymbols + _syncSymbol)
        End If
        base64.Append(footer)
        Return Encoding.UTF8.GetBytes(base64.ToString())
    End Function

    Public Function Decode(base64 As Byte(), Optional title As String = _title, Optional messageWidth As Integer = 16) As Byte()
        Dim syncBlockSize As Integer = _baseBlock64Size * messageWidth
        Dim header = GetHeader(title, syncBlockSize)
        Dim footer = GetFooter(title, syncBlockSize)
        Dim base64WithSync As String = Encoding.UTF8.GetString(base64).Replace(_syncSymbol2, _syncSymbol)
        base64WithSync = base64WithSync.Replace(header, String.Empty).Replace(footer, String.Empty)
        Dim base64ByLines() As String = base64WithSync.Split({_syncSymbol}, StringSplitOptions.RemoveEmptyEntries)
        Dim base64sb = New StringBuilder()
        For i = 0 To base64ByLines.Length - 1
            Dim s = base64ByLines(i) : Dim isExtended = (i = base64ByLines.Length - 1)
            If Not s.StartsWith(_pageMarker) Then
                Dim cs As String = GetBase64String(s, isExtended)
                If cs.Length >= _baseBlock64Size Then
                    Dim blockOffset As Integer = cs.Length Mod _baseBlock64Size
                    Dim blockToCopySize As Integer = cs.Length - blockOffset
                    cs = cs.Substring(blockOffset, blockToCopySize)
                    If cs.Length Mod _baseBlock64Size = 0 Then base64sb.Append(cs)
                End If
            End If
        Next
        Dim paddingCount As Integer = GetPadding(base64sb.Length, _baseBlock64Size)
        For i As Integer = 0 To paddingCount - 1
            base64sb.Append(_padSymbol)
        Next
        Return Convert.FromBase64String(base64sb.ToString())
    End Function

    Private Function GetHeader(title As String, syncBlockSize As Integer) As String
        Dim header As New List(Of Char)("- BEGIN " + title + " MESSAGE -")
        While header.Count < syncBlockSize
            header.Insert(0, "-"c)
            If header.Count < syncBlockSize Then header.Add("-"c)
        End While
        header.Add(ControlChars.Lf)
        Return New String(header.ToArray())
    End Function

    Private Function GetFooter(title As String, syncBlockSize As Integer) As String
        Dim footer As New List(Of Char)("--- END " + title + " MESSAGE -")
        While footer.Count < syncBlockSize
            footer.Insert(0, "-"c)
            If footer.Count < syncBlockSize Then footer.Add("-"c)
        End While
        Return New String(footer.ToArray())
    End Function
End Module
