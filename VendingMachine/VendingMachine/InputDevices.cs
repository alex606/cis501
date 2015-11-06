//////////////////////////////////////////////////////////////////////
//      Vending Machine (Actuators.cs)                              //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010, 2011 //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    // For each class, you can (must) add fields and overriding constructors

    public class CoinInserter
    {
        // add a field to specify an object that CoinInserted() will firstvisit
        Coin _coin;
        //VMControl _total;

        // rewrite the following constructor with a constructor that takes an object
        // to be set to the above field
        public CoinInserter()
        {
        }
        public CoinInserter(Coin coin)
        {
            _coin = coin;
            //_total = Total;
        }
        public void CoinInserted()
        {
            // You can add only one line here
            //_total.addCoin(_coin);
            _coin.addCoin();

        }

    }

    public interface VMButton
    {
        void ButtonPressed();
    }

    public class PurchaseButton : VMButton
    {
        // add a field to specify an object that ButtonPressed() will first visit
        Can _can;
        //VMControl _total;
        

        public PurchaseButton(Can can)
        {
            _can = can;
            //_total = total;
        }
        public void ButtonPressed()
        {
            // You can add only one line here
            //_total.purchaseCan(_can);
            _can.PurchaseCan();
            
        }
    }

    public class CoinReturnButton : VMButton
    {
        // add a field to specify an object that Button Pressed will visit
        // replace the following default constructor with a constructor that takes
        // an object to be set to the above field
        VMControl _total;
        public CoinReturnButton(VMControl total)
        {
            _total = total;
        }
        public void ButtonPressed()
        {
            // You can add only one lines here
            _total.returnCoins();
            
        }
    }

    public class SalesRecordListButton : VMButton
    {
        // add a field to specify an object that ButtonPressed will visit
        public SalesRecordListButton()
        {
        }
        public void ButtonPressed()
        {
            // You can add only one line herer
        }
    }

    public class SalesRecordClearButton : VMButton
    {
        // add a field to specify an object that ButtonPressed will visit 
        public SalesRecordClearButton()
        {
        }

        public void ButtonPressed()
        {
            // You can add only one line here
        }
    }
}
