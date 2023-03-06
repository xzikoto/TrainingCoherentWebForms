﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/ChildMaster.master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="WebFormsTraining._Default" %>

<asp:Content ID="nestedContent" ContentPlaceHolderID="ChildContent3" runat="server">
    <div class="jumbotron">
        <h1>Survey</h1>
        <p class="lead">This survey is about investigating knowledge of people about the most famous capitals?</p>

        <div class="form-group">
            <label for="Name">Name</label>
            <asp:TextBox class="form-control" ID="Name" aria-describedby="emailHelp" placeholder="Enter name" runat="server" required="required"></asp:TextBox>
            <small id="nameHelp" class="form-text text-muted">Please, enter your name</small>
        </div>
        <div class="form-group">
            <label for="Age">Age</label>
            <asp:TextBox class="form-control" ID="age" aria-describedby="AgeHelp" placeholder="Enter age" runat="server" CausesValidation="true" required="required"></asp:TextBox>
            <small id="AgeHelp" class="form-text text-muted">Please, enter your Age</small>
            <br>
            <asp:CustomValidator runat="server" ValidateEmptyText="True" ID="cusCustom" ControlToValidate="age" ValidationGroup="submission" OnServerValidate="cusCustom_ServerValidate" ErrorMessage="Age must be between 0 and 120!" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="Gender" AssociatedControlID="txtCategory"><b>Gender</b></asp:Label><br />
            <asp:DropDownList ID="txtCategory" CssClass="form-control input-sm" runat="server" required="required">
                <asp:ListItem Text="MAN" />
                <asp:ListItem Text="WOMAN" />
                <asp:ListItem Text="CHILD" />
            </asp:DropDownList>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Repeater ID="RepeaterQuestions" runat="server" OnItemDataBound="OnItemDataBound">
                    <ItemTemplate>
                        <table id="quizTable">
                            <tr>
                                <td>
                                    <asp:Label ID="QuestionId" runat="server" Text='<%#Eval("QuestionId") %>'></asp:Label>
                                    : 
                                    <asp:Label ID="Question" runat="server" Text='<%#Eval("Question") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr class="quizOptions">
                                <td scope="col-8">
                                    <asp:Repeater ID="repeaterOptions" runat="server">
                                        <ItemTemplate>
                                            <asp:RadioButton CssClass="tdrbn" runat="server" Text='<%#Eval("Option") %>'></asp:RadioButton>
                                            <asp:Label ID="OptionId" hidden="true" runat="server" Text='<%#Eval("OptionId") %>'></asp:Label>
                                            <asp:Label ID='IsCorrect' hidden="true" runat="server" Text='<%#Eval("IsCorrect") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    </br> 
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelUserSelectedOption" hidden="true" runat="server" Text="Please, answer all the questions!"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
            </div>
        </div>
    </div>



</asp:Content>

