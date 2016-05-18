Public Class paidiatriko2
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
            Call viewDhmografika()
            Dim his As String() = hasRowsChildHistoryPerTab()
            pi0.InnerHtml = his(0)
            pi1.InnerHtml = his(1)
            If his(2) <> "" Then pi2.InnerHtml = his(2) : pi4.InnerHtml = his(2)
            If his(3) <> "" Then pi3.InnerHtml = his(3) : pi4.InnerHtml = his(3)
            pi5.InnerHtml = his(4)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xarakthristika1 As String = "", xarakthristika2 As String = "",
         xarakthristika3 As String = ""
        'ανοίγω τη σύνδεση της βάσης και καλώ τη ρουτίνα insertOrUpdate
        Dim localData As New localDBconnection
        Label1.Visible = True
        If TextBox35.Text <> "" AndAlso Not IsDate(TextBox35.Text) Then
            Label1.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Panel1.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox41.Text <> "" Then
            If Not IsNumeric(TextBox41.Text) Then
                Label1.Text = "Το βάρος του παιδιού πρέπει να είναι αριθμός"
                Panel1.Controls.Add(notOK(Label1.Text))
                Exit Sub
            End If
            If CDbl(TextBox41.Text) <= 0 Then
                Label1.Text = "Το βάρος  του παιδιού πρέπει να είναι μεγαλύτερο από 0 κιλών"
                Panel1.Controls.Add(notOK(Label1.Text))
                Exit Sub
            End If
            If CDbl(TextBox41.Text) >= 20 Then
                Label1.Text = "Το βάρος του παιδιού πρέπει να είναι μικρότερο των 20 κιλών"
                Panel1.Controls.Add(notOK(Label1.Text))
                Exit Sub
            End If
        End If
        If TextBox42.Text <> "" Then
            If Not IsNumeric(TextBox42.Text) Then
                Label1.Text = "Το μήκος του παιδιού πρέπει να είναι αριθμός"
                Panel1.Controls.Add(notOK(Label1.Text))
                Exit Sub
            End If
            If CDbl(TextBox42.Text) <= 43 Then
                Label1.Text = "Το μήκος του παιδιού πρέπει να είναι μεγαλύτερο από 43 εκατοστά"
                Panel1.Controls.Add(notOK(Label1.Text))
                Exit Sub
            End If
            If CDbl(TextBox42.Text) >= 105 Then
                Label1.Text = "Το μήκος του παιδιού πρέπει να είναι μικρότερο από 105 εκατοστά"
                Panel1.Controls.Add(notOK(Label1.Text))
                Exit Sub
            End If
        End If
        If TextBox43.Text <> "" AndAlso Not IsNumeric(TextBox43.Text) Then
            Label1.Text = "Η περίμετρος κεφαλής του παιδιού πρέπει να είναι αριθμός"
            Panel1.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox39.Text <> "" AndAlso Not IsNumeric(TextBox39.Text) Then
            Label1.Text = "Οι εβδομάδες πρέπει να είναι αριθμός"
            Panel1.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox36.Text <> "" AndAlso Not IsNumeric(TextBox36.Text) Then
            Label1.Text = "Η ώρα πρέπει να είναι αριθμός"
            Panel1.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΗΜΕΡΟΜΗΝΙΑ", TextBox35.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΩΡΑ", TextBox36.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΚΛΙΝΙΚΗ/ΝΟΣΟΚΟΜΕΙΟ", TextBox37.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΤΟΠΟΣ", TextBox38.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΔΙΑΡΚΕΙΑ ΚΥΗΣΗΣ(ΕΒΔΟΜΑΔΕΣ)", TextBox39.Text, localData)
        If CheckBox1.Checked Then xarakthristika1 &= CheckBox1.Text & ","
        If CheckBox2.Checked Then xarakthristika1 &= CheckBox2.Text & ","
        If CheckBox3.Checked Then xarakthristika1 &= CheckBox3.Text & ","
        If CheckBox4.Checked Then xarakthristika1 &= CheckBox4.Text & ","
        If CheckBox5.Checked Then xarakthristika1 &= CheckBox5.Text & ","
        If CheckBox6.Checked Then xarakthristika1 &= CheckBox6.Text & ","
        If CheckBox7.Checked Then xarakthristika1 &= CheckBox7.Text & ","
        If CheckBox8.Checked Then xarakthristika1 &= CheckBox8.Text & ","
        If CheckBox9.Checked Then xarakthristika1 &= CheckBox9.Text & ","
        If xarakthristika1.Length > 0 Then xarakthristika1 = Left(xarakthristika1, xarakthristika1.Length - 1)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΧΑΡΑΚΤΗΡΙΣΤΙΚΑ", xarakthristika1, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΤΟΚΕΤΟΣ", "ΑΛΛΕΣ ΕΠΕΜΒΑΣΕΙΣ ΚΑΙ ΑΙΤΙΑ", TextBox40.Text, localData)
        'καλώ τη ρουτίνα για να προσθέσω τις μετρήσεις του παιδιού
        Call insertorupdatebarosypsos(localData)
        'Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΒΑΡΟΣ(gr)", TextBox41.Text, localData)
        'Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΜΗΚΟΣ(cm)", TextBox42.Text, localData)
        'Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΠΕΡΙΜΕΤΡΟΣ ΚΕΦΑΛΙΟΥ(cm)", TextBox43.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "APGAR 1min", TextBox44.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "APGAR 5min", TextBox45.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "APGAR 10min", TextBox46.Text, localData)
        If CheckBox10.Checked Then xarakthristika2 &= CheckBox10.Text & ","
        If CheckBox11.Checked Then xarakthristika2 &= CheckBox11.Text & ","
        If CheckBox12.Checked Then xarakthristika2 &= CheckBox12.Text & ","
        If CheckBox13.Checked Then xarakthristika2 &= CheckBox13.Text & ","
        If CheckBox14.Checked Then xarakthristika2 &= CheckBox14.Text & ","
        If CheckBox15.Checked Then xarakthristika2 &= CheckBox15.Text & ","
        If CheckBox16.Checked Then xarakthristika2 &= CheckBox16.Text & ","
        If CheckBox17.Checked Then xarakthristika2 &= CheckBox17.Text & ","
        If CheckBox18.Checked Then xarakthristika2 &= CheckBox18.Text & ","
        If CheckBox19.Checked Then xarakthristika2 &= CheckBox19.Text & ","
        If CheckBox20.Checked Then xarakthristika2 &= CheckBox20.Text & ","
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΧΑΡΑΚΤΗΡΙΣΤΙΚΑ", xarakthristika2, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΙΣΧΙΑ", TextBox47.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ", TextBox48.Text, localData)
        If CheckBox21.Checked = True Then
            Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΠΗΡΕ ΟΞΥΓΟΝΟ ΓΙΑ ΔΙΑΣΤΗΜΑ", TextBox49.Text, localData)
        End If
        If CheckBox22.Checked = True Then
            Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΜΠΗΚΕ ΣΕ ΘΕΡΜΟΚΟΙΤΙΔΑ ΓΙΑ ΔΙΑΣΤΗΜΑ", TextBox50.Text, localData)
        End If
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΑΙΤΙΑ", TextBox51.Text, localData)
        If CheckBox23.Checked = True Then
            Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΛΟΙΜΩΞΗ", TextBox52.Text, localData)
        End If
        If CheckBox24.Checked = True Then
            Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΣΠΑΣΜΟΙ", TextBox53.Text, localData)
        End If
        If CheckBox25.Checked = True Then
            Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΙΚΤΕΡΟΣ", TextBox54.Text, localData)
        End If
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΧΟΛΕΡΥΘΡΙΝΗ", TextBox55.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΣΥΓΓΕΝΕΙΣ ΑΝΩΜΑΛΙΕΣ", TextBox56.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΘΕΡΑΠΕΥΤΙΚΗ / ΦΑΡΜΑΚΕΥΤΙΚΗ ΑΓΩΓΗ", TextBox57.Text, localData)
        If CheckBox26.Checked Then xarakthristika3 &= CheckBox26.Text & ","
        If CheckBox27.Checked Then xarakthristika3 &= CheckBox27.Text & ","
        If CheckBox28.Checked Then xarakthristika3 &= CheckBox28.Text & ","
        If CheckBox29.Checked Then xarakthristika3 &= CheckBox29.Text & ","
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ", "ΑΙΜΟΛΗΨΙΑ ΓΙΑ", xarakthristika3, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ", "RHESUS", DropDownListOmada.SelectedItem.Text.Replace("--", ""), localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ", "ΕΛΛΕΙΨΗ G-6PD", DropDownListPD.SelectedItem.Text.Replace("--", ""), localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ", "ΠΛΗΡΟΦΟΡΙΕΣ G-6PD", TextBox58.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ", "ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ", TextBox59.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ", "ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ", TextBox60.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ", "ΑΛΛΑ", TextBox61.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΒΑΡΟΣ ΣΩΜΑΤΟΣ", TextBox62.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΝΕΟΓΝΙΚΑ ΑΝΤΑΝΑΚΛΑΣΤΙΚΑ", TextBox63.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΙΣΧΙΑ", TextBox64.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ", TextBox65.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΟΙΔΗΜΑ", TextBox66.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΙΚΤΕΡΟΣ", TextBox67.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΦΥΣΙΟΛΟΓΙΚΟ ΚΛΑΜΑ", TextBox68.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΔΥΣΠΝΟΙΑ", TextBox69.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΚΥΑΝΩΣΗ", TextBox70.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΚΑΡΔΙΑΚΗ ΤΟΝΟΙ", TextBox71.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΗΠΑΤΟΜΕΓΑΛΙΑ", TextBox72.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΣΠΛΗΝΟΜΕΓΑΛΙΑ", TextBox73.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΑΝΤΙΔΡΑΣΗ ΣΤΟΝ ΗΧΟ", TextBox74.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΑΝΤΙΔΡΑΣΗ ΣΤΟ ΦΩΣ", TextBox75.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΣΥΓΓΕΝΕΙΣ ΑΝΩΜΑΛΙΕΣ", TextBox76.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΜΗΤΡΙΚΟΣ ΘΗΛΑΣΜΟΣ", TextBox77.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΓΑΛΑ ΕΜΠΟΡΙΟΥ", TextBox78.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΜΙΚΤΗ ΔΙΑΤΡΟΦΗ", TextBox79.Text, localData)
        Call insertOrUpdate("ΠΕΡΙΓΕΝΝΗΤΙΚΑ", "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ", "ΑΛΛΕΣ ΠΛΗΡΟΦΟΡΙΕΣ ΚΑΙ ΠΑΡΑΤΗΡΗΣΕΙΣ", TextBox80.Text, localData)
        localData.TerminateLocalDBConnection()
        currentUser.insertCommentsForWatching(currentUser.user.UserName, "Ενημέρωση Περιγγενητικού ιστορικού για τον ασθενή με ΑΜ " & Request.QueryString("patientID"), currentUser.user.ip)
        Label1.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        Panel1.Controls.Add(okOk())
    End Sub
    Private Sub insertOrUpdate(xar1 As String, xar2 As String, xar3 As String, value As String, localData As localDBconnection)
        Dim dt As DataTable = localData.getData("SELECT ΤΙΜΗ FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='" & xar1 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2]='" & xar2 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3]='" & xar3 & "'")
        If dt.Rows.Count > 0 Then
            'αν υπάρχει το πεδιο στη βαση και διαγραφεί το πεδίο γινεται διαγραφη
            If value = "" Then
                localData.updateData("DELETE FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='" & xar1 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2]='" & xar2 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3]='" & xar3 & "'")
            Else
                'ενημέρωση
                Dim hm As String = conStrs.AccessDateTime(Now)
                localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] SET [ΤΙΜΗ]='" & value & "'" &
                    "[userName]='" & currentUser.user.UserName & "', [ΟΝΟΜΑΤΕΠΩΝΥΜΟ]='" & currentUser.user.UserRealName & "', [ΚΛΙΝΙΚΗ]='" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "', [date-stamp]='" & hm & "'" &
                                 " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='" & xar1 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2]='" & xar2 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3]='" & xar3 & "'")
            End If
        Else
            'εισαγωγή στοιχείων
            If value <> "" Then
                localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] ( [PATIENT_CODE], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ, [userName], [ΟΝΟΜΑΤΕΠΩΝΥΜΟ], [ΚΛΙΝΙΚΗ]) VALUES (" &
                                 "'" & Request.QueryString("patientID") & "', '" & xar1 & "','" & xar2 & "', '" & xar3 & "', '" & value & "', '" & currentUser.user.UserName & "', '" & currentUser.user.UserRealName & "', '" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "')")
            End If
        End If
    End Sub
    Private Sub viewDhmografika()
        Dim localData As New localDBconnection
        Dim dt1 As DataTable = localData.getData("SELECT [ΒΑΡΟΣ], [ΥΨΟΣ], [ΚΕΦΑΛΗ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND ΗΛΙΚΙΑ=0 AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        If dt1.Rows.Count > 0 Then
            If Not dt1.Rows(0).Item(0) Is DBNull.Value Then TextBox41.Text = dt1.Rows(0).Item(0)
            If Not dt1.Rows(0).Item(1) Is DBNull.Value Then TextBox42.Text = dt1.Rows(0).Item(1)
            If Not dt1.Rows(0).Item(2) Is DBNull.Value Then TextBox43.Text = dt1.Rows(0).Item(2)
        End If
        Dim dt As DataTable = localData.getData("SELECT [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ, [userName], [ΟΝΟΜΑΤΕΠΩΝΥΜΟ], [ΚΛΙΝΙΚΗ], [date-stamp] FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='ΠΕΡΙΓΕΝΝΗΤΙΚΑ'")
        For f As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΗΜΕΡΟΜΗΝΙΑ" Then TextBox35.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΩΡΑ" Then TextBox36.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΚΛΙΝΙΚΗ/ΝΟΣΟΚΟΜΕΙΟ" Then TextBox37.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΤΟΠΟΣ" Then TextBox38.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΔΙΑΡΚΕΙΑ ΚΥΗΣΗΣ(ΕΒΔΟΜΑΔΕΣ)" Then TextBox39.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΧΑΡΑΚΤΗΡΙΣΤΙΚΑ" Then
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox1.Text) >= 0 Then CheckBox1.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox2.Text) >= 0 Then CheckBox2.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox3.Text) >= 0 Then CheckBox3.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox4.Text) >= 0 Then CheckBox4.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox5.Text) >= 0 Then CheckBox5.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox6.Text) >= 0 Then CheckBox6.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox7.Text) >= 0 Then CheckBox7.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox8.Text) >= 0 Then CheckBox8.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox9.Text) >= 0 Then CheckBox9.Checked = True
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΤΟΚΕΤΟΣ" And dt.Rows(f).Item(1) = "ΑΛΛΕΣ ΕΠΕΜΒΑΣΕΙΣ ΚΑΙ ΑΙΤΙΑ" Then TextBox40.Text = dt.Rows(f).Item(2) : GoTo nextValue
            'If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΒΑΡΟΣ(gr)" Then TextBox41.Text = dt.Rows(f).Item(2) : GoTo nextValue
            'If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΜΗΚΟΣ(cm)" Then TextBox42.Text = dt.Rows(f).Item(2) : GoTo nextValue
            'If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΠΕΡΙΜΕΤΡΟΣ ΚΕΦΑΛΙΟΥ(cm)" Then TextBox43.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "APGAR 1min" Then TextBox44.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "APGAR 5min" Then TextBox45.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "APGAR 10min" Then TextBox46.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΧΑΡΑΚΤΗΡΙΣΤΙΚΑ" Then
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox10.Text) >= 0 Then CheckBox10.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox11.Text) >= 0 Then CheckBox11.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox12.Text) >= 0 Then CheckBox12.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox13.Text) >= 0 Then CheckBox13.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox14.Text) >= 0 Then CheckBox14.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox15.Text) >= 0 Then CheckBox15.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox16.Text) >= 0 Then CheckBox16.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox17.Text) >= 0 Then CheckBox17.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox18.Text) >= 0 Then CheckBox18.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox19.Text) >= 0 Then CheckBox19.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox20.Text) >= 0 Then CheckBox20.Checked = True
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΙΣΧΙΑ" Then TextBox47.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ" Then TextBox48.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΠΗΡΕ ΟΞΥΓΟΝΟ ΓΙΑ ΔΙΑΣΤΗΜΑ" Then
                TextBox49.Text = dt.Rows(f).Item(2)
                CheckBox21.Checked = True
                oksygono.Attributes("style") = ""
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΜΠΗΚΕ ΣΕ ΘΕΡΜΟΚΟΙΤΙΔΑ ΓΙΑ ΔΙΑΣΤΗΜΑ" Then
                TextBox50.Text = dt.Rows(f).Item(2)
                CheckBox22.Checked = True
                thermo.Attributes("style") = ""
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΑΙΤΙΑ" Then TextBox51.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΛΟΙΜΩΞΗ" Then
                TextBox52.Text = dt.Rows(f).Item(2)
                CheckBox23.Checked = True
                loimo.Attributes("style") = ""
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΣΠΑΣΜΟΙ" Then
                TextBox53.Text = dt.Rows(f).Item(2)
                CheckBox24.Checked = True
                spasmoi.Attributes("style") = ""
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΙΚΤΕΡΟΣ" Then
                TextBox54.Text = dt.Rows(f).Item(2)
                CheckBox25.Checked = True
                ikteros.Attributes("style") = ""
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΧΟΛΕΡΥΘΡΙΝΗ" Then TextBox55.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΣΥΓΓΕΝΕΙΣ ΑΝΩΜΑΛΙΕΣ" Then TextBox56.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΘΕΡΑΠΕΥΤΙΚΗ / ΦΑΡΜΑΚΕΥΤΙΚΗ ΑΓΩΓΗ" Then TextBox57.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ" And dt.Rows(f).Item(1) = "ΑΙΜΟΛΗΨΙΑ ΓΙΑ" Then
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox26.Text) >= 0 Then CheckBox26.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox27.Text) >= 0 Then CheckBox27.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox28.Text) >= 0 Then CheckBox28.Checked = True
                If dt.Rows(f).Item(2).ToString.IndexOf(CheckBox29.Text) >= 0 Then CheckBox29.Checked = True
                GoTo nextValue
            End If
            If dt.Rows(f).Item(0) = "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ" And dt.Rows(f).Item(1) = "RHESUS" Then DropDownListOmada.SelectedValue = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ" And dt.Rows(f).Item(1) = "ΕΛΛΕΙΨΗ G-6PD" Then DropDownListPD.SelectedValue = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ" And dt.Rows(f).Item(1) = "ΠΛΗΡΟΦΟΡΙΕΣ G-6PD" Then TextBox58.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ" And dt.Rows(f).Item(1) = "ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ" Then TextBox59.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ" And dt.Rows(f).Item(1) = "ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ" Then TextBox60.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ" And dt.Rows(f).Item(1) = "ΑΛΛΑ" Then TextBox61.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΒΑΡΟΣ ΣΩΜΑΤΟΣ" Then TextBox62.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΝΕΟΓΝΙΚΑ ΑΝΤΑΝΑΚΛΑΣΤΙΚΑ" Then TextBox63.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΙΣΧΙΑ" Then TextBox64.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ" Then TextBox65.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΟΙΔΗΜΑ" Then TextBox66.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΙΚΤΕΡΟΣ" Then TextBox67.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΦΥΣΙΟΛΟΓΙΚΟ ΚΛΑΜΑ" Then TextBox68.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΔΥΣΠΝΟΙΑ" Then TextBox69.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΚΥΑΝΩΣΗ" Then TextBox70.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΚΑΡΔΙΑΚΗ ΤΟΝΟΙ" Then TextBox71.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΗΠΑΤΟΜΕΓΑΛΙΑ" Then TextBox72.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΣΠΛΗΝΟΜΕΓΑΛΙΑ" Then TextBox73.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΑΝΤΙΔΡΑΣΗ ΣΤΟΝ ΗΧΟ" Then TextBox74.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΑΝΤΙΔΡΑΣΗ ΣΤΟ ΦΩΣ" Then TextBox75.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΣΥΓΓΕΝΕΙΣ ΑΝΩΜΑΛΙΕΣ" Then TextBox76.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΜΗΤΡΙΚΟΣ ΘΗΛΑΣΜΟΣ" Then TextBox77.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΓΑΛΑ ΕΜΠΟΡΙΟΥ" Then TextBox78.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΜΙΚΤΗ ΔΙΑΤΡΟΦΗ" Then TextBox79.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ" And dt.Rows(f).Item(1) = "ΑΛΛΕΣ ΠΛΗΡΟΦΟΡΙΕΣ ΚΑΙ ΠΑΡΑΤΗΡΗΣΕΙΣ" Then TextBox80.Text = dt.Rows(f).Item(2) : GoTo nextValue
