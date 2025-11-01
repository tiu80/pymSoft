Namespace pymsoft

    Public Class numerodecimales

        Public cont As Integer

        Function negativos_punto(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox) As Integer

            Dim dig As Integer = Len(Text.Text & e.KeyChar)
            Dim a, esDecimal, NumDecimales As Integer
            Dim esDec As Boolean
            ' se verifica si es un digito o un punto 
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = "-" Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return a
            Else
                e.Handled = True
            End If
            ' se verifica que el primer digito ingresado no sea un punto al seleccionar
            If Text.SelectedText <> "" Then
                If e.KeyChar = "." Then
                    e.Handled = True
                    Return a
                End If
            End If

            If form_factura.txt_desc_rcgo.Text = "" Then
                cont = 0
            End If

            If dig = 1 And e.KeyChar = "." Then
                e.Handled = True
                Return a
            End If

            If e.KeyChar = "-" And cont > 0 Then
                e.KeyChar = ""
                Return a
            End If

            If e.KeyChar = "-" And cont = 0 Then
                cont = cont + 1
            End If

            'aqui se hace la verificacion cuando es seleccionado el valor del texto
            'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
            If Text.SelectedText = "" Then
                ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
                For a = 0 To dig - 1
                    Dim car As String = CStr(Text.Text & e.KeyChar)
                    If car.Substring(a, 1) = "." Then
                        esDecimal = esDecimal + 1
                        esDec = True
                    End If
                    If esDec = True Then
                        NumDecimales = NumDecimales + 1
                    End If
                    ' aqui se controla los digitos a partir del punto numdecimales = 5 si es de tres decimales 
                    If NumDecimales >= 5 Or esDecimal >= 2 Then
                        e.Handled = True
                    End If
                Next
            End If

        End Function

        Function positivos_punto(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox) As Integer

            Dim dig As Integer = Len(Text.Text & e.KeyChar)
            Dim a, esDecimal, NumDecimales As Integer
            Dim esDec As Boolean
            ' se verifica si es un digito o un punto 
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return a
            Else
                e.Handled = True
            End If
            ' se verifica que el primer digito ingresado no sea un punto al seleccionar
            If Text.SelectedText <> "" Then
                If e.KeyChar = "." Then
                    e.Handled = True
                    Return a
                End If
            End If
            If dig = 1 And e.KeyChar = "." Then
                e.Handled = True
                Return a
            End If
            'aqui se hace la verificacion cuando es seleccionado el valor del texto
            'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
            If Text.SelectedText = "" Then
                ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
                For a = 0 To dig - 1
                    Dim car As String = CStr(Text.Text & e.KeyChar)
                    If car.Substring(a, 1) = "." Then
                        esDecimal = esDecimal + 1
                        esDec = True
                    End If
                    If esDec = True Then
                        NumDecimales = NumDecimales + 1
                    End If
                    ' aqui se controla los digitos a partir del punto numdecimales = 5 si es de tres decimales 
                    If NumDecimales >= 5 Or esDecimal >= 2 Then
                        e.Handled = True
                    End If
                Next
            End If

        End Function

    End Class

End Namespace
