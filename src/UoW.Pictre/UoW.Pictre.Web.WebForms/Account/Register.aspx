<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Account.Register" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="~/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="~/Content/css/register.css" type="text/css" />
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/register.css" type="text/css" />
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>First Name:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FName"
                                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Last Name:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LName" CssClass="form-control"" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LName"
                                    CssClass="text-danger" ErrorMessage="The Last Name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Gender" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>I am:</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Gender" runat="server" style="width:150px">
                    <asp:ListItem Text="Select Sex:" Value="0" ></asp:ListItem> 
                    <asp:ListItem Text="Male"  Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Unspecified" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Gender"
                    CssClass="text-danger" ErrorMessage="The Gender field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DOB" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Date of Birth:</asp:Label>
            <div class="col-md-10">
                <div style="float:left;">
                    <asp:TextBox runat="server" ID="DOB"  CssClass="form-control" />
                </div>
                <div>
                    <asp:Image ID="calenderImg" style="height:40px;width:40px;" runat="server" ImageUrl="../Content/Images/Google-Calendar-icon.png" />
                </div>

                <ajaxtoolkit:CalendarExtender runat="server"
                    TargetControlID="DOB"
                    Format="MMMM d, yyyy" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="DOB" PopupButtonID="calenderImg">
                </ajaxToolkit:CalendarExtender>

                <asp:RequiredFieldValidator runat="server" ControlToValidate="DOB"
                    CssClass="text-danger" ErrorMessage="The Date of Birth field is required." />
            </div>
        </div>

        <div class="form-group">
            
            
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Your Email:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
