﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CRUD.pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server"> 
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-controls " Text="Create" OnClick="BtnCreate_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" class="btn form-control-sm btn-info" ID="BtnRead" OnClick="BtnRead_Click"/>
                                <asp:Button runat="server" Text="Update" class="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Delete" class="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
