Public Class incio

    Private Sub Limpiar()
        TextName.Text = ""
        TextTele.Text = ""
        TextCargo.Text = ""
        fingreso.Text = ""
        fingreso.Text = ""
        TextSalida.Text = ""
        TextCargos.Text = ""
        TextBuscar.Text = ""
        TextCC.Text = ""

        TextNombre.Text = ""
        TextTelefono.Text = ""
        TextCargo.Text = ""
        TextBuscar.Focus()
        TextCC.Focus()
    End Sub

    Private Sub fecha()

        Dim FirstDate As Date    ' Declare variables.
        Dim IntervalType As String
        Dim Number As Integer
        Dim Msg As String

        IntervalType = "d"    ' "m" specifies months as interval.
        FirstDate = InputBox("31-Jan-95")
        Number = InputBox(1)
        Msg = "New date: " & DateAdd(IntervalType, Number, FirstDate)


    End Sub

    Private Sub BtnEntrada_Click_1(sender As Object, e As EventArgs) Handles BtnEntrada.Click

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim fecha As Date

        fecha = Now

        Dim da As New SqlClient.SqlDataAdapter("SELECT * FROM dbo.registroentrada where cc ='" & TextCedula.Text & "' ", Conexiones.Cnn)

        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then

            MsgBox("Usuario ya ha ingresado")

        Else

            Dim cmd As New SqlClient.SqlCommand("insert into dbo.registroentrada (cc, fecha_entrada) values('" & TextCedula.Text & "', '" & fecha & "')", Conexiones.Cnn)
            cmd.ExecuteNonQuery()

            MsgBox("Usuario ingresado correctamente")

        End If


    End Sub

    Private Sub BtnSalida_Click_1(sender As Object, e As EventArgs) Handles BtnSalida.Click

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim fecha As Date

        fecha = Now

        Dim da As New SqlClient.SqlDataAdapter("SELECT * FROM dbo.registrosalida  where cc = '" & TextCedula.Text & "'", Conexiones.Cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then

            MsgBox("Usuario ya ha salido")

        Else

            Dim cmd As New SqlClient.SqlCommand("insert into dbo.registrosalida (cc, fecha_salida) values('" & TextCedula.Text & "', '" & fecha & "')", Conexiones.Cnn)
            cmd.ExecuteNonQuery()

            MsgBox("Usuario ingresado correctamente")

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim da As New SqlClient.SqlDataAdapter("select cc from dbo.empleado where cc LIKE '%" & TextCC.Text & "%' ", Conexiones.Cnn)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows.Count > 1 Then

            MsgBox("Usuario ya esta registreado en el sistema")

        Else

            Dim cmd As New SqlClient.SqlCommand("insert into dbo.empleado ( cc, nombre , telefono, cargo) values('" & TextCC.Text & "','" & TextNombre.Text & "','" & TextTelefono.Text & "','" & TextCargo.Text & "')", Conexiones.Cnn)
            cmd.ExecuteNonQuery()

            MsgBox("Usuario se registro en el sistema")

        End If


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        If TextCC.Text <> " " Then

            Dim di As New SqlClient.SqlDataAdapter("select fecha_salida from dbo.registrosalida where cc LIKE '%" & TextBuscar.Text & "%' ", Conexiones.Cnn)
            Dim dx As New DataSet
            di.Fill(dx)
            If dx.Tables(0).Rows.Count > 0 Then
                TextSalida.Text = Convert.ToString(dx.Tables(0).Rows(0).Item("fecha_salida"))

            End If

            Dim db As New SqlClient.SqlDataAdapter("select fecha_entrada from dbo.registroentrada where cc LIKE '%" & TextBuscar.Text & "%' ", Conexiones.Cnn)
            Dim dc As New DataSet
            db.Fill(dc)
            If dc.Tables(0).Rows.Count > 0 Then
                fingreso.Text = Convert.ToString(dc.Tables(0).Rows(0).Item("fecha_entrada"))
            End If

            Dim da As New SqlClient.SqlDataAdapter("select nombre,telefono,cargo from dbo.empleado where cc LIKE '%" & TextBuscar.Text & "%'", Conexiones.Cnn)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                TextName.Text = ds.Tables(0).Rows(0).Item("nombre")
                TextTele.Text = ds.Tables(0).Rows(0).Item("telefono")
                TextCargos.Text = ds.Tables(0).Rows(0).Item("cargo")
            End If

        Else

            Limpiar()

        End If

        Conexiones.Cnn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Limpiar()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Limpiar()

    End Sub


End Class


