Public Class paidiatriko1
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
            LabelEpi.Text = GridView1.Rows(0).Cells(3).Text
            LabelOn.Text = GridView1.Rows(0).Cells(4).Text
            LabelOnfat.Text = GridView1.Rows(0).Cells(5).Text
            TextBoxEpfat.Text = GridView1.Rows(0).Cells(3).Text
            LabelhmGen.Text = "Τρέχουσα " & GridView1.ToolTip.Replace(" ασθενούς", "")
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
        'ανοίγω τη σύνδεση της βάσης και καλώ τη ρουτίνα insertOrUpdate
        Dim localData As New localDBconnection
        Label1.Visible = True
        'έλεγχος ημερομηνίας
        If TextBox13.Text <> "" AndAlso Not IsDate(TextBox13.Text) Then
            Label1.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Panel1.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ", "ΤΟΠΟΣ ΓΕΝΝΗΣΗΣ", TextBox1.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ", "ΔΙΕΥΘΥΝΣΗ ΚΑΤΟΙΚΙΑΣ", TextBox2.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ", "ΑΡΙΘΜΟΣ ΛΗΞΙΑΡΧΙΚΗΣ ΠΡΑΞΗΣ ΓΕΝΝΗΣΗΣ", TextBox3.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ", "ΤΗΛΕΦΩΝΟ", TextBox4.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΟΝΟΜΑ", TextBox5.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΕΠΙΘΕΤΟ", TextBox6.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ", TextBox7.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΤΟΠΟΣ ΚΑΤΑΓΩΓΗΣ", TextBox8.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΕΘΝΙΚΟΤΗΤΑ", TextBox9.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΑΣΦΑΛΙΣΗ", TextBox10.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΚΑΤΑΣΤΑΣΗ ΥΓΕΙΑΣ", TextBox11.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Η ΜΗΤΕΡΑ", "ΠΡΟΗΓΟΥΜΕΝΕΣ ΠΑΘΗΣΕΙΣ/ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ", TextBox12.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ", TextBox13.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΤΟΠΟΣ ΚΑΤΑΓΩΓΗΣ", TextBox14.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΕΘΝΙΚΟΤΗΤΑ", TextBox15.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΚΑΤΑΣΤΑΣΗ ΥΓΕΙΑΣ", TextBox16.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΠΡΟΗΓΟΥΜΕΝΕΣ ΠΑΘΗΣΕΙΣ/ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ", TextBox17.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΑΣΦΑΛΙΣΗ", TextBox18.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "Ο ΠΑΤΕΡΑΣ", "ΑΔΕΡΦΙΑ", TextBox19.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ", "ΤΕΡ", TextBox20.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ", "ΑΝΑΜΕΝΟΜΕΝΗ ΗΜΕΡ. ΤΟΚΕΤΟΥ", TextBox21.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ", "ΗΛΙΚΙΑ ΠΑΤΕΡΑ ΚΑΤΑ ΤΗ ΣΥΛΛΗΨΗ", TextBox22.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ", "ΗΛΙΚΙΑ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗ ΣΥΛΛΗΨΗ", TextBox23.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ", "ΟΜΑΔΑ ΑΙΜΑΤΟΣ ΜΗΤΕΡΑΣ", DropDownListOmada.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΧΡΟΝΙΑ ΝΟΣΗΜΑΤΑ", TextBox24.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΛΟΙΜΩΞΕΙΣ", TextBox25.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΑΙΜΟΡΡΑΓΙΑ", TextBox26.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΑΚΙΝΗΣΙΑ", TextBox27.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΠΕΡΙΔΕΣΗ ΤΡΑΧΗΛΟΥ", TextBox28.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΑΛΛΑ ΠΡΟΒΛΗΜΑΤΑ", TextBox29.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΑΡΤΗΡΙΑΚΗ ΠΙΕΣΗ", TextBox30.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΕΡΓΑΣΤΗΡΙΑΚΕΣ ΕΞΕΤΑΣΕΙΣ", TextBox31.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΦΑΡΜΑΚΑ", TextBox32.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΚΑΠΝΙΣΜΑ", DropDownListSmoke.SelectedItem.Text.Replace("--", ""), localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΚΑΠΝΙΣΜΑ - ΣΧΟΛΙΑ", TextBox33.Text, localData)
        Call insertOrUpdate("ΔΗΜΟΓΡΑΦΙΚΑ", "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ", "ΑΛΚΟΟΛ - ΑΛΛΑ", TextBox34.Text, localData)
        localData.TerminateLocalDBConnection()
        currentUser.insertCommentsForWatching(currentUser.user.UserName, "Ενημέρωση Παιδιατρικού ιστορικού (Γενικά) για τον ασθενή με ΑΜ " & Request.QueryString("patientID"), currentUser.user.ip)
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
        Dim dt As DataTable = localData.getData("SELECT [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ, [userName], [ΟΝΟΜΑΤΕΠΩΝΥΜΟ], [ΚΛΙΝΙΚΗ], [date-stamp] FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='ΔΗΜΟΓΡΑΦΙΚΑ'")
        For f As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(f).Item(0) = "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ" And dt.Rows(f).Item(1) = "ΤΟΠΟΣ ΓΕΝΝΗΣΗΣ" Then TextBox1.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ" And dt.Rows(f).Item(1) = "ΔΙΕΥΘΥΝΣΗ ΚΑΤΟΙΚΙΑΣ" Then TextBox2.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ" And dt.Rows(f).Item(1) = "ΑΡΙΘΜΟΣ ΛΗΞΙΑΡΧΙΚΗΣ ΠΡΑΞΗΣ ΓΕΝΝΗΣΗΣ" Then TextBox3.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ" And dt.Rows(f).Item(1) = "ΤΗΛΕΦΩΝΟ" Then TextBox4.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΟΝΟΜΑ" Then TextBox5.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΕΠΙΘΕΤΟ" Then TextBox6.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ" Then TextBox7.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΤΟΠΟΣ ΚΑΤΑΓΩΓΗΣ" Then TextBox8.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΕΘΝΙΚΟΤΗΤΑ" Then TextBox9.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΑΣΦΑΛΙΣΗ" Then TextBox10.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΚΑΤΑΣΤΑΣΗ ΥΓΕΙΑΣ" Then TextBox11.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Η ΜΗΤΕΡΑ" And dt.Rows(f).Item(1) = "ΠΡΟΗΓΟΥΜΕΝΕΣ ΠΑΘΗΣΕΙΣ/ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ" Then TextBox12.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ" Then TextBox13.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΤΟΠΟΣ ΚΑΤΑΓΩΓΗΣ" Then TextBox14.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΕΘΝΙΚΟΤΗΤΑ" Then TextBox15.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΚΑΤΑΣΤΑΣΗ ΥΓΕΙΑΣ" Then TextBox16.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΠΡΟΗΓΟΥΜΕΝΕΣ ΠΑΘΗΣΕΙΣ/ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ" Then TextBox17.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΑΣΦΑΛΙΣΗ" Then TextBox18.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "Ο ΠΑΤΕΡΑΣ" And dt.Rows(f).Item(1) = "ΑΔΕΡΦΙΑ" Then TextBox19.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ" And dt.Rows(f).Item(1) = "ΤΕΡ" Then TextBox20.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ" And dt.Rows(f).Item(1) = "ΑΝΑΜΕΝΟΜΕΝΗ ΗΜΕΡ. ΤΟΚΕΤΟΥ" Then TextBox21.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ" And dt.Rows(f).Item(1) = "ΗΛΙΚΙΑ ΠΑΤΕΡΑ ΚΑΤΑ ΤΗ ΣΥΛΛΗΨΗ" Then TextBox22.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ" And dt.Rows(f).Item(1) = "ΗΛΙΚΙΑ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗ ΣΥΛΛΗΨΗ" Then TextBox23.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ" And dt.Rows(f).Item(1) = "ΟΜΑΔΑ ΑΙΜΑΤΟΣ ΜΗΤΕΡΑΣ" Then DropDownListOmada.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΧΡΟΝΙΑ ΝΟΣΗΜΑΤΑ" Then TextBox24.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΛΟΙΜΩΞΕΙΣ" Then TextBox25.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΑΙΜΟΡΡΑΓΙΑ" Then TextBox26.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΑΚΙΝΗΣΙΑ" Then TextBox27.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΠΕΡΙΔΕΣΗ ΤΡΑΧΗΛΟΥ" Then TextBox28.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΑΛΛΑ ΠΡΟΒΛΗΜΑΤΑ" Then TextBox29.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΑΡΤΗΡΙΑΚΗ ΠΙΕΣΗ" Then TextBox30.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΕΡΓΑΣΤΗΡΙΑΚΕΣ ΕΞΕΤΑΣΕΙΣ" Then TextBox31.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΦΑΡΜΑΚΑ" Then TextBox32.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΦΑΡΜΑΚΑ" Then TextBox32.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΚΑΠΝΙΣΜΑ" Then DropDownListSmoke.SelectedValue = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΚΑΠΝΙΣΜΑ - ΣΧΟΛΙΑ" Then TextBox33.Text = dt.Rows(f).Item(2) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ" And dt.Rows(f).Item(1) = "ΑΛΚΟΟΛ - ΑΛΛΑ" Then TextBox34.Text = dt.Rows(f).Item(2) : GoTo nextValue
nextValue:
        Next
        If dt.Rows.Count > 0 Then
            Label2.Visible = True
            Label2.Text = "Τελευταία ενημέρωση στις " & dt.Rows(0).Item("date-stamp") & " από τον " & dt.Rows(0).Item("ΟΝΟΜΑΤΕΠΩΝΥΜΟ") & " (un: " & dt.Rows(0).Item("userName") & "), στην κλινική/τμήμα/ιατρείο: " & dt.Rows(0).Item("ΚΛΙΝΙΚΗ") & "."
        End If
        localData.TerminateLocalDBConnection()
    End Sub
End Class