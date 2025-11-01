Module descargar_ram

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean


    Public Sub ClearMemory()

        Try

            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                Dim Mem As Process = Process.GetCurrentProcess()
                SetProcessWorkingSetSize(Mem.Handle, -1, -1)
            End If

        Catch ex As Exception

        End Try

    End Sub


End Module
