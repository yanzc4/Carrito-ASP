<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="AppWeb_Carrito.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 90%;
        }


        .auto-style2 {
            text-align: center;
        }

        .auto-style3 {
            margin-left: 202;
        }

        .auto-style4 {
            text-align: end;
        }

        .auto-style5 {
            font-size: medium;
        }

        .text-start {
            text-align: start;
        }

        .modal {
            display: none;
            position: fixed;
            z-index: 10;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: hidden;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }

        .modal-content {
            background-color: #fefefe;
            padding: 20px;
            border: 1px solid #888;
            width: 28%;
            
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            position: absolute;
        }

        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover, .close:focus {
                color: black;
                text-decoration: none;
                cursor: pointer;
            }
            .caja{
                     width: 100%;
                     padding: 9px 20px;
                     margin: 8px 0;
                     display: inline-block;
                     border: 1px solid #ccc;
                     border-radius: 4px;
                     box-sizing: border-box;
              }
            .btn{
                     background-color: #4CAF50;
                     color: white;
                     padding: 14px 20px;
                     margin: 8px 0;
                     border: none;
                     cursor: pointer;
                     width: 100%;
                     opacity: 0.9;
              }
              .btn:hover{
                     opacity: 1;
              }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table class="auto-style1">
            <tr>
                <td style="text-align: center;" width="100%">

                    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False"
                        OnRowEditing="GridView1_RowEditing1" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" CellPadding="4" CssClass="auto-style3" Font-Names="Arial Narrow" Font-Size="14pt" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="codigo" ControlStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCodigo" ReadOnly="true" runat="server" Text='<%# Bind("codigo") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <ControlStyle Width="120px"></ControlStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="nombre" ControlStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <ControlStyle Width="180px"></ControlStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="precio" ControlStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" ReadOnly="true" runat="server" Text='<%# Bind("precio") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <ControlStyle Width="80px"></ControlStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="cantidad" ControlStyle-Width="85px">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <ControlStyle Width="85px"></ControlStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="total" ControlStyle-Width="85px">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" ReadOnly="true" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <ControlStyle Width="85px"></ControlStyle>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" Width="90%" ForeColor="White" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">

                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style5">&nbsp;Total a Pagar&nbsp;&nbsp;&nbsp; :</span>&nbsp;
                <asp:Label ID="lblTotal" runat="server" ForeColor="#FF8080" Height="22px" Font-Size="14pt"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button class="btn" type="button" id="myBtn">Pagar</button>
                    </strong>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <p align="center">
                            
                    </p>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </center>
    <div id="myModal" class="modal">
        <div class="modal-content">
            <span class="close">&times;</span>
            <h3>Confirmar pedido</h3><br />
            <hr />
            <label>Ingrese sus datos para el envio de su pedido!</label>
            <hr /><br />
            <div>
                <label>Nombres:</label><br />
                <asp:TextBox CssClass="caja" ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Direccion:</label><br />
                <asp:TextBox CssClass="caja" ID="txtDir" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Correo:</label><br />
                <asp:TextBox CssClass="caja" TextMode="Email" ID="txtCorreo" runat="server"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Confirmar" OnClick="Button1_Click" />

        </div>
    </div>

    <script>
        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the button that opens the modal
        var btn = document.getElementById("myBtn");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal 
        btn.onclick = function () {
            modal.style.display = "block";
            document.body.style.overflow = "hidden";
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
            document.body.style.overflow = "auto";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
                document.body.style.overflow = "auto";
            }
        }
    </script>
    
</asp:Content>
