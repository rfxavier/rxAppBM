<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnDashboardConsumoMensal.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnDashboards.cnDashboardConsumoMensal" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v21.1.Web.WebForms, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style>  
        .dxflGroup {  
            height:100%;  
        }  
    </style>
	<script>
        var host = location.protocol + '//' + location.host + '/';

		function onItemClick(s, args) {
            console.log(args.ItemName);
            console.log(host);
            //console.log(args.GetData());
            //console.log(args.GetData().GetAxisNames());
            //console.log(args.GetData().GetAxisNames()[0]);
            //console.log(args.GetAxisPoint(args.GetData().GetAxisNames()[0])) //axisPoint;
            //console.log(args.GetDimensions(args.GetData().GetAxisNames()[0])[0]); //dimension
            //console.log(args.GetDimensions(args.GetData().GetAxisNames()[0])[0].Id); //dimension.Id
            console.log(args.GetAxisPoint(args.GetData().GetAxisNames()[0]).GetDimensionValue(args.GetDimensions(args.GetData().GetAxisNames()[0])[0].Id).GetDisplayText()); //axisPoint.GetDimensionValue(dimension.Id);
            //console.log(args.GetData().GetDimensions());
            //console.log(args.GetData().GetMeasures());

            if (args.ItemName == 'gridDashboardItem1') {
                $.ajax({
                    url: host + "api/BlueMeteringHidrometros/" + args.GetAxisPoint(args.GetData().GetAxisNames()[0]).GetDimensionValue(args.GetDimensions(args.GetData().GetAxisNames()[0])[0].Id).GetDisplayText(),
                    type: "GET",
                    success: function (result) {
                        console.log(result);
                        const popupContentTemplate = function () {
                            return $('<div>').append(
                                $(`<p><b>Id: </b></p>`),
                                $(`<p><span>${result.RedeIotId}</span></p>`),
                                $(`<p><b>Número série relojoaria: </b></p>`),
                                $(`<p><span>${result.NumeroSerieRelojoaria}</span>`),
                                $(`<p><b>Capacidade: </b></p>`),
                                $(`<p><span>${result.Capacidade}</span>`),
                                $(`<p><b>Device Id: </b></p>`),
                                $(`<p><span>${result.DeviceId}</span>`)
                            );
                        }
                        $popupContent = popup.content();
                        $popupContent.empty();
                        $popupContent.append(popupContentTemplate);
                        popup.show();
                    }
                });

            }
        }
        var popup;

        function initPopup() {
            console.log("init popup");
            popup = $("#myPopup").dxPopup({
                width: 300, height: 300,
                title: "Dados do medidor",
                showCloseButton: true,
                closeOnOutsideClick: true
            }).dxPopup('instance');
            console.log(popup);
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">

    <div style="position: absolute; left:0; right:0; top:90px; bottom:0;">
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="5" ColumnCount="5" Width="100%" Height="100%">
            <Items>
                <dx:LayoutItem ShowCaption="False" ColSpan="1" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="1" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Data inicial" ColSpan="1" Width="16%" HorizontalAlign="Right" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxDateEdit ID="deStart" ClientInstanceName="deStart" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" Width="90" runat="server">
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle"></CaptionSettings>
                    <CaptionStyle Font-Bold="False" Font-Names="Tahoma, Geneva, sans-serif"></CaptionStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Data final" ColSpan="1" Width="16%" HorizontalAlign="Right" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxDateEdit ID="deEnd" ClientInstanceName="deEnd" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" Width="90" runat="server">
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                                <DateRangeSettings StartDateEditID="deStart"></DateRangeSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle"></CaptionSettings>
                    <CaptionStyle Font-Bold="False" Font-Names="Tahoma, Geneva, sans-serif"></CaptionStyle>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="1" Width="10%" HorizontalAlign="Center" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Aplicar filtro" OnClick="ASPxButton1_Click"></dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="5" ColumnSpan="5" Height="100%">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <div id="myPopup"></div>
                            <dx:ASPxDashboard runat="server" ID="ASPxDashboard1" WorkingMode="ViewerOnly" Width="100%" Height="100%" OnDataLoading="ASPxDashboard1_DataLoading" OnCustomParameters="ASPxDashboard1_CustomParameters" OnConfigureDataReloadingTimeout="ASPxDashboard1_ConfigureDataReloadingTimeout" OnSetInitialDashboardState="ASPxDashboard1_SetInitialDashboardState">
				                <ClientSideEvents
					                ItemClick="onItemClick"
					                Init="function(s, e) { initPopup(); }" />
                            </dx:ASPxDashboard>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:ASPxFormLayout>
    </div>
</asp:Content>
