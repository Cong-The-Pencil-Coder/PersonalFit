<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientListPage.aspx.cs" Inherits="ClientListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Client List Page</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Style/font-awesome.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Style/animate.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Style/select2.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Style/perfect-scrollbar.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Style/ClientListPageStyle2.css" rel="stylesheet" />
    <link href="Style/ClientListPageStyle1.css" rel="stylesheet" />
    <link href="Style/boostrap-superhero.css" rel="stylesheet" />
<!--===============================================================================================-->
</head>
<body>
	<div class="limiter">
		<div class="container-table100">
			<div class="wrap-table100">
				<div class="table100 ver1 m-b-110">
					<div class="table100-head">
						<table>
							<thead>
								<tr class="row100 head">
									<th class="cell100 column1">Program Name</th>
									<th class="cell100 column2">Type</th>
									<th class="cell100 column3">Hours</th>
									<th class="cell100 column4">Client Name</th>
								</tr>
							</thead>
						</table>
					</div>

					<div class="table100-body js-pscroll">
						<table>
							<tbody>
								<tr class="row100 body">
									<td class="cell100 column1">Like a butterfly</td>
									<td class="cell100 column2">Boxing</td>
									<td class="cell100 column3">9:00 AM - 11:00 AM</td>
									<td class="cell100 column4">Aaron Chapman</td>
								</tr>

								<tr class="row100 body">
									<td class="cell100 column1">Mind & Body</td>
									<td class="cell100 column2">Yoga</td>
									<td class="cell100 column3">8:00 AM - 9:00 AM</td>
									<td class="cell100 column4">Adam Stewart</td>
								</tr>
							</tbody>
						</table>

                        <asp:Table ID="Table1" runat="server"></asp:Table>
					</div>
				</div>
            </div>
         </div>
     </div>
 </body>
</html>
