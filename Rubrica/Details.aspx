<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Rubrica.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="d-flex justify-content-center align-items-center flex-column mt-5 ">
                <div>
                    Nome:
                    <asp:TextBox CssClass="form-control" ID="Nome" runat="server"></asp:TextBox>
                    Cognome: 
                    <asp:TextBox ID="Cognome" CssClass="form-control" runat="server"></asp:TextBox>
                    Indirizzo:
                    <asp:TextBox ID="Indirizzo" CssClass="form-control" runat="server"></asp:TextBox>
                    Numero:
                    <asp:TextBox ID="Numero" CssClass="form-control" runat="server"></asp:TextBox>
                    Email: 
                    <asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:FileUpload ID="FileUpload1" CssClass="form-control mt-3 mb-3" runat="server" />

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-success" Text="Modifica Contatto" OnClick="Modifica" />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-outline-danger" Text="Elimina Contatto" OnClick="Elimina" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
