using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using ShoppingList_Sy;

namespace ShoppingList_Sy
{
    public partial class Display : Form
    {
        private string filePath = "D:\\VS Code Projects\\ShoppingList_Sy\\shoppinglist.json";

        public Display()
        {
            InitializeComponent();
            LoadShoppingList();
        }

        private void LoadShoppingList()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var items = JsonSerializer.Deserialize<List<GroceryItem>>(json);
                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    listBox1.Items.Add($"ID: {item.Id} - Product: {item.Name} - Quantity: {item.Quantity}");
                }
            }
        }

        private void btnOpenAddForm_Click(object sender, EventArgs e)
        {
            var addForm = new AddGroceriesForm();
            addForm.FormClosed += (s, args) => LoadShoppingList();
            addForm.Show();
        }
    }
}