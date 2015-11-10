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

        /// <summary>
        /// Coin constructor connecting coin dispensers with controller class
        /// </summary>
        /// <param name="coinValue"></param>
        /// <param name="initNum"></param>
        /// <param name="coinDispenser"></param>
        /// <param name="total"></param>
        public Coin(int coinValue, int initNum, CoinDispenser coinDispenser, VMControl total)
        {
            _coinValue = coinValue;
            _numCoin += initNum;
            _initCoins = initNum;
            _coinDispenser = coinDispenser;
            _total = total;
        }

        // Properties to grab the number of coins and the value of the coin
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

        // Method to simulate when coin is being added
        public void addCoin()
        {
            _numCoin++;
            _total.UpdateCredit(this);
        }

        // Method to remove a single coin from the inventory
        public void removeCoin(int numcoin)
        {
            _numCoin -= numcoin;
        }

        // Method to reset coin inventory
        public void resetCoin()
        {
            _numCoin = _initCoins;
        }
        
        // Method to dispense coins
        public void dispenseCoin(int numcoin)
        {
            removeCoin(numcoin);
            _coinDispenser.Actuate(numcoin);
        }
    }
}
