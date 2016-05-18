<%@ Page Title="Βιβλιάριο Υγείας Παιδιού-Στοιχεία εμβολίων" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="paidiatriko6.aspx.vb" Inherits="nosilia.paidiatriko6" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/wait.js"></script> 
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
        <li><a onclick="javascript:moveToPage()" href="paidiatriko4.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi3" runat="server"></span>Παιδι</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko5.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi4" runat="server"></span>Σωματομετρικα</b></a></li>
        <li class="current"><a href="#tab-1"><b><span id="pi5" runat="server"></span>Εμβολια</b></a></li>
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
    <div>
     <h4 style ="color:mediumorchid"><b>ΗΜΕΡΟΛΟΓΙΟ ΕΜΒΟΛΙΑΣΜΩΝ</b></h4>
     <table border="1" style="width:80%; border:solid mediumorchid; border-collapse: collapse;">
     <tr>
         <th style="background-color:mediumorchid; color:white"><b>ΕΜΒΟΛΙΟ</b></th>
         <td style="background-color:mediumorchid; color:white"><b>1η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>2η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>3η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>4η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>5η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>6η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>Παρατηρήσεις</b></td>
     </tr>
        
     <tr>
         <td><b>Ηπατίτιδας Β</b></td>
         <td><asp:TextBox ID="TextBox123" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender101" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox123" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox124" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender102" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox124" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox125" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender103" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox125" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox126" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender104" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox126" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox128" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender105" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox128" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox130" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender106" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox130" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox131" runat="server"></asp:TextBox></td>    
     </tr>

     <tr>
         <td><b>Διφθερίτιδας Τετάνου Κοκκύτη (ακυτταρικό)</b></td>
         <td><asp:TextBox ID="TextBox132" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender107" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox132" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox133" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender108" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox133" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox134" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender109" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox134" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox135" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender110" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox135" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox136" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender111" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox136" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox137" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender112" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox137" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox138" runat="server"></asp:TextBox></td>    
     </tr>

     <tr>
         <td><b>Πολυομυελίτιδας</b></td>
         <td><asp:TextBox ID="TextBox139" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender113" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox139" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox140" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender114" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox140" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox141" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender115" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox141" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox142" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender116" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox142" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox143" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender117" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox143" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox144" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender118" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox144" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox145" runat="server"></asp:TextBox></td>    
     </tr>

     <tr>
         <td><b>Αιμοφίλου ινφλουέντζας Β</b></td>
         <td><asp:TextBox ID="TextBox146" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender119" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox146" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox147" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender120" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox147" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox148" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender121" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox148" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox149" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender122" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox149" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox150" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender123" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox150" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox161" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender124" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox161" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox162" runat="server"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender125" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox162" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>    
     </tr>

     <tr>
         <td ><b>Μηνιγγιτιδόκοκκου</b></td>
         <td><asp:TextBox ID="TextBox163" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender126" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox163" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox164" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender127" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox164" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox165" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender128" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox165" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox166" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender129" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox166" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox167" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender130" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox167" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox168" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender131" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox168" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox169" runat="server"></asp:TextBox></td>    
     </tr>

     <tr>
         <td><b>Πνευμονιόκοκκου</b></td>
         <td><asp:TextBox ID="TextBox170" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender132" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox170" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox171" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender133" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox171" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox172" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender134" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox172" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox173" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender135" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox173" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox174" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender136" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox174" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox175" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender137" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox175" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox176" runat="server"></asp:TextBox></td>    
     </tr>


     <tr>
         <td><b>Ιλαράς Ερυθράς Παρωτίτιδας</b></td>
         <td><asp:TextBox ID="TextBox185" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender138" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox185" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox186" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender139" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox186" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox187" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender140" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox187" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox188" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender141" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox188" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox189" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender142" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox189" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox190" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender143" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox190" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox191" runat="server"></asp:TextBox></td>    
     </tr>

     <tr>
         <td><b>Ανεμοευλογιάς</b></td>
         <td><asp:TextBox ID="TextBox192" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender144" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox192" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox193" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender145" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox193" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox194" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender146" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox194" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox195" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender147" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox195" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox196" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender148" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox196" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox197" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender149" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox197" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox198" runat="server"></asp:TextBox></td>    
     </tr>
     
     <tr>
         <td><b>Ιός Ανθρώπινων Θηλωμάτων (HPV)</b></td>
         <td><asp:TextBox ID="TextBox199" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender150" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox199" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox200" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender151" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox200" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox201" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender152" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox201" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox202" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender153" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox202" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox203" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender154" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox203" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox204" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender155" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox204" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox205" runat="server"></asp:TextBox></td>    
     </tr>
    
     <tr>
         <td><b>Ηπατίτιδας Α</b></td>
         <td><asp:TextBox ID="TextBox206" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender156" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox206" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox207" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender157" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox207" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox208" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender158" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox208" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox209" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender159" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox209" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox210" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender160" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox210" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox211" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender161" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox211" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox212" runat="server"></asp:TextBox></td>    
     </tr>

    <tr>
         <td><b>Φυματινοαντίδραση (Mantoux)</b></td>
         <td><asp:TextBox ID="TextBox213" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender162" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox213" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox214" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender163" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox214" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox215" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender164" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox215" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox216" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender165" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox216" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox217" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender166" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox217" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox218" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender167" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox218" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox219" runat="server"></asp:TextBox></td>    
     </tr>

    <tr>
         <td><b>Φυματίωσης BCG</b></td>
         <td><asp:TextBox ID="TextBox220" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender168" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox220" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox221" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender169" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox221" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox222" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender170" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox222" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox223" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender171" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox223" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox224" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender172" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox224" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox225" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender173" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox225" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox226" runat="server"></asp:TextBox></td>    
     </tr>

    <tr>
         <td><b>Γρίπης (INFL)</b></td>
         <td><asp:TextBox ID="TextBox227" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender174" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox227" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox228" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender175" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox228" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox229" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender176" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox229" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox230" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender177" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox230" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox231" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender178" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox231" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox232" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender179" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox232" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox233" runat="server"></asp:TextBox></td>    
     </tr>

    <tr>
         <td><b>Άλλα</b><asp:TextBox ID="TextBox1" runat="server" Width="100"></asp:TextBox>
         </td>
         <td><asp:TextBox ID="TextBox234" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender180" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox234" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td><asp:TextBox ID="TextBox235" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender181" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox235" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox236" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender182" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox236" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox237" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender183" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox237" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox238" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender184" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox238" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox239" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender185" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox239" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td><asp:TextBox ID="TextBox240" runat="server"></asp:TextBox></td>    
     </tr>
   </table>
    <asp:Panel ID="PanelError1" runat="server"></asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Προσθήκη στοιχείων" />
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    <br /> 
     <h4 style ="color:mediumorchid"><b>ΠΙΝΑΚΑΣ Α</b></h4>
     <table border="1" style="width:80%; border:solid mediumorchid; border-collapse: collapse;">
     <tr>
         <td colspan="10"><b>Πρόγραμμα εμβολιασμών για παιδιά ηλικίας μέχρι 6 ετών που δεν εμβολιάσθηκαν στη συνιστώμενη από το Εθνικό Πρόγραμμα ηλικία </b></td>
     </tr>
     <tr>
         <th rowspan="2" style="background-color:mediumorchid; color:white"><b>ΕΜΒΟΛΙΟ</b></th>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>1η δόση</b></td>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>2η δόση</b></td>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>3η δόση</b></td>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>4η δόση</b></td>
         <td style="background-color:mediumorchid; color:white"><b>5η δόση</b></td>
    </tr>
     <tr>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 1ης-2ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 2ης-3ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 3ης-4ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 4ης-5ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
    </tr>
   
     <tr>
         <td><b>Ηπατίτιδας Β (Hep B)</b></td>
         <td><asp:TextBox ID="TextBox241" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender41" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox241" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox242" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender42" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox242" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>3 μήνες</td>
         <td><asp:TextBox ID="TextBox243" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender43" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox243" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox244" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender44" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox244" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox245" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender45" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox245" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>     
     </tr>

     <tr>
         <td><b>Διφθερίτιδας, Τετάνου, Κοκκύτη (DTaP)</b></td>
         <td><asp:TextBox ID="TextBox246" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender46" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox246" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox247" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender47" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox247" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox248" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender48" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox248" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>6 μήνες</td>
         <td><asp:TextBox ID="TextBox249" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender49" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox249" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>3-4 χρόνια</td>
         <td><asp:TextBox ID="TextBox250" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender50" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox250" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Πολυομυελίτιδας IPV</b></td>
         <td><asp:TextBox ID="TextBox251" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender51" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox251" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox252" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender52" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox252" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox253" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender53" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox253" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox254" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender54" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox254" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox255" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender55" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox255" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Αιμοφίλου τύπου Β (Hib)</b></td>
         <td><asp:TextBox ID="TextBox256" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender56" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox256" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox257" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender57" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox257" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox258" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender58" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox258" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>8 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox259" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender59" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox259" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox260" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender60" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox260" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Μηνιγγιτιδόκοκκου C (MCC)</b></td>
         <td><asp:TextBox ID="TextBox261" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender61" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox261" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox262" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender62" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox262" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox263" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender63" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox263" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>8 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox264" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender64" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox264" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox265" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender65" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox265" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Πνευμονιόκοκκου (7δύναμο)(PCV)</b></td>
         <td><asp:TextBox ID="TextBox266" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender66" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox266" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox267" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender67" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox267" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox268" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender68" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox268" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>8 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox269" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender69" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox269" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox270" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender70" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox270" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Ιλαράς, Παρωτίτιδας, Ερυθράς (MMR)</b></td>
         <td><asp:TextBox ID="TextBox271" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender71" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox271" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox272" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender72" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox272" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox273" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender73" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox273" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox274" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender74" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox274" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox275" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender75" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox275" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Ανεμοευλογιάς (Var)</b></td>
         <td><asp:TextBox ID="TextBox276" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender76" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox276" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>8 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox277" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender77" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox277" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox278" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender78" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox278" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox279" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender79" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox279" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox280" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender80" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox280" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Ηπατίτιδας Α (Hep A)</b></td>
         <td><asp:TextBox ID="TextBox281" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender81" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox281" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>6 μήνες</td>
         <td><asp:TextBox ID="TextBox282" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender82" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox282" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox283" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender83" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox283" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox284" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender84" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox284" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox285" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender85" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox285" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

    <tr>
         <td><b>Φυματίωσης (BCG)</b></td>
         <td><asp:TextBox ID="TextBox286" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender86" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox286" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td></td>
         <td><asp:TextBox ID="TextBox287" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender87" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox287" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox288" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender88" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox288" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox289" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender89" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox289" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox290" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender90" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox290" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

    <tr>
         <td><b>Φυματινοαντίδραση (Mantoux)</b></td>
         <td><asp:TextBox ID="TextBox291" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender91" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox291" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td></td>
         <td><asp:TextBox ID="TextBox292" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender92" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox292" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox293" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender93" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox293" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox294" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender94" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox294" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox295" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender95" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox295" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

    <tr>
         <td><b>Γρίπης (INFL)</b></td>
         <td><asp:TextBox ID="TextBox296" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender96" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox296" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox297" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender97" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox297" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox298" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender98" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox298" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox299" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender99" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox299" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox300" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender100" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox300" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>
   </table>
         <asp:Panel ID="PanelError2" runat="server"></asp:Panel>
        <asp:Button ID="Button2" runat="server" Text="Προσθήκη στοιχείων" />
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
   <br />
     <h4 style ="color:mediumorchid"><b>ΠΙΝΑΚΑΣ Β</b></h4>
     <table border="1" style="width:90%; border:solid mediumorchid; border-collapse: collapse;">
     <tr>
         <td colspan="8"><b>Πρόγραμμα εμβολιασμών για παιδιά ηλικίας 7-18 ετών που δεν εμβολιάστηκαν στη συνιστώμενη  από το Εθνικό Πρόγραμμα ηλικία </b></td>
     </tr>
     <tr>
         <th rowspan="2" style="background-color:mediumorchid; color:white"><b>ΕΜΒΟΛΙΟ</b></th>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>1η δόση</b></td>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>2η δόση</b></td>
         <td style="background-color:mediumorchid; color:white" colspan="2" align="center"><b>3η δόση</b></td>
         <td style="background-color:mediumorchid; color:white" colspan="2"><b>4η δόση</b></td>
    </tr>
     <tr>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 1ης-2ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 2ης-3ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
         <td style="background-color:mediumorchid; color:white" >Απόσταση 3ης-4ης δόσης</td>
         <td style="background-color:mediumorchid; color:white" ><b>Ημερομηνία</b></td>
    </tr>
   
     <tr>
         <td><b>Ηπατίτιδας Β (Hep B)</b></td>
         <td><asp:TextBox ID="TextBox301" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox301" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox302" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox302" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>3 μήνες</td>
         <td><asp:TextBox ID="TextBox303" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender3" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox303" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox304" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender4" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox304" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
    </tr>

     <tr>
         <td><b>Διφθερίτιδας, Τετάνου (Td)</b></td>
         <td><asp:TextBox ID="TextBox305" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender5" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox305" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox306" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender6" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox306" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>6 μήνες</td>
         <td><asp:TextBox ID="TextBox307" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender7" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox307" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>6 μήνες</td>
         <td><asp:TextBox ID="TextBox308" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender8" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox308" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
    </tr>

     <tr>
         <td><b>(TdaP)</b></td>
         <td><asp:TextBox ID="TextBox309" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender9" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox309" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td></td>
         <td><asp:TextBox ID="TextBox310" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender10" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox310" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox311" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender11" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox311" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>5 χρόνια</td>
         <td><asp:TextBox ID="TextBox312" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender12" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox312" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
    </tr>

     <tr>
         <td><b>Πολιομυελίτιδας IPV</b></td>
         <td><asp:TextBox ID="TextBox313" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender13" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox313" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox314" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender14" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox314" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox315" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender15" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox315" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>6 μήνες</td>
         <td><asp:TextBox ID="TextBox316" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender16" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox316" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Μηνιγγιτιδόκοκκου C (MCC)</b></td>
         <td><asp:TextBox ID="TextBox317" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender17" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox317" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td></td>
         <td><asp:TextBox ID="TextBox318" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender18" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox318" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox319" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender19" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox319" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox320" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender20" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox320" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
    </tr>

     <tr>
         <td><b>Ιλαράς, Παρωτίτιδας, Ερυθράς (ΜΜΡ)</b></td>
         <td><asp:TextBox ID="TextBox321" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender21" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox321" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox322" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender22" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox322" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox323" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender23" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox323" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox324" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender24" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox324" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Ανεμοευλογιάς (Var)</b></td>
         <td><asp:TextBox ID="TextBox325" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender25" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox325" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>8 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox326" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender26" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox326" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox327" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender27" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox327" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox328" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender28" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox328" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
    </tr>

     <tr>
         <td><b>Ιός Ανθρώπινων Θηλωμάτων (HPV)</b></td>
         <td><asp:TextBox ID="TextBox329" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender29" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox329" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>4-8 εβδομάδες</td>
         <td><asp:TextBox ID="TextBox330" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender30" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox330" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td>4-5 μήνες</td>
         <td><asp:TextBox ID="TextBox331" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender31" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox331" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox332" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender32" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox332" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

     <tr>
         <td><b>Ηπατίτιδας Α (Hep A)</b></td>
         <td><asp:TextBox ID="TextBox333" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender33" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox333" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td>6 μήνες</td>
         <td><asp:TextBox ID="TextBox334" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender34" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox334" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox335" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender35" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox335" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox336" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender36" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox336" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
     </tr>

    <tr>
         <td><b>Γρίπης (INFL)</b></td>
         <td><asp:TextBox ID="TextBox337" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender37" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox337" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>		
         <td></td>
         <td><asp:TextBox ID="TextBox338" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender38" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox338" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox339" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender39" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox339" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
         <td></td>
         <td><asp:TextBox ID="TextBox340" runat="server" Width="100"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender40" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox340" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
         </td>
    </tr>
