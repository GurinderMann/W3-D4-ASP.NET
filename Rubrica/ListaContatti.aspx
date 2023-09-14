<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaContatti.aspx.cs" Inherits="Rubrica.ListaContatti" %>

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
            <div class="container">
            <div class="row">
                <asp:Repeater ID="Repeater1" runat="server" ItemType="Rubrica.Contatto">
                    <ItemTemplate>
                        <div class="col-3 mt-5">
                            <div>
                                <img style="width: 10%" src="Content/img/<%# Item.ProfileImg %>" />
                            </div>
                            <h2><%# Item.Nome %> <%# Item.Cognome %></h2>
                            <hr />
                            <p>Indirizzo: <%# Item.Indirizzo %></p>
                            <p>Numero di Telefono: <strong><%# Item.Numero %></strong></p>
                            <p>Indirizzo Email: <%# Item.Email %></p>
                            <a class="btn btn-outline-primary" href="Details.aspx?IdContatto=<%# Item.IdContatto %>">Dettagli</a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
          </div>
        </div>
    </form>
</body>
</html>
