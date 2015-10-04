using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace BlackJack
{
    public class Player
    {

        private List<Card> _hand = new List<Card>();
        private int _money;
        private int _handValue;
        private string _handString;

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
        public int HandValue
        {
            get { return _handValue; }
        }

        public Player(int money)
        {
            _money = money;
        }

        public int AceCount;

        public void Deal(Card card)
        {
            _hand.Add(card);
            string r;
            char re;
            if (card.rank >= 10)
            {
                _handValue += 10;
                 r = card.rank.ToString();
                 re = replaceRank(r);
                _handString += (re + card.suit[0].ToString() + " ");
            }

            else if (card.rank == 1)
            {
                _handValue += 11;
                if(_handValue > 21)
                {
                    _handValue -= 10;
                }
                r = card.rank.ToString();
                re = replaceRank(r);
                _handString += (re + card.suit[0].ToString() + " ");
            }

            else
            {
                _handValue += card.rank;
                _handString += card.rank.ToString() + card.CardToString()[0] + " ";
            }
        }

        public void Reset()
        {
            _hand = new List<Card>();
            _handValue = 0;
            AceCount = 0;
            _handString = "";
        }

        public string HandToString()
        {
            return _handString;
        }

        private char replaceRank(string r)
        {
            switch (r)
            {
                case "10":
                    return 'T';
                case "11":
                    return 'J';
                case "12":
                    return 'Q';
                case "13":
                    return 'K';
                case "1":
                    return 'A';
            }
            return r[0];
        }
    }
}
