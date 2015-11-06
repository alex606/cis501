using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Can class to keep track of can price and inventory
    /// </summary>
    public class Can
    {

        private int _price;
        private int _numCans;
        private string _canName;
        private CanDispenser _canDispenser;

        public Can(int price, int numCans, string name, CanDispenser canDispenser)
        {
            _price = price;
            _numCans = numCans;
            _canName = name;
            _canDispenser = canDispenser;
        }

        public void resetCans(int initCans)
        {
            _numCans = initCans;
        }

        public int price
        {
            get
            {
                return _price;
            }
        }

        public void removeCan()
        {
            _numCans--;
        }

        public int CanStock
        {
            get
            {
                return _numCans;
            }
        }

        public void DispenseCan()
        {
            _canDispenser.Actuate();
        }
    }
}
