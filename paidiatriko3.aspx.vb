Public Class paidiatriko3
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
        If katastash = 1 OrElse katastash = 3 Then
            Response.Write("ΠΡΟΣΟΧΗ: Δεν έχετε δικαίωμα να βλέπετε τα δεδομένα της σελίδας.")
            Response.End()
        End If
        If Not IsPostBack Then
            Call enhmervshTheioyBrefoys()
            Dim his As String() = hasRowsChildHistoryPerTab()
            pi0.InnerHtml = his(0)
            pi1.InnerHtml = his(1)
            If his(2) <> "" Then pi2.InnerHtml = his(2) : pi4.InnerHtml = his(2)
            If his(3) <> "" Then pi3.InnerHtml = his(3) : pi4.InnerHtml = his(3)
            pi5.InnerHtml = his(4)
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label4.Visible = True

        If TextBox82.Text <> "" Then
            TextBox82.Text = TextBox82.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox83.Text <> "" Then
            TextBox83.Text = TextBox83.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox84.Text <> "" Then
            TextBox84.Text = TextBox84.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox85.Text <> "" Then
            TextBox85.Text = TextBox85.Text.Replace(".", ",").Replace("'", "").Trim
        End If

        ' ελεγχοι
        If TextBox81.Text <> "" AndAlso Not IsDate(TextBox81.Text) Then
            Label4.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        If TextBox82.Text <> "" AndAlso Not IsNumeric(TextBox82.Text) Then
            Label4.Text = "Η ηλικία πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        'έλεγχοι βάρους
        If TextBox83.Text <> "" AndAlso Not IsNumeric(TextBox83.Text) Then
            Label4.Text = "Το βάρος πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        If TextBox83.Text.Trim = "" Then
            Label4.Text = "Το βάρος είναι υποχρεωτικό"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        If TextBox83.Text <> "" Then
            If CDbl(TextBox83.Text) <= 0 Then
                Label4.Text = "Το βάρος πρέπει να είναι μεγαλύτερο από 0 κιλών"
                PanelError.Controls.Add(notOK(Label4.Text))
                Exit Sub
            End If
            If CDbl(TextBox83.Text) >= 20 Then
                Label4.Text = "Το βάρος πρέπει να είναι μικρότερο των 20 κιλών"
                PanelError.Controls.Add(notOK(Label4.Text))
                Exit Sub
            End If
        End If
        'έλεγχοι ύψους
        If TextBox84.Text.Trim = "" Then
            Label4.Text = "Το ύψος είναι υποχρεωτικό"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        If TextBox84.Text <> "" Then
            If Not IsNumeric(TextBox84.Text) Then
                Label4.Text = "Το ύψος πρέπει να είναι αριθμός"
                PanelError.Controls.Add(notOK(Label4.Text))
                Exit Sub
            End If
            If CDbl(TextBox84.Text) <= 43 Then
                Label4.Text = "Το ύψος πρέπει να είναι μεγαλύτερο από 43 εκατοστά"
                PanelError.Controls.Add(notOK(Label4.Text))
                Exit Sub
            End If
            If CDbl(TextBox84.Text) >= 105 Then
                Label4.Text = "Το ύψος πρέπει να είναι μικρότερο από 105 εκατοστά"
                PanelError.Controls.Add(notOK(Label4.Text))
                Exit Sub
            End If
        End If
        ' έλεγχος κεφαλής
        If TextBox85.Text <> "" AndAlso Not IsNumeric(TextBox85.Text) Then
            Label4.Text = "Η περίμετρος κεφαλής πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        If TextBox86.Text <> "" AndAlso Not IsNumeric(TextBox86.Text) Then
            Label4.Text = "Ο αριθμός των δοντιών πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        'στρογγυλοποίηση τιμών στα textbox
        If TextBox82.Text <> "" Then
            TextBox82.Text = Math.Round(TextBox82.Text * 2) / 2
        End If
        If TextBox83.Text <> "" Then
            TextBox83.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox83.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        If TextBox84.Text <> "" Then
            TextBox84.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox84.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        If TextBox85.Text <> "" Then
            TextBox85.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox85.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        TextBox86.Text = TextBox86.Text.Replace("'", "''").Trim
        TextBox87.Text = TextBox87.Text.Replace("'", "''").Trim
        If Not (TextBox81.Text <> "" AndAlso TextBox82.Text <> "" AndAlso (TextBox83.Text <> "" OrElse TextBox84.Text <> "" OrElse TextBox85.Text <> "")) Then
            Label4.Text = "Πρέπει να εισάγετε υποχρεωτικά κάποια από τις τιμές του βάρους, του ύψους ή της περίμετρου κεφαλής"
            PanelError.Controls.Add(notOK(Label4.Text))
            Exit Sub
        End If
        ' βαση δεδομενων
        Dim hm2 As String = conStrs.AccessDateTime(Now)
        ' hm2 ημερομηνία του datestamp
        Dim hm As Date = CDate(TextBox81.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ] AS [Ηλικία σε μήνες], [ΒΑΡΟΣ], [ΥΨΟΣ], [ΚΕΦΑΛΗ] AS [Περίμετρος κεφαλής], [ΔΟΝΤΙΑ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ], [ΚΛΙΝΙΚΗ], [DATE-STAMP], [UN] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "', " &
               "[ΗΛΙΚΙΑ]=" & If(TextBox82.Text.Replace(",", ".") = "", "NULL", TextBox82.Text.Replace(",", ".")) &
               ", [ΒΑΡΟΣ]=" & If(TextBox83.Text.Replace(",", ".") = "", "NULL", TextBox83.Text.Replace(",", ".")) &
               ", [ΥΨΟΣ]=" & If(TextBox84.Text.Replace(",", ".") = "", "NULL", TextBox84.Text.Replace(",", ".")) &
               ", [ΚΕΦΑΛΗ]=" & If(TextBox85.Text.Replace(",", ".") = "", "NULL", TextBox85.Text.Replace(",", ".")) &
               ", [ΔΟΝΤΙΑ]=" & If(TextBox86.Text = "", "NULL", "'" & TextBox86.Text & "'") &
               ", [ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox87.Text = "", "NULL", "'" & TextBox87.Text & "' ") &
               ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
               ", [ΚΛΙΝΙΚΗ]='" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "'" &
               ", [DATE-STAMP]='" & hm2 & "'" &
               ", [UN]='" & currentUser.user.UserName & "'" &
               " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΙΑΤΡΟΣ], [ΚΛΙΝΙΚΗ], [DATE-STAMP], [UN], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ], [ΥΨΟΣ], [ΚΕΦΑΛΗ], [ΔΟΝΤΙΑ], [ΠΑΡΑΤΗΡΗΣΕΙΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΓΕΝΙΚΑ', 1, '" & finalHm & "','" & currentUser.user.UserRealName & "', " &
                             "'" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "', " &
                             "'" & hm2 & "', " &
                             "'" & currentUser.user.UserName & "', " &
                             If(TextBox82.Text.Replace(",", ".") = "", "NULL", TextBox82.Text.Replace(",", ".")) & ", " &
                             If(TextBox83.Text.Replace(",", ".") = "", "NULL", TextBox83.Text.Replace(",", ".")) & ", " &
                             If(TextBox84.Text.Replace(",", ".") = "", "NULL", TextBox84.Text.Replace(",", ".")) & ", " &
                             If(TextBox85.Text.Replace(",", ".") = "", "NULL", TextBox85.Text.Replace(",", ".")) & ", " &
                             If(TextBox86.Text.Replace("'", "''") = "", "NULL", "'" & TextBox86.Text & "'") & ", " &
                             If(TextBox87.Text.Replace("'", "''") = "", "NULL", "'" & TextBox87.Text & "'") & ") ")
        End If
        localData.TerminateLocalDBConnection()
        currentUser.insertCommentsForWatching(currentUser.user.UserName, "Ενημέρωση Ιστορικού βρέφους για τον ασθενή με ΑΜ " & Request.QueryString("patientID"), currentUser.user.ip)
        Label4.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        PanelError.Controls.Add(okOk())
        Call enhmervshTheioyBrefoys()
    End Sub
    Private Sub enhmervshTheioyBrefoys()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ] as [ΗΜ/ΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ] AS [ΒΑΡΟΣ(KG)], [ΥΨΟΣ] AS [ΥΨΟΣ(CM)], [ΚΕΦΑΛΗ] AS [ΠΕΡ.ΚΕΦΑΛΗΣ], [ΔΟΝΤΙΑ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ], [ΚΛΙΝΙΚΗ], [DATE-STAMP] AS [ΗΜ/ΝΙΑ ΚΑΤΑΧΩΡΗΣΗΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 ORDER BY [ΗΛΙΚΙΑ]")
        localData.TerminateLocalDBConnection()
        GridView2.DataSource = dt
        GridView2.DataBind()
        removeTime(GridView2, 0)
    End Sub
End Class