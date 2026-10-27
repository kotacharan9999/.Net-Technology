
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Practical8
{
    public partial class Form1 : Form
    {
        readonly string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=InventoryDB;Integrated Security=True;TrustServerCertificate=True;";

        TextBox txtID = new TextBox();
        TextBox txtName = new TextBox();
        TextBox txtQuantity = new TextBox();
        TextBox txtPrice = new TextBox();
        DataGridView grid = new DataGridView();

        public Form1()
        {
            InitializeComponent();

            Text = "Inventory Management System";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "INVENTORY MANAGEMENT";
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.Location = new Point(260, 15);
            title.AutoSize = true;
            Controls.Add(title);

            AddLabel("Product ID", 30, 75);
            AddLabel("Product Name", 30, 120);
            AddLabel("Quantity", 30, 165);
            AddLabel("Price", 30, 210);

            AddTextBox(txtID, 150, 75);
            AddTextBox(txtName, 150, 120);
            AddTextBox(txtQuantity, 150, 165);
            AddTextBox(txtPrice, 150, 210);

            txtID.ReadOnly = true;

            AddButton("Add", 360, 75, AddProduct);
            AddButton("Update", 460, 75, UpdateProduct);
            AddButton("Delete", 360, 120, DeleteProduct);
            AddButton("Clear", 460, 120, ClearFields);
            AddButton("Refresh", 360, 165, RefreshProducts);

            grid.Location = new Point(30, 270);
            grid.Size = new Size(820, 260);
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            grid.CellClick += Grid_CellClick;

            Controls.Add(grid);

            LoadProducts();
        }

        void AddLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            Controls.Add(label);
        }

        void AddTextBox(TextBox box, int x, int y)
        {
            box.Location = new Point(x, y);
            box.Size = new Size(170, 25);
            Controls.Add(box);
        }

        void AddButton(string text, int x, int y,
            EventHandler action)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(85, 32);
            button.Click += action;
            Controls.Add(button);
        }

        void LoadProducts()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Products";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    grid.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error");
            }
        }

        bool ValidateInput()
        {
            int quantity;
            decimal price;

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                !int.TryParse(txtQuantity.Text, out quantity) ||
                !decimal.TryParse(txtPrice.Text, out price) ||
                quantity < 0 || price < 0)
            {
                MessageBox.Show(
                    "Enter a product name and valid quantity and price.");
                return false;
            }

            return true;
        }

        void AddProduct(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query =
                        "INSERT INTO Products " +
                        "(ProductName, Quantity, Price) " +
                        "VALUES (@name, @quantity, @price)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue(
                        "@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue(
                        "@quantity", int.Parse(txtQuantity.Text));
                    cmd.Parameters.AddWithValue(
                        "@price", decimal.Parse(txtPrice.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product added successfully!");
                LoadProducts();
                ClearFields(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error");
            }
        }

        void UpdateProduct(object? sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Select a product from the table.");
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query =
                        "UPDATE Products SET ProductName=@name, " +
                        "Quantity=@quantity, Price=@price " +
                        "WHERE ProductID=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue(
                        "@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue(
                        "@quantity", int.Parse(txtQuantity.Text));
                    cmd.Parameters.AddWithValue(
                        "@price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue(
                        "@id", int.Parse(txtID.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product updated successfully!");
                LoadProducts();
                ClearFields(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error");
            }
        }

        void DeleteProduct(object? sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Select a product from the table.");
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query =
                        "DELETE FROM Products WHERE ProductID=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue(
                        "@id", int.Parse(txtID.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product deleted successfully!");
                LoadProducts();
                ClearFields(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error");
            }
        }

        void Grid_CellClick(object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid.Rows[e.RowIndex];

                txtID.Text =
                    row.Cells["ProductID"].Value?.ToString() ?? "";
                txtName.Text =
                    row.Cells["ProductName"].Value?.ToString() ?? "";
                txtQuantity.Text =
                    row.Cells["Quantity"].Value?.ToString() ?? "";
                txtPrice.Text =
                    row.Cells["Price"].Value?.ToString() ?? "";
            }
        }

        void ClearFields(object? sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            grid.ClearSelection();
        }

        void RefreshProducts(object? sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
