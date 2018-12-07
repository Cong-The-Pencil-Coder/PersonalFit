<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgramCreationPage.aspx.cs" Inherits="ProgramCreationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Program Creation Page</title>
    <link href="Style/boostrap-superhero.css" rel="stylesheet" />
    <link href="Style/ProgramCreationPage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
    <table align="center" width ="60%">
        <tr>
            <td>Program Name</td>
            <td><asp:TextBox ID="progname" runat="server" Width ="99%"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Program Duration</td>
            <td><asp:TextBox ID="progduration" runat="server" Width ="99%"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Program Price</td>
            <td><asp:TextBox ID="progprice" runat="server" Width ="99%" ></asp:TextBox></td>
        </tr>

        <tr>
            <td>Program Focus</td>
            <td><asp:TextBox ID="progfocus" runat="server" Width ="99%" ></asp:TextBox></td>
        </tr>

        <tr>
            <td>Program Description</td>
            <td><asp:TextBox ID="progbody" runat="server" Width ="99%" Height ="150px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="ProgramSubmit" runat="server" Text="Submit" OnClick="AddNewProgramToDatabaseButtonEventHandler" />  
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>


        <table class="table table-hover"> 
            <thead>
                <tr class="table-light">
                    <th scope="row">Exercises Name</th>
                    <td>Day</td>
                    <td>#Sets</td>
                    <td>#Reps</td>
                    <td>UrlPic</td>
                </tr>
            </thead>
            <tbody>
                <tr class="table-active">
                    <td><asp:TextBox ID="ExNameTextBox" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="DayTextBox" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="SetTextBox" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="RepTextBox" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="UrlPicTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <asp:PlaceHolder ID="ExerciseList" runat="server"></asp:PlaceHolder>

            </tbody>
        </table>
        <asp:Button ID="ExerciseButton" runat="server" Text="Add Exercise" OnClick="AddingExerciseEventHandler" />
        <asp:Table CssClass="exercise-table" id="ExerciseTable" CellPadding="10" GridLines="Both" HorizontalAlign="Left" runat="server"></asp:Table> 
        

        <br />
        <br />
        <br />
        <table class="table table-hover"> 
            <thead>
                <tr class="table-light">
                    <th scope="row">Meal</th>
                    <td>Time</td>
                    <td>Description</td>
                </tr>
            </thead>
            <tbody>
                <tr class="table-active">
                    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                </tr>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            </tbody>
        </table>
        <asp:Button ID="MealButton" runat="server" Text="Add Meal" OnClick="AddingMealEventHandler"/>
        <asp:Table CssClass="meal-table" id="MealTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Left"></asp:Table> 
    </form>
</body>
</html>
