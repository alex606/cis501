using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Coin class to keep track of coin inventory for each denomination
    /// </summary>
    public class Coin
    {

        private int _numCoin;
        private int _totalValue;
        private int _coinValue;
        private CoinDispenser _coinDispenser;

        public Coin(int coinValue, int initNum, CoinDispenser coinDispenser)
        {
            _coinValue = coinValue;
            _numCoin += initNum;
            _coinDispenser = coinDispenser;
        }

        public void addCoin()
        {
            _numCoin++;
            _totalValue += _coinValue;
        }

        public void removeCoin()
        {
            _numCoin--;
            _totalValue -= _coinValue;
        }

        public void resetCoin(int initNum)
        {
            _numCoin = initNum;
            _totalValue = 0;
        }

        public int numCoin
        {
            get
            {
                return _numCoin;
            }
        }

        public int coinValue
        {
            get
            {
                return _coinValue;
            }
        }

        public void dispenseCoin(int numcoin)
        {
            _coinDispenser.Actuate(numcoin);
        }



    }
}
