using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTS;

namespace StockControlSystem
{
    public partial class Console : Form
    {
        ConsoleController consoleController;
        Till till; // just in case, for ConsoleController and Till to share information
        ListDialog listDialog;
        List<Supplier> SupplierList = new List<Supplier>();
        List<StockItem> StockItemList = new List<StockItem>();


        public Console()
        {
            InitializeComponent();
        }

        private void Console_Load(object sender, EventArgs e)
        {
            consoleController = new ConsoleController(this);
            listDialog = new ListDialog();
        }

        public string GetItemKeyToOrder()
        {
            return tbOrder.Text.Trim();
        }

        public void ResetItemKeyToOrder()
        {
            tbOrder.Text = string.Empty;
        }
        public string GetNumberOfItemsToOrder()
        {
            return tbNumItemsToOrder.Text.Trim();
        }
        public void ResetNumberOfItemsToOrder()
        {
            tbNumItemsToOrder.Text = string.Empty;
        }
        public string GetItemKeyToRestock()
        {
            return tbRestockItemKey.Text.Trim();
        }
        public void ResetItemKeyToRestock()
        {
            tbRestockItemKey.Text = string.Empty;
        }
        public void ResetListDialog()
        {
            listDialog.ResetDisplayItems();
        }

        public void AppendItemsToListDialog(params object[] items)
        {
            listDialog.AppendDisplayItems(items);
        }

        public void ShowListDialog()
        {
            listDialog.ShowDialog();
        }
        public void DisplayListDialog(object[] list)
        {
            listDialog.ResetDisplayItems();
            listDialog.AppendDisplayItems(list);
            listDialog.ShowDialog();
        }

        public void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message);
        }


        private void bnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bnListStockBelowTH_Click(object sender, EventArgs e)
        {
            consoleController.ListStockItemsBelowThreshold_Handler();

        }

        private void bnListAllStock_Click(object sender, EventArgs e)
        {
            consoleController.ListAllStockItems_Handler();
        }

        private void bnListAllSuppliers_Click(object sender, EventArgs e)
        {
            consoleController.ListAllSuppliers_Handler();
        }

        private void bnOrder_Click(object sender, EventArgs e)
        {
            consoleController.Order_Handler();

        }

        private void bnListOutstandingOrders_Click(object sender, EventArgs e)
        {
            consoleController.ListOutstandingOrders_Handler();
 
        }

        private void bnRestock_Click(object sender, EventArgs e)
        {
            consoleController.Restock_Handler();
            bnLoadStock.Enabled = true;
        }

        private void bnLoadStock_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Stock Items|*.txt";
            openFileDialog.InitialDirectory = Application.StartupPath;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    consoleController.LoadStockItems_Handler(openFileDialog.FileName);

                    bnListStockBelowTH.Enabled = bnListAllStock.Enabled = bnListAllSuppliers.Enabled = true;
                    bnListOutstandingOrders.Enabled = bnOrder.Enabled = bnRestock.Enabled = true;
                    bnLoadSuppliers.Enabled = bnLoadStock.Enabled = false;

                    till = new Till( SupplierList, StockItemList);  // you can pass any argument
                    till.Show();
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        private void bnLoadSuppliers_Click(object sender, EventArgs e)
        {
            // the following 2 lines are to demostrate how to use ListDialog() and should be deleted.
            // Also delete ListDialogDemo.cs in this project
            // after you understand how to use ListDialog
            //ListDialogDemo demo = new ListDialogDemo(this);
            //demo.ListDemo();
            // the demo code ends here

            // do not delete the following lines. 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suppliers|*.txt";
            openFileDialog.InitialDirectory = Application.StartupPath;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    consoleController.LoadSuppliers_Handler(openFileDialog.FileName);
                    bnLoadStock.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }
    }
}
