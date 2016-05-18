Public Class paidiatriko4
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
            Call enhmervshPaidioy()
            Call enhmervshMatiou()
            Call enhmervshOrthopediki()
            Call enhmervshAllergies()
            Call enhmervshKardies()
            Call enhmervshEndo()
            Call enhmervshWrologiko()
            Call enhmervshNeuriko()
            Call enhmervshOdontoto()
            Call enhmervshLoimo()
            Dim his As String() = hasRowsChildHistoryPerTab()
            pi0.InnerHtml = his(0)
            pi1.InnerHtml = his(1)
            If his(2) <> "" Then pi2.InnerHtml = his(2) : pi4.InnerHtml = his(2)
            If his(3) <> "" Then pi3.InnerHtml = his(3) : pi4.InnerHtml = his(3)
            pi5.InnerHtml = his(4)
            Dim localData As New localDBconnection
            'σε περίπτωση που υπάρχουν εγγραφές στις οφθαλμολογικές εξετάσεις εμφανίζεται ένα αστεράκι δίπλα 
            Dim dt As DataTable = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΟΦΘΑΛΜΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelOfthalm.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για οθφαλμολογικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelOfthalm.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΟΡΘΟΠΑΙΔΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelOrthopaid.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για ορθοπαιδικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelOrthopaid.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΑΛΛΕΡΓΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelAllerg.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για αλλεργιολογικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelAllerg.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΚΑΡΔΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelKard.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για καρδιολογικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelKard.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelEndokr.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για ενδοκρινολογικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelEndokr.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΩΡΛ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelVrl.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για ΩΡΛ εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelVrl.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelPaidneyr.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για παιδονευρολογικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelPaidneyr.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΟΔΟΝΤΟΤΡΙΑΤΙΚΗ ΕΞΕΤΑΣΗ'")
            If dt.Rows.Count > 0 Then TabPanelOdont.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για οδοντοτριατικές εξετάσεις' src='Pictures/ast_sky.gif'/>" & TabPanelOdont.HeaderText
            dt = localData.getData("SELECT TOP 1 [aa] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΤΥΠΟΣ]='ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ'")
            If dt.Rows.Count > 0 Then TabPanelLoim.HeaderText = "<img alt='' title='Στην καρτέλα αυτή έχουν εισαχθεί στοιχεία για λοιμώδη νοσήματα' src='Pictures/ast_sky.gif'/>" & TabPanelLoim.HeaderText
            localData.TerminateLocalDBConnection()
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label1.Visible = True
        If TextBox88.Text <> "" Then
            TextBox88.Text = TextBox88.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox89.Text <> "" Then
            TextBox89.Text = TextBox89.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox90.Text <> "" Then
            TextBox90.Text = TextBox90.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox92.Text <> "" Then
            TextBox92.Text = TextBox92.Text.Replace(".", ",").Replace("'", "").Trim
        End If
        If TextBox93.Text <> "" Then
            TextBox93.Text = TextBox93.Text.Replace(".", "").Replace(",", "").Replace("'", "").Trim
        End If
        If TextBox1.Text <> "" Then
            TextBox1.Text = TextBox1.Text.Replace(".", "").Replace(",", "").Replace("'", "").Trim
        End If
        If Not IsDate(TextBox87.Text) Then
            Label1.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        ' έλεγχοι ηλικίας
        If TextBox88.Text <> "" AndAlso Not IsNumeric(TextBox88.Text) Then
            Label1.Text = "Η ηλικία πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox88.Text.Trim = "" Then
            Label1.Text = "Η ηλικία είναι υποχρεωτική"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If CDbl(TextBox88.Text) <= 1.5 Then
            Label1.Text = "Η ηλικία πρέπει να είναι από 1,5 ετών και πάνω"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If CDbl(TextBox88.Text) >= 18 Then
            Label1.Text = "Η ηλικία πρέπει να είναι μικρότερη των 18 ετών"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        'έλεγχοι βάρους
        If TextBox89.Text <> "" AndAlso Not IsNumeric(TextBox89.Text) Then
            Label1.Text = "Το βάρος πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If CDbl(TextBox89.Text) <= 0 Then
            Label1.Text = "Το βάρος πρέπει να είναι μεγαλύτερο από 0 kg"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If CDbl(TextBox89.Text) >= 200 Then
            Label1.Text = "Το βάρος πρέπει να είναι μικρότερο ή ίσο των 200 kg"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        ' έλεγχοι ύψους
        If TextBox90.Text <> "" AndAlso Not IsNumeric(TextBox90.Text) Then
            Label1.Text = "Το ύψος πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If CDbl(TextBox90.Text) <= 47 Then
            Label1.Text = "Το ύψος πρέπει να είναι μεγαλύτερο του 47 cm"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If CDbl(TextBox90.Text) >= 240 Then
            Label1.Text = "Το ύψος πρέπει να είναι μικρότερο των 240 cm"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        ' έλεγχοι μέσης
        If TextBox92.Text <> "" AndAlso Not IsNumeric(TextBox92.Text) Then
            Label1.Text = "Η περίμετρος κεφαλής πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        ' έλεγχος πίεσης
        If TextBox93.Text <> "" AndAlso Not IsNumeric(TextBox93.Text) Then
            Label1.Text = "Η συστολική πίεση πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox93.Text <> "" AndAlso CDbl(TextBox93.Text) <= 35 Then
            Label1.Text = "Η συστολική πίεση πρέπει να είναι μεγαλύτερη του 35 mmHg"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox93.Text <> "" AndAlso CDbl(TextBox93.Text) >= 250 Then
            Label1.Text = "Η συστολική πίεση πρέπει να είναι μικρότερη του 250 mmHg"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox1.Text <> "" AndAlso Not IsNumeric(TextBox1.Text) Then
            Label1.Text = "Η διαστολική πίεση πρέπει να είναι αριθμός"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox1.Text <> "" AndAlso CDbl(TextBox1.Text) <= 20 Then
            Label1.Text = "Η διαστολική πίεση πρέπει να είναι μεγαλύτερη του 20 mmHg"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox1.Text <> "" AndAlso CDbl(TextBox1.Text) >= 190 Then
            Label1.Text = "Η διαστολική πίεση πρέπει να είναι μικρότερη του 190 mmHg"
            PanelError.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        If TextBox88.Text <> "" Then
            TextBox88.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox88.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        If TextBox89.Text <> "" Then
            TextBox89.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox89.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        If TextBox90.Text <> "" Then
            TextBox90.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox90.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        If TextBox92.Text <> "" Then
            TextBox92.Text = Math.Round(Math.Round(Math.Round(CDbl(TextBox92.Text) * 10, 0) * 2, 0) / 10 / 2, 1)
        End If
        TextBox94.Text = TextBox94.Text.Replace("'", "''").Trim
        TextBox95.Text = TextBox95.Text.Replace("'", "''").Trim
        If Not (TextBox87.Text <> "" AndAlso TextBox88.Text <> "" AndAlso (TextBox89.Text <> "" OrElse TextBox90.Text <> "" OrElse TextBox92.Text <> "")) Then
            Label1.Text = "Πρέπει να εισάγετε υποχρεωτικά κάποια από τις τιμές του βάρους, του ύψους ή της περίμετρου κεφαλής"
            Exit Sub
        End If
        ' βαση δεδομενων
        Dim hm2 As String = conStrs.AccessDateTime(Now)
        ' hm2 ημερομηνία του datestamp
        Dim hm As Date = CDate(TextBox87.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        Call bmi()
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "', " &
                "[ΗΛΙΚΙΑ]=" & If(TextBox88.Text.Replace(",", ".") = "", "NULL", TextBox88.Text.Replace(",", ".")) &
                ", [ΒΑΡΟΣ]=" & If(TextBox89.Text.Replace(",", ".") = "", "NULL", TextBox89.Text.Replace(",", ".")) &
                ", [ΥΨΟΣ]=" & If(TextBox90.Text.Replace(",", ".") = "", "NULL", TextBox90.Text.Replace(",", ".")) &
                ", [BMI]=" & If(TextBox91.Text.Replace(",", ".") = "", "NULL", TextBox91.Text.Replace(",", ".")) &
                ", [ΚΕΦΑΛΗ] = " & If(TextBox92.Text.Replace("'", "") = "", "NULL", TextBox92.Text.Replace(",", ".")) &
                ", [ΣΑΠ] = " & If(TextBox93.Text.Replace(".", "").Replace(",", "") = "", "NULL", TextBox93.Text.Replace(".", "").Replace(",", "")) &
                ", [ΔΑΠ] = " & If(TextBox1.Text.Replace(".", "").Replace(",", "") = "", "NULL", TextBox1.Text.Replace("'", "").Replace(".", "").Replace(",", "")) &
                ", [ΔΟΝΤΙΑ]=" & If(TextBox94.Text = "", "NULL", "'" & TextBox94.Text & "'") &
                ", [ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox95.Text = "", "NULL", "'" & TextBox95.Text & "' ") &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                ", [ΚΛΙΝΙΚΗ]='" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "'" &
                ", [DATE-STAMP]='" & hm2 & "'" &
                ", [UN]='" & currentUser.user.UserName & "'" &
                 " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΓΕΝΙΚΑ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ([PATIENT_CODE], [ΤΥΠΟΣ], " &
                                 "[ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ], [ΥΨΟΣ], [BMI], " &
                                 "[ΚΕΦΑΛΗ], [ΔΟΝΤΙΑ], [ΣΑΠ], [ΔΑΠ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ], [ΚΛΙΝΙΚΗ], [DATE-STAMP], [UN]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΓΕΝΙΚΑ', 0, '" & finalHm & "', " &
                             If(TextBox88.Text.Replace(",", ".") = "", "NULL", TextBox88.Text.Replace(",", ".")) & ", " &
                             If(TextBox89.Text.Replace(",", ".") = "", "NULL", TextBox89.Text.Replace(",", ".")) & ", " &
                             If(TextBox90.Text.Replace(",", ".") = "", "NULL", TextBox90.Text.Replace(",", ".")) & ", " &
                             If(TextBox91.Text.Replace(",", ".") = "", "NULL", TextBox91.Text.Replace(",", ".")) & ", " &
                             If(TextBox92.Text.Replace(",", ".") = "", "NULL", TextBox92.Text.Replace(",", ".")) & ", " &
                             If(TextBox93.Text.Replace(".", "").Replace(",", "") = "", "NULL", TextBox93.Text.Replace(".", "").Replace(",", "")) & ", " &
                             If(TextBox1.Text.Replace(".", "").Replace(",", "") = "", "NULL", TextBox1.Text.Replace(".", "").Replace(",", "")) & ", " &
                             If(TextBox94.Text = "", "NULL", "'" & TextBox94.Text & "'") & ", " &
                             If(TextBox95.Text = "", "NULL", "'" & TextBox95.Text & "'") & ", " &
                             "'" & currentUser.user.UserRealName & "', " &
                             "'" & currentUser.hospital.UserClinicProperties.ClinicName.Replace("'", "''") & "', " &
                             "'" & hm2 & "', " &
                             "'" & currentUser.user.UserName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        currentUser.insertCommentsForWatching(currentUser.user.UserName, "Ενημέρωση Παιδιατρικού Ιστορικού για τον ασθενή με ΑΜ " & Request.QueryString("patientID"), currentUser.user.ip)
        Label1.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        PanelError.Controls.Add(okOk())
        Call enhmervshPaidioy()
    End Sub
    Private Sub enhmervshPaidioy()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("Select [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΗΛΙΚΙΑ], [ΒΑΡΟΣ], [ΥΨΟΣ], [BMI], [ΚΕΦΑΛΗ] As [ΠΕΡ. ΚΕΦΑΛΗΣ], [ΔΟΝΤΙΑ], [ΣΑΠ] As [ΣΥΣΤ. ΠΙΕΣΗ], [ΔΑΠ] As [ΔΙΑΣΤ. ΠΙΕΣΗ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ], [ΚΛΙΝΙΚΗ], [DATE-STAMP] AS [ΗΜ/ΝΙΑ ΚΑΤΑΧΩΡΗΣΗΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΤΥΠΟΣ]='ΓΕΝΙΚΑ' ORDER BY [ΗΛΙΚΙΑ]")
        localData.TerminateLocalDBConnection()
            GridView2.DataSource = dt
        GridView2.DataBind()
        removeTime(GridView2, 0)
    End Sub
    Private Sub bmi()
        TextBox89.Text = TextBox89.Text.Replace(".", ",")
        TextBox90.Text = TextBox90.Text.Replace(".", ",")
        If TextBox89.Text <> "" AndAlso TextBox90.Text <> "" AndAlso IsNumeric(TextBox89.Text) AndAlso IsNumeric(TextBox90.Text) Then
            TextBox91.Text = (Math.Round(TextBox89.Text / ((TextBox90.Text / 100) ^ 2), 1)).ToString.Replace(",", ".")
        End If
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label2.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox96.Text) Then
            Label2.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox96.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΟΦΘΑΛΜΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox97.Text.Replace("'", "''") = "", "NULL", "'" & TextBox97.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΟΦΘΑΛΜΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΟΦΘΑΛΜΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox97.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label2.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshMatiou()
    End Sub
    Private Sub enhmervshMatiou()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΟΦΘΑΛΜΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView3.DataSource = dt
        GridView3.DataBind()
        removeTime(GridView3, 0)
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label3.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox99.Text) Then
            Label3.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox99.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΟΡΘΟΠΑΙΔΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox100.Text.Replace("'", "''") = "", "NULL", "'" & TextBox100.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΟΡΘΟΠΑΙΔΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΟΡΘΟΠΑΙΔΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox100.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label3.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshOrthopediki()
    End Sub
    Private Sub enhmervshOrthopediki()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΟΡΘΟΠΑΙΔΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView4.DataSource = dt
        GridView4.DataBind()
        removeTime(GridView4, 0)
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label4.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox102.Text) Then
            Label4.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox102.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΑΛΛΕΡΓΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox103.Text.Replace("'", "''") = "", "NULL", "'" & TextBox103.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΑΛΛΕΡΓΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΑΛΛΕΡΓΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox103.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label4.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshAllergies()
    End Sub
    Private Sub enhmervshAllergies()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΑΛΛΕΡΓΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView5.DataSource = dt
        GridView5.DataBind()
        removeTime(GridView5, 0)
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label5.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox105.Text) Then
            Label5.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox105.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΚΑΡΔΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox106.Text.Replace("'", "''") = "", "NULL", "'" & TextBox106.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΚΑΡΔΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΚΑΡΔΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox106.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label5.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshKardies()
    End Sub
    Private Sub enhmervshKardies()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΚΑΡΔΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView6.DataSource = dt
        GridView6.DataBind()
        removeTime(GridView6, 0)
    End Sub
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label6.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox108.Text) Then
            Label6.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox108.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox109.Text.Replace("'", "''") = "", "NULL", "'" & TextBox109.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox109.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label6.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshEndo()
    End Sub
    Private Sub enhmervshEndo()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView7.DataSource = dt
        GridView7.DataBind()
        removeTime(GridView7, 0)
    End Sub
    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label7.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox111.Text) Then
            Label7.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox111.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΩΡΛ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox112.Text.Replace("'", "''") = "", "NULL", "'" & TextBox112.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΩΡΛ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΩΡΛ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox112.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label7.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshWrologiko()
    End Sub
    Private Sub enhmervshWrologiko()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΩΡΛ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView8.DataSource = dt
        GridView8.DataBind()
        removeTime(GridView8, 0)
    End Sub
    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label8.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox114.Text) Then
            Label8.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox114.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox115.Text.Replace("'", "''") = "", "NULL", "'" & TextBox115.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox115.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label8.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        PanelError.Controls.Add(okOk())
        Call enhmervshNeuriko()
    End Sub
    Private Sub enhmervshNeuriko()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView9.DataSource = dt
        GridView9.DataBind()
        removeTime(GridView9, 0)
    End Sub
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label9.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox117.Text) Then
            Label9.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox117.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΟΔΟΝΤΟΤΡΙΑΤΙΚΗ ΕΞΕΤΑΣΗ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox118.Text.Replace("'", "''") = "", "NULL", "'" & TextBox118.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΟΔΟΝΤΟΤΡΙΑΤΙΚΗ ΕΞΕΤΑΣΗ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΟΔΟΝΤΟΤΡΙΑΤΙΚΗ ΕΞΕΤΑΣΗ', 0, '" & finalHm & "', '" & TextBox118.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label9.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshOdontoto()
    End Sub
    Private Sub enhmervshOdontoto()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΟΔΟΝΤΟΤΡΙΑΤΙΚΗ ΕΞΕΤΑΣΗ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView10.DataSource = dt
        GridView10.DataBind()
        removeTime(GridView10, 0)
    End Sub
    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim localData As New localDBconnection
        Dim dt As DataTable
        Label10.Visible = True
        ' ελεγχοι
        If Not IsDate(TextBox121.Text) Then
            Label10.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            Exit Sub
        End If
        Dim hm As Date = CDate(TextBox121.Text)
        Dim finalHm As String = hm.Year & "-" & hm.Month & "-" & hm.Day
        dt = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ'")
        If dt.Rows.Count > 0 Then
            localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] SET  " &
                "[ΠΑΡΑΤΗΡΗΣΕΙΣ] = " & If(TextBox120.Text.Replace("'", "''") = "", "NULL", "'" & TextBox120.Text.Replace("'", "''")) & "' " &
                ", [ΙΑΤΡΟΣ]='" & currentUser.user.UserRealName & "' " &
                " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0 AND [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]='" & finalHm & "' AND ΤΥΠΟΣ='ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ'")
        Else
            localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] ( [PATIENT_CODE], [ΤΥΠΟΣ], [ΒΡΕΦΟΣ], [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ]) VALUES (" &
                             "'" & Request.QueryString("patientID") & "', 'ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ', 0, '" & finalHm & "', '" & TextBox120.Text.Replace("'", "''") & "', '" &
                              currentUser.user.UserRealName & "') ")
        End If
        localData.TerminateLocalDBConnection()
        Label10.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        'PanelError.Controls.Add(okOk())
        Call enhmervshLoimo()
    End Sub
    Private Sub enhmervshLoimo()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ], [ΠΑΡΑΤΗΡΗΣΕΙΣ], [ΙΑΤΡΟΣ] FROM [ΠΑΙΔΙΑΤΡΙΚΑ ΣΤΟΙΧΕΙΑ ΑΝΑΠΤΥΞΗΣ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΒΡΕΦΟΣ]=0  AND ΤΥΠΟΣ='ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ' ORDER BY [ΗΜΕΡΟΜΗΝΙΑ ΕΞΕΤΑΣΗΣ]")
        localData.TerminateLocalDBConnection()
        GridView11.DataSource = dt
        GridView11.DataBind()
        removeTime(GridView11, 0)
    End Sub
End Class