<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainerCatalog.aspx.cs" Inherits="TrainerCatalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trainer Catalogue Page</title>
    
    <link href="~/Style/boostrap-superhero.css" rel="stylesheet" />
    <link href="Style/TrainerCatalogStyle.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="#">Personal Fit</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

        <div class="collapse navbar-collapse" id="navbarColor02">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item ">
                    <a class="nav-link" href="#">About</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="#">Trainer Catalog<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Articles</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Community</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Store</a>
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
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="MyPlaceholder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>

