<%@ Page Title="Βιβλιάριο Υγείας Παιδιού-Γενικά στοιχεία" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="paidiatriko1.aspx.vb" Inherits="nosilia.paidiatriko1" %>
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
            width: 96%;
            padding-left: 20px;
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
        <li class="current"><a href="#tab-1"><span id="pi0" runat="server"></span><b>Δημογραφικα</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko2.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi1" runat="server"></span>Περιγεννητικα</b></a></li>
        <li><a onclick="javascript:moveToPage()" href="paidiatriko3.aspx?visitID=<%=Request.QueryString("visitID") %>&patientID=<%=Request.QueryString("patientID") & "&panakeia=" & Request.QueryString("panakeia") & "&find=" & Request.QueryString("find") & "&nomenu=" & Request.QueryString("nomenu")%>"><b><span id="pi2" runat="server"></span>Βρεφος</b></a></li>
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
            <h4 style ="color :cornflowerblue"><b>ΣΤΟΙΧΕΙΑ ΚΑΤΟΧΟΥ</b></h4>
            <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
                <table>
                    <tr>
                        <td>
                            <b><label>ΕΠΙΘΕΤΟ: </label></b><asp:Label ID="LabelEpi" runat="server" Text="LabelEpi"></asp:Label>
                        </td>
                        <td>
                            <b><label>ΟΝΟΜΑ: </label></b><asp:Label ID="LabelOn" runat="server" Text="LabelOn"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="LabelhmGen" Font-Bold="true" runat="server" Text="LabelhmGen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <label>ΤΟΠΟΣ ΓΕΝΝΗΣΗΣ:</label><asp:TextBox ID="TextBox1" runat="server" Width="300" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <label>ΔΙΕΥΘΥΝΣΗ ΚΑΤΟΙΚΙΑΣ:  </label><asp:TextBox ID="TextBox2" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>ΑΡΙΘΜΟΣ ΛΗΞΙΑΡΧΙΚΗΣ ΠΡΑΞΗΣ ΓΕΝΝΗΣΗΣ:  </label><asp:TextBox ID="TextBox3" runat="server" MaxLength="20"></asp:TextBox> 
                        </td>
                        <td>
                            <label>ΤΗΛΕΦΩΝΟ:  </label><asp:TextBox ID="TextBox4" runat="server" MaxLength="20"></asp:TextBox> 
                        </td>
                    </tr>
                </table>
            </div>
    <!--MOTHER-->
    <h4 style ="color:cornflowerblue"><b>Η ΜΗΤΕΡΑ</b></h4>
  <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
   <table>
       <tr>
           <td >
               <b><label>ΟΝΟΜΑ:  </label></b><asp:TextBox ID="TextBox5" runat="server" Width="300" MaxLength="100"></asp:TextBox> 
           </td>
           <td>
               <b><label>ΕΠΙΘΕΤΟ:  </label></b><asp:TextBox ID="TextBox6" runat="server" Width="300" MaxLength="100"></asp:TextBox> 
           </td>
       </tr>
       <tr>
           <td colspan="2">
               <label>ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ:  </label><asp:TextBox ID="TextBox7" runat="server" MaxLength="50"></asp:TextBox>
               <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox7" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
           </td>
       </tr>
       <tr>
           <td colspan="2">
                <label>ΤΟΠΟΣ ΚΑΤΑΓΩΓΗΣ:  </label><asp:TextBox ID="TextBox8" runat="server" Width="300" MaxLength="100"></asp:TextBox> 
           </td>
       </tr>
       <tr>
           <td>
             <label>ΕΘΝΙΚΟΤΗΤΑ:  </label><asp:TextBox ID="TextBox9" runat="server" MaxLength="80"></asp:TextBox> 
            </td>
           <td>
             <label>ΑΣΦΑΛΙΣΗ:  </label><asp:TextBox ID="TextBox10" runat="server" MaxLength="100" ></asp:TextBox>  
           </td>
       </tr>
       <tr>
            <td  colspan="2">
                <label>ΚΑΤΑΣΤΑΣΗ ΥΓΕΙΑΣ:  </label><asp:TextBox ID="TextBox11" runat="server" Width="400" MaxLength="200"></asp:TextBox> 
            </td>
       </tr>
       <tr>
           <td  colspan="2">
            <label>ΠΡΟΗΓΟΥΜΕΝΕΣ ΠΑΘΗΣΕΙΣ/ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ:  </label>
            <br /><asp:TextBox ID="TextBox12" rows="5" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
           </td>
       </tr>
   </table>
  </div>
      <!-- FATHER -->
    <h4 style ="color:cornflowerblue"><b>Ο ΠΑΤΕΡΑΣ</b></h4>
    <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
        <table>
            <tr>
                <td>
                    <b>ΟΝΟΜΑ:</b><asp:Label ID="LabelOnfat" runat="server" Text="LabelOnfat"></asp:Label> 
                </td>
                <td>
                    <b>ΕΠΙΘΕΤΟ:</b><asp:Textbox ID="TextBoxEpfat" runat="server" MaxLength="100"></asp:Textbox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ:  </label><asp:TextBox ID="TextBox13" runat="server" MaxLength="50" ></asp:TextBox> 
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox13" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                 <label>ΤΟΠΟΣ ΚΑΤΑΓΩΓΗΣ:  </label><asp:TextBox ID="TextBox14" runat="server" Width="300" MaxLength="100"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <label>ΕΘΝΙΚΟΤΗΤΑ:  </label><asp:TextBox ID="TextBox15" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                <td>
                    <label>ΚΑΤΑΣΤΑΣΗ ΥΓΕΙΑΣ:  </label><asp:TextBox ID="TextBox16" runat="server" Width="400" MaxLength="200"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΠΡΟΗΓΟΥΜΕΝΕΣ ΠΑΘΗΣΕΙΣ/ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ:  </label>
                    <br /><asp:TextBox ID="TextBox17" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΑΣΦΑΛΙΣΗ:  </label><asp:TextBox ID="TextBox18" runat="server" Width="400" MaxLength="300"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΑΔΕΡΦΙΑ(Ονοματεπώνυμο, φύλο, ημερομηνία γέννησης):  </label>
                    <br /><asp:TextBox ID="TextBox19" rows="5" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
        </table>
</div>
            <!-- BABY HISTORY  -->
     <h4 style ="color:cornflowerblue"><b>ΙΣΤΟΡΙΚΟ ΕΓΚΥΜΟΣΥΝΗΣ</b></h4>
     <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
         <table>
             <tr>
                 <td colspan="2">
                    <label>ΤΕΡ:  </label><asp:TextBox ID="TextBox20" runat="server" Width="200" MaxLength="100"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td colspan="2">
                    <label>ΑΝΑΜΕΝΟΜΕΝΗ ΗΜΕΡ. ΤΟΚΕΤΟΥ:  </label><asp:TextBox ID="TextBox21" runat="server" Width="200" MaxLength="50"></asp:TextBox>  
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox21" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
                </td>
             </tr>
             <tr>
                 <td>
                    <label>ΗΛΙΚΙΑ ΠΑΤΕΡΑ ΚΑΤΑ ΤΗ ΣΥΛΛΗΨΗ:  </label><asp:TextBox ID="TextBox22" runat="server" MaxLength="10" ></asp:TextBox>  
                 </td>
                 <td>
                    <label>ΗΛΙΚΙΑ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗ ΣΥΛΛΗΨΗ:  </label><asp:TextBox ID="TextBox23" runat="server" MaxLength="10" ></asp:TextBox>  
                 </td>
             </tr>
             <tr>
                 <td>
                    <label>ΟΜΑΔΑ ΑΙΜΑΤΟΣ ΜΗΤΕΡΑΣ:  </label>
                    <asp:DropDownList ID="DropDownListOmada" runat="server">
                    <asp:ListItem>--</asp:ListItem>
                    <asp:ListItem>Α-</asp:ListItem>
                    <asp:ListItem>Α+</asp:ListItem>
                    <asp:ListItem>Β-</asp:ListItem>
                    <asp:ListItem>Β+</asp:ListItem>
                    <asp:ListItem>ΑΒ-</asp:ListItem>
                    <asp:ListItem>ΑΒ+</asp:ListItem>
                    <asp:ListItem>Ο-</asp:ListItem>
                    <asp:ListItem>Ο+</asp:ListItem>
                    </asp:DropDownList>
                 </td>
             </tr>
         </table>
     </div>
           <!-- ΣΥΝΘΗΚΕΣ  -->
     <h4 style ="color:cornflowerblue"><b>ΣΥΝΘΗΚΕΣ ΖΩΗΣ ΚΑΙ ΣΥΝΗΘΕΙΕΣ ΤΗΣ ΜΗΤΕΡΑΣ ΚΑΤΑ ΤΗΝ ΚΥΗΣΗ</b></h4>
    <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
        <table>
            <tr>
                <td colspan="2">
                   <label>ΧΡΟΝΙΑ ΝΟΣΗΜΑΤΑ(πχ. άσθμα, επιληψία, ρευματικά νοσήματα, νεφρικά νοσήματα):  </label>
                   <br /><asp:TextBox ID="TextBox24" rows="5" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td colspan="2">
                    <label>ΛΟΙΜΩΞΕΙΣ(αναφέρετε κάθε λοίμωξη, οξεία ή χρόνια, μικροβιακή ή ιογενή):  </label>
                    <br /><asp:TextBox ID="TextBox25" rows="4" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td colspan="2">
                    <label>ΑΙΜΟΡΡΑΓΙΑ:  </label>
                    <br /><asp:TextBox ID="TextBox26" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΑΚΙΝΗΣΙΑ(αναφέρετε συγκεκριμένα στοιχεία):  </label>
                    <br /><asp:TextBox ID="TextBox27" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΠΕΡΙΔΕΣΗ ΤΡΑΧΗΛΟΥ:  </label>
                    <br /><asp:TextBox ID="TextBox28" rows="1" TextMode="multiline" runat="server" Width="800" MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΑΛΛΑ ΠΡΟΒΛΗΜΑΤΑ:  </label>
                    <br /><asp:TextBox ID="TextBox29" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>ΑΡΤΗΡΙΑΚΗ ΠΙΕΣΗ(παθολογικές μετρήσεις):  </label>
                    <br /><asp:TextBox ID="TextBox30" rows="2" TextMode="multiline" runat="server" Width="400" MaxLength="400"></asp:TextBox>
                </td>
                <td>
                    <label>ΕΡΓΑΣΤΗΡΙΑΚΕΣ ΕΞΕΤΑΣΕΙΣ(εφόσον είναι παθολογικές):  </label>
                    <br /><asp:TextBox ID="TextBox31" rows="2" TextMode="multiline" runat="server" Width="400" MaxLength="400"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΦΑΡΜΑΚΑ:  </label>
                    <br /><asp:TextBox ID="TextBox32" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                <label>ΚΑΠΝΙΣΜΑ:  </label>
                        <asp:DropDownList ID="DropDownListSmoke" runat="server">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>1-5 ημερησίως</asp:ListItem>
                        <asp:ListItem>5-10 ημερησίως</asp:ListItem>
                        <asp:ListItem>10-20 ημερησίως</asp:ListItem>
                        <asp:ListItem>1-2 πακέτα</asp:ListItem>
                    </asp:DropDownList>
              <br /><asp:TextBox ID="TextBox33" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                </td> 
          </tr>
          <tr>
              <td colspan="2">
                <label>ΑΛΚΟΟΛ - ΑΛΛΑ:  </label>
                <br /><asp:TextBox ID="TextBox34" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                 <asp:Panel ID="Panel1" runat="server"></asp:Panel>
              </td>
          </tr>
            </table> 
    </div>
         <asp:Button ID="Button1" runat="server" Text="Προσθήκη στοιχείων" />
         <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        <div style="text-align:right; font-size:x-small">
           <asp:Label ID="Label2" runat="server" ForeColor="blue" Text="Label" Visible="False"></asp:Label>
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
