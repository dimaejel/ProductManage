<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="ProductManage.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product Manager</title>

    <style>
        body {
            font-family: Segoe UI;
            background: #f4f6f9;
            padding: 40px;
        }

        .card {
            background: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            max-width: 750px;
            margin-bottom: 19px;



        }

        .grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 12px;
        }

        input {
            padding: 8px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }

        input:focus {
            border-color: #2c7be5;
            outline: none;
        }

        .btn {
            padding: 10px 18px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-weight: bold;
        }

        .btn-save {
            background: #2c7be5;
            color: white;
        }

        .btn-save:hover {
            background: #1a5fbe;
        }

        .btn-delete {
            background: #e74c3c;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 5px;
            cursor: pointer;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            background: white;
            border-radius: 10px;
            overflow: hidden;
        }

        th {
            background: #2c3e50;
            color: white;
            padding: 10px;
        }

        td {
            padding: 10px;
            border-bottom: 1px solid #eee;
        }

        tr:hover td {
            background: #f1f5ff;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <!-- 🟢 Form -->
    <div class="card">

        <h2>Add Product</h2>

        <div class="grid">
            <asp:TextBox ID="TxtId" runat="server" placeholder="ID" />
            <asp:TextBox ID="TxtName" runat="server" placeholder="Name" />
            <asp:TextBox ID="TxtPrice" runat="server" placeholder="Price" />
            <asp:TextBox ID="TxtQuantity" runat="server" placeholder="Quantity" />
        </div>

        <br />

        <asp:Button ID="BtnSave" runat="server"
            Text="Save"
            CssClass="btn btn-save"
            OnClick="BtnSave_Click" />

    </div>

    <!-- 🟢 Grid -->
    <div class="card">

        <h2>Products List</h2>

        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnRowCommand="GridView1_RowCommand">

            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                <asp:ButtonField ButtonType="Button"
                    CommandName="DeleteRow"
                    Text="Delete"
                    ControlStyle-CssClass="btn-delete" />

            </Columns>

        </asp:GridView>

    </div>

</form>

</body>
</html>