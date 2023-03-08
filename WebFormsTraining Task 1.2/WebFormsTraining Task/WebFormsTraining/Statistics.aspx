<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/ChildMaster.master" AutoEventWireup="True" CodeBehind="Statistics.aspx.cs" Inherits="WebFormsTraining.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ChildContent3" runat="server">
    <div class="jumbotron">
        <h1>Survey statistics</h1>
        <div class="row">
            <div class="col-md-4">
               <asp:Repeater ID="RepeaterStatistics" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">Correct Overall</th>
                                    <th scope="col">Wrong Overall</th>
                                    <th scope="col">Correct Man</th>
                                    <th scope="col">Wrong Men</th>
                                    <th scope="col">Correct Women</th>
                                    <th scope="col">Wrong Women</th>
                                    <th scope="col">Correct Childs</th>
                                    <th scope="col">Wrong Childs</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row"><%#Eval("CorrectOverall") %></th>
                                    <td><%#Eval("WrongOverall") %></td>
                                    <td><%#Eval("CorrectMen") %></td>
                                    <td><%#Eval("WrongMen") %></td>
                                    <td><%#Eval("CorrectWomen") %></td>
                                    <td><%#Eval("WrongWomen") %></td>
                                    <td><%#Eval("CorrectChilds") %></td>
                                    <td><%#Eval("WrongChilds") %></td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