nextValue:
        Next
        If dt.Rows.Count > 0 Then
            Label2.Visible = True
            Label2.Text = "Τελευταία ενημέρωση στις " & dt.Rows(0).Item("date-stamp") & " από τον " & dt.Rows(0).Item("ΟΝΟΜΑΤΕΠΩΝΥΜΟ") & " (un: " & dt.Rows(0).Item("userName") & "), στην κλινική/τμήμα/ιατρείο: " & dt.Rows(0).Item("ΚΛΙΝΙΚΗ") & "."
        End If
        localData.TerminateLocalDBConnection()
    End Sub
    Private Sub insertorupdatebarosypsos(localData As localDBconnection)
        Dim hm As Date = Now
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND ΗΛΙΚΙΑ=0 AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        If dt.Rows.Count > 0 Then
            If TextBox41.Text <> "" OrElse TextBox42.Text <> "" OrElse TextBox43.Text <> "" Then

                MsgBox("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "'" &
               ", [ΒΑΡΟΣ]=" & If(TextBox41.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox41.Text.Replace("'", "").Replace(",", ".")) &
               ", [ΥΨΟΣ]=" & If(TextBox42.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox42.Text.Replace("'", "").Replace(",", ".")) &
               ", [ΚΕΦΑΛΗ]=" & If(TextBox43.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox43.Text.Replace("'", "").Replace(",", ".")) &
               " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND ΗΛΙΚΙΑ=0 AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")

                localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "'" &
               ", [ΒΑΡΟΣ]=" & If(TextBox41.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox41.Text.Replace("'", "").Replace(",", ".")) &
               ", [ΥΨΟΣ]=" & If(TextBox42.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox42.Text.Replace("'", "").Replace(",", ".")) &
               ", [ΚΕΦΑΛΗ]=" & If(TextBox43.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox43.Text.Replace("'", "").Replace(",", ".")) &
               " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND ΗΛΙΚΙΑ=0 AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
            Else
                localData.updateData("DELETE FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=1 AND ΗΛΙΚΙΑ=0 AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
            End If
        ElseIf TextBox41.Text <> "" OrElse TextBox42.Text <> "" OrElse TextBox43.Text <> "" Then
            MsgBox("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ], [ΥΨΟΣ], [ΚΕΦΑΛΗ], [ΙΑΤΡΟΣ], [UN], [ΚΛΙΝΙΚΗ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΓΕΝΙΚΑ', 1, '" & finalHm & "', 0 , " &
                             If(TextBox41.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox41.Text.Replace("'", "").Replace(",", ".")) & ", " &
                             If(TextBox42.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox42.Text.Replace("'", "").Replace(",", ".")) & ", " &
                             If(TextBox43.Text.Replace("'", "").Replace(",", ".") = "", "NULL", "'" & TextBox43.Text.Replace("'", "").Replace(",", ".") & "'") & ", " &
                             "'" & currentUser.user.UserRealName & "', " &
                             "'" & currentUser.user.UserName & "', " &
                             "'" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "')")
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ], [ΥΨΟΣ], [ΚΕΦΑΛΗ], [ΙΑΤΡΟΣ], [UN], [ΚΛΙΝΙΚΗ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΓΕΝΙΚΑ', 1, '" & finalHm & "', 0 , " &
                             If(TextBox41.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox41.Text.Replace("'", "").Replace(",", ".")) & ", " &
                             If(TextBox42.Text.Replace("'", "").Replace(",", ".") = "", "NULL", TextBox42.Text.Replace("'", "").Replace(",", ".")) & ", " &
                             If(TextBox43.Text.Replace("'", "").Replace(",", ".") = "", "NULL", "'" & TextBox43.Text.Replace("'", "").Replace(",", ".") & "'") & ", " &
                             "'" & currentUser.user.UserRealName & "', " &
                             "'" & currentUser.user.UserName & "', " &
                             "'" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "')")
        End If
    End Sub
End Class