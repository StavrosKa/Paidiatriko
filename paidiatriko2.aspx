<%@ Page Title="Βιβλιάριο Υγείας Παιδιού-Περιγγενητικά στοιχεία" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="paidiatriko2.aspx.vb" Inherits="nosilia.paidiatriko2" %>
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

<script type="text/javascript">
    function viewOr(value) {
        if (value.style.display == 'none') {
            value.style.display = '';
        } else {
            value.style.display = 'none';
        }
    }
</script>

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
        <li class="current"><a href="#tab-1"><b><span id="pi1" runat="server"></span>Περιγεννητικα</b></a></li>
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
        <h4 style ="color:cornflowerblue"><b>ΠΕΡΙΓΕΝΝΗΤΙΚΟ ΙΣΤΟΡΙΚΟ</b></h4>
        <h4><b>Ο ΤΟΚΕΤΟΣ</b></h4>
    <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
        <table>
            <tr>
                <td>
                    <label>ΗΜΕΡΟΜΗΝΙΑ:  </label><asp:TextBox ID="TextBox35" runat="server" Width="100" MaxLength="20"></asp:TextBox> 
                    <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" ClearTime="True" Format="dd/MM/yyyy" TargetControlID="TextBox35" TodaysDateFormat="dd MMMM yyyy" Enabled="True"></asp:CalendarExtender>
                </td>
                <td>
                    <label>ΩΡΑ:  </label><asp:TextBox ID="TextBox36" runat="server" Width="100" MaxLength="20"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΚΛΙΝΙΚΗ/ΝΟΣΟΚΟΜΕΙΟ:  </label><asp:TextBox ID="TextBox37" runat="server" Width="300" MaxLength="100"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                   <label>ΤΟΠΟΣ:  </label><asp:TextBox ID="TextBox38" runat="server" Width="300" MaxLength="100"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΤΟΚΟΣ:  </label> 
                    <label>ΔΙΑΡΚΕΙΑ ΚΥΗΣΗΣ(ΕΒΔΟΜΑΔΕΣ):  </label><asp:TextBox ID="TextBox39" runat="server" Width="50" MaxLength="10"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="ΦΥΣΙΟΛΟΓΙΚΟΣ" />
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="ΚΕΦΑΛΙΚΗ ΠΡΟΒΟΛΗ"/>
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="ΙΣΧΙΑΚΗ ΠΡΟΒΟΛΉ" />
                    <br />
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="ΕΠΙΠΛΟΚΕΣ"/>
                    <br />
                    <asp:CheckBox ID="CheckBox5" runat="server" Text="ΜΕ ΕΠΕΜΒΑΣΗ"/>
                    <asp:CheckBox ID="CheckBox6" runat="server" Text="ΜΕΤΑΣΧΗΜΑΤΙΣΜΟΣ"/>
                    <br />
                    <asp:CheckBox ID="CheckBox7" runat="server" Text="ΚΑΙΣΑΡΙΚΗ ΤΟΜΗ"/>
                    <asp:CheckBox ID="CheckBox8" runat="server" Text="ΜΕ ΑΝΑΡΡΟΦΗΤΗΡΑ"/>
                    <br />
                    <asp:CheckBox ID="CheckBox9" runat="server" Text="ΕΜΒΡΥΟΥΛΚΙΑ"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>ΑΛΛΕΣ ΕΠΕΜΒΑΣΕΙΣ ΚΑΙ ΑΙΤΙΑ:  </label>
                    <br /><asp:TextBox ID="TextBox40" rows="3" TextMode="multiline" runat="server" Width="800" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
        </table>                
    </div>
      <h4 style ="color:orchid"><b>ΤΟ ΝΕΟΓΕΝΝΗΤΟ</b></h4> 
      <h4 style ="color:orchid"><b>ΠΡΩΤΗ ΕΞΕΤΑΣΗ ΜΕΤΑ ΤΗ ΓΕΝΝΗΣΗ</b></h4>
      <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
      <table border="1" style="width:50%; border:solid orchid; border-collapse: collapse;">
        <tr>
         <td><b>ΒΑΡΟΣ (Kgr)</b></td>
         <td><b>ΜΗΚΟΣ (cm)</b></td>		
         <td><b>ΠΕΡΙΜΕΤΡΟΣ ΚΕΦΑΛΙΟΥ (cm)</b></td>
         </tr>
        <tr>
          <td>
              <asp:TextBox ID="TextBox41" runat="server" MaxLength="50"></asp:TextBox></td>
           <td>
               <asp:TextBox ID="TextBox42" runat="server" MaxLength="50"></asp:TextBox></td>		
            <td>
                <asp:TextBox ID="TextBox43" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
      </table>
     <table border="1" style="width:60%; border:solid orchid; border-collapse: collapse;">
        <tr>
         <td><b>ΒΑΘΜΟΛΟΓΗΣΗ APGAR</b></td>
         <td>1 min: 1 min: <asp:TextBox ID="TextBox44" runat="server" MaxLength="50"></asp:TextBox></td>		
         <td>5 min: <asp:TextBox ID="TextBox45" runat="server" MaxLength="50"></asp:TextBox></td>
         <td>10 min: <asp:TextBox ID="TextBox46" runat="server" MaxLength="50"></asp:TextBox></td>
         </tr>
      </table>
        <asp:CheckBox ID="CheckBox10" runat="server" Text="ΚΥΑΝΩΣΗ" />
        <asp:CheckBox ID="CheckBox11" runat="server" Text="ΑΝΤΙΔΡΑΣΗ ΣΤΟΝ ΗΧΟ"/>
        <br />
        <asp:CheckBox ID="CheckBox12" runat="server" Text="ΕΚΛΑΨΕ ΑΜΕΣΩΣ"/>
        <asp:CheckBox ID="CheckBox13" runat="server" Text="ΟΡΑΣΗ(ΦΩΤΟΚΙΝΙΤΙΚΗ ΑΝΤΙΔΡΑΣΗ)"/>
        <br />
        <asp:CheckBox ID="CheckBox14" runat="server" Text="ΚΡΙΣΗ ΑΠΝΟΙΑΣ"/>
        <asp:CheckBox ID="CheckBox15" runat="server" Text="ΦΥΣΙΟΛΟΓΙΚΟΣ ΜΥΪΚΟΣ ΤΟΝΟΣ"/>
        <br />
        <asp:CheckBox ID="CheckBox16" runat="server" Text="ΚΑΡΔΙΑΚΟ ΦΥΣΗΜΑ"/>
        <asp:CheckBox ID="CheckBox17" runat="server" Text="ΦΥΣΙΟΛΟΓΙΚΗ ΚΙΝΗΤΙΚΟΤΗΤΑ"/>
        <br />
        <asp:CheckBox ID="CheckBox18" runat="server" Text="ΗΠΑΤΟΜΕΓΑΛΙΑ"/>
        <asp:CheckBox ID="CheckBox19" runat="server" Text="ΠΡΟΣΟΧΗ - ΕΓΡΗΓΟΡΣΗ"/>
        <br />
        <asp:CheckBox ID="CheckBox20" runat="server" Text="ΣΠΛΗΝΟΜΕΓΑΛΙΑ"/>
        <br />

          <table>
              <tr>
                  <td>
                    <label>ΙΣΧΙΑ  </label><asp:TextBox ID="TextBox47" runat="server" MaxLength="50"></asp:TextBox>
                  </td>
                  <td>
                    <label>ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ  </label><asp:TextBox ID="TextBox48" runat="server" MaxLength="50"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                     <asp:CheckBox ID="CheckBox21" runat="server" Text="ΠΗΡΕ ΟΞΥΓΟΝΟ;" onclick="viewOr(document.getElementById('oksygono'))" />
                     <span id="oksygono" style="display:none" runat="server" clientidmode="Static"><label>ΓΙΑ ΠΟΣΟ ΧΡΟΝΙΚΟ ΔΙΑΣΤΗΜΑ </label><asp:TextBox ID="TextBox49" runat="server"></asp:TextBox></span>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <asp:CheckBox ID="CheckBox22" runat="server" Text="ΜΠΗΚΕ ΣΕ ΘΕΡΜΟΚΟΙΤΙΔΑ;" onclick="viewOr(document.getElementById('thermo'))" />
                    <span id="thermo" style="display:none" runat="server" clientidmode="Static"><label>ΠΟΣΕΣ ΜΕΡΕΣ  </label><asp:TextBox ID="TextBox50" runat="server"></asp:TextBox></span>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <label>ΑΙΤΙΑ:  </label>
                    <br />
                    <asp:TextBox ID="TextBox51" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="500"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <asp:CheckBox ID="CheckBox23" runat="server" Text="ΛΟΙΜΩΞΗ" onclick="viewOr(document.getElementById('loimo'))" />
                    <span id="loimo" style="display:none" runat="server" clientidmode="Static"><asp:TextBox ID="TextBox52" runat="server"></asp:TextBox></span>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <asp:CheckBox ID="CheckBox24" runat="server" Text="ΣΠΑΣΜΟΙ" onclick="viewOr(document.getElementById('spasmoi'))" />
                    <span id="spasmoi" style="display:none" runat="server" clientidmode="Static"><asp:TextBox ID="TextBox53" runat="server"></asp:TextBox></span>
                  </td>
              </tr>
              <tr>
                  <td>
                    <asp:CheckBox ID="CheckBox25" runat="server" Text="ΙΚΤΕΡΟΣ" onclick="viewOr(document.getElementById('ikteros'))" />
                    <span id="ikteros" style="display:none" runat="server" clientidmode="Static"><asp:TextBox ID="TextBox54" runat="server"></asp:TextBox></span>
                  </td>
                  <td>
                    <label>ΧΟΛΕΡΥΘΡΙΝΗ  </label>
                    <asp:TextBox ID="TextBox55" runat="server" MaxLength="50"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <label>ΣΥΓΓΕΝΕΙΣ ΑΝΩΜΑΛΙΕΣ  </label><br />
                    <asp:TextBox ID="TextBox56" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="500"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <label>ΘΕΡΑΠΕΥΤΙΚΗ / ΦΑΡΜΑΚΕΥΤΙΚΗ ΑΓΩΓΗ  </label><br />
                    <asp:TextBox ID="TextBox57" rows="5" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                    <label>ΑΙΜΟΛΗΨΙΑ ΓΙΑ:  </label>
                    <asp:CheckBox ID="CheckBox26" runat="server" Text="G-6PD" />
                    <asp:CheckBox ID="CheckBox27" runat="server" Text="PKU" />
                    <asp:CheckBox ID="CheckBox28" runat="server" Text="TSH" />
                    <asp:CheckBox ID="CheckBox29" runat="server" Text="ΓΑΛΑΚΤΟΖΑΙΜΙΑ" />
                  </td>
              </tr>
          </table>
    </div>
        <h4 style ="color:orchid"><b>ΠΛΗΡΟΦΟΡΙΕΣ ΓΙΑ ΤΟ ΠΑΙΔΙ</b></h4>
      <table border="1" style="width:60%; border:solid orchid; border-collapse: collapse;">
        <tr>
         <td><b>ΠΛΗΡΟΦΟΡΙΕΣ - ΣΗΜΕΙΩΣΕΙΣ - ΠΑΡΑΤΗΡΗΣΕΙΣ</b></td>
        </tr>
        <tr>
         <td><b>ΟΜΑΔΑ ΑΙΜΑΤΟΣ RHESUS</b>
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
         <tr>    
         <td><b>ΕΛΛΕΙΨΗ G-6PD</b>
                 <asp:DropDownList ID="DropDownListPD" runat="server">
                    <asp:ListItem>--</asp:ListItem>
                    <asp:ListItem>ΟΧΙ</asp:ListItem>
                    <asp:ListItem>ΝΑΙ</asp:ListItem>
                </asp:DropDownList><br />
             <asp:TextBox ID="TextBox58" runat="server" Width="100%" MaxLength="200"></asp:TextBox></td>    
         </tr>
          <tr>    
         <td><b>ΚΛΗΡΟΝΟΜΙΚΑ ΝΟΣΗΜΑΤΑ</b><asp:TextBox ID="TextBox59" runat="server" Width="100%" MaxLength="200"></asp:TextBox></td>  
         </tr>
          <tr>    
         <td><b>ΛΟΙΜΩΔΗ ΝΟΣΗΜΑΤΑ</b><asp:TextBox ID="TextBox60" runat="server" Width="100%" MaxLength="200"></asp:TextBox></td>     
         </tr>
          <tr>    
         <td><b>ΑΛΛΑ</b><asp:TextBox ID="TextBox61" runat="server" Width="100%" MaxLength="200"></asp:TextBox></td>       
         </tr>
      </table>
        <h4 style ="color:orchid"><b>ΠΑΙΔΙΑΤΡΙΚΗ ΕΞΕΤΑΣΗ</b> </h4> 
        <h4 style ="color:orchid"><b>ΤΗΝ ΗΜΕΡΑ ΤΗΣ ΕΞΟΔΟΥ ΑΠΟ ΤΟ ΜΑΙΕΥΤΗΡΙΟ</b></h4>
      <div style="position:relative;top:-6px;border:solid;border-color:darkblue;border-width:1px;width:100%">
          <table>
            <tr>
                <td>
                    <label>ΒΑΡΟΣ ΣΩΜΑΤΟΣ  </label>
                    <asp:TextBox ID="TextBox62" runat="server" Width="100" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
              <tr>
                  <td>
                     <label>ΝΕΟΓΝΙΚΑ ΑΝΤΑΝΑΚΛΑΣΤΙΚΑ  </label>
                     <br />
                     <asp:TextBox ID="TextBox63" rows="3" TextMode="multiline" runat="server" Width="800" MaxLength="500"></asp:TextBox>
                 </td>
              </tr>
              <tr>
                  <td>
                     <label>ΙΣΧΙΑ  </label>
                     <asp:TextBox ID="TextBox64" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <label>ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ  </label>
                      <asp:TextBox ID="TextBox1" runat="server" Width="300" MaxLength="200"></asp:TextBox>      
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΓΕΝΝΗΤΙΚΑ ΟΡΓΑΝΑ  </label>
                    <asp:TextBox ID="TextBox65" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <label>ΟΙΔΗΜΑ  </label>
                      <asp:TextBox ID="TextBox66" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <label>ΙΚΤΕΡΟΣ  </label>
                      <asp:TextBox ID="TextBox67" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΦΥΣΙΟΛΟΓΙΚΟ ΚΛΑΜΑ  </label>
                    <asp:TextBox ID="TextBox68" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΔΥΣΠΝΟΙΑ  </label>
                    <asp:TextBox ID="TextBox69" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΚΥΑΝΩΣΗ  </label>
                    <asp:TextBox ID="TextBox70" runat="server" Width="300" MaxLength="200"></asp:TextBox>       
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΚΑΡΔΙΑΚΗ ΤΟΝΟΙ  </label>
                    <asp:TextBox ID="TextBox71" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΗΠΑΤΟΜΕΓΑΛΙΑ  </label>
                    <asp:TextBox ID="TextBox72" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΣΠΛΗΝΟΜΕΓΑΛΙΑ  </label>
                    <asp:TextBox ID="TextBox73" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΑΝΤΙΔΡΑΣΗ ΣΤΟΝ ΗΧΟ  </label>
                    <asp:TextBox ID="TextBox74" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                    <label>ΑΝΤΙΔΡΑΣΗ ΣΤΟ ΦΩΣ  </label>
                    <asp:TextBox ID="TextBox75" runat="server" Width="300" MaxLength="200"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                     <label>ΣΥΓΓΕΝΕΙΣ ΑΝΩΜΑΛΙΕΣ  </label><br />
                     <asp:TextBox ID="TextBox76" rows="2" TextMode="multiline" runat="server" Width="800" MaxLength="600"></asp:TextBox>
                  </td>
              </tr>
          </table>
         <table border="1" style="width:60%; border:solid orchid; border-collapse: collapse;">
        <tr>
         <td><b>ΔΙΑΤΡΟΦΗ &nbsp &nbsp</b></td>
         <td><b>ΜΗΤΡΙΚΟΣ ΘΗΛΑΣΜΟΣ</b><asp:TextBox ID="TextBox77" runat="server" Width="70%" MaxLength="100"></asp:TextBox>
             <br /><b>ΓΑΛΑ ΕΜΠΟΡΙΟΥ</b><asp:TextBox ID="TextBox78" runat="server" Width="70%" MaxLength="100"></asp:TextBox>
             <br /><b>ΜΙΚΤΗ ΔΙΑΤΡΟΦΗ</b><asp:TextBox ID="TextBox79" runat="server" Width="70%" MaxLength="100"></asp:TextBox>
         </td>		
         </tr>
        </table>
        <label>ΑΛΛΕΣ ΠΛΗΡΟΦΟΡΙΕΣ ΚΑΙ ΠΑΡΑΤΗΡΗΣΕΙΣ  </label><br />
        <asp:TextBox ID="TextBox80" rows="3" TextMode="multiline" runat="server" Width="800" MaxLength="1000"></asp:TextBox>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
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
