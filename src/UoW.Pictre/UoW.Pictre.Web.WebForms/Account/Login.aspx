<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/login.css" type="text/css" />
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
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
                    </div>
                    <%--<div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>User Name:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UName"
                                                CssClass="text-danger" ErrorMessage="The User Name field is required." />
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" ID="lbl_RememberMe" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" style="margin-top: -35px;"/>
                        </div>
                    </div>
                </div>
                <div class="register-forgot">
                    <div class="register-user" id="registerUser">
                        <p>
                            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                        </p>
                    </div>
                    <div class="forgot-password" id="forgorPassword">
                        <p>
                             <%--Enable this once you have account confirmation enabled for password reset functionality--%>
                            <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>                           
                        </p>
                    </div>
                </div>
                
                
            </section>
        </div>

        <%--<div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />--%>
                <%--<h4>Use another service to log in.</h4>
                 <hr />
                <div class="form-group">
                    <div class="form-group">
                        <img class="login-with-fb login-with" src="../Content/Images/login-with-facebook.png" />
                    </div><br />
                    <div class="form-group">
                        <img class="login-with-fb login-with" src="../Content/Images/login-with--google.png" />
                    </div>
                </div>--%>
<%--            </section>
        </div>--%>
    </div>
</asp:Content>
