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
        private TimerLight _noChangelight;
        private int[] _initCans;
        private int[] _initCoins;
        private Light[] _soldOutLights;

        /// <summary>
        /// Controller Class constructor
        /// </summary>
        /// <param name="AD"></param>
        /// <param name="PL"></param>
        /// <param name="NCL"></param>
        /// <param name="SOL"></param>
        public VMControl(AmountDisplay AD, Light[] PL, TimerLight NCL,  Light[] SOL)
        {
            _ad = AD;
            _purchaseLights = PL;
            _noChangelight = NCL;
            _soldOutLights = SOL;
        }

        /// <summary>
        /// Method to Connect Cans and Coins objects with Controller
        /// </summary>
        /// <param name="Coins"></param>
        /// <param name="Cans"></param>
        /// <param name="InitCans"></param>
        /// <param name="InitCoins"></param>
        /// <param name="?"></param>
        public void initMachine(Coin[] Coins, Can[] Cans, int[] InitCans, int[] InitCoins)
        {
            _Coins = Coins;
            _Cans = Cans;
            _initCans = InitCans;
            _initCoins = InitCoins;
        }

        /// <summary>
        /// Method to update coin inventory after inserting a coin
        /// </summary>
        /// <param name="coin"></param>
        public void UpdateCredit(Coin coin)
        {
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
            if(credit >= can.price && can.CanStock > 0)
            {
                if (CanReturnCoins(can.price))
                {
                    return true;
                }
                _noChangelight.TurnOn3Sec();
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
        /// Method to return correct change in coins
        /// </summary>
        public void returnCoins()
        {
            int start = _Coins.Length - 1;
            for (int i = start; i >= 0; i--)
            {
                int value = _Coins[i].coinValue;
                int count = 0;
                while (value <= credit && _Coins[i].numCoin > count)
                {
                    credit -= _Coins[i].coinValue;
                    count++;
                }
                _Coins[i].dispenseCoin(count);
            }
            UpdateDisplay();
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
                can.DispenseCan();
                returnCoins();
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Method to update the lights and Amount Displayed on the vending machine form
        /// </summary>
        public void UpdateDisplay()
        {
            for (int i = 0; i < _Cans.Length; i++)
            {
                _Cans[i].IsCanPurchaseable(credit);
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
                _Coins[i].resetCoin();
            }

            for (int i = 0; i < _Cans.Length; i++)
            {
                _Cans[i].resetCans();
            }
            credit = 0;
            UpdateDisplay();
        }
    }
}
