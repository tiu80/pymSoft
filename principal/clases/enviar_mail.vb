Imports System.Net
Imports System.Net.Mail
Namespace pymsoft

    Public Class enviar_mail

        Public Sub enviar_mail(ByVal desde, ByVal para, ByVal asunto, ByVal archivo, ByVal cuerpo, ByVal servidor, ByVal puerto, ByVal correo_enviante, ByVal contraseña)

            Dim correo As New MailMessage

            'De
            correo.From = New MailAddress(desde)

            'Para
            correo.To.Add(para)

            'Asunto
            correo.Subject = asunto

            'Cuerpo del correo
            correo.Body = cuerpo

            Dim data As New Attachment(archivo)

            correo.Attachments.Add(data)

            'Mostrar como HTML
            correo.IsBodyHtml = False

            'Prioridad de el correo
            correo.Priority = MailPriority.Normal

            'acto seguido le indicamos cual servidor utilizaremos
            'aqu&#236; usaremos por default a gmail y su puerto SMTP
            'pero en una futura entrega les mostrar&#233; como hacerlo
            'cn cualquier servidor

            Dim smtp As New SmtpClient()

            smtp.Host = servidor
            'smtp.Host = "smtp.live.com"

            smtp.Port = puerto

            smtp.Credentials = New System.Net.NetworkCredential("pcpymsoft@gmail.com", "PgcGt2020")

            smtp.EnableSsl = True

            Try

                'listo tenemos la estructura de nuestro mensaje armada ahora enviemosla a nuestro destinatario y listo

                smtp.Send(correo)

                MsgBox("Mensaje enviado satisfactoriamente")

            Catch ex As Exception

                MsgBox("ERROR: " & ex.Message)

            End Try

        End Sub

    End Class

End Namespace
