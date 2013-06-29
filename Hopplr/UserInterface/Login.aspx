<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hopplr - Connexion</title>
    <link rel="Stylesheet" type="text/css" href="~/Content/css/style1.css"/>
</head>
<body>
    <a href="/Blog/Index">Acceder à la liste des blogs</a>
    <img id="home_page" src="Content/images/home_page.png" alt="home page logo"/>
    <h1>Createur de microblogs</h1>
    <h2>Connectez-vous maintenant</h2>
    <form id="form" runat="server">
    <div id="login_div">
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/User/Profile">
        </asp:Login>
    </div>
    </form>
    <div id="home_footer">
        Bienvenue sur Hopplr ! Creez et partagez vos microblogs pour echanger sur vos passions, 
        rejoignez le reseau et suivez vos bloggeurs favoris !
    </div>
</body>
</html>
