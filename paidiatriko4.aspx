<%@ Page Title="Βιβλιάριο Υγείας Παιδιού-Στοιχεία παιδιού" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="paidiatriko4.aspx.vb" Inherits="nosilia.paidiatriko4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="Scripts/wait.js"></script> 
 	<link rel="stylesheet" href="/Styles/nicetitle.css"/>
    <script type="text/javascript">
    function calculateBMI() {
        if (document.getElementById("TextBox89").value.replace(",", ".") == "" || document.getElementById("TextBox90").value.replace(",", ".") == "") { return; }
        else {
            var w = Math.round(document.getElementById("TextBox89").value.replace(",", ".") / 2) * 2;
            var l = Math.round(document.getElementById("TextBox90").value.replace(",", ".") / 2) * 2;
            if (isNaN(w)) { alert("Το βάρος πρέπει να είναι αριθμός"); return; }
            if (isNaN(l)) { alert("Το ύψος πρέπει να είναι  αριθμός"); return; }
            document.getElementById("TextBox91").value = Math.round(w / (Math.pow(l, 2)) * 10000 * 10) / 10;
        }
    }
    </script>
    <style type="text/css">
        body {
          padding: 20px;
          font-family: Arial, Helvetica, sans-serif;
          line-height: 1.5;
          font-size: 14px;        
        }

        .tabs-menu {
            height: 30px;
            float: left;
            clear: both;
            list-style-type:none;
        }

        .tabs-menu li {
            height: 30px;
            line-height: 30px;
            float: left;
            margin-right: 10px;
            background-color: #ccc;
            border-top: 1px solid #d4d4d1;
            border-right: 1px solid #d4d4d1;
            border-left: 1px solid #d4d4d1;
        }

        .tabs-menu li.current {
            position: relative;
            background-color: #fff;
            border-bottom: 1px solid #fff;
            z-index: 5;
        }

        .tabs-menu li a {
            padding: 10px;
            text-transform: uppercase;
            color: #fff;
            text-decoration: none; 
        }

        .tabs-menu .current a {
            color: #2e7da3;
        }

        .tab {
            position:relative;
            top:-13px;
            border: 1px solid #d4d4d1;
            background-color: #fff;
            float: left;
            margin-bottom: 20px;
            width: 100%;
        }

        .tab-content {
            width: 96%;
            padding: 20px;
            display: none;
        }

        #tab-1 {
         display: block;   
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div id="DivNav" runat="server" style="position:relative; margin-left: -20px;margin-top: -9px; width:103.9%;background-color:lightgray"></div> 
<div id="pleaseWait" style="position: fixed;top: 50%;left: 50%;margin-top: -30px;margin-left: -30px;z-index:1000;display:none"><img alt="" src="Pictures/wait_medium.gif" style="vertical-align:middle"/></div>
     <asp:Table ID="TableHeader" runat="server" Width="100%" BackColor="#8899ee">
        <asp:TableRow>
        <asp:TableCell>
        <table>
            <tr>
                <td>
                    <img alt="" src="Pictures/medicalHistory.png"/>
                </td>
                <td>
                    <span style="font-size:160%;color:yellow">&nbsp;&nbsp;ΙΑΤΡΙΚΟ ΙΣΤΟΡΙΚΟ <asp:HyperLink ID="HyperLinkView" runat="server" Visible="false"></asp:HyperLink> /</span>
                </td>
                <td>
                    <br /><span style="font-size:130%;color:yellow">Παιδιατρικό αναμνηστικό</span>
                </td>
            </tr>
        </table>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
<asp:GridView ID="GridView1" runat="server" Width="100%">
    </asp:GridView>
   <div id="tabs-container">
    <ul class="tabs-menu">
        <li><a onclick="javascript:moveToPage()" href="patient.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><img alt="" src="Pictures/medicalHistory-small.png"/></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko1.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi0" runat="server"></span>Δημογραφικα</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko2.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi1" runat="server"></span>Περιγεννητικα</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko3.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi2" runat="server"></span>Βρεφος</b></a></li>
        <li class="current"><a href="#tab-1"><span id="pi3" runat="server"></span><b>Παιδι</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko5.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi4" runat="server"></span>Σωματομετρικα</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko6.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi5" runat="server"></span>Εμβολια</b></a></li>
    </ul>
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization = "true">
</asp:ToolkitScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress4" runat="server">
            <ProgressTemplate>
                <div id="progress" style="position: fixed;top: 50%;left: 50%;margin-top: -30px;margin-left: -30px;z-index:1000"><img alt="" src="Pictures/wait_medium.gif" style="vertical-align:middle"/></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
