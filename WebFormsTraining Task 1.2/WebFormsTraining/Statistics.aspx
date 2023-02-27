<%@ Page Title="Statistics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="WebFormsTraining.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Survey statistics</h1>
        <div class="row">
            <div class="col-md-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Question</th>
                                    <th scope="col">Corrects Answers</th>
                                    <th scope="col">Wrong Answers</th>
                                    <th scope="col">Man Correct Answers</th>
                                    <th scope="col">Women Correct Answers</th>
                                    <th scope="col">Man Wrong Answers</th>
                                    <th scope="col">Women Wrong Answers </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row"><%#Eval("QuestionId") %></th>
                                    <td><%#Eval("Question") %></td>
                                    <td><%#Eval("CorrectAnswers") %></td>
                                    <td><%#Eval("WrongAnswers") %></td>
                                    <td><%#Eval("CorrectManAnswers") %></td>
                                    <td><%#Eval("CorrectWomenAnswers") %></td>
                                    <td><%#Eval("WrongManAnswers") %></td>
                                    <td><%#Eval("WrongWomenAnswers") %></td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
