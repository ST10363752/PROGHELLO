<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcademicManager.aspx.cs" Inherits="PROGHELLO.AcademicManager" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Manager</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: white;
            color: black;
        }
        h2 {
            color: #007bff;
            text-align: center;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        table, th, td {
            border: 1px solid green;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        th {
            background-color: orange;
            color: white;
        }
        .action-button {
            background-color: #28a745;
            color: white;
            padding: 5px 10px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-right: 5px;
        }
        .action-button.reject {
            background-color: #dc3545;
        }
        .navigation-button {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Academic Manager</h2>
            <asp:GridView ID="gvClaims" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClaims_RowCommand" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ClaimNo" HeaderText="Claim No." />
                    <asp:BoundField DataField="LecturerName" HeaderText="Lecturer Name" />
                    <asp:BoundField DataField="ProgramCode" HeaderText="Program Code" />
                    <asp:BoundField DataField="ModuleCode" HeaderText="Module Code" />
                    <asp:BoundField DataField="Rate" HeaderText="Rate/hr" />
                    <asp:BoundField DataField="Hours" HeaderText="Hours" />
                    <asp:BoundField DataField="ClaimAmount" HeaderText="Claim Amount" />
                    <asp:BoundField DataField="AttachedDocuments" HeaderText="Attached Documents" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="action-button" CommandName="Approve" CommandArgument='<%# Eval("ClaimNo") %>' />
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="action-button reject" CommandName="Reject" CommandArgument='<%# Eval("ClaimNo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <!-- View Claims Button -->
            <asp:Button ID="btnViewClaims" runat="server" Text="Go to Programme Coordinator" CssClass="navigation-button" PostBackUrl="~/ProgrammeCoordinator.aspx" />
        </div>
    </form>
</body>
</html>