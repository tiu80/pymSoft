
Public Class Form_empresa
    Dim a As Boolean = True
    Dim abm As New pymsoft.parametro
    Dim sel As New pymsoft.selecciona
    Dim clin As New pymsoft.cliente1
    Dim xxx As New pymsoft.prov_vend_list_bco

    Private Sub cmb_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_iva.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_empresa.Focus()
        End If

    End Sub

    Private Sub txt_ejercicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ejercicio.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.cmd_aceptar.Focus()
        End If

    End Sub

    Private Sub Form_empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_iva.Text = Me.cmb_iva.Items(1)
        Me.dt_inicio_act.Text = Date.Now
        Me.txt_estado_form.Text = 1
        sel.instruccion = "select *from empresa_01"
        sel.nombre_tabla = "empresa_01"
        sel.carga_campos()

        Me.txt_codigo.Text = sel.codigo
        Me.txt_interno.Text = sel.codigo
        Me.txt_empresa.Text = sel.nombre
        Me.txt_iva.Text = sel.cuit
        Me.txt_ingbrutos.Text = sel.ing_brutos
        Me.txt_ejercicio.Text = sel.ejercicio
        Me.txt_direccion.Text = sel.direccion
        Me.txt_localidad.Text = sel.cod_localidad
        Me.lbl_localidad.Text = sel.localidad
        Me.txt_cod_postal.Text = sel.cod_postal
        Me.dt_inicio_act.Text = sel.fecha_inicio
        Me.txt_telefono.Text = sel.telefono
        Me.cmb_iva.Text = sel.encuadre
        Me.txt_crt.Text = sel.CRT
        Me.txt_key.Text = sel.KEY
        Me.txt_nombre_certificado_pfx.Text = sel.pfx
        Me.txt_contrasena_pfx.Text = sel.pass_pfx

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Try

            If Me.txt_empresa.Text = "" Or Me.txt_iva.Text = "" Or Me.txt_ingbrutos.Text = "" Or Me.txt_ejercicio.Text = "" Or Me.txt_direccion.Text = "" Or Me.txt_cod_postal.Text = "" Or Me.lbl_localidad.Text = "" Then
                MessageBox.Show("Complete los Campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If RTrim(Me.cmb_iva.Text) <> "Consumidor Final" Then

                a = clin.validarCuit(Me.txt_iva.Text)

                If a = False Then

                    MessageBox.Show("Verifique C.U.I.T", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txt_iva.Focus()
                    Exit Sub

                End If

            End If

            abm.instruccion = "INSERT INTO empresa_01(id_emp ,empresa,encuadre, cuit, ing_bruto, ejercicio,localidad,cod_postal,direccion,inicio,cod_loc,telefono,crt,crt_key,pfx,pass_pfx) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_empresa.Text + "','" + Me.cmb_iva.Text + "','" + Me.txt_iva.Text + "','" + Me.txt_ingbrutos.Text + "','" + Me.txt_ejercicio.Text + "','" + Me.lbl_localidad.Text + "','" + Me.txt_cod_postal.Text + "','" + Me.txt_direccion.Text + "','" + Me.dt_inicio_act.Text + "','" + Me.txt_localidad.Text + "','" + Me.txt_telefono.Text + "','" + Me.txt_crt.Text + "','" + Me.txt_key.Text + "','" + Me.txt_nombre_certificado_pfx.Text + "','" + Me.txt_contrasena_pfx.Text + "')"
            abm.abm()

            Call limpia()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_localidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_localidad.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_localidad.Show()

        End If

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            xxx.instruccion = "select *from localidad where id_loc like '" & Me.txt_localidad.Text & "'"
            xxx.codigo = "id_loc"
            xxx.nombre = "nom_localidad"
            xxx.cargar()
            Me.lbl_localidad.Text = xxx.text2
            Me.cmb_iva.Focus()
        End If

    End Sub

    Private Sub txt_cod_postal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_postal.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_telefono.Focus()
        End If
    End Sub

    Private Sub limpia()

        Me.txt_codigo.Text = ""
        Me.txt_empresa.Text = ""
        Me.txt_iva.Text = ""
        Me.txt_ingbrutos.Text = ""
        Me.txt_ejercicio.Text = ""
        Me.txt_localidad.Text = ""
        Me.lbl_localidad.Text = ""
        Me.txt_cod_postal.Text = ""
        Me.txt_direccion.Text = ""
        Me.txt_telefono.Text = ""
        Me.txt_crt.Text = ""
        Me.txt_key.Text = ""
        Me.txt_nombre_certificado_pfx.Text = ""
        Me.txt_contrasena_pfx.Text = ""

    End Sub

    Private Sub cmd_borra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borra.Click

        Dim a As Integer = MessageBox.Show("Esta Seguro!!!!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If a = 6 Then
            abm.instruccion = "delete from empresa_01"
            abm.abm()

            Call limpia()

        End If

    End Sub

    Private Sub cmd_actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualiza.Click

        a = clin.validarCuit(Me.txt_iva.Text)

        If RTrim(Me.cmb_iva.Text) <> "Consumidor Final" Then

            If a = False Then

                MessageBox.Show("Verifique C.U.I.T", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_iva.Focus()
                Exit Sub

            End If

        End If

        abm.instruccion = "update empresa_01 set id_emp = '" & Me.txt_codigo.Text & "', empresa = '" & Me.txt_empresa.Text & "', encuadre = '" & Me.cmb_iva.Text & "',cuit='" & Me.txt_iva.Text & "',ing_bruto='" & Me.txt_ingbrutos.Text & "',localidad='" & Me.lbl_localidad.Text & "',cod_loc='" & Me.txt_localidad.Text & "',cod_postal='" & Me.txt_cod_postal.Text & "',inicio='" & Me.dt_inicio_act.Text & "',direccion='" & Me.txt_direccion.Text & "',ejercicio='" & Me.txt_ejercicio.Text & "',telefono = '" & Me.txt_telefono.Text & "',crt = '" + Me.txt_crt.Text + "',crt_key = '" + Me.txt_key.Text + "',pfx = '" + Me.txt_nombre_certificado_pfx.Text + "',pass_pfx = '" + Me.txt_contrasena_pfx.Text + "' where id_emp ='" & Me.txt_interno.Text & "'"
        abm.abm()

        Call limpia()
        Me.txt_codigo.Focus()

    End Sub

    Private Sub txt_cod_postal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_postal.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress
        If InStr(1, "-0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

End Class