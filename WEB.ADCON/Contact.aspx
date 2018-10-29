<%@ Page Title="Veículos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WEB.ADCON.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> - Monitoramento de acesso de veículos</h2>
    
    <address>
<div class="container-fluid">

  <div class="row">
    <div class="col-sm-3 col-md-6 col-lg-4">
      <asp:Image ID="Image1" Width="100%" Height="100%" ImageUrl="~/Placas/SemCarro.png" runat="server" />
      <asp:FileUpload id="FileUploadControl" runat="server" />
      <asp:Button runat="server" id="UploadPlaca" text="Upload" OnClick="UploadPlaca_Click" />
    </div>
    <div class="col-sm-3 col-md-6 col-lg-4">
    <div class="form-group">
        <label class="control-label col-sm-2" for="email">PLACA:</label>
        <div class="col-sm-10">
        <asp:TextBox class="form-control" ID="txtPlaca" Width="100px" Font-Bold="true" Font-Size="Medium" BackColor="Black" ForeColor="White" runat="server" ReadOnly="True"></asp:TextBox>  
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Bloco:</label>
        <div class="col-sm-3">
        <asp:TextBox ID="txtBloco" class="form-control" Width="80px" runat="server"></asp:TextBox>
        </div>
        <label class="control-label col-sm-2">Apto:</label>
        <div class="col-sm-3"> 
        <asp:TextBox ID="txtApto" class="form-control" Width="80px" runat="server"></asp:TextBox>
        </div>
    </div>
    </div>
    <div class="col-sm-3 col-md-6 col-lg-4">
        <div class="form-group">
            <label class="control-label col-sm-3">MORADOR:</label>
            <div class="col-sm-4"> 
            <asp:TextBox ID="txtEMorador" class="form-control" Width="80px" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-sm-3 col-md-6 col-lg-4">
        <div class="form-group">
            <label class="control-label col-sm-3">LIBERADO:</label>
            <div class="col-sm-4"> 
            <asp:TextBox ID="txtAcessoLiberado" class="form-control" Width="80px" runat="server"></asp:TextBox>
            </div>
        </div>

    </div>        
    <h3>Modadores do Apartamento</h3>
    <div class="col-sm-3 col-md-6 col-lg-4">
        <div class="form-group">
            <label class="control-label col-sm-2">Nome:</label>
            <div class="col-sm-9"> 
            <input name="ctl00$MainContent$txtANome" type="text" id="txtNomeA" class="form-control" style="width:100%;">
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2">Nome:</label>
            <div class="col-sm-9"> 
            <input name="ctl00$MainContent$txtBNome" type="text" id="txtNomeB" class="form-control" style="width:100%;">
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2">Nome:</label>
            <div class="col-sm-9"> 
            <input name="ctl00$MainContent$txtANome" type="text" id="txtNomeC" class="form-control" style="width:100%;">
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2">Nome:</label>
            <div class="col-sm-9"> 
            <input name="ctl00$MainContent$txtBNome" type="text" id="txtNomeD" class="form-control" style="width:100%;">
            </div>
        </div>
    </div>

                     
    <div class="col-sm-3 col-md-6 col-lg-4">
        <div class="form-group">
            <div class="col-sm-6"> 
            <img id="Image2" src="FotoMorador/Edinei.JPG" style="height:100%;width:100%;">
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-6"> 
            <img id="Image3" src="FotoMorador/B%C3%A1rbara.PNG" style="height:100%;width:100%;">
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-6"> 
            <img id="Image4" src="FotoMorador/Edinei.JPG" style="height:100%;width:100%;">
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-6"> 
            <img id="Image5" src="FotoMorador/B%C3%A1rbara.PNG" style="height:100%;width:100%;">
            </div>
        </div>
    </div>

  </div>


  <hr />
  <h3>Histórico de acesso</h3>
      <%--<asp:Label runat="server" id="StatusLabel" text=" " />--%>
  <div class="row">
    <div class="col-sm-12 col-md-12 col-lg-12">
      Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
      Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
    </div> 
  </div>
</div>
        
        <br />
        
    </address>


    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
