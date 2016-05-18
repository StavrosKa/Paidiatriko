Public Class paidiatriko6
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
            Call viewEmvolia()
            Call viewPinakasA()
            Call viewPinakasB()
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
        'έλεγχοι σωστής ημερομηνίας
        If ((TextBox123.Text <> "" AndAlso Not IsDate(TextBox123.Text)) _
            OrElse (TextBox124.Text <> "" AndAlso Not IsDate(TextBox124.Text)) _
            OrElse (TextBox126.Text <> "" AndAlso Not IsDate(TextBox126.Text)) _
            OrElse (TextBox128.Text <> "" AndAlso Not IsDate(TextBox128.Text)) _
            OrElse (TextBox130.Text <> "" AndAlso Not IsDate(TextBox130.Text)) _
            OrElse (TextBox132.Text <> "" AndAlso Not IsDate(TextBox132.Text)) _
            OrElse (TextBox133.Text <> "" AndAlso Not IsDate(TextBox133.Text)) _
            OrElse (TextBox134.Text <> "" AndAlso Not IsDate(TextBox134.Text)) _
            OrElse (TextBox135.Text <> "" AndAlso Not IsDate(TextBox135.Text)) _
            OrElse (TextBox136.Text <> "" AndAlso Not IsDate(TextBox136.Text)) _
            OrElse (TextBox137.Text <> "" AndAlso Not IsDate(TextBox137.Text)) _
            OrElse (TextBox139.Text <> "" AndAlso Not IsDate(TextBox139.Text)) _
            OrElse (TextBox140.Text <> "" AndAlso Not IsDate(TextBox140.Text)) _
            OrElse (TextBox141.Text <> "" AndAlso Not IsDate(TextBox141.Text)) _
            OrElse (TextBox142.Text <> "" AndAlso Not IsDate(TextBox142.Text)) _
            OrElse (TextBox143.Text <> "" AndAlso Not IsDate(TextBox143.Text)) _
            OrElse (TextBox144.Text <> "" AndAlso Not IsDate(TextBox144.Text)) _
            OrElse (TextBox146.Text <> "" AndAlso Not IsDate(TextBox146.Text)) _
            OrElse (TextBox147.Text <> "" AndAlso Not IsDate(TextBox147.Text)) _
            OrElse (TextBox148.Text <> "" AndAlso Not IsDate(TextBox148.Text)) _
            OrElse (TextBox149.Text <> "" AndAlso Not IsDate(TextBox149.Text)) _
            OrElse (TextBox150.Text <> "" AndAlso Not IsDate(TextBox150.Text)) _
            OrElse (TextBox161.Text <> "" AndAlso Not IsDate(TextBox161.Text)) _
            OrElse (TextBox163.Text <> "" AndAlso Not IsDate(TextBox163.Text)) _
            OrElse (TextBox164.Text <> "" AndAlso Not IsDate(TextBox164.Text)) _
            OrElse (TextBox165.Text <> "" AndAlso Not IsDate(TextBox165.Text)) _
            OrElse (TextBox166.Text <> "" AndAlso Not IsDate(TextBox166.Text)) _
            OrElse (TextBox167.Text <> "" AndAlso Not IsDate(TextBox167.Text)) _
            OrElse (TextBox168.Text <> "" AndAlso Not IsDate(TextBox168.Text)) _
            OrElse (TextBox170.Text <> "" AndAlso Not IsDate(TextBox170.Text)) _
            OrElse (TextBox171.Text <> "" AndAlso Not IsDate(TextBox171.Text)) _
            OrElse (TextBox172.Text <> "" AndAlso Not IsDate(TextBox172.Text)) _
            OrElse (TextBox173.Text <> "" AndAlso Not IsDate(TextBox173.Text)) _
            OrElse (TextBox174.Text <> "" AndAlso Not IsDate(TextBox174.Text)) _
            OrElse (TextBox175.Text <> "" AndAlso Not IsDate(TextBox175.Text)) _
            OrElse (TextBox185.Text <> "" AndAlso Not IsDate(TextBox185.Text)) _
            OrElse (TextBox186.Text <> "" AndAlso Not IsDate(TextBox186.Text)) _
            OrElse (TextBox187.Text <> "" AndAlso Not IsDate(TextBox187.Text)) _
            OrElse (TextBox188.Text <> "" AndAlso Not IsDate(TextBox188.Text)) _
            OrElse (TextBox189.Text <> "" AndAlso Not IsDate(TextBox189.Text)) _
            OrElse (TextBox190.Text <> "" AndAlso Not IsDate(TextBox190.Text)) _
            OrElse (TextBox192.Text <> "" AndAlso Not IsDate(TextBox192.Text)) _
            OrElse (TextBox193.Text <> "" AndAlso Not IsDate(TextBox193.Text)) _
            OrElse (TextBox194.Text <> "" AndAlso Not IsDate(TextBox194.Text)) _
            OrElse (TextBox195.Text <> "" AndAlso Not IsDate(TextBox195.Text)) _
            OrElse (TextBox196.Text <> "" AndAlso Not IsDate(TextBox196.Text)) _
            OrElse (TextBox197.Text <> "" AndAlso Not IsDate(TextBox197.Text)) _
            OrElse (TextBox199.Text <> "" AndAlso Not IsDate(TextBox199.Text)) _
            OrElse (TextBox200.Text <> "" AndAlso Not IsDate(TextBox200.Text)) _
            OrElse (TextBox201.Text <> "" AndAlso Not IsDate(TextBox201.Text)) _
            OrElse (TextBox202.Text <> "" AndAlso Not IsDate(TextBox202.Text)) _
            OrElse (TextBox203.Text <> "" AndAlso Not IsDate(TextBox203.Text)) _
            OrElse (TextBox204.Text <> "" AndAlso Not IsDate(TextBox204.Text)) _
            OrElse (TextBox206.Text <> "" AndAlso Not IsDate(TextBox206.Text)) _
            OrElse (TextBox207.Text <> "" AndAlso Not IsDate(TextBox207.Text)) _
            OrElse (TextBox208.Text <> "" AndAlso Not IsDate(TextBox208.Text)) _
            OrElse (TextBox209.Text <> "" AndAlso Not IsDate(TextBox209.Text)) _
            OrElse (TextBox210.Text <> "" AndAlso Not IsDate(TextBox210.Text)) _
            OrElse (TextBox211.Text <> "" AndAlso Not IsDate(TextBox211.Text)) _
            OrElse (TextBox213.Text <> "" AndAlso Not IsDate(TextBox213.Text)) _
            OrElse (TextBox214.Text <> "" AndAlso Not IsDate(TextBox214.Text)) _
            OrElse (TextBox215.Text <> "" AndAlso Not IsDate(TextBox215.Text)) _
            OrElse (TextBox216.Text <> "" AndAlso Not IsDate(TextBox216.Text)) _
            OrElse (TextBox217.Text <> "" AndAlso Not IsDate(TextBox217.Text)) _
            OrElse (TextBox218.Text <> "" AndAlso Not IsDate(TextBox218.Text)) _
            OrElse (TextBox220.Text <> "" AndAlso Not IsDate(TextBox220.Text)) _
            OrElse (TextBox221.Text <> "" AndAlso Not IsDate(TextBox221.Text)) _
            OrElse (TextBox222.Text <> "" AndAlso Not IsDate(TextBox222.Text)) _
            OrElse (TextBox223.Text <> "" AndAlso Not IsDate(TextBox223.Text)) _
            OrElse (TextBox224.Text <> "" AndAlso Not IsDate(TextBox224.Text)) _
            OrElse (TextBox225.Text <> "" AndAlso Not IsDate(TextBox225.Text)) _
            OrElse (TextBox227.Text <> "" AndAlso Not IsDate(TextBox227.Text)) _
            OrElse (TextBox228.Text <> "" AndAlso Not IsDate(TextBox228.Text)) _
            OrElse (TextBox229.Text <> "" AndAlso Not IsDate(TextBox229.Text)) _
            OrElse (TextBox230.Text <> "" AndAlso Not IsDate(TextBox230.Text)) _
            OrElse (TextBox231.Text <> "" AndAlso Not IsDate(TextBox231.Text)) _
            OrElse (TextBox232.Text <> "" AndAlso Not IsDate(TextBox232.Text)) _
            OrElse (TextBox234.Text <> "" AndAlso Not IsDate(TextBox234.Text)) _
            OrElse (TextBox235.Text <> "" AndAlso Not IsDate(TextBox235.Text)) _
            OrElse (TextBox236.Text <> "" AndAlso Not IsDate(TextBox236.Text)) _
            OrElse (TextBox237.Text <> "" AndAlso Not IsDate(TextBox237.Text)) _
            OrElse (TextBox238.Text <> "" AndAlso Not IsDate(TextBox238.Text)) _
            OrElse (TextBox239.Text <> "" AndAlso Not IsDate(TextBox239.Text))) Then
            Label1.Visible = True
            Label1.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            PanelError1.Controls.Add(notOK(Label1.Text))
            Exit Sub
        End If
        Dim localData As New localDBconnection
        Label1.Visible = True
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "1η δόση", TextBox123.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "2η δόση", TextBox124.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "3η δόση", TextBox125.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "4η δόση", TextBox126.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "5η δόση", TextBox128.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "6η δόση", TextBox130.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Β", "Παρατηρήσεις", TextBox131.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "1η δόση", TextBox132.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "2η δόση", TextBox133.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "3η δόση", TextBox134.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "4η δόση", TextBox135.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "5η δόση", TextBox136.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "6η δόση", TextBox137.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Διφθερίτιδας Τετάνου Κοκκύτη", "Παρατηρήσεις", TextBox138.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "1η δόση", TextBox139.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "2η δόση", TextBox140.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "3η δόση", TextBox141.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "4η δόση", TextBox142.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "5η δόση", TextBox143.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "6η δόση", TextBox144.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πολυομυελίτιδας", "Παρατηρήσεις", TextBox145.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "1η δόση", TextBox146.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "2η δόση", TextBox147.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "3η δόση", TextBox148.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "4η δόση", TextBox149.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "5η δόση", TextBox150.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "6η δόση", TextBox161.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Αιμοφίλου ινφλουέντζας Β", "Παρατηρήσεις", TextBox162.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "1η δόση", TextBox163.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "2η δόση", TextBox164.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "3η δόση", TextBox165.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "4η δόση", TextBox166.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "5η δόση", TextBox167.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "6η δόση", TextBox168.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Μηνιγγιτιδόκοκκου", "Παρατηρήσεις", TextBox169.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "1η δόση", TextBox170.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "2η δόση", TextBox171.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "3η δόση", TextBox172.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "4η δόση", TextBox173.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "5η δόση", TextBox174.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "6η δόση", TextBox175.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Πνευμονιόκοκκου", "Παρατηρήσεις", TextBox176.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "1η δόση", TextBox185.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "2η δόση", TextBox186.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "3η δόση", TextBox187.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "4η δόση", TextBox188.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "5η δόση", TextBox189.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "6η δόση", TextBox190.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ιλαράς Ερυθράς Παρωτίτιδας", "Παρατηρήσεις", TextBox191.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "1η δόση", TextBox192.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "2η δόση", TextBox193.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "3η δόση", TextBox194.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "4η δόση", TextBox195.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "5η δόση", TextBox196.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "6η δόση", TextBox197.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ανεμοευλογιάς", "Παρατηρήσεις", TextBox198.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "1η δόση", TextBox199.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "2η δόση", TextBox200.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "3η δόση", TextBox201.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "4η δόση", TextBox202.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "5η δόση", TextBox203.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "6η δόση", TextBox204.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "HPV", "Παρατηρήσεις", TextBox205.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "1η δόση", TextBox206.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "2η δόση", TextBox207.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "3η δόση", TextBox208.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "4η δόση", TextBox209.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "5η δόση", TextBox210.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "6η δόση", TextBox211.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Ηπατίτιδας Α", "Παρατηρήσεις", TextBox212.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "1η δόση", TextBox213.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "2η δόση", TextBox214.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "3η δόση", TextBox215.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "4η δόση", TextBox216.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "5η δόση", TextBox217.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "6η δόση", TextBox218.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Mantoux", "Παρατηρήσεις", TextBox219.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "1η δόση", TextBox220.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "2η δόση", TextBox221.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "3η δόση", TextBox222.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "4η δόση", TextBox223.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "5η δόση", TextBox224.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "6η δόση", TextBox225.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Φυματίωσης BCG", "Παρατηρήσεις", TextBox226.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "1η δόση", TextBox227.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "2η δόση", TextBox228.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "3η δόση", TextBox229.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "4η δόση", TextBox230.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "5η δόση", TextBox231.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "6η δόση", TextBox232.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Γρίπης INFL", "Παρατηρήσεις", TextBox233.Text.Replace("'", "").Replace("""", ""), localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "1η δόση", TextBox234.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "2η δόση", TextBox235.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "3η δόση", TextBox236.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "4η δόση", TextBox237.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "5η δόση", TextBox238.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "6η δόση", TextBox239.Text, localData)
        Call insertOrUpdate("ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ", "Άλλα: " & TextBox1.Text, "Παρατηρήσεις", TextBox240.Text.Replace("'", "").Replace("""", ""), localData)
        localData.TerminateLocalDBConnection()
        currentUser.insertCommentsForWatching(currentUser.user.UserName, "Ενημέρωση Ιστορικού εμβολίων για τον ασθενή με ΑΜ " & Request.QueryString("patientID"), currentUser.user.ip)
        Label1.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        PanelError1.Controls.Add(okOk())
    End Sub
    Private Sub insertOrUpdate(xar1 As String, xar2 As String, xar3 As String, value As String, localData As localDBconnection)
        Dim dt As DataTable = localData.getData("SELECT ΤΙΜΗ FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='" & xar1 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2]='" & xar2 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3]='" & xar3 & "'")
        If dt.Rows.Count > 0 Then
            'αν υπάρχει το πεδιο στη βαση και διαγραφεί το πεδίο γινεται διαγραφη
            If value = "" Then
                localData.updateData("DELETE FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='" & xar1 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2]='" & xar2 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3]='" & xar3 & "'")
            Else
                'ενημέρωση
                localData.updateData("UPDATE [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] SET [ΤΙΜΗ]='" & value & "'" &
                                 " WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1]='" & xar1 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2]='" & xar2 & "' AND [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3]='" & xar3 & "'")
            End If
        Else
            'εισαγωγή στοιχείων
            If value <> "" Then
                localData.updateData("INSERT INTO [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] ( [PATIENT_CODE], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ) VALUES (" &
                                 "'" & Request.QueryString("patientID") & "', '" & xar1 & "','" & xar2 & "', '" & xar3 & "', '" & value & "')")
            End If
        End If
    End Sub
    Private Sub viewEmvolia()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "'")
        For f As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox123.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox124.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox125.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox126.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox128.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox130.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox131.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox132.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox133.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox134.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox135.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox136.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox137.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Διφθερίτιδας Τετάνου Κοκκύτη" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox138.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox139.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox140.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox141.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox142.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox143.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox144.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox145.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox146.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox147.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox148.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox149.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox150.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox161.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Αιμοφίλου ινφλουέντζας Β" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox162.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox163.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox164.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox165.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox166.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox167.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox168.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox169.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox170.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox171.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox172.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox173.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox174.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox175.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Πνευμονιόκοκκου" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox176.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox185.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox186.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox187.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox188.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox189.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox190.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ιλαράς Ερυθράς Παρωτίτιδας" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox191.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox192.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox193.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox194.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox195.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox196.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox197.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox198.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox199.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox200.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox201.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox202.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox203.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox204.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox205.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox206.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox207.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox208.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox209.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox210.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox211.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox212.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox213.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox214.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox215.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox216.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox217.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox218.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox219.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox220.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox221.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox222.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox223.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox224.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox225.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Φυματίωσης BCG" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox226.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox227.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox228.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox229.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox230.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox231.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "6η δόση" Then TextBox232.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox233.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "1η δόση" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox234.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "2η δόση" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox235.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "3η δόση" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox236.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "4η δόση" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox237.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "5η δόση" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox238.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "6η δόση" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox239.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ" And dt.Rows(f).Item(1).ToString.StartsWith("Άλλα: ") And dt.Rows(f).Item(2) = "Παρατηρήσεις" Then TextBox1.Text = dt.Rows(f).Item(1).ToString.Replace("Άλλα: ", "") : TextBox240.Text = dt.Rows(f).Item(3) : GoTo nextValue
