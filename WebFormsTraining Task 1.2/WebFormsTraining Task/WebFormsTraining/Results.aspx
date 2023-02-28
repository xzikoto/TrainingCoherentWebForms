<%@ Page Title="Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="WebFormsTraining.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Survey answers</h1>
        <div class="row">
            <div class="col-md-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Age</th>
                                    <th scope="col">Gender</th>
                                    <th scope="col">Answer</th>
                                    <th scope="col">Answer</th>
                                    <th scope="col">Answer</th>
                                    <th scope="col">Corrects </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row"><%#Eval("AnswerId") %></th>
                                    <td><%#Eval("Name") %></td>
                                    <td><%#Eval("Age") %></td>
                                    <td><%#Eval("Gender") %></td>
                                    <td><%#Eval("AnswerQuestion1") %></td>
                                    <td><%#Eval("AnswerQuestion2") %></td>
                                    <td><%#Eval("AnswerQuestion3") %></td>
                                    <td><%#Eval("CorrectAnswers") %></td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
