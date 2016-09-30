<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />

</head>
<body>

	<div class="wrapper">
	<div class="container">
		<h1>Welcome</h1>
		
		<form id="form1" runat="server">
			<asp:TextBox ID="username" runat="server" placeholder="Username" required="required"></asp:TextBox>
            <asp:TextBox ID="password" TextMode="Password" placeholder="Password" runat="server" required="required"></asp:TextBox>
&nbsp;<asp:Button ID="Login" runat="server" Height="52px" OnClick="login" Text="Login" Width="221px" BackColor="White" ForeColor="#53E3A6" />
        </form>
	</div>
	
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
	</div>
	    <script src="JavaScript.js"></script>
</body>
</html>