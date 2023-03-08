<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/ChildMaster.master" AutoEventWireup="True" CodeBehind="Results.aspx.cs" Inherits="WebFormsTraining.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ChildContent3" runat="server">
    <div class="jumbotron">
        <h1>Survey answers</h1>
        <div class="row">
            <div class="col-md-4">
                <asp:Repeater ID="RepeaterUsers" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Age</th>
                                    <th scope="col">Gender</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row"><%#Eval("UserId") %></th>
                                    <td><%#Eval("Name") %></td>
                                    <td><%#Eval("Age") %></td>
                                    <td><%#Eval("Gender") %></td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
