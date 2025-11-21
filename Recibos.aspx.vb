' Nombre del archivo: Recibos.aspx.vb

Partial Public Class Recibos
    Inherits System.Web.UI.Page

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs)
        ' 1. Obtener el texto que el usuario escribió (el número de teléfono)
        Dim telefonoID As String = txtReciboID.Text.Trim()
        
        ' 2. SIMULACIÓN: Lógica de búsqueda
        Dim datosRecibo As String = ""

        Select Case telefonoID
            Case "78991675"
                ' --- DATOS DE CÉSAR ---
                datosRecibo = "<h3>Detalle de Recibo</h3>"
                datosRecibo &= "<p><strong>Cliente:</strong> César</p>"
                datosRecibo &= "<table>"
                datosRecibo &= "<tr><th>Servicio</th><th>Precio</th><th>Cantidad</th><th>Total</th></tr>"
                datosRecibo &= "<tr><td>spotify</td><td>4.00</td><td>2</td><td>8.00</td></tr>"
                datosRecibo &= "<tr><td>youtube</td><td>4.25</td><td>1</td><td>4.25</td></tr>"
                datosRecibo &= "<tr><td>app</td><td>3.51</td><td>1</td><td>3.51</td></tr>"
                datosRecibo &= "<tr class='total-row'><td colspan='3' style='text-align:right;'>TOTAL A PAGAR:</td><td>$15.76</td></tr>"
                datosRecibo &= "<tr class='pendiente-row'><td colspan='3' style='text-align:right;'>PENDIENTE:</td><td>$15.76</td></tr>"
                datosRecibo &= "</table>"
            
            Case "73179224"
                ' --- DATOS DE DAISY ---
                datosRecibo = "<h3>Detalle de Recibo</h3>"
                datosRecibo &= "<p><strong>Cliente:</strong> Daisy</p>"
                datosRecibo &= "<table>"
                datosRecibo &= "<tr><th>Servicio</th><th>Precio</th><th>Cantidad</th><th>Total</th></tr>"
                datosRecibo &= "<tr><td>youtube</td><td>4.25</td><td>1</td><td>4.25</td></tr>"
                datosRecibo &= "<tr class='total-row'><td colspan='3' style='text-align:right;'>TOTAL A PAGAR:</td><td>$4.25</td></tr>"
                datosRecibo &= "<tr class='pendiente-row'><td colspan='3' style='text-align:right;'>PENDIENTE:</td><td>$8.25</td></tr>"
                datosRecibo &= "</table>"
                
            Case "76470201"
                ' --- DATOS DE ADRIANA ---
                datosRecibo = "<h3>Detalle de Recibo</h3>"
                datosRecibo &= "<p><strong>Cliente:</strong> Adriana</p>"
                datosRecibo &= "<table>"
                datosRecibo &= "<tr><th>Servicio</th><th>Precio</th><th>Cantidad</th><th>Total</th></tr>" 
                datosRecibo &= "<tr><td>youtube</td><td>4.25</td><td>3</td><td>12.75</td></tr>"
                datosRecibo &= "<tr class='total-row'><td colspan='3' style='text-align:right;'>TOTAL A PAGAR:</td><td>$12.75</td></tr>"
                datosRecibo &= "<tr class='pendiente-row'><td colspan='3' style='text-align:right;'>PENDIENTE:</td><td>$12.75</td></tr>"
                datosRecibo &= "</table>"

            Case Else
                datosRecibo = ""
        End Select

        ' 3. Mostrar el resultado
        If Not String.IsNullOrEmpty(datosRecibo) Then
            litRecibo.Text = datosRecibo
        Else
            litRecibo.Text = "<p class='pendiente-row'>El número de teléfono **" & telefonoID & "** no fue encontrado.</p>"
        End If

    End Sub

End Class
