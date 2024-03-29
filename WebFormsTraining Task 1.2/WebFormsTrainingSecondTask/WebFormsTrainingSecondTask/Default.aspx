﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsTrainingSecondTask._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Survey</h1>
                            </div>

                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="userName"><b>Participant name</b></asp:Label><br />
                                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="userName" class="form-control input-sm" placeholder="Task Name"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-4 col-md-offset-1">
                                    <div id="hahaha" class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtCategory"><b>Gender</b></asp:Label><br />
                                        <asp:DropDownList ID="txtCategory" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Text="MALE" />
                                            <asp:ListItem Text="FEMALE" />
                                            <asp:ListItem Text="CHILD" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtdob"><b>Age</b></asp:Label><br />
                                        <asp:TextBox runat="server" required="required" TextMode="Date" Enabled="True" name="BrandName" ID="txtAge" class="form-control input-sm" placeholder="Date "></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Button Text="Save" ID="btnsave" OnClick="btnsave_Click" CssClass="btn btn-primary btn-lg" Width="220px" runat="server" />
                                        <asp:Button Text="Delete" ID="btndlt" OnClick="btndlt_Click" CssClass="btn btn-danger btn-lg" Width="220px" runat="server" />
                                        <asp:Label Text="" ForeColor="Green" Font-Bold="true" ID="lblmessage" CssClass="label label-success" runat="server" />
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="ValidationMessageLabel" ></asp:Label><br />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <h3>HIGH Priority</h3>
                                    <div class="form-group">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridViewHigh" Width="100%" AutoGenerateSelectButton="true" SelectedRowStyle-BackColor="Green" OnSelectedIndexChanged="gv_SelectedIndexChanged" runat="server"></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <h3>MEDIUM Priority</h3>
                                    <div class="form-group">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridViewMedium" Width="100%" AutoGenerateSelectButton="true" SelectedRowStyle-BackColor="Green" OnSelectedIndexChanged="gv_SelectedIndexChanged" runat="server"></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <h3>LOW Priority</h3>
                                    <div class="form-group">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridViewLow" Width="100%" AutoGenerateSelectButton="true" SelectedRowStyle-BackColor="Green" OnSelectedIndexChanged="gv_SelectedIndexChanged" runat="server"></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </section>
                </div>
            </div>
        </section>
    </section>

</asp:Content>
