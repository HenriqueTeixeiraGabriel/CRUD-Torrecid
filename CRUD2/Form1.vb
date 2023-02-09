Imports System.Data.SqlClient

Public Class Form1
    Private conexao As SqlConnection
    Private comando As SqlCommand
    Private da As SqlDataAdapter

    Private strSQL As String

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        Try
            conexao = New SqlConnection("Server=DESKTOP-246GAH0\SQLEXPRESS; Database=CRUD;Trusted_Connection=True;")

            strSQL = "INSERT INTO CAD_CRUD (CNPJ, NOME, TELEFONE) VALUES (@CNPJ, @NOME, @TELEFONE)"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text)
            comando.Parameters.AddWithValue("@NOME", txtNome.Text)
            comando.Parameters.AddWithValue("@TELEFONE", txtTelefone.Text)
            conexao.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing
        End Try
    End Sub

    Private Sub btnExibir_Click(sender As Object, e As EventArgs) Handles btnExibir.Click
        Try
            conexao = New SqlConnection("Server=DESKTOP-246GAH0\SQLEXPRESS; Database=CRUD;Trusted_Connection=True;")

            strSQL = "SELECT * FROM CAD_CRUD"

            comando = New SqlCommand(strSQL, conexao)
            da = New SqlDataAdapter(strSQL, conexao)
            Dim ds As New DataSet
            da.Fill(ds)

            dgvDados.DataSource = ds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            conexao = New SqlConnection("Server=DESKTOP-246GAH0\SQLEXPRESS; Database=CRUD;Trusted_Connection=True;")

            strSQL = "UPDATE CAD_CRUD SET CNPJ = @CNPJ, NOME = @NOME, TELEFONE = @TELEFONE WHERE CNPJ =@CNPJ"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text)
            comando.Parameters.AddWithValue("@NOME", txtNome.Text)
            comando.Parameters.AddWithValue("@TELEFONE", txtTelefone.Text)
            conexao.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing
        End Try
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Try
            conexao = New SqlConnection("Server=DESKTOP-246GAH0\SQLEXPRESS; Database=CRUD;Trusted_Connection=True;")

            strSQL = "DELETE CAD_CRUD WHERE CNPJ =@CNPJ"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text)
            conexao.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing
        End Try
    End Sub
End Class
