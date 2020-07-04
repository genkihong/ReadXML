<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadXML.aspx.cs" Inherits="XML.ReadXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" Height="78px" Width="487px">
                <%--<Columns>
                    <asp:BoundField DataField="資料年度" HeaderText="資料年度" />
                    <asp:BoundField DataField="統計項目" HeaderText="統計項目" />
                    <asp:BoundField DataField="稅目別" HeaderText="稅目別" />
                    <asp:BoundField DataField="資料單位" HeaderText="資料單位" />
                    <asp:BoundField DataField="值" HeaderText="值" />
                </Columns>--%>
            </asp:GridView>
            <hr />
            <asp:GridView ID="GridView2" runat="server" Height="78px" Width="487px">
               
            </asp:GridView>
        </div>
    </form>
</body>
</html>
