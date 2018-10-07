Imports System.Data.SqlClient
Public Class Form1
    Sub awal()
        txt_nama.Enabled = False
        txt_alamat.Enabled = False
        txt_agama.Enabled = False
        ComboBox_kelamin.Enabled = False
        txt_tempatlahir.Enabled = False
        txt_id.Enabled = False
        txt_nisn.Enabled = False
        DateTimePicker1.Enabled = False
        txt_sekolah.Enabled = False

        btn_simpan.Enabled = False
        btn_tampil.Enabled = False
        btn_update.Enabled = False
    End Sub

    Sub bersih()
        txt_id.Text = ""
        txt_nis.Text = ""
        txt_nama.Text = ""
        txt_nisn.Text = ""
        ComboBox_kelamin.Text = ""
        txt_tempatlahir.Text = ""
        txt_agama.Text = ""
        txt_alamat.Text = ""
        txt_sekolah.Text = ""
    End Sub


    Sub cek_id()
        conn.Open()
        cmd = New SqlCommand("SELECT * FROM biodata where nis = '" & txt_nis.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            conn.Close()
            MsgBox("Nomer induk sudah ada !", MsgBoxStyle.Critical)
        Else
            conn.Close()
            txt_nama.Enabled = True
            txt_alamat.Enabled = True
            txt_agama.Enabled = True
            ComboBox_kelamin.Enabled = True
            txt_tempatlahir.Enabled = True

            txt_nisn.Enabled = True
            DateTimePicker1.Enabled = True
            txt_sekolah.Enabled = True

            btn_simpan.Enabled = True
            btn_tampil.Enabled = True
            txt_nama.Focus()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        tampil_data()
        awal()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
    Sub tampil_data()
        Try
            conn.Open()
            da = New SqlDataAdapter("SELECT * FROM biodata", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "biodata")
            DataGridView1.DataSource = ds.Tables(0)
            conn.Close()
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        Select Case MsgBox("Apakah anda akan menyimpan data ini ?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes

                Try

                    conn.Open()

                    cmd = New SqlCommand("INSERT INTO biodata (nis, nama, nisn, jeniskelamin, tempatlahir, tanggallahir, agama, alamat, sekolahasal) values('" & txt_nis.Text & "','" & txt_nama.Text & "', '" & txt_nisn.Text & "', '" & ComboBox_kelamin.Text & "', '" & txt_tempatlahir.Text & "', @tanggal, '" & txt_agama.Text & "', '" & txt_alamat.Text & "', '" & txt_sekolah.Text & "')", conn)
                    cmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = DateTimePicker1.Value
                    cmd.ExecuteNonQuery()
                    conn.Close()
                    MsgBox("Simpan Data Berhasil", MsgBoxStyle.Information)
                    bersih()
                    tampil_data()
                    awal()
                Catch ex As Exception
                    conn.Close()
                    MsgBox(ex.Message)
                End Try
            Case MsgBoxResult.No
        End Select

    End Sub

    Private Sub btn_tampil_Click(sender As Object, e As EventArgs) Handles btn_tampil.Click
        tampil_data()
    End Sub



    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click

        Select Case MsgBox("Apakah anda akan mengupdate data ini ?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                Try

                    conn.Open()

                    cmd = New SqlCommand("UPDATE biodata SET nis='" & txt_nis.Text & "' , nama ='" & txt_nama.Text & "' , nisn='" & txt_nisn.Text & "' , jeniskelamin = '" & ComboBox_kelamin.Text & "', tempatlahir='" & txt_tempatlahir.Text & "' , tanggallahir = @tanggal, agama ='" & txt_agama.Text & "' , alamat = '" & txt_alamat.Text & "', sekolahasal ='" & txt_sekolah.Text & "' WHERE id_siswa = '" & txt_id.Text & "' ", conn)
                    cmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = DateTimePicker1.Value
                    cmd.ExecuteNonQuery()
                    conn.Close()
                    MsgBox("Update Data Berhasil", MsgBoxStyle.Information)
                    bersih()
                    tampil_data()
                    awal()
                Catch ex As Exception
                    conn.Close()
                    MsgBox(ex.Message)
                End Try
            Case MsgBoxResult.No

        End Select



    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Dim id As String = row.Cells(0).Value.ToString

        Select Case MsgBox("Apakah anda akan merubah data nomer " & id & " ?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                txt_id.Text = row.Cells(0).Value.ToString
                txt_nis.Text = row.Cells(1).Value.ToString
                txt_nama.Text = row.Cells(2).Value.ToString
                txt_nisn.Text = row.Cells(3).Value.ToString
                ComboBox_kelamin.Text = row.Cells(4).Value.ToString
                txt_tempatlahir.Text = row.Cells(5).Value.ToString
                DateTimePicker1.Value = row.Cells(6).Value
                txt_agama.Text = row.Cells(7).Value.ToString
                txt_alamat.Text = row.Cells(8).Value.ToString
                txt_sekolah.Text = row.Cells(9).Value.ToString
                txt_nama.Enabled = True
                txt_alamat.Enabled = True
                txt_agama.Enabled = True
                ComboBox_kelamin.Enabled = True
                txt_tempatlahir.Enabled = True
                txt_id.Enabled = False
                txt_nisn.Enabled = True
                DateTimePicker1.Enabled = True
                txt_sekolah.Enabled = True
                ' btn_hapus.Enabled = False
                btn_simpan.Enabled = False
                btn_tampil.Enabled = False
                btn_update.Enabled = True
            Case MsgBoxResult.No

        End Select
    End Sub

    Private Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Dim id As String = row.Cells(0).Value.ToString
        Select Case MsgBox("Apakah anda akan menghapus data nomer " & id & " ?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                cmd = New SqlCommand("DELETE FROM biodata WHERE id_siswa = '" & id & "'", conn)
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
                MsgBox("Data berhasil dihapus", MsgBoxStyle.Information)
        End Select
    End Sub

    Private Sub txt_nis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nis.KeyPress
        If e.KeyChar = Chr(13) Then
            cek_id()
        End If
    End Sub

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Dim id As String = row.Cells(1).Value.ToString
        Dim report_siswa As New siswa
        Dim user As String = "sa"
        Dim pass As String = "NPMI"

        Select Case MsgBox("Apakah anda akan melihat data siswa " & id & " ?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes


                report_siswa.RecordSelectionFormula = "{biodata.nis} ='" & id & "'"
                report_siswa.SetDatabaseLogon(user, pass)
                preview.prev_report.ReportSource = report_siswa
                'preview.prev_report.Refresh()

                preview.Show()
            Case MsgBoxResult.No


        End Select
    End Sub

    Private Sub txt_nama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nama.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_nisn.Focus()
        End If
    End Sub

    Private Sub txt_nisn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nisn.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox_kelamin.Focus()
        End If
    End Sub

    Private Sub ComboBox_kelamin_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_kelamin.SelectedValueChanged
        txt_tempatlahir.Focus()
    End Sub

    Private Sub txt_tempatlahir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_tempatlahir.KeyPress
        If e.KeyChar = Chr(13) Then
            DateTimePicker1.Focus()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        txt_agama.Focus()
    End Sub

    Private Sub txt_agama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_agama.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_alamat.Focus()
        End If
    End Sub

    Private Sub txt_alamat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_alamat.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_sekolah.Focus()
        End If
    End Sub
End Class
