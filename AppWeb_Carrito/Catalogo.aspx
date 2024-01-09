<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="AppWeb_Carrito.Catalogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        
a
{
    margin: 0;
    padding: 0;
}

        .style2
        {
            width: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" 
            RepeatColumns="2" RepeatDirection="Horizontal" 
            onselectedindexchanged="DataList1_SelectedIndexChanged" 
            onitemcommand="DataList1_ItemCommand">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <ItemTemplate>
                <table class="style1" style="border-style: groove">
                    <tr>
                        <td class="style2">
                            <img alt="" src='fotos\<%#DataBinder.Eval(Container.DataItem,"idarticulo")%>.jpg' style="height: 80px; width: 57px" />
                        </td>
                        <td style="border-style: double">
                            codigo :
                            <asp:Label ID="lblId" runat="server" 
                                Text='<%#DataBinder.Eval(Container.DataItem,"idarticulo") %>' />
                            <br />
                            articulo :<asp:Label ID="lblArticulo" runat="server" 
                                Text='<%#DataBinder.Eval(Container.DataItem,"nomarticulo") %>' />
                            <br />
                            precio :
                            <asp:Label ID="lblPrecio" runat="server" 
                                Text='<%#DataBinder.Eval(Container.DataItem,"precio") %>' />
                            <br />
                            stock :
                            <asp:Label ID="lblStock" runat="server" 
                                Text='<%#DataBinder.Eval(Container.DataItem,"stock") %>' />
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="comprar">Comprar</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
