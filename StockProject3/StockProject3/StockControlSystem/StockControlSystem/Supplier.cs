using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    public class Supplier
    {
        private int _SupplierID;
        private string _SupplierName;
        private string _SupplierAddress;
        private string _SupplierPhoneNumber;

        public Supplier(string[] SupplierInfo)
        {
            _SupplierID = Convert.ToInt16(SupplierInfo[0]);
            _SupplierName = SupplierInfo[1];
            _SupplierAddress = SupplierInfo[2];
            _SupplierPhoneNumber = SupplierInfo[3];
        }

        public int ID
        {
            get { return _SupplierID; }
        }
        public string Name
        {
            get { return _SupplierName; }
        }
        public string Address
        {
            get { return _SupplierAddress; }
        }
        public string PhoneNumber
        {
            get { return _SupplierPhoneNumber; }
        }

    }
}
