<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/ChildMaster.master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="WebFormsTraining._Default" %>

<asp:Content ID="nestedContent" ContentPlaceHolderID="ChildContent3" runat="server">
    <div class="jumbotron">
        <h1>Survey</h1>
        <p class="lead">This survey is about investigating knowledge of people about the most famous capitals?</p>
      
         <div class="form-group">
    <label for="exampleInputEmail1">Name</label>
     <asp:TextBox class="form-control" ID="Name" aria-describedby="emailHelp" placeholder="Enter name" runat="server"></asp:TextBox>
    <small id="nameHelp" class="form-text text-muted">Please, enter your name</small>
     </div>
        <div class="form-group">
    <label for="exampleInputEmail1">Age</label>
     <asp:TextBox class="form-control" ID="Age" aria-describedby="AgeHelp" placeholder="Enter age" runat="server"></asp:TextBox>
    <small id="AgeHelp" class="form-text text-muted">Please, enter your Age</small>
     </div> 
        <div class="form-group">
    <label for="exampleInputEmail1">Gender</label>
     <asp:TextBox class="form-control" ID="Gender" aria-describedby="genderHelp" placeholder="Enter gender" runat="server"></asp:TextBox>
    <small id="genderHelp" class="form-text text-muted">Please, enter your gender</small>
     </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                  <asp:Label ID="QuestionId" runat="server" Text='<%#Eval("QuestionId") %>'></asp:Label> :  <asp:Label ID="Question" runat="server" Text='<%#Eval("QUESTION") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td scope="col-8">
                                    <asp:RadioButton  ID="option1" runat="server" Text='<%#Eval("Option1") %>' GroupName="QuestionAnswers"></asp:RadioButton>

                                    <asp:RadioButton ID="option2" runat="server" Text='<%#Eval("Option2") %>' GroupName="QuestionAnswers"></asp:RadioButton>

                                    <asp:RadioButton ID="option3" runat="server" Text='<%#Eval("Option3") %>' GroupName="QuestionAnswers"></asp:RadioButton>

                                    <asp:RadioButton ID="option4" runat="server" Text='<%#Eval("Option4") %>' GroupName="QuestionAnswers"></asp:RadioButton>

                                    </br>   

                                <asp:Label ID="LabelCorrectAnswer" runat="server" Text='<%#Eval("Correctans") %>' Visible="false"></asp:Label>
                               
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelUserSelectedOption" runat="server" Text=""></asp:Label>
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

