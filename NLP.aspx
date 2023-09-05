<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="true" CodeFile="NLP.aspx.cs" Inherits="NLP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .btn-primary
        {
            margin-left: 2px;
            margin-top: 0px;
        }
        .col-md-3
        {
            margin-top: 0px;
            margin-right: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">

    <div class="container-fluid">
        <div class="col-md-3" align="center" 
            
            style="border-style: inset; font-family: 'Nexa Bold'; font-size: 38px; font-weight: bold; color: #FFFFFF; background-color: #0000FF;">
            Text To IFML Conversion Tool<br />
        </div>
        <div class="col-md-6"> <div style="text-align:center">
            <br />
            <font size="6"> Title of Case-Study </font> </br>
        <asp:TextBox ID="TextBox2" runat="server" 
                BackColor="White" Font-Bold="True" ForeColor="#003366" Height="37px" 
                Width="241px"></asp:TextBox></div>
                <br>

            <asp:TextBox ID="TextBox1" Style="width: 100%; height: 130px" runat="server" 
                TextMode="MultiLine" BackColor="White" Font-Bold="True" 
                ForeColor="#003366" BorderStyle="Inset" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
            <br /> &nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button ID="brnres" runat="server" Text="View Results" 
                CssClass="btn btn-primary" OnClick="brnres_Click" BorderColor="#000099" 
                Font-Bold="True" Width="353px" Height="53px" Font-Size="Medium" />
           


            &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="Generate XMI for IFML Model" Width="353px" Height="53px" 
                BorderColor="#000066" Font-Bold="True" Font-Size="Medium" /> 
           


            <asp:Button ID="Button3" runat="server" Height="53px" onclick="Button3_Click" 
                Text="Generate XMI for Domain Model" Width="353px" BorderColor="#000066" 
                Font-Bold="True" 
                style="margin-left: 12px; margin-right: 1px; margin-top: 0px" 
                Font-Size="Medium" />
           

           <div style="width:100%; margin:0 auto; float:left; padding:5px 0 15px;">
            <div                 style=" width:25%;  float: left; ">
                <asp:Button ID="Button4" runat="server" BorderColor="#000006" Font-Bold="True" 
                    Font-Size="Medium" Height="53px" onclick="Button4_Click1" 
                    Text="Identify View Containers" Width="98%" />
                <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="strViewContainer1_1" DataValueField="strViewContainer1_1" 
                    Height="100px"  onselectedindexchanged="ListBox1_SelectedIndexChanged1" 
                    style=" padding-bottom:5px;" Visible="False" Width="97%" >
                </asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IFMLConnectionString %>" 
                    SelectCommand="SELECT strViewContainer1_1 FROM table_ViewContainers WHERE (strViewContainer1_1 IS NOT NULL) UNION SELECT strViewContainer2_1 FROM table_ViewContainers AS table_ViewContainers_5 WHERE (strViewContainer2_1 IS NOT NULL) UNION SELECT strViewContainer3_1 FROM table_ViewContainers AS table_ViewContainers_4 WHERE (strViewContainer3_1 IS NOT NULL) UNION SELECT strViewContainer4_1 FROM table_ViewContainers AS table_ViewContainers_3 WHERE (strViewContainer4_1 IS NOT NULL) UNION SELECT strViewContainer55_1 FROM table_ViewContainers AS table_ViewContainers_2 WHERE (strViewContainer55_1 IS NOT NULL) UNION SELECT strViewContainer6_1 FROM table_ViewContainers AS table_ViewContainers_1 WHERE (strViewContainer6_1 IS NOT NULL)">
                </asp:SqlDataSource>
              
            </div>
           <div style="width:25%; float:left;">  
                <asp:Button ID="Button5" runat="server" BorderColor="#000006" Font-Bold="True" 
                    Font-Size="Medium" Height="53px" onclick="Button5_Click" 
                    Text="Identify View Component" Width="96%" 
                    style="margin-left: 4px; margin-bottom: 0px" />
                <br />
                <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource3" 
                    DataTextField="strViewComponent1_1" DataValueField="strViewComponent1_1" 
                    Height="100px"  onselectedindexchanged="ListBox1_SelectedIndexChanged1" 
                    style=" padding-bottom:5px;" Visible="False" Width="97%" >
                </asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IFMLConnectionString %>" 
                    SelectCommand="SELECT strViewComponent1_1 FROM table_ViewComponent WHERE (strViewComponent1_1 &lt;&gt; ' ') UNION ALL SELECT strViewComponent1_1 FROM table_ViewComponent AS table_ViewComponent_5 WHERE (strViewComponent2_1 &lt;&gt; ' ') UNION ALL SELECT strViewComponent3_1 FROM table_ViewComponent AS table_ViewComponent_4 WHERE (strViewComponent3_1 &lt;&gt; ' ') UNION ALL SELECT strViewComponent4_1 FROM table_ViewComponent AS table_ViewComponent_3 WHERE (strViewComponent4_1 &lt;&gt; ' ') UNION ALL SELECT strViewComponent5_1 FROM table_ViewComponent AS table_ViewComponent_2 WHERE (strViewComponent5_1 &lt;&gt; ' ') UNION ALL SELECT strViewComponent6_1 FROM table_ViewComponent AS table_ViewComponent_1 WHERE (strViewComponent6_1 &lt;&gt; ' ')">
                </asp:SqlDataSource>
               </div>
           <div style="width:25%;  float:left;">  
                <asp:Button ID="Button6" runat="server" BorderColor="#000006" Font-Bold="True" 
                    Font-Size="Medium" Height="53px" onclick="Button6_Click" 
                    Text="Identify Events" Width="96%" />
                <br />
                <asp:ListBox ID="ListBox3" runat="server" DataSourceID="SqlDataSource4" 
                    DataTextField="strEvent1_1" DataValueField="strEvent1_1" 
                    Height="100px"  onselectedindexchanged="ListBox1_SelectedIndexChanged1" 
                    style=" padding-bottom:5px;" Visible="False" Width="97%" >
                </asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IFMLConnectionString %>" 
                    SelectCommand="SELECT strEvent1_1 FROM table_Events WHERE (strEvent1_1 &lt;&gt; ' ') UNION ALL SELECT strEvent2_1 FROM table_Events AS table_Events_5 WHERE (strEvent2_1 &lt;&gt; ' ') UNION ALL SELECT strEvent3_1 FROM table_Events AS table_Events_4 WHERE (strEvent3_1 &lt;&gt; ' ') UNION ALL SELECT strEvent4_1 FROM table_Events AS table_Events_3 WHERE (strEvent4_1 &lt;&gt; ' ') UNION ALL SELECT strEvent5_1 FROM table_Events AS table_Events_2 WHERE (strEvent5_1 &lt;&gt; ' ') UNION ALL SELECT strEvent6 FROM table_Events AS table_Events_1 WHERE (strEvent6 &lt;&gt; ' ')">
                </asp:SqlDataSource>
               </div>
           <div style="width:25%; float:left;"> 
                <asp:Button ID="Button7" runat="server" BorderColor="#000006" Font-Bold="True" 
                    Font-Size="Medium" Height="53px" onclick="Button7_Click" 
                    Text="Identify Action" Width="97%" />
                <br />
                <asp:ListBox ID="ListBox4" runat="server" DataSourceID="SqlDataSource5" 
                    DataTextField="strAction1_1" DataValueField="strAction1_1" 
                    Height="100px"  onselectedindexchanged="ListBox1_SelectedIndexChanged1" 
                    style=" padding-bottom:5px;" Visible="False" Width="97%" >
                </asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IFMLConnectionString %>" 
                    SelectCommand="SELECT strAction1_1 FROM table_Actions WHERE (strAction1_1 &lt;&gt; ' ') UNION ALL SELECT strAction2_1 FROM table_Actions AS table_Actions_1 WHERE (strAction2_1 &lt;&gt; ' ')">
                </asp:SqlDataSource>
               </div>
           </div>
            



<div class="col-md-3" style="position: static">
             
            <center style="position: static"> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" align="center"
                BorderColor="#000066" DataKeyNames="intId" DataSourceID="SqlDataSource1" 
                Font-Bold="True" ForeColor="#333333" 
                style="margin-left: 0px; margin-right: 0px; margin-top: 0px" Visible="False" 
                Width="941px" onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="intId" HeaderText="intId" InsertVisible="False" 
                        ReadOnly="True" SortExpression="intId" />
                    <asp:BoundField DataField="line" HeaderText="line" SortExpression="line" />
                    <asp:BoundField DataField="container" HeaderText="container" 
                        SortExpression="container" />
                    <asp:BoundField DataField="component" HeaderText="component" 
                        SortExpression="component" />
                    <asp:BoundField DataField="events" HeaderText="events" 
                        SortExpression="events" />
                    <asp:BoundField DataField="actions" HeaderText="actions" 
                        SortExpression="actions" />
                    <asp:BoundField DataField="navigation" HeaderText="navigation" 
                        SortExpression="navigation" />
                </Columns>
            </asp:GridView> </center>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IFMLConnectionString %>" 
                
                SelectCommand="SELECT [intId], [line], [container], [component], [events], [actions], [navigation] FROM [table_Results]" 
                onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                <br />
                <br />
            <br />

            
        </div>



 
            <br />
           


        </div>



       <div class="col-md-12" id="printable" runat="server">
         <asp:TextBox ID="TextBox3" Style="width: 100%; height: 130px" runat="server" 
                TextMode="MultiLine" BackColor="White" Font-Bold="True" 
               ForeColor="#003366" Visible="False"></asp:TextBox>
            <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <center>College of E&amp;ME, National University of Sciences and Technology (NUST), 
                Pakistan</center> <br />
                       
        </div>


</asp:Content>
