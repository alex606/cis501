using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockControlSystem
{
    public class StockItem
    {
        private string _StockName;
        private double _StockPrice;

        private int _StockKey;
        private int _StockBarCode;
        private int _StockThreshold;
        private int _StockNumberInStock;
        private int _StockPreferredSupplierKey;

        public StockItem(string[] StockInfo)
        {
            _StockKey = Convert.ToInt16(StockInfo[0]);
            _StockName = StockInfo[1];
            _StockBarCode = Convert.ToInt16(StockInfo[2]);
            _StockPrice = Convert.ToDouble(StockInfo[3]);
            _StockThreshold = Convert.ToInt16(StockInfo[4]);
            _StockNumberInStock = Convert.ToInt16( StockInfo[5]);
            _StockPreferredSupplierKey = Convert.ToInt16(StockInfo[6]);
        }

        public int Key
        { 
            get { return _StockKey; } 
        }
        public string Name
        { 
            get { return _StockName; } 
        }
        public int BarCode
        {
            get { return _StockBarCode; }
        }
        public double Price
        {
            get { return _StockPrice; }
        }
        public int Threshold
        {
            get { return _StockThreshold; }
        }
        public int NumberInStock
        {
            get { return _StockNumberInStock; }
        }
        public int PreferredSupplier
        {
            get { return _StockPreferredSupplierKey; }
        }

        public void Purchase()
        {
            _StockNumberInStock--;
        }

        public void ReStock(int NumToRestock)
        {
            _StockNumberInStock += NumToRestock;
        }
    }
}
