using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Controller class for handling Vending machine input and output
    /// </summary>
    public class VMControl
    {
        private int credit;
        private Coin[] _Coins;
        private Can[] _Cans;
        private AmountDisplay _ad;
        private Light[] _purchaseLights;
        private CanDispenser[] _canDispensors;
        private CoinDispenser[] _coinDispensors;
        private TimerLight _noChangelight;
        private int[] _initCans;
        private int[] _initCoins;
        private Light[] _soldOutLights;

        public VMControl(Coin[] Coins, Can[] Cans, AmountDisplay AD, Light[] PL,
            CanDispenser[] CD, CoinDispenser[] CoD, TimerLight NCL, int[] InitCans, int[] InitCoins,
            Light[] SOL)
        {
            _Coins = Coins;
            _Cans = Cans;
            _ad = AD;
            _purchaseLights = PL;
            _canDispensors = CD;
            _coinDispensors = CoD;
            _noChangelight = NCL;
            _initCans = InitCans;
            _initCoins = InitCoins;
            _soldOutLights = SOL;
        }

        /// <summary>
        /// Method to update coin inventory after inserting a coin
        /// </summary>
        /// <param name="coin"></param>
        public void addCoin(Coin coin)
        {
            coin.addCoin();
            credit += coin.coinValue;
            UpdateDisplay();
        }

        /// <summary>
        /// Method to check whether a can can be purchased
        /// </summary>
        /// <param name="can"></param>
        /// <returns></returns>
        public Boolean isPurchseable(Can can)
        {
            if(credit >= can.price)
            {
                if(can.CanStock > 0)
                {   
                    if (CanReturnCoins(can.price))
                    {
                        return true;
                    }
                    _noChangelight.TurnOn3Sec();
                }
            }
            return false;
        }

        /// <summary>
        /// Method to calculate whether correct change can be given
        /// </summary>
        /// <param name="purchasePrice"></param>
        /// <returns></returns>
        public Boolean CanReturnCoins(int purchasePrice = 0)
        {
            int start = _Coins.Length - 1;
            int testCredit = credit - purchasePrice;
            for (int i = start; i >= 0; i--)
            {
                int value = _Coins[i].coinValue;
                int numCoins = _Coins[i].numCoin;
                while (value <= testCredit && numCoins > 0)
                {
                    testCredit -= _Coins[i].coinValue;
                    numCoins--;
                }
            }
            if(testCredit > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Method to actuate can purchase
        /// </summary>
        /// <param name="can"></param>
        public void purchaseCan(Can can)
        {
            if(isPurchseable(can))
            {
                credit -= can.price;
                can.removeCan();
                returnCoins();
                UpdateDisplay();
                int i = Array.IndexOf(_Cans, can);
                _canDispensors[i].Actuate();
            }
        }

        /// <summary>
        /// Method to return correct change in coins
        /// </summary>
        public void returnCoins()
        {
            if(!CanReturnCoins())
            {
                _noChangelight.TurnOn3Sec();
                return;
            }

            int start = _Coins.Length - 1;
            for (int i = start; i >= 0; i--)
            {
                int value = _Coins[i].coinValue;
                int count = 0;
                while(value <= credit && _Coins[i].numCoin > 0)
                {
                    credit -= _Coins[i].coinValue;
                    _Coins[i].removeCoin();
                    count++;
                }
                _coinDispensors[i].Actuate(count);
            }
            UpdateDisplay();
        }

        /// <summary>
        /// Method to update the lights and Amount Displayed on the vending machine form
        /// </summary>
        public void UpdateDisplay()
        {
            for (int i = 0; i < _Cans.Length; i++)
            {
                if (_Cans[i].price <= credit && _Cans[i].CanStock > 0)
                {
                    _purchaseLights[i].TurnOn();
                }
                else
                {
                    _purchaseLights[i].TurnOff();
                }
                if(_Cans[i].CanStock == 0)
                {
                    _soldOutLights[i].TurnOn();
                }
                else
                {
                    _soldOutLights[i].TurnOff();
                }
            }
            _ad.DisplayAmount(credit);
        }

        /// <summary>
        /// Method for when user resets vending machine inventory
        /// </summary>
        public void resetAll()
        {
            for(int i = 0; i < _Coins.Length; i++)
            {
                _Coins[i].resetCoin(_initCoins[i]);
            }

            for (int i = 0; i < _Cans.Length; i++)
            {
                _Cans[i].resetCans(_initCans[i]);
            }
            credit = 0;
            UpdateDisplay();
        }
    }
}