</table>
        <asp:Panel ID="PanelError3" runat="server"></asp:Panel>
        <asp:Button ID="Button3" runat="server" Text="Προσθήκη στοιχείων" />
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
<br />
     <!--   
     <h4 style ="color:darkseagreen"><b>ΕΚΤΙΜΗΣΗ ΕΜΒΟΛΙΑΣΤΙΚΗΣ ΚΑΤΑΣΤΑΣΗ ΣΤΗΝ ΗΛΙΚΙΑ ΤΩΝ 11-12 ΕΤΩΝ</b></h4>
     <table border="1" style="width:80%; border:solid darkseagreen; border-collapse: collapse;">
     <tr>
         <th rowspan="2" style="background-color:darkseagreen; color:white"><b>ΕΜΒΟΛΙΟ</b></th>
         <td colspan="2" style="background-color:darkseagreen; color:white" align="center"><b>ΒΑΣΙΚΟΣ ΕΜΒΟΛΙΑΣΜΟΣ</b></td>
         <td style="background-color:darkseagreen; color:white"><b>ΑΝΑΖΩΠΥΡΩΣΕΙΣ<br />(Αριθμ.Δόσεων)</b></td>
         <td style="background-color:darkseagreen; color:white"><b>ON/MO</b></td>
    </tr>
    <tr>
         <td style="background-color:darkseagreen; color:white"><b>Ατελής (Αρ. Δόσεων)</b></td>
         <td style="background-color:darkseagreen; color:white"><b>Πλήρης</b></td>
         <td style="background-color:darkseagreen"></td>
         <td style="background-color:darkseagreen"></td>
    </tr>
     </table>
    -->
    </div>
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