<script type="text/javascript">
	var prm = Sys.WebForms.PageRequestManager.getInstance();
	prm.add_endRequest(function (s, e) {
		if (document.getElementById("notOK") != null && typeof document.getElementById("notOK") !== "undefined") {
			myVarError = window.setInterval(function () { ok_insert() }, 4000);
		}
		else {
			if (document.getElementById("OKOK") != null && typeof document.getElementById("OKOK") !== "undefined") {
				myVarError = window.setInterval(function () { ok_insert() }, 1700);
			}
		}
		function ok_insert() {
			if (document.getElementById("notOK") != null && typeof document.getElementById("notOK") !== "undefined") {
				var t = document.getElementById("notOK");
				t.style.display = "none";
			}
			else {
				if (document.getElementById("OKOK") != null && typeof document.getElementById("OKOK") !== "undefined") {
					var t = document.getElementById("OKOK");
					t.style.display = "none";
				}
			}
			clearInterval(myVarError)
		} 
	});
</script>
    <div class="tab">
        <div id="tab-1" class="tab-content">
      <h4 style ="color:cornflowerblue"><b>ΠΕΡΙΟΔΙΚΟΣ ΕΛΕΓΧΟΣ ΥΓΕΙΑΣ ΤΟΥ ΠΑΙΔΙΟΥ</b></h4>
    <table border="1" style="width:100%; border:solid cornflowerblue; border-collapse: collapse;">
        <tr>
            <td><b>ΗΜΕΡ. ΕΞΕΤΑΣΗΣ</b></td>
            <td><b>ΗΛΙΚΙΑ</b></td>		
            <td><b>ΒΑΡΟΣ</b></td>
            <td><b>ΥΨΟΣ</b></td>
            <td><b>ΔΜΣ</b></td>
            <td><b>ΠΕΡ. ΚΕΦΑΛΗΣ</b></td>
            <td><b>ΣΥΣΤ. ΠΙΕΣΗ</b></td>
            <td><b>ΔΙΑΣΤ. ΠΙΕΣΗ</b></td>
            <td><b>ΔΟΝΤΙΑ</b></td>
         </tr>
        <tr>
          <td><asp:TextBox ID="TextBox87" runat="server" Width="100px"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox87" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
          </td>
          <td><span class="tooltip" id="Span1" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για την ηλικία" height="48" width="48" /><em>Η ηλικία πρέπει να εισαχθεί σε χρόνια.</em>Επιτρέπονται εισαγωγές και μισών χρονών (πχ. 16,5 χρονών).</span></span>
              <asp:TextBox ID="TextBox88" runat="server" Width="50"  ToolTip="Η ηλικία πρέπει να εισαχθεί σε χρόνια. Επιτρέπονται εισαγωγές και μισών χρονών (πχ. 16,5 χρονών)."></asp:TextBox></td>		
          <td><span class="tooltip" id="Span2" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για το βάρος" height="48" width="48" /><em>Το βάρος πρέπει να εισαχθεί σε κιλά.</em>Επιτρέπονται εισαγωγές και μισών κιλών(πχ. 16,5 κιλών)</span></span>
              <asp:TextBox ID="TextBox89" runat="server" Width="50" ClientIDMode="Static" onchange="javascript:calculateBMI()" ToolTip="Το βάρος πρέπει να εισαχθεί σε κιλά. Επιτρέπονται εισαγωγές και μισών κιλών (πχ. 16,5 κιλά)."></asp:TextBox></td>
          <td><span class="tooltip" id="Span3" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για το ύψος" height="48" width="48" /><em>Το ύψος πρέπει να εισαχθεί σε εκατοστά.</em> Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών).</span></span>
              <asp:TextBox ID="TextBox90" runat="server" Width="50" ClientIDMode="Static" onchange="javascript:calculateBMI()"  ToolTip="Το ύψος πρέπει να εισαχθεί σε εκατοστά. Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστά)."></asp:TextBox></td>
          <td><asp:TextBox ID="TextBox91" runat="server" Width="50" ClientIDMode="Static" ReadOnly="true" BackColor="#ccffcc"></asp:TextBox></td>
          <td><span class="tooltip" id="Span4" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για τη περίμετρος κεφαλής" height="48" width="48" /><em>Η περίμετρος κεφαλής πρέπει να εισαχθεί σε εκατοστά.</em> Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών).</span></span>
              <asp:TextBox ID="TextBox92" runat="server" Width="50px" ToolTip="Η περίμετρος κεφαλής πρέπει να εισαχθεί σε εκατοστά. Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών)."></asp:TextBox></td>
          <td><span class="tooltip" id="Span5" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για τη συστολική πίεση" height="48" width="48" /><em>Η συστολική πίεση πρέπει να εισαχθεί σε mmHg.</em>Η τιμή του πρέπει να είναι ακέραιος αριθμός.</span></span>
              <asp:TextBox ID="TextBox93" runat="server" Width="50px" ToolTip="Πληροφορίες για τη συστολική πίεση. Η συστολική πίεση πρέπει να εισαχθεί σε mmHg."></asp:TextBox></td>
          <td><span class="tooltip" id="Span6" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για τη διαστολική πίεση" height="48" width="48" /><em>Η διαστολική πίεση πρέπει να εισαχθεί σε mmHg.</em>Η τιμή του πρέπει να είναι ακέραιος αριθμός.</span></span>
              <asp:TextBox ID="TextBox1" runat="server" Width="50px" ToolTip="Πληροφορίες για τη διαστολική πίεση. Η διαστολική πίεση πρέπει να εισαχθεί σε mmHg."></asp:TextBox></td>
          <td><span class="tooltip" id="Span7" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για τα δόντια" height="48" width="48" /><em>Ελεύθερο κείμενο.</em></span></span>
              <asp:TextBox ID="TextBox94" runat="server" Width="200px" ToolTip="Πληροφορίες για τα δόντια. Ελεύθερο κείμενο."></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="9">
                <b><label>ΠΑΡΑΤΗΡΗΣΕΙΣ  </label></b><br />
                    <asp:TextBox ID="TextBox95" rows="2" TextMode="multiline" runat="server" Width="99%"></asp:TextBox>
            </td>
        </tr>
      </table>    <asp:Panel ID="PanelError" runat="server"></asp:Panel>
            <asp:Button ID="Button1" runat="server" Text="Προσθήκη νέου περιστατικού" />
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
        <h4 style ="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΜΕΤΡΗΣΕΙΣ ΣΤΟ ΠΑΙΔΙ</b></h4>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" BorderStyle="None">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

      <h4 style ="color:cornflowerblue"><b>ΕΛΕΓΧΟΣ ΥΓΕΙΑΣ ΤΟΥ ΠΑΙΔΙΟΥ (εξετασεις)</b></h4>
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                    <asp:TabPanel ID="TabPanelOfthalm" runat="server" HeaderText ="Οφθαλμολογικές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΟΦΘΑΛΜΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox96" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox96" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox97" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button2" runat="server" Text="Προσθήκη Οφθαλμολογικής Εξέτασης" />
                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                            <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΟΦΘΑΛΜΟΛΟΓΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                            <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για οφθαλμολογικές εξετάσεις">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelOrthopaid" runat="server" HeaderText ="Ορθοπαιδικές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΟΡΘΟΠΑΙΔΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox99" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox99" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox100" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button3" runat="server" Text="Προσθήκη Ορθοπαιδικής Εξέτασης" />
                                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΟΡΘΟΠΑΙΔΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για ορθοπαιδικές εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelAllerg" runat="server" HeaderText ="Αλλεργιολογικές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΑΛΛΕΡΓΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox102" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox102" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox103" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button4" runat="server" Text="Προσθήκη Αλλεργιολογικής Εξέτασης" />
                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΑΛΛΕΡΓΙΟΛΟΓΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView5" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για αλλεργιολογικές εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelKard" runat="server" HeaderText ="Καρδ/κές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΚΑΡΔΙΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox105" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox105" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox106" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button5" runat="server" Text="Προσθήκη Καρδιολογικής Εξέτασης" />
                                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΚΑΡΔΙΟΛΟΓΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView6" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για καρδιολογικές εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelEndokr" runat="server" HeaderText ="Ενδοκρ/κές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox108" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox108" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox109" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button6" runat="server" Text="Προσθήκη Ενδοκρινολογικής Εξέτασης" />
                                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΕΝΔΟΚΡΙΝΟΛΟΓΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView7" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για ενδοκρινολογικές εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelVrl" runat="server" HeaderText ="ΩΡΛ" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΩΡΛ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox111" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox111" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox112" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button7" runat="server" Text="Προσθήκη ΩΡΛ Εξέτασης" />
                                <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΩΡΛ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView8" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για ΩΡΛ εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelPaidneyr" runat="server" HeaderText ="Παιδονευρολογικές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox114" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox114" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox115" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button8" runat="server" Text="Προσθήκη Παιδονευρολογικής Εξέτασης" />
                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΠΑΙΔΟΝΕΥΡΟΛΟΓΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView9" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για παιδονευρολογικές εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelOdont" runat="server" HeaderText ="Οδοντιατρικές" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΟΔΟΝΤΟΤΡΙΑΤΙΚΗ ΕΞΕΤΑΣΗ</b></h4>
                                <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                        <td><b>ΕΥΡΗΜΑΤΑ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox117" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox117" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox118" runat="server" Width="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button9" runat="server" Text="Προσθήκη Οδοντοτριατικής Εξέτασης" />
                                <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΟΔΟΝΤΟΤΡΙΑΤΙΚΕΣ ΜΕΤΡΗΣΕΙΣ</b></h4>
                                <asp:GridView ID="GridView10" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για οδοντοτριατικές εξετάσεις">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelLoim" runat="server" HeaderText ="Λοιμώδη νοσήματα" style="min-height:250px">
                        <ContentTemplate>
                            <h4 style="color:cornflowerblue"><b>ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ ΠΑΙΔΙΚΗΣ ΗΛΙΚΙΑΣ</b></h4>
                               <table border="1" style="width:35%; border:solid cornflowerblue; border-collapse: collapse;">
                                    <tr>
                                        <td><b>ΝΟΣΗΜΑ</b></td>
                                        <td><b>ΗΜΕΡΟΜΗΝΙΑ</b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox120" runat="server" Width="300"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox121" runat="server" Width="100"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" ClearTime="True" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox121" TodaysDateFormat="dd MMMM yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button10" runat="server" Text="Προσθήκη Λοιμώδους Εξέτασης" />
                                <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <h4 style="color:cornflowerblue"><b>ΩΣ ΤΩΡΑ ΜΕΤΡΗΣΕΙΣ ΛΟΙΜΩΞΕΩΝ</b></h4>
                                <asp:GridView ID="GridView11" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="Δεν έχουν εισαχθεί στοιχεία για μετρήσεις λοιμόξεων">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="cornflowerblue" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                        </ContentTemplate> 
                    </asp:TabPanel>
                </asp:TabContainer>
             </div>            
         </div>
      </ContentTemplate>
    </asp:UpdatePanel> 
    </div>
                          <asp:Table ID="TableFooter" runat="server" Width="100%">
              <asp:TableRow><asp:TableCell>      <a href="javascript: window.history.back()">
        <img alt="" src="Pictures/back.gif" />
    </a>
</asp:TableCell><asp:TableCell HorizontalAlign="Right"></asp:TableCell></asp:TableRow>
        </asp:Table>
</asp:Content>