nextValue:
        Next
        localData.TerminateLocalDBConnection()
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'ανοίγω τη σύνδεση της βάσης και καλώ τη ρουτίνα insertOrUpdate
        'έλεγχοι σωστής ημερομηνίας
        If ((TextBox241.Text <> "" AndAlso Not IsDate(TextBox241.Text)) _
            OrElse (TextBox242.Text <> "" AndAlso Not IsDate(TextBox242.Text)) _
            OrElse (TextBox243.Text <> "" AndAlso Not IsDate(TextBox243.Text)) _
            OrElse (TextBox244.Text <> "" AndAlso Not IsDate(TextBox244.Text)) _
            OrElse (TextBox245.Text <> "" AndAlso Not IsDate(TextBox245.Text)) _
            OrElse (TextBox246.Text <> "" AndAlso Not IsDate(TextBox246.Text)) _
            OrElse (TextBox247.Text <> "" AndAlso Not IsDate(TextBox247.Text)) _
            OrElse (TextBox248.Text <> "" AndAlso Not IsDate(TextBox248.Text)) _
            OrElse (TextBox249.Text <> "" AndAlso Not IsDate(TextBox249.Text)) _
            OrElse (TextBox250.Text <> "" AndAlso Not IsDate(TextBox250.Text)) _
            OrElse (TextBox251.Text <> "" AndAlso Not IsDate(TextBox251.Text)) _
            OrElse (TextBox252.Text <> "" AndAlso Not IsDate(TextBox252.Text)) _
            OrElse (TextBox253.Text <> "" AndAlso Not IsDate(TextBox253.Text)) _
            OrElse (TextBox254.Text <> "" AndAlso Not IsDate(TextBox254.Text)) _
            OrElse (TextBox255.Text <> "" AndAlso Not IsDate(TextBox255.Text)) _
            OrElse (TextBox256.Text <> "" AndAlso Not IsDate(TextBox256.Text)) _
            OrElse (TextBox257.Text <> "" AndAlso Not IsDate(TextBox257.Text)) _
            OrElse (TextBox258.Text <> "" AndAlso Not IsDate(TextBox258.Text)) _
            OrElse (TextBox259.Text <> "" AndAlso Not IsDate(TextBox259.Text)) _
            OrElse (TextBox260.Text <> "" AndAlso Not IsDate(TextBox260.Text)) _
            OrElse (TextBox261.Text <> "" AndAlso Not IsDate(TextBox261.Text)) _
            OrElse (TextBox262.Text <> "" AndAlso Not IsDate(TextBox262.Text)) _
            OrElse (TextBox263.Text <> "" AndAlso Not IsDate(TextBox263.Text)) _
            OrElse (TextBox264.Text <> "" AndAlso Not IsDate(TextBox264.Text)) _
            OrElse (TextBox265.Text <> "" AndAlso Not IsDate(TextBox265.Text)) _
            OrElse (TextBox266.Text <> "" AndAlso Not IsDate(TextBox266.Text)) _
            OrElse (TextBox267.Text <> "" AndAlso Not IsDate(TextBox267.Text)) _
            OrElse (TextBox268.Text <> "" AndAlso Not IsDate(TextBox268.Text)) _
            OrElse (TextBox269.Text <> "" AndAlso Not IsDate(TextBox269.Text)) _
            OrElse (TextBox270.Text <> "" AndAlso Not IsDate(TextBox270.Text)) _
            OrElse (TextBox271.Text <> "" AndAlso Not IsDate(TextBox271.Text)) _
            OrElse (TextBox272.Text <> "" AndAlso Not IsDate(TextBox272.Text)) _
            OrElse (TextBox273.Text <> "" AndAlso Not IsDate(TextBox273.Text)) _
            OrElse (TextBox274.Text <> "" AndAlso Not IsDate(TextBox274.Text)) _
            OrElse (TextBox275.Text <> "" AndAlso Not IsDate(TextBox275.Text)) _
            OrElse (TextBox276.Text <> "" AndAlso Not IsDate(TextBox276.Text)) _
            OrElse (TextBox277.Text <> "" AndAlso Not IsDate(TextBox277.Text)) _
            OrElse (TextBox278.Text <> "" AndAlso Not IsDate(TextBox278.Text)) _
            OrElse (TextBox279.Text <> "" AndAlso Not IsDate(TextBox279.Text)) _
            OrElse (TextBox280.Text <> "" AndAlso Not IsDate(TextBox280.Text)) _
            OrElse (TextBox281.Text <> "" AndAlso Not IsDate(TextBox281.Text)) _
            OrElse (TextBox282.Text <> "" AndAlso Not IsDate(TextBox282.Text)) _
            OrElse (TextBox283.Text <> "" AndAlso Not IsDate(TextBox283.Text)) _
            OrElse (TextBox284.Text <> "" AndAlso Not IsDate(TextBox284.Text)) _
            OrElse (TextBox285.Text <> "" AndAlso Not IsDate(TextBox285.Text)) _
            OrElse (TextBox286.Text <> "" AndAlso Not IsDate(TextBox286.Text)) _
            OrElse (TextBox287.Text <> "" AndAlso Not IsDate(TextBox287.Text)) _
            OrElse (TextBox288.Text <> "" AndAlso Not IsDate(TextBox288.Text)) _
            OrElse (TextBox289.Text <> "" AndAlso Not IsDate(TextBox289.Text)) _
            OrElse (TextBox290.Text <> "" AndAlso Not IsDate(TextBox290.Text)) _
            OrElse (TextBox291.Text <> "" AndAlso Not IsDate(TextBox291.Text)) _
            OrElse (TextBox292.Text <> "" AndAlso Not IsDate(TextBox292.Text)) _
            OrElse (TextBox293.Text <> "" AndAlso Not IsDate(TextBox293.Text)) _
            OrElse (TextBox294.Text <> "" AndAlso Not IsDate(TextBox294.Text)) _
            OrElse (TextBox295.Text <> "" AndAlso Not IsDate(TextBox295.Text)) _
            OrElse (TextBox296.Text <> "" AndAlso Not IsDate(TextBox296.Text)) _
            OrElse (TextBox297.Text <> "" AndAlso Not IsDate(TextBox297.Text)) _
            OrElse (TextBox298.Text <> "" AndAlso Not IsDate(TextBox298.Text)) _
            OrElse (TextBox299.Text <> "" AndAlso Not IsDate(TextBox299.Text)) _
            OrElse (TextBox300.Text <> "" AndAlso Not IsDate(TextBox300.Text))) Then
            Label2.Visible = True
            Label2.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            PanelError2.Controls.Add(notOK(Label2.Text))
            Exit Sub
        End If
        Dim localData As New localDBconnection
        Label2.Visible = True
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Β", "1η δόση", TextBox241.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Β", "2η δόση", TextBox242.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Β", "3η δόση", TextBox243.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Β", "4η δόση", TextBox244.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Β", "5η δόση", TextBox245.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "DTaP", "1η δόση", TextBox246.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "DTaP", "2η δόση", TextBox247.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "DTaP", "3η δόση", TextBox248.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "DTaP", "4η δόση", TextBox249.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "DTaP", "5η δόση", TextBox250.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Πολυομυελίτιδας IPV", "1η δόση", TextBox251.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Πολυομυελίτιδας IPV", "2η δόση", TextBox252.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Πολυομυελίτιδας IPV", "3η δόση", TextBox253.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Πολυομυελίτιδας IPV", "4η δόση", TextBox254.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Πολυομυελίτιδας IPV", "5η δόση", TextBox255.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Αιμοφίλου τύπου Β", "1η δόση", TextBox256.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Αιμοφίλου τύπου Β", "2η δόση", TextBox257.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Αιμοφίλου τύπου Β", "3η δόση", TextBox258.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Αιμοφίλου τύπου Β", "4η δόση", TextBox259.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Αιμοφίλου τύπου Β", "5η δόση", TextBox260.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Μηνιγγιτιδόκοκκου C", "1η δόση", TextBox261.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Μηνιγγιτιδόκοκκου C", "2η δόση", TextBox262.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Μηνιγγιτιδόκοκκου C", "3η δόση", TextBox263.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Μηνιγγιτιδόκοκκου C", "4η δόση", TextBox264.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Μηνιγγιτιδόκοκκου C", "5η δόση", TextBox265.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "PCV", "1η δόση", TextBox266.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "PCV", "2η δόση", TextBox267.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "PCV", "3η δόση", TextBox268.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "PCV", "4η δόση", TextBox269.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "PCV", "5η δόση", TextBox270.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "MMR", "1η δόση", TextBox271.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "MMR", "2η δόση", TextBox272.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "MMR", "3η δόση", TextBox273.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "MMR", "4η δόση", TextBox274.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "MMR", "5η δόση", TextBox275.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ανεμοευλογιάς", "1η δόση", TextBox276.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ανεμοευλογιάς", "2η δόση", TextBox277.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ανεμοευλογιάς", "3η δόση", TextBox278.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ανεμοευλογιάς", "4η δόση", TextBox279.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ανεμοευλογιάς", "5η δόση", TextBox280.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Α", "1η δόση", TextBox281.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Α", "2η δόση", TextBox282.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Α", "3η δόση", TextBox283.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Α", "4η δόση", TextBox284.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Ηπατίτιδας Α", "5η δόση", TextBox285.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Φυματίωσης", "1η δόση", TextBox286.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Φυματίωσης", "2η δόση", TextBox287.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Φυματίωσης", "3η δόση", TextBox288.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Φυματίωσης", "4η δόση", TextBox289.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Φυματίωσης", "5η δόση", TextBox290.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Mantoux", "1η δόση", TextBox291.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Mantoux", "2η δόση", TextBox292.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Mantoux", "3η δόση", TextBox293.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Mantoux", "4η δόση", TextBox294.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Mantoux", "5η δόση", TextBox295.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Γρίπης INFL", "1η δόση", TextBox296.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Γρίπης INFL", "2η δόση", TextBox297.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Γρίπης INFL", "3η δόση", TextBox298.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Γρίπης INFL", "4η δόση", TextBox299.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ Α", "Γρίπης INFL", "5η δόση", TextBox300.Text, localData)
        localData.TerminateLocalDBConnection()
        Label2.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        PanelError2.Controls.Add(okOk())
    End Sub
    Private Sub viewPinakasA()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "'")
        For f As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox241.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox242.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox243.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox244.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox245.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "DTaP" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox246.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "DTaP" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox247.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "DTaP" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox248.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "DTaP" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox249.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "DTaP" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox250.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας IPV" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox251.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας IPV" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox252.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας IPV" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox253.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας IPV" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox254.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Πολυομυελίτιδας IPV" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox255.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Αιμοφίλου τύπου Β" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox256.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Αιμοφίλου τύπου Β" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox257.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Αιμοφίλου τύπου Β" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox258.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Αιμοφίλου τύπου Β" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox259.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Αιμοφίλου τύπου Β" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox260.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox261.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox262.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox263.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox264.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox265.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "PCV" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox266.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "PCV" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox267.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "PCV" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox268.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "PCV" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox269.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "PCV" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox270.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "MMR" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox271.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "MMR" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox272.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "MMR" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox273.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "MMR" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox274.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "MMR" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox275.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox276.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox277.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox278.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox279.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox280.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox281.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox282.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox283.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox284.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox285.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Φυματίωσης" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox286.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Φυματίωσης" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox287.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Φυματίωσης" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox288.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Φυματίωσης" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox289.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Φυματίωσης" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox290.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox291.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox292.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox293.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox294.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Mantoux" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox295.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox296.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox297.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox298.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox299.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ Α" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "5η δόση" Then TextBox300.Text = dt.Rows(f).Item(3) : GoTo nextValue
