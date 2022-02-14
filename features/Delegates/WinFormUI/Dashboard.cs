using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        ShoppingCartModel cart = new ShoppingCartModel();

        public Dashboard()
        {
            InitializeComponent();
            PopulateCartWithDemoData();
        }

        private void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

        private void messageBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, PrintOutDiscountAlert);
            MessageBox.Show($"The total is {total:C2}");
        }

        private void textBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal(
                (subTotal) => subTotalTextBox.Text = $"The subtotal is {subTotal:C2}",
                (products, subTotal) => subTotal - products.Count,
                (message) => {});
            totalTextBox.Text = $"The total is {total:C2}";
        }

        private void PrintOutDiscountAlert(string discountMessage)
        {
            MessageBox.Show(discountMessage);
        }
        private void SubTotalAlert(decimal subTotal)
        {
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }

        private decimal CalculateLeveledDiscount(List<ProductModel> products, decimal subTotal)
        {
            if (products.Count > 3)
            {
                return subTotal - (products.Count * 2);
            }

            return subTotal;
        }
    }
}
