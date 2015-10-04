using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class Card
    {
        private int _rank;
        private string _suit;

        // enum to hold card suits
        private enum CardSuit {
            Hearts = 0,
            Diamonds = 1,
            Clubs = 2,
            Spades = 3}

        /// <summary>
        /// properties to hold rank and suit
        /// </summary>
        public int rank
        {
            get { return _rank;  }
        }
        public string suit
        {
            get { return _suit;  }
        }

        public Card(int cardNo)
        {
            CardSuit suit = (CardSuit)(cardNo / 13);
            _rank = (cardNo % 13) + 1;
            _suit = suit.ToString();
        }

        /// <summary>
        /// Method to grab string representation of card
        /// </summary>
        /// <returns></returns>
        public string CardToString()
        {
            return suit.ToString() + rank.ToString();
        }
    }
}
