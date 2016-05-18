<%@ Page Title="Βιβλιάριο Υγείας Παιδιού-Στοιχεία βρέφους" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="paidiatriko3.aspx.vb" Inherits="nosilia.paidiatriko3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/wait.js"></script> 
	<link rel="stylesheet" href="/Styles/nicetitle.css"/>
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
            width: 100%;
            padding: 20px;
            display: none;
        }

        #tab-1 {
         display: block;   
        }
/**/
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
        <li class="current"><a href="#tab-1"><b><span id="pi2" runat="server"></span>Βρεφος</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko4.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi3" runat="server"></span>Παιδι</b></a></li>
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
    <h4 style ="color:mediumorchid"><b>ΠΕΡΙΟΔΙΚΟΣ ΕΛΕΓΧΟΣ ΥΓΕΙΑΣ ΤΟΥ ΒΡΕΦΟΥΣ</b>
            </h4>      
    <table border="1" style="width:70%; border:solid mediumorchid; border-collapse: collapse;">
        <tr>
            <td><b>ΗΜΕΡ. ΕΞΕΤΑΣΗΣ</b></td>
            <td><b>ΗΛΙΚΙΑ</b></td>		
            <td><b>ΒΑΡΟΣ</b></td>
            <td><b>ΥΨΟΣ</b></td>
            <td><b>ΠΕΡΙΜ. ΚΕΦΑΛΗΣ</b></td>
            <td><b>ΔΟΝΤΙΑ</b></td>
         </tr>
        <tr>
          <td><asp:TextBox ID="TextBox81" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
              <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox81" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
          </td>
          <td><span class="tooltip" id="Span1" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για την ηλικία" height="48" width="48" /><em>Η ηλικία πρέπει να εισαχθεί σε μήνες.</em>Επιτρέπονται εισαγωγές και μισών μηνών (πχ. 16,5 μηνών).</span></span>
              <asp:TextBox ID="TextBox82" runat="server" Width="50" MaxLength="10" ToolTip="Η ηλικία πρέπει να εισαχθεί σε μήνες. Επιτρέπονται εισαγωγές και μισών μηνών (πχ. 16,5 μηνών)."></asp:TextBox></td>		
          <td><span class="tooltip" id="Span2" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για το βάρος" height="48" width="48" /><em>Το βάρος πρέπει να εισαχθεί σε κιλά.</em>Επιτρέπονται εισαγωγές και μισών κιλών(πχ. 16,5 κιλών).</span></span>
              <asp:TextBox ID="TextBox83" runat="server" Width="50" MaxLength="10" ToolTip="Η ηλικία πρέπει να εισαχθεί σε κιλά. Επιτρέπονται εισαγωγές και μισών κιλών (πχ. 16,5 κιλών)."></asp:TextBox></td>
          <td><span class="tooltip" id="Span3" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για το ύψος" height="48" width="48" /><em>Το ύψος πρέπει να εισαχθεί σε εκατοστά.</em> Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών).</span></span>
              <asp:TextBox ID="TextBox84" runat="server" Width="50" MaxLength="10" ToolTip="Το ύψος πρέπει να εισαχθεί σε εκατοστά. Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών)."></asp:TextBox></td>
          <td><span class="tooltip" id="Span4" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για τη περίμετρος κεφαλής" height="48" width="48" /><em>Η περίμετρος κεφαλής πρέπει να εισαχθεί σε εκατοστά.</em> Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών).</span></span>
              <asp:TextBox ID="TextBox85" runat="server" Width="50px" MaxLength="20" ToolTip="Η περίμετρος κεφαλής πρέπει να εισαχθεί σε εκατοστά. Επιτρέπονται εισαγωγές και μισών εκατοστών (πχ. 16,5 εκατοστών)."></asp:TextBox></td>
          <td><span class="tooltip" id="Span5" runat="server">?
			<span class="custom info"><img src="/Styles/info.png" alt="Πληροφορίες για τα δόντια" height="48" width="48" /><em>Ελεύθερο κείμενο</span></span>
              <asp:TextBox ID="TextBox86" runat="server" Width="200px" MaxLength="20" ToolTip="Πληροφορίες για τα δόντια. Ελεύθερο κείμενο."></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="6">
                <b><label>ΠΑΡΑΤΗΡΗΣΕΙΣ  </label></b><br />
                    <asp:TextBox ID="TextBox87" rows="2" TextMode="multiline" runat="server" Width="99%" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
      </table>
         <asp:Panel ID="PanelError" runat="server"></asp:Panel>
         <asp:Button ID="Button1" runat="server" Text="Προσθήκη νέου περιστατικού" />
         <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        <h4 style ="color:mediumorchid"><b>ΩΣ ΤΩΡΑ ΜΕΤΡΗΣΕΙΣ ΣΤΟ ΒΡΕΦΟΣ</b></h4>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" BorderStyle="None" Width ="97%">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="mediumorchid" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
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
