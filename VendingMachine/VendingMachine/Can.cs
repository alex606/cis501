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
        private Light _purchaseLight;
        private Light _SoldOutLight;
        

        public Can(int price, int numCans, string name, 
            CanDispenser canDispenser, VMControl total, Light purchaseLight, Light SoldOutLight)
        {
            _price = price;
            _numCans = numCans;
            _initCans = numCans;
            _canName = name;
            _canDispenser = canDispenser;
            _total = total;
            _purchaseLight = purchaseLight;
            _SoldOutLight = SoldOutLight;

        }

        public void resetCans()
        {
            _numCans = _initCans;
            _SoldOutLight.TurnOff();
            _purchaseLight.TurnOff();
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

        public void PurchaseCan()
        {
            _total.purchaseCan(this);
        }

        public void IsCanPurchaseable(int credit)
        {
            if(credit >= _price && _numCans > 0)
            {
                _purchaseLight.TurnOn();
            }
            else
            {
                _purchaseLight.TurnOff();
            }
        }

        public void DispenseCan()
        {
            _numCans--;
            _canDispenser.Actuate();
            if(_numCans == 0)
            {
                _SoldOutLight.TurnOn();
            }
        }
    }
}
