<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contatti.aspx.cs" Inherits="Rubrica.Contatti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-center flex-column mt-5 ">
            <div> 
           Nome: <asp:TextBox CssClass="form-control" ID="Nome" runat="server"></asp:TextBox>
           Cognome:  <asp:TextBox ID="Cognome" CssClass="form-control" runat="server"></asp:TextBox>
           Indirizzo: <asp:TextBox ID="Indirizzo" CssClass="form-control" runat="server"></asp:TextBox>
           Numero: <asp:TextBox ID="Numero" CssClass="form-control" runat="server"></asp:TextBox>
           Email:  <asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>
             
            <asp:FileUpload ID="FileUpload1"  CssClass="form-control mt-3 mb-3" runat="server" />
            </div>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-success" Text="Crea Contatto" OnClick="aggiungi" />
            <a class="btn btn-primary mt-3"  href="ListaContatti.aspx"> Lista </a>
            <asp:Label ID="Label1" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