nextValue:
        Next
        localData.TerminateLocalDBConnection()
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'ανοίγω τη σύνδεση της βάσης και καλώ τη ρουτίνα insertOrUpdate
        'έλεγχοι σωστής ημερομηνίας
        If ((TextBox301.Text <> "" AndAlso Not IsDate(TextBox301.Text)) _
            OrElse (TextBox302.Text <> "" AndAlso Not IsDate(TextBox302.Text)) _
            OrElse (TextBox303.Text <> "" AndAlso Not IsDate(TextBox303.Text)) _
            OrElse (TextBox304.Text <> "" AndAlso Not IsDate(TextBox304.Text)) _
            OrElse (TextBox305.Text <> "" AndAlso Not IsDate(TextBox305.Text)) _
            OrElse (TextBox306.Text <> "" AndAlso Not IsDate(TextBox306.Text)) _
            OrElse (TextBox307.Text <> "" AndAlso Not IsDate(TextBox307.Text)) _
            OrElse (TextBox308.Text <> "" AndAlso Not IsDate(TextBox308.Text)) _
            OrElse (TextBox309.Text <> "" AndAlso Not IsDate(TextBox309.Text)) _
            OrElse (TextBox310.Text <> "" AndAlso Not IsDate(TextBox310.Text)) _
            OrElse (TextBox311.Text <> "" AndAlso Not IsDate(TextBox311.Text)) _
            OrElse (TextBox312.Text <> "" AndAlso Not IsDate(TextBox312.Text)) _
            OrElse (TextBox313.Text <> "" AndAlso Not IsDate(TextBox313.Text)) _
            OrElse (TextBox314.Text <> "" AndAlso Not IsDate(TextBox314.Text)) _
            OrElse (TextBox315.Text <> "" AndAlso Not IsDate(TextBox315.Text)) _
            OrElse (TextBox316.Text <> "" AndAlso Not IsDate(TextBox316.Text)) _
            OrElse (TextBox317.Text <> "" AndAlso Not IsDate(TextBox317.Text)) _
            OrElse (TextBox318.Text <> "" AndAlso Not IsDate(TextBox318.Text)) _
            OrElse (TextBox319.Text <> "" AndAlso Not IsDate(TextBox319.Text)) _
            OrElse (TextBox320.Text <> "" AndAlso Not IsDate(TextBox320.Text)) _
            OrElse (TextBox321.Text <> "" AndAlso Not IsDate(TextBox321.Text)) _
            OrElse (TextBox322.Text <> "" AndAlso Not IsDate(TextBox322.Text)) _
            OrElse (TextBox323.Text <> "" AndAlso Not IsDate(TextBox323.Text)) _
            OrElse (TextBox324.Text <> "" AndAlso Not IsDate(TextBox324.Text)) _
            OrElse (TextBox325.Text <> "" AndAlso Not IsDate(TextBox325.Text)) _
            OrElse (TextBox326.Text <> "" AndAlso Not IsDate(TextBox326.Text)) _
            OrElse (TextBox327.Text <> "" AndAlso Not IsDate(TextBox327.Text)) _
            OrElse (TextBox328.Text <> "" AndAlso Not IsDate(TextBox328.Text)) _
            OrElse (TextBox329.Text <> "" AndAlso Not IsDate(TextBox329.Text)) _
            OrElse (TextBox330.Text <> "" AndAlso Not IsDate(TextBox330.Text)) _
            OrElse (TextBox331.Text <> "" AndAlso Not IsDate(TextBox331.Text)) _
            OrElse (TextBox332.Text <> "" AndAlso Not IsDate(TextBox332.Text)) _
            OrElse (TextBox333.Text <> "" AndAlso Not IsDate(TextBox333.Text)) _
            OrElse (TextBox334.Text <> "" AndAlso Not IsDate(TextBox334.Text)) _
            OrElse (TextBox335.Text <> "" AndAlso Not IsDate(TextBox335.Text)) _
            OrElse (TextBox336.Text <> "" AndAlso Not IsDate(TextBox336.Text)) _
            OrElse (TextBox337.Text <> "" AndAlso Not IsDate(TextBox337.Text)) _
            OrElse (TextBox338.Text <> "" AndAlso Not IsDate(TextBox338.Text)) _
            OrElse (TextBox339.Text <> "" AndAlso Not IsDate(TextBox339.Text)) _
            OrElse (TextBox340.Text <> "" AndAlso Not IsDate(TextBox340.Text))) Then
            Label3.Visible = True
            Label3.Text = "Πρέπει να εισάγετε σωστή ημερομηνία!!"
            PanelError3.Controls.Add(notOK(Label3.Text))
            Exit Sub
        End If
        Dim localData As New localDBconnection
        Label3.Visible = True
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Β", "1η δόση", TextBox301.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Β", "2η δόση", TextBox302.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Β", "3η δόση", TextBox303.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Β", "4η δόση", TextBox304.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Διφθερίτιδας-Τετάνου", "1η δόση", TextBox305.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Διφθερίτιδας-Τετάνου", "2η δόση", TextBox306.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Διφθερίτιδας-Τετάνου", "3η δόση", TextBox307.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Διφθερίτιδας-Τετάνου", "4η δόση", TextBox308.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "TdaP", "1η δόση", TextBox309.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "TdaP", "2η δόση", TextBox310.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "TdaP", "3η δόση", TextBox311.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "TdaP", "4η δόση", TextBox312.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Πολιομυελίτιδας IPV", "1η δόση", TextBox313.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Πολιομυελίτιδας IPV", "2η δόση", TextBox314.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Πολιομυελίτιδας IPV", "3η δόση", TextBox315.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Πολιομυελίτιδας IPV", "4η δόση", TextBox316.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Μηνιγγιτιδόκοκκου C", "1η δόση", TextBox317.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Μηνιγγιτιδόκοκκου C", "2η δόση", TextBox318.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Μηνιγγιτιδόκοκκου C", "3η δόση", TextBox319.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Μηνιγγιτιδόκοκκου C", "4η δόση", TextBox320.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "ΜΜΡ", "1η δόση", TextBox321.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "ΜΜΡ", "2η δόση", TextBox322.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "ΜΜΡ", "3η δόση", TextBox323.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "ΜΜΡ", "4η δόση", TextBox324.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ανεμοευλογιάς", "1η δόση", TextBox325.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ανεμοευλογιάς", "2η δόση", TextBox326.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ανεμοευλογιάς", "3η δόση", TextBox327.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ανεμοευλογιάς", "4η δόση", TextBox328.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "HPV", "1η δόση", TextBox329.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "HPV", "2η δόση", TextBox330.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "HPV", "3η δόση", TextBox331.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "HPV", "4η δόση", TextBox332.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Α", "1η δόση", TextBox333.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Α", "2η δόση", TextBox334.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Α", "3η δόση", TextBox335.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Ηπατίτιδας Α", "4η δόση", TextBox336.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Γρίπης INFL", "1η δόση", TextBox337.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Γρίπης INFL", "2η δόση", TextBox338.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Γρίπης INFL", "3η δόση", TextBox339.Text, localData)
        Call insertOrUpdate("ΠΙΝΑΚΑΣ B", "Γρίπης INFL", "4η δόση", TextBox340.Text, localData)
        localData.TerminateLocalDBConnection()
        Label3.Text = "Τα δεδομένα ενημερώθηκαν με επιτυχία..."
        PanelError3.Controls.Add(okOk())
    End Sub
    Private Sub viewPinakasB()
        Dim localData As New localDBconnection
        Dim dt As DataTable = localData.getData("SELECT [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ1], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ2], [ΧΑΡΑΚΤΗΡΙΣΤΙΚΟ3], ΤΙΜΗ FROM [ΠΑΙΔΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ] WHERE [PATIENT_CODE]='" & Request.QueryString("patientID") & "'")
        For f As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox301.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox302.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox303.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Β" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox304.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Διφθερίτιδας-Τετάνου" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox305.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Διφθερίτιδας-Τετάνου" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox306.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Διφθερίτιδας-Τετάνου" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox307.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Διφθερίτιδας-Τετάνου" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox308.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "TdaP" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox309.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "TdaP" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox310.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "TdaP" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox311.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "TdaP" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox312.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Πολιομυελίτιδας IPV" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox313.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Πολιομυελίτιδας IPV" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox314.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Πολιομυελίτιδας IPV" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox315.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Πολιομυελίτιδας IPV" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox316.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox317.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox318.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox319.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Μηνιγγιτιδόκοκκου C" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox320.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "ΜΜΡ" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox321.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "ΜΜΡ" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox322.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "ΜΜΡ" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox323.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "ΜΜΡ" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox324.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox325.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox326.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox327.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ανεμοευλογιάς" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox328.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox329.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox330.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox331.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "HPV" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox332.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox333.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox334.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox335.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Ηπατίτιδας Α" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox336.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "1η δόση" Then TextBox337.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "2η δόση" Then TextBox338.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "3η δόση" Then TextBox339.Text = dt.Rows(f).Item(3) : GoTo nextValue
            If dt.Rows(f).Item(0) = "ΠΙΝΑΚΑΣ B" And dt.Rows(f).Item(1) = "Γρίπης INFL" And dt.Rows(f).Item(2) = "4η δόση" Then TextBox340.Text = dt.Rows(f).Item(3) : GoTo nextValue
nextValue:
        Next
        localData.TerminateLocalDBConnection()
    End Sub
End Class