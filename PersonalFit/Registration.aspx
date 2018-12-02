<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link href="Style/boostrap-superhero.css" rel="stylesheet" />
    <link href="Style/RegistrationStyle.css" rel="stylesheet" />
</head>

<body>
    <a href ="Default.aspx">Home</a> | <a href ="#">Registration</a>
    <form id="form1" runat="server">
        <p class="header">PersonalFit Registration</p>
        <div class="InfoSection">
            <p>Enter First Name</p>
            <asp:TextBox ID="firstNameTextBox" Text ="" runat="server" PlaceHolder="First Name"/>
            <asp:Label CssClass="" ID="firstNameTextBoxLabel" runat="server"></asp:Label>
            <br/>

            <p>Enter Middle Name</p>
            <asp:TextBox ID="middleNameTextBox" Text ="" runat="server" PlaceHolder="Middle Name"/>
            <asp:Label ID="middleNameTextBoxLabel" runat="server" Text=""></asp:Label>
            <br/>

            <p>Enter Last Name</p>
            <asp:TextBox ID="lastNameTextBox" Text ="" runat="server" PlaceHolder="Last Name"/>
            <asp:Label ID="lastNameTextBoxLabel" runat="server" Text=""></asp:Label>
            <br/>

            <p>Enter Email</p>
            <asp:TextBox ID="emailTextBox" Text ="" runat="server" PlaceHolder="Email"/>
            <asp:Label ID="emailTextBoxLabel" runat="server" Text=""></asp:Label>
            <br/>

            <p>Enter Phone Number</p>
            <asp:TextBox ID="phoneNumberTextBox" Text ="" runat="server" PlaceHolder="Phone Number"/>
            <asp:Label ID="phoneNumberTextBoxLabel" runat="server" Text=""></asp:Label>
            <br/>

            <p>Create Username</p>
            <asp:TextBox ID="usernameTextBox" Text ="" runat="server" PlaceHolder="Username"/>
            <asp:Label ID="usernameTextBoxLabel" runat="server" Text=""></asp:Label>
            <br/>

            <p>Create Password</p>
            <asp:TextBox ID="passwordTextBox" Text ="" runat="server" PlaceHolder="Password"/>
            <asp:Label ID="passwordTextBoxLabel" runat="server" Text=""></asp:Label>

            <div class="custom-control custom-checkbox">
                <input type="checkbox" class="custom-control-input" id="customCheck1" checked="" runat="server"/>
                <label class="custom-control-label" for="customCheck1">Do you want to become an online personal trainer?</label>
            </div>

            <br/>
            <br/>
            <asp:Button CssClass="btn btn-success" ID="regButton" Text="REGISTER"  runat="server" OnClick="registerEventMethod"/>
        </div>
    </form>
</body>
</html>


<!--
mysql> CREATE USER 'finley'@'localhost' IDENTIFIED BY 'password';
mysql> GRANT ALL PRIVILEGES ON *.* TO 'finley'@'localhost'
->     WITH GRANT OPTION;
mysql> CREATE USER 'finley'@'%' IDENTIFIED BY 'password';
mysql> GRANT ALL PRIVILEGES ON *.* TO 'finley'@'%'
->     WITH GRANT OPTION;
mysql> CREATE USER 'admin'@'localhost' IDENTIFIED BY 'password';
mysql> GRANT RELOAD,PROCESS ON *.* TO 'admin'@'localhost';
mysql> CREATE USER 'dummy'@'localhost';
                                                
    -->