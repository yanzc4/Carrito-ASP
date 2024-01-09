<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Catalogos.aspx.cs" Inherits="AppWeb_Carrito.Catalogos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        
        .style2
        {
            width: 29px;
        }
    </style>
    <style type="text/css">
        .pagination a {
            padding: 5px;
        }

        .pagination span {
            padding: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" RepeatColumns="3" onitemcommand="DataList1_ItemCommand" RepeatDirection="Horizontal">
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
                <td style="border-style: double">codigo :
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
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="comprar" OnClick="LinkButton1_Click">Comprar</asp:LinkButton>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:DataList>

        

     <asp:Panel runat="server" id="pnlPager" CssClass="pagination">
   
    </asp:Panel>
        </center>
</asp:Content>
