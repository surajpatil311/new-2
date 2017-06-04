<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="Addstatus.aspx.cs" Inherits="ThreeWebApplication2.Addstatus" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="head">
    
    <script src="js/tcal.js"></script>
    <link href="CSS/tcal.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div style="width:100%">
        <table style="margin-left:45%">
            <tr>
                <td style="text-align:left">
                <asp:Label ID="Label1" runat="server" Text="Add Status" Font-Bold="True" Font-Overline="False" Font-Size="Larger" Enabled="False" EnableViewState="False"></asp:Label>
                </td>
                </tr>
         </table>
        <div>
             <div style="margin-left:5%"> 
        <table> 
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Search By Name" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="form-control input-md" ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Client Name</asp:ListItem>
                        <asp:ListItem>Task Name</asp:ListItem>
                        <asp:ListItem>Sub Task Name</asp:ListItem>
                        <asp:ListItem>Employee Name</asp:ListItem>
                        <asp:ListItem>Date</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:TextBox CssClass="form-control input-md" ID="txtsearch" runat="server"></asp:TextBox>

                </td>
                <td>
                    <asp:Button CssClass="btn btn-info"  ID="Button3" runat="server" Text="Search" OnClick="search_Click" />
                </td>
            </tr>
           </table>
          </div>

          <div style="margin-left:5%" id="from1" runat="server">
           <table>
                <tr>
                <td> <asp:Label ID="Label3" runat="server" Text="From" Font-Bold="True"></asp:Label>

                </td>
                <td style="margin-left:25%">
                    <asp:TextBox class="tcal" ID="From" runat="server" Width="80px" Height="20px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="To" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox class="tcal" ID="To" runat="server" Width="80px" Height="20px"></asp:TextBox>
                </td>
            </tr>
               </table>
            </div>
   
        <div style="margin-left:5%">

            <asp:GridView CssClass="table table-condensed table-hover table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound" PageSize="7" >
                <Columns>
                    <asp:TemplateField HeaderText="SrNo" SortExpression="srno">
                        
                        <ItemTemplate>
                            <asp:Label ID="lablesrno" runat="server" Text='<%# Eval("srno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ClientName" SortExpression="clientname">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("clientname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lableclientname" runat="server" Text='<%# Bind("clientname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TaskName" SortExpression="taskname">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("taskname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="labletaskname" runat="server" Text='<%# Bind("taskname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SubtaskName" SortExpression="subtaskname">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("subtaskname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lablesubtaskname" runat="server" Text='<%# Bind("subtaskname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Name" SortExpression="empname">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("empname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lableempname" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assigndate" SortExpression="assigndate">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("assigndate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lableassigndate" runat="server" Text='<%# Bind("assigndate", "{0:dd-M-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DeadlineDate">
                        <ItemTemplate>
                               <asp:TextBox ID="txtdeadlinedate" runat="server" Width="111px" CssClass="tcal" Text='<%#Eval("deadlinedate") %>'>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:BoundField DataField="Deadline Date" HeaderText="DeadlineDate" SortExpression="deadlinedate" />--%>
                    <asp:TemplateField HeaderText="Remark">
                        <ItemTemplate>
                            <asp:TextBox CssClass="form-control input-md" ID="Remark" runat="server" Text='<%#Eval("remark") %>'>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="remark" />--%>
                    <asp:TemplateField HeaderText=" Status">
                    <ItemTemplate>

                        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="status" DataValueField="status" AutoPostBack="true" AppendDataBoundItems="true"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1">
                            <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Inprogress</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>Complete</asp:ListItem>
                            </asp:DropDownList>
                   
                    </ItemTemplate>
                        
                </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>   <div style="margin-left:45%">
        
    </div>
        </div>
    <div style="width:100%">
        <table style="margin-left:45%">
            <tr>
                <td>
                    <asp:Button CssClass="btn btn-success" ID="save" runat="server" Text="Save" OnClick="save_Click1"/>
                </td>
                <td>
                    <asp:Button CssClass="btn btn-warning" ID="Button2" runat="server" Text="Cancel"/>
                    
                </td>
                
            </tr>
            
            
        </table>
    </div>
        
</asp:Content>

