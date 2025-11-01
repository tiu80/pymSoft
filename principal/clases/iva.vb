Imports System.Data.SqlClient
Imports System.Data

Namespace pymsoft

    Public Class iva

        Inherits pymsoft.talonario

        Dim conex As New SqlConnection
        Private minstruccion1 As String
        Private mduplicado As Boolean
        Public veri As Boolean

        Public Sub New()
            conex = conecta()
        End Sub

        Public Property instruccion1()
            Get
                Return minstruccion1
            End Get
            Set(ByVal value)
                minstruccion1 = value
            End Set
        End Property

        Public Property duplicado()
            Get
                Return mduplicado
            End Get
            Set(ByVal value)
                mduplicado = value
            End Set
        End Property

        Public Sub mostrar_iva()

            Try

                Dim comando2 As New SqlCommand(minstruccion1, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                form_tipo_iva.txt_codigo_iva.Text = reader("id_iva")
                form_tipo_iva.txt_interno.Text = reader("id_iva")
                form_tipo_iva.txt_descripcion.Text = reader("nombre")
                form_tipo_iva.txt_iva_ins.Text = reader("iva_insc")
                form_tipo_iva.txt_iva_nins.Text = reader("iva_ninsc")
                form_tipo_iva.txt_cta_iva_vta_in.Text = reader("cta_vta_ins")
                form_tipo_iva.txt_cta_iva_vta_nin.Text = reader("cta_vta_nins")
                form_tipo_iva.txt_cta_iva_cmp_in.Text = reader("cta_cmp_ins")
                form_tipo_iva.txt_cta_iva_cmp_nins.Text = reader("cta_cmp_nins")
                form_tipo_iva.dt_fec_alta.Text = reader("fec_alta")
                form_tipo_iva.TextBox1.Text = reader("letra_estado")
                form_tipo_iva.cmb_estado.Text = reader("estado")
                veri = True

            Catch ex As Exception

                veri = False

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub verificar_duplicado()

            Try

                Dim comando As New SqlCommand(minstruccion1, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando.ExecuteReader

                reader.Read()

                If reader("id_iva") = form_tipo_iva.txt_codigo_iva.Text Then

                    MsgBox("El numero esta en uso", MsgBoxStyle.Information, "PymSoft")
                    mduplicado = False
                    Exit Sub

                End If

                comando.Dispose()

            Catch ex As Exception

                mduplicado = True

            Finally

                conex.Close()

            End Try

        End Sub


        Public Sub mostrar_imp_interno()

            Try

                Dim comando2 As New SqlCommand(minstruccion1, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                form_tipo_iva.txt_cod_imp_interno.Text = reader("cod_int")
                form_tipo_iva.txt_cod_interno1.Text = reader("cod_int")
                form_tipo_iva.txt_importe_imp.Text = reader("monto")
                form_tipo_iva.txt_nombre_imp_int.Text = reader("nombre")
                form_tipo_iva.dt_fec_alta_imp_int.Text = reader("fec_alta")
                form_tipo_iva.TextBox3.Text = reader("letra")
                form_tipo_iva.cmb_estado_imp_int.Text = reader("estado")
                veri = True

            Catch ex As Exception

                veri = False

            Finally

                conex.Close()

            End Try

        End Sub

    End Class

End Namespace
