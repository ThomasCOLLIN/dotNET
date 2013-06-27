<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hopplr - Connexion</title>
</head>
<body>
    <a href="/Blog/Index">Acceder à la liste des blogs</a>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/User/Index">
        </asp:Login>
    </div>
    </form>
</body>
</html>
