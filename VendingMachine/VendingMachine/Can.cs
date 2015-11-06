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
        private int _initCans;
        private string _canName;
        private CanDispenser _canDispenser;
        private VMControl _total;

        public Can(int price, int numCans, string name, CanDispenser canDispenser, VMControl total)
        {
            _price = price;
            _numCans = numCans;
            _initCans = numCans;
            _canName = name;
            _canDispenser = canDispenser;
            _total = total;
        }

        public void resetCans()
        {
            _numCans = _initCans;
        }

        public int price
        {
            get
            {
                return _price;
            }
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
            _numCans--;
            _canDispenser.Actuate();
        }
    }
}
