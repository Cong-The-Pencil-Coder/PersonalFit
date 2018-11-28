<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgramInfoPage.aspx.cs" Inherits="ProgramInfoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Program Profile Page</title>
    
    <link href="~/Style/boostrap-superhero.css" rel="stylesheet" />
    <link href="Style/ProgramInfoPageStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="#">Personal Fit</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

        <div class="collapse navbar-collapse" id="navbarColor02">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item">
                    <a class="nav-link" href="#">About<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" href="#">Programs Catalog</a>
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
    <form id="form1" runat="server">
        <b /><asp:Label CssClass="prog-label" ID="progLabel" runat="server" Text="Program Name"></asp:Label>
        <asp:TextBox CssClass="DescriptionTextBox" ID="DescriptionTextBox" runat="server" Disabled="disabled"></asp:TextBox>
        <div class="div1">
            <asp:Label CssClass="explan-label" ID="exerplanLabel" runat="server" Text="Exercise Plan"></asp:Label>
            <b /><asp:Table CssClass="exercise-table" id="ExerciseTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Left"></asp:Table> 
            
            <asp:Label CssClass="mealplan-label" ID="mealplanLabel" runat="server" Text="Meal Plan"></asp:Label>
            <b /><asp:Table CssClass="meal-table" id="MealTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center"></asp:Table>  
        </div>
    </form>
    
</body>
</html>
