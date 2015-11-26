 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace StockControlSystem
{
    public class ConsoleController
    {
        Console console;
        
        // Add your fields
        List<Supplier> SupplierList = new List<Supplier>();
        List<StockItem> StockItemList = new List<StockItem>();

        public ConsoleController(Console console)
        {
            this.console = console;
        }

        public void ListStockItemsBelowThreshold_Handler()
        {
  
        }
        public void ListAllSuppliers_Handler()
        {
           
        }

        public void ListAllStockItems_Handler()
        {
           
        }

        public void Order_Handler()
        {

        }

        public void ListOutstandingOrders_Handler()
        {

        }

        public void Restock_Handler()
        {

        }

        public void LoadStockItems_Handler(string fileName)
        {
            StreamReader readFile = new StreamReader(fileName);
            string[] StockInfo;

            while (!readFile.EndOfStream)
            {
                string readLine = readFile.ReadLine();
                StockInfo = readLine.Split('&');
                StockItem newSupplier = new StockItem(StockInfo);
                StockItemList.Add(newSupplier);
            }
        }

        public void LoadSuppliers_Handler(string fileName)
        {

            StreamReader readFile = new StreamReader(fileName);
            string[] SupplierInfo;

            while (!readFile.EndOfStream)
            {
                string readLine = readFile.ReadLine();
                SupplierInfo = readLine.Split('&');
                Supplier newSupplier = new Supplier(SupplierInfo);
                SupplierList.Add(newSupplier);
            }
        }

        public List<Supplier> getSupplierList
        {
            get { return SupplierList;  }
        }

        public List<StockItem> getStockListList
        {
            get { return StockItemList; }
        }
    }
}
