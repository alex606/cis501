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
        private int _initCoins;
        private int _coinValue;
        private CoinDispenser _coinDispenser;
        private VMControl _total;

        public Coin(int coinValue, int initNum, CoinDispenser coinDispenser, VMControl total)
        {
            _coinValue = coinValue;
            _numCoin += initNum;
            _coinDispenser = coinDispenser;
            _total = total;
        }

        public void addCoin()
        {
            _numCoin++;
            _total.UpdateCredit(this);
        }

        public void removeCoin()
        {
            _numCoin--;
        }

        public void resetCoin()
        {
            _numCoin = _initCoins;
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
