﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainerProfile.aspx.cs" Inherits="TrainerProfile" %>

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

        <div class="collapse navbar-collapse" id="navbarColor02">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#">About<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Programs</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Pricing</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Contact</a>
                </li>
                <li class="nav-item dropdown">
                   <a class="nav-link fa fa-bars" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="true"></a>
                    <div class="dropdown-menu show" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 42px, 0px);">
                        <a class="dropdown-item" href="#">Profile</a>
                        <a class="dropdown-item" href="#">Register</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">Log out</a>
                    </div>
                </li>
            </ul>
        </div>
        
    </nav>
     
</head>

<body>
    <div class="profilePic">
        <img src="img_src/avt.png" class="avatar" runat="server"/>
        <strong><asp:Label CssClass="UsernameLabel" runat="server" ID="Username" Text="TrainerName"></asp:Label></strong>
        <asp:Label CssClass="IntroLabel" ID="short_intro" runat="server" Text="Label">short intro</asp:Label>
        <span class="badge badge-pill badge-primary gym-span trainer-span">gym</span>
        <span class="badge badge-pill badge-secondary yoga-span trainer-span">yoga</span>
        <span class="badge badge-pill badge-success trainer-span">bounding</span>
        <span class="badge badge-pill badge-danger crossfit-span trainer-span">crossfit</span>
        <span class="badge badge-pill badge-warning diet-span trainer-span">diet</span>
        <span class="badge badge-pill badge-info fitness-span trainer-span">fitness</span>
        <span class="badge badge-pill badge-light trainer-span">Light</span>
        <span class="badge badge-pill badge-dark trainer-span">Dark</span>

    </div>

    <div class="info_section" runat="server">
        <form id="frm" runat="server">
            <asp:TextBox CssClass="BioText" id="txt" runat="server" Text="testing" Disabled="disabled"/><br /><br />
            <asp:Button Cssclass="btn btn-warning" type="button" ID="BioModifyButton" runat="server" Text="Modify" />
        </form>
    </div>
</body>

</html>