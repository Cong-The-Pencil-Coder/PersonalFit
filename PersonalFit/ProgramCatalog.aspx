<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgramCatalog.aspx.cs" Inherits="ProgramCatalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Program Catalogue Page</title>
    
    <link href="~/Style/boostrap-superhero.css" rel="stylesheet" />
    <link href="~/Style/ProgramCatalogStyle.css" rel="stylesheet" />

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
                </li>btn-warning
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
    <form id="form1" runat="server">
        <div>
            <div class="card bg-light mb-3 holder" style="max-width: 20rem;">
                  <div class="card-header">Header</div>
                  <div class="card-body">
                    <h4 class="card-title">Light card title</h4>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <asp:Button class="btn btn-warning" ID="SubmitButton" runat="server" Text="Button" OnClick="SubmitEventHandler"/>
                  </div>
            </div>

            <asp:PlaceHolder ID="MyPlaceholder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
