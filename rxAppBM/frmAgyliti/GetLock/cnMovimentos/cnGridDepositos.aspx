<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridDepositos.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnMovimentos.cnGridDepositos" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <strong>Depósitos</strong>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="7" ColumnCount="7">
        <Items>
            <dx:EmptyLayoutItem ColSpan="1"></dx:EmptyLayoutItem>
            <dx:EmptyLayoutItem ColSpan="1"></dx:EmptyLayoutItem>
            <dx:EmptyLayoutItem ColSpan="1"></dx:EmptyLayoutItem>
            <dx:EmptyLayoutItem ColSpan="1"></dx:EmptyLayoutItem>
            <dx:LayoutItem ShowCaption="False" ColSpan="7" ColumnSpan="7">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding" OnCustomUnboundColumnData="ASPxGridView1_CustomUnboundColumnData">
                            <SettingsDetail ShowDetailRow="True"></SettingsDetail>

                            <SettingsPager PageSize="20"></SettingsPager>
                            <Columns>
                                <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="0" SortOrder="Descending" ShowInCustomizationForm="True" Caption="Data Movimento" VisibleIndex="0">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>

                                    <CellStyle Wrap="False"></CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="id_cofre" ShowInCustomizationForm="True" Caption="ID Cofre" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="cofre_nome" ShowInCustomizationForm="True" Caption="Nome Cofre" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="cod_loja" ShowInCustomizationForm="True" Caption="C&#243;d.Loja" VisibleIndex="8"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="razao_social_loja" ShowInCustomizationForm="True" Caption="Raz&#227;o Social Loja" VisibleIndex="10"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="data_user" ShowInCustomizationForm="True" Caption="Usu&#225;rio" VisibleIndex="47"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="user_nome" ShowInCustomizationForm="True" Caption="Usu&#225;rio Nome" VisibleIndex="48"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TotalCount" UnboundType="Decimal" Caption="Total Cédulas" VisibleIndex="60">
                                    <PropertiesTextEdit DisplayFormatString="#,#0" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TotalValue" UnboundType="Decimal" Caption="Total Valor" VisibleIndex="61">
                                    <PropertiesTextEdit DisplayFormatString="#,#0" />
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Settings ShowFooter="true" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="TotalCount" SummaryType="Sum" DisplayFormat="{0:n0}" />
                                <dx:ASPxSummaryItem FieldName="TotalValue" SummaryType="Sum" DisplayFormat="{0:c}" />
                            </TotalSummary>
                            <Styles>
                                <Header Wrap="True">
                                </Header>
                                <AlternatingRow Enabled="True" BackColor="#CEFFB7">
                                </AlternatingRow>
                                <TitlePanel Font-Size="Medium">
                                </TitlePanel>
                            </Styles>
                            <Templates>
                                <DetailRow>
                                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView2" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect">
                                        <SettingsPager PageSize="20"></SettingsPager>
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 2" VisibleIndex="53"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 5" VisibleIndex="54"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 10" VisibleIndex="55"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 20" VisibleIndex="56"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 50" VisibleIndex="57"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 100" VisibleIndex="58"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 200" VisibleIndex="59"></dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </DetailRow>
                            </Templates>
                        </dx:ASPxGridView>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
        <SettingsItems Width="100%"></SettingsItems>
    </dx:ASPxFormLayout>
</asp:Content>
