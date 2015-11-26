using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTS;

namespace StockControlSystem
{
    public partial class Till : Form
    {
 
        TillController tillController;
        ListDialog listDialog;

        List<Supplier> SupplierList = new List<Supplier>();
        List<StockItem> StockItemList = new List<StockItem>();


        public Till(List<Supplier> SupplierList, List<StockItem> StockItemList)
        {
            InitializeComponent();
            this.SupplierList = SupplierList;
            this.StockItemList = StockItemList;

        }

        private void Till_Load(object sender, EventArgs e)
        {
            tillController = new TillController(this);
            listDialog = new ListDialog();
        }
            
        public string GetBarCode()
        {
            return tbBarCode.Text.Trim();
        }

        public void ResetBarCode()
        {
            tbBarCode.Text = string.Empty;
        }

        public void DisplayItemNameAndPrice(string name, string price)
        {
            tbName.Text = name;
            tbPrice.Text = price;
        }
        public void ResetItemNameAndPrice()
        {
            tbName.Text = string.Empty;
            tbPrice.Text = string.Empty;
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
            listDialog.ShowDialog ();
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

        private void bnScan_Click(object sender, EventArgs e)
        {
            tillController.BarCodeScan_Handler();
        }

        private void bnTotal_Click(object sender, EventArgs e)
        {
            tillController.Total_Handler();
        }

        private void bnBalance_Click(object sender, EventArgs e)
        {
            tillController.Balance_Handler();

        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            tillController.TransactionClear_Handler();
        }
    }
}
