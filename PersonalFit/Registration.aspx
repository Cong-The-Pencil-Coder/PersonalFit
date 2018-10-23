<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <p>This is the registration page</p>
    <a href ="Default.aspx">Home</a> | <a href ="#">Registration</a>
    <form id="form1" runat="server">
        <div>
            <p>Enter First Name</p>
            <asp:TextBox ID="firstNameTextBox" Text ="" runat="server" />

            <p>Enter Middle Name</p>
            <asp:TextBox ID="middleNameTextBox" Text ="" runat="server" />

            <p>Enter Last Name</p>
            <asp:TextBox ID="lastNameTextBox" Text ="" runat="server" />

            <p>Enter Email</p>
            <asp:TextBox ID="emailTextBox" Text ="" runat="server" />

            <p>Enter Phone Number</p>
            <asp:TextBox ID="phoneNumberTextBox" Text ="" runat="server" />

            <p>Create Username</p>
            <asp:TextBox ID="usernameTextBox" Text ="" runat="server" />

            <p>Create Password</p>
            <asp:TextBox ID="passwordTextBox" Text ="" runat="server" />

            <asp:Button ID="regButton" Text="REGISTER"  runat="server" OnClick="registerEventMethod"/>
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