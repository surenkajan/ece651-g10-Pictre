<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Account.ForgotPassword" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/forgotpwd.css" type="text/css" />
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="form-horizontal">
                    <h4>Forgot your password?</h4>
                    <hr />
                    <%--                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>--%>

                    <asp:PlaceHolder ID="SecQueGetSubmitHolder" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="The email field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="SecQueGetSubmitBtn" OnClick="SecQueGetSubmitBtn_Click" runat="server" Text="Retrieve" CssClass="btn btn-default" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Label ID="wrongEmailErrormsg" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </asp:PlaceHolder>




                    <asp:PlaceHolder ID="securityquestionsHolder" runat="server" Visible="false">
                        <div class="security-questions-div" id="securityquestionsdiv">
                            <%--<div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Question1txt" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>What is your Dog Name?</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Question1txt" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Question1txt"
                                        CssClass="text-danger" ErrorMessage="The answered is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Question2txt" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>What is your first school name??</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Question2txt" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Question2txt"
                                        CssClass="text-danger" ErrorMessage="The answered is required." />
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <asp:Label runat="server" CssClass="col-md-2 control-label">Security Questions:</asp:Label>
                                <br />
                                <br />
                                <asp:Label runat="server" ID="SQuestion1" AssociatedControlID="SQuestion1Ans" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="SQuestion1Ans" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SQuestion1Ans"
                                        CssClass="text-danger" ErrorMessage="Answer to Security Question 1 is required." />
                                </div>
                                <br />
                                <asp:Label runat="server" ID="SQuestion2" AssociatedControlID="SQuestion2Ans" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="SQuestion2Ans" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SQuestion2Ans"
                                        CssClass="text-danger" ErrorMessage="Answer to Security Question 2 is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <%--<asp:Button runat="server" OnClick="Forgot" Text="Email Link" CssClass="btn btn-default" />--%>
                                    <asp:Button runat="server" ID="SecQueAnsSubmitBtn" Text="Submit Answers" OnClick="SecQueAnsSubmitBtn_Click" CssClass="btn btn-default" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Label ID="wrongAnsErrormsg" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>

                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <p class="text-info">
                    Please check your email to reset your password.
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
