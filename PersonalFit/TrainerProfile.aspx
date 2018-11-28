<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainerProfile.aspx.cs" Inherits="TrainerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trainer Profile Page</title>
    
    <link href="~/Style/boostrap-superhero.css" rel="stylesheet" />
    <link href="~/Style/TrainerProfileStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="#">Personal Fit</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

        <div class="collapse navbar-collapse" id="navbarColor02" runat="server">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#">About<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item" runat="server">
                    <a class="nav-link" href="ProgramCatalog.aspx">Programs</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Pricing</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Contact</a>
                </li>
                <li class="nav-item dropdown">
                   <a class="nav-link fa fa-bars" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="true" style="margin-left:68rem;"></a>
                    <div class="dropdown-menu show" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 42px, 0px); margin-left:60rem;">
                        <a class="dropdown-item" href="#">Home</a>
                        <a class="dropdown-item" href="#">My Programs</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="Default.aspx">Log out</a>
                    </div>
                </li>
            </ul>
        </div>
        
    </nav>

</head>

<body>
    <div class="profilePic">
        <asp:Image src="img_src/avt.png" Cssclass="avatar" ID="avatar" runat="server" />
        <strong><asp:Label CssClass="UsernameLabel" runat="server" ID="Username" ></asp:Label></strong>
        <asp:Label CssClass="IntroLabel" ID="short_intro" runat="server">short intro</asp:Label>
        <asp:PlaceHolder ID="SpecialtySpanHolder" runat="server"></asp:PlaceHolder>
    </div>

    <div class="info_section" runat="server">
        <form id="frm" runat="server">
            <asp:Label CssClass="BioText" id="long_intro" runat="server" Text="testing"/><br /><br />

        </form>
    </div>
</body>

</html>
