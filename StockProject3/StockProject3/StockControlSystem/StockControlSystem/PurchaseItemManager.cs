using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    public class PurchaseItemManager
    {

        private double _totalPrice;
        private int _itemsPuchased;

        public PurchaseItemManager()
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
