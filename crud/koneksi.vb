Imports System.Data.SqlClient

Module koneksi
    Public conn As SqlConnection
    Public cmd As SqlCommand
    Public rd As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public dt As DataTable

    Sub connect()
        Try

            conn = New SqlConnection("data source= KACONK-MBP\SQLEXPRESS; initial catalog= pl_crud; persist security info= true; UID= sa; PWD= NPMI;")
            conn.Open()
            conn.Close()
        Catch ex As Exception
            MsgBox("Connection Error", MsgBoxStyle.Critical)
        End Try
    End Sub

End Module
