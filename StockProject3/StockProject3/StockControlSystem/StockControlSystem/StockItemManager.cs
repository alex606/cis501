using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    public class StockItemManager
    {

        private double _totalPrice;
        private int _itemsPuchased;

        public StockItemManager()
        {

        }

        public void addItem()
        {
            _itemsPuchased++;
        }

        public void Purchase(double PurchasePrice)
        {
            _totalPrice += PurchasePrice;
        }
    }
}
