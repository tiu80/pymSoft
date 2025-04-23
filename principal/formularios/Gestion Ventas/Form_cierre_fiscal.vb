'Imports OCXFISLib

Public Class Form_cierre_fiscal

    Dim fact As New pymsoft.factura
    'Dim eps As OCXFISLib.DriverFiscal
    Dim nError As Long
    Dim puerto As String
    Dim baude As String

    Private Sub cmd_cierre_z_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cierre_z.Click

        Try

            If fact.fiscal_hasar = "SI" Then

                Me.Enabled = False

                'Me.AxHASAR1.Puerto = fact.Puerto_Com
                'Me.AxHASAR1.Baudios = fact.baude_rate
                'Me.AxHASAR1.Comenzar()
                'Me.AxHASAR1.ReporteZ()
                'Me.AxHASAR1.Finalizar()

                Me.cmd_cierre_z.Enabled = False

                Me.Dispose()

            End If

            If fact.fiscal_epson = "SI" Then

                puerto = "COM" & fact.Puerto_Com
                baude = Me.baude

                'nError = eps.IF_OPEN(puerto, baude)
                'eps.EpsonTicket.CIERREZ()

                'eps.IF_CLOSE()

            End If

        Catch ex As Exception

            MessageBox.Show(Err.Description, "PyM Soft")
            Me.Dispose()

        End Try

    End Sub

    Private Sub Form_cierre_fiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fact.carga_parametro()
    End Sub

    Private Sub cmd_cierre_x_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cierre_x.Click

        Try

            If fact.fiscal_hasar = "SI" Then

                Me.Enabled = False

                'Me.AxHASAR1.Puerto = fact.Puerto_Com
                'Me.AxHASAR1.Baudios = fact.baude_rate
                'Me.AxHASAR1.Comenzar()
                'Me.AxHASAR1.ReporteX()
                'Me.AxHASAR1.Finalizar()

                Me.cmd_cierre_x.Enabled = False

                Me.Dispose()

            End If

            If fact.fiscal_epson = "SI" Then

                puerto = "COM" & fact.Puerto_Com
                baude = Me.baude

                'nError = eps.IF_OPEN(puerto, baude)
                'eps.EpsonTicket.CIERREX()

                'eps.IF_CLOSE()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description, "PyM Soft")
            Me.Dispose()
        End Try

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        'eps = New OCXFISLib.DriverFiscal

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class