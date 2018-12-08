<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainerProfileCreationPage.aspx.cs" Inherits="TrainerProfileCreationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- Required meta tags-->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <!-- Title Page-->
    <title>Apply for job by Colorlib</title>

    <!-- Font special for pages-->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet"/>

    <!-- Main CSS-->

    <link href="Style/TrainerProfileCreationPage.css" rel="stylesheet" />
</head>

<body>
    <div class="page-wrapper bg-dark p-t-100 p-b-50">
        <div class="wrapper wrapper--w900">
            <div class="card card-6">
                <div class="card-heading">
                    <h2 class="title">Trainer Profile</h2>
                </div>
                <div class="card-body">
                    <form method="POST" runat="server">
                        <div class="form-row">
                            <div class="name">Full name</div>
                            <div class="value">
                                <input id="fullnametextbox" class="input--style-6" type="text" name="full_name" runat="server"/>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="name">URL Pic</div>
                            <div class="value">
                                <div class="input-group">
                                    <input id="urlpic" class="input--style-6" name="picture" placeholder="urlpicture" runat="server"/>
                                </div>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="name">Short Bio</div>
                            <div class="value">
                                <div class="input-group">
                                    <input id="shortintro" class="input--style-6" name="shortbio" placeholder="short bio" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="name">Long Bio</div>
                            <div class="value">
                                <div class="input-group">
                                    <textarea id="longintro" class="textarea--style-6" name="longbio" placeholder="long bio" runat="server"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <asp:Button CssClass="btn btn--radius-2 btn--blue-2" ID="Button1" runat="server" Text="Submit" OnClick="SubmitEventHandler"/>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</body>
</html>
