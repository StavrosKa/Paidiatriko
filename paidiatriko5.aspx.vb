Public Class paidiatriko5
    Inherits panakeiaPagesHistory

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.check()
        MyBase.viewGrid(GridView1, Application)
        MyBase.makeNavigatorsHeaderFooter(12, TableHeader, TableFooter, True)
        DivNav.Controls.Add(MyBase.makeCommands("patient", Request.QueryString("patientID"), True))
        If conStrs.HealthRecordAccessWarning AndAlso Not incidentOfaPatient.parakoloyueitaiApoTonXrhsth AndAlso Not incidentOfaPatient.hasAuthorizationToViewHealthRecord AndAlso Not currentUser.hospital.UserClinicProperties.monadaTexnhtoyNefroy Then
            Response.Redirect("requestAccess.aspx?visitID=" & Request.QueryString("visitID") & "&nomenu=" & Request.QueryString("nomenu") & "&panakeia=" & Request.QueryString("panakeia") & "&returnurl=" & HttpContext.Current.Request.RawUrl.Replace("&", "!"))
        End If
        If currentUser.user.WorkerType = "VIEWER" OrElse currentUser.user.WorkerType = "ΔΙΟΙΚΗΤΙΚΟΣ" Then Response.Redirect("~/access.aspx")
        If katastash = 1 OrElse katastash = 3 OrElse Request.QueryString("patientID") = "" Then
            Response.Write("ΠΡΟΣΟΧΗ: Δεν έχετε δικαίωμα να βλέπετε τα δεδομένα της σελίδας.")
            Response.End()
        End If
        If Not IsPostBack Then
            Dim his As String() = hasRowsChildHistoryPerTab()
            pi0.InnerHtml = his(0)
            pi1.InnerHtml = his(1)
            If his(2) <> "" Then pi2.InnerHtml = his(2) : pi4.InnerHtml = his(2)
            If his(3) <> "" Then pi3.InnerHtml = his(3) : pi4.InnerHtml = his(3)
            pi5.InnerHtml = his(4)
            Dim remoteData As New AMedConnection(currentUser.hospital.HospitalCode, Application)
            Dim remoteString As String = remoteData.getDemographicDataForPanaceiaPatient(Request.QueryString("patientID"))
            If remoteString.StartsWith("ΑΔΥΝΑΜΙΑ") OrElse remoteString.StartsWith("ΠΡΟΒΛΗΜΑ") Then
                Response.Redirect("~/error.aspx?error=" & remoteString)
            Else
                Dim dt As DataTable = remoteData.convertToDataTable(remoteString)
                Dim fyllo As String = dt.Rows(0).Item(3)
                TextBoxFyllo.Text = fyllo
                If fyllo = "ΑΡΡΕΝ" Then
                    Label1.Text = "Μετρήσεις αγοριού: "
                Else
                    Label1.Text = "Μετρήσεις κοριτσιού: "
                End If
            End If
            Call enhmervsh()
            If DropDownList1.SelectedIndex = 0 Then divGr2.Attributes("style") = ""
            If Request.QueryString("page") <> "" Then
                DropDownList1.SelectedIndex = CInt(Request.QueryString("page"))
                If Request.QueryString("page") = "1" Then
                    divGr2.Attributes("style") = ""
                ElseIf Request.QueryString("page") = "2" Then
                    divGr3.Attributes("style") = ""
                ElseIf Request.QueryString("page") = "3" Then
                    divGr4.Attributes("style") = ""
                ElseIf Request.QueryString("page") = "4" Then
                    divGr5.Attributes("style") = ""
                ElseIf Request.QueryString("page") = "5" Then
                    divGr6.Attributes("style") = ""
                ElseIf Request.QueryString("page") = "6" Then
                    divGr7.Attributes("style") = ""
                ElseIf Request.QueryString("page") = "7" Then
                    divGr8.Attributes("style") = ""
                End If
            End If
            TextBoxCalcX.Attributes("readonly") = "readonly"
            TextBoxCalcY.Attributes("readonly") = "readonly"
        End If
    End Sub
    Private Sub enhmervsh()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΥΨΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [ΥΨΟΣ] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView2.DataSource = dt
        GridView2.DataBind()
        removeTime(GridView2, 0)
        'ρουτίνα που αφαιρεί τον χρόνο από τις ημερομηνίες μας
        'το 2ο όρισμα είναι σε ποιά σειρά υπάρχει η ημερ. στο sql select μας
        'υπάρχει στο conStrs.vb
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxHYB.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΥΨΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [ΥΨΟΣ] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView3.DataSource = dt
        GridView3.DataBind()
        removeTime(GridView3, 0)
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxHYP.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [ΒΑΡΟΣ] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView4.DataSource = dt
        GridView4.DataBind()
        removeTime(GridView4, 0)
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxHVB.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [ΒΑΡΟΣ] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView5.DataSource = dt
        GridView5.DataBind()
        removeTime(GridView5, 0)
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxHVP.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΚΕΦΑΛΗ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [ΚΕΦΑΛΗ] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView6.DataSource = dt
        GridView6.DataBind()
        removeTime(GridView6, 0)
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxHPB.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΚΕΦΑΛΗ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [ΚΕΦΑΛΗ] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView7.DataSource = dt
        GridView7.DataBind()
        removeTime(GridView7, 0)
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxHPP.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [BMI] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' AND [BMI] IS NOT NULL ORDER BY [ΗΛΙΚΙΑ] DESC")
        GridView8.DataSource = dt
        GridView8.DataBind()
        removeTime(GridView8, 0)
        For f As Integer = 0 To dt.Rows.Count - 1
            TextBoxBMIP.Text &= dt.Rows(f).Item(1).ToString.Replace(",", ".") & "-" & dt.Rows(f).Item(2).ToString.Replace(",", ".") & "*"
        Next
        localData.TerminateLocalDBConnection()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'kanw update h insert tis times pou vriskontai sto textboxcalcX kai textboxcalcY
        'sth vash dedomenwn
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Dim hm As Date = Now
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        Dim vrefos As Integer = 0
        Dim sqlStringForUpdate As String = ""
        Dim sqlStringForInsert As String = ""
        Dim sqlStringForInsert1 As String = ""
        'MsgBox(TextBoxCalcX.Text)
        'MsgBox(TextBoxCalcY.Text)
        If DropDownList1.SelectedItem.Text = "Ύψος ανά μήνα" Then
            vrefos = 1
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                ", [ΥΨΟΣ]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [ΥΨΟΣ]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        If DropDownList1.SelectedItem.Text = "Ύψος ανά έτος" Then
            vrefos = 0
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                    ", [ΥΨΟΣ]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [ΥΨΟΣ]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        If DropDownList1.SelectedItem.Text = "Βάρος ανά μήνα" Then
            vrefos = 1
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                        ", [ΒΑΡΟΣ]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [ΒΑΡΟΣ]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        If DropDownList1.SelectedItem.Text = "Βάρος ανά έτος" Then
            vrefos = 0
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                        ", [ΒΑΡΟΣ]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [ΒΑΡΟΣ]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        If DropDownList1.SelectedItem.Text = "Περίμετρος κεφαλής ανά μήνα" Then
            vrefos = 0
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                        ", [ΚΕΦΑΛΗ]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [ΚΕΦΑΛΗ]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        If DropDownList1.SelectedItem.Text = "Περίμετρος κεφαλής ανά έτος" Then
            vrefos = 1
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                        ", [ΚΕΦΑΛΗ]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [ΚΕΦΑΛΗ]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        If DropDownList1.SelectedItem.Text = "BMI ανά χρόνο" Then
            vrefos = 0
            sqlStringForUpdate = "[ΗΛΙΚΙΑ]=" & If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) &
                        ", [BMI]=" & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
            sqlStringForInsert = "[ΗΛΙΚΙΑ], [BMI]"
            sqlStringForInsert1 = If(TextBoxCalcX.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcX.Text.Replace(",", ".").Replace("'", "")) & ", " & If(TextBoxCalcY.Text.Replace(",", ".").Replace("'", "") = "", "NULL", TextBoxCalcY.Text.Replace(",", ".").Replace("'", ""))
        End If
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=" & vrefos & " AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET " &
                                 sqlStringForUpdate &
                                 " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=" & vrefos & " AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
            If vrefos = 0 Then
                dt = localData.getData("SELECT [ΒΑΡΟΣ], [ΥΨΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=" & vrefos & " AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
                If dt.Rows.Count > 0 Then
                    If Not dt.Rows(0).Item(0) Is DBNull.Value AndAlso Not dt.Rows(0).Item(1) Is DBNull.Value Then
                        'ypologismos bmi
                        Dim bmi As Double
                        bmi = (Math.Round(dt.Rows(0).Item(0) / ((dt.Rows(0).Item(1)) ^ 2), 1))
                        localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET [BMI]=" & bmi & " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=" & vrefos & " AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
                    End If
                End If
            End If
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ([PATIENT_CODE], [ΤΥΠΟΣ], " &
                                 "[ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], " & sqlStringForInsert & ") VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΓΕΝΙΚΑ', " & vrefos & ", '" & finalHm & "', " & sqlStringForInsert1 & ")")
        End If
        localData.TerminateLocalDBConnection()
        currentUser.insertCommentsForWatching(currentUser.user.UserName, "Ενημέρωση Σωματομετρικών στοιχείων για τον ασθενή με ΑΜ " & Request.QueryString("patientID"), currentUser.user.ip)
        Response.Redirect("~/paidiatriko5.aspx?page=" & DropDownList1.SelectedIndex & "&visitID=" & Request.QueryString("visitID") & "&patientID=" & Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu"))
    End Sub
End Class