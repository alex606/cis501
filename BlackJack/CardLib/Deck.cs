using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class Deck
    {
        private List<int> _avail = new List<int>();
        private Random random = new Random();
        private int cardNo;

        /// <summary>
        /// Property to get available cards
        /// </summary>
        public List<int> Cards
        {
            get { return _avail; }
        }

        private CardGame _cardGame
        { get ; set; }

        /// <summary>
        /// Constructor for Deck Class
        /// </summary>
        /// <param name="cardGame"></param>
        public Deck(CardGame cardGame)
        {
            _avail = Enumerable.Range(0, 51).ToList<int>();
            _cardGame = cardGame;

        }

       /// <summary>
       /// Draw method
       /// </summary>
       /// <param name="prompt"></param>
        public Card CardDraw(string prompt)
        {
#if DEBUG
            int suitValue;
            string choice = _cardGame.GetCardString(prompt);

            if(choice == "XX")
            {
                cardNo = random.Next(_avail.Count);
            }

            else
            {
                if (choice[1] == 'H')
                { suitValue = 0; }
                else if (choice[1] == 'D')
                { suitValue = 1; }
                else if (choice[1] == 'C')
                { suitValue = 2; }
                else
                { suitValue = 3; }

                if(choice[0] == 'T')
                {
                    cardNo = (suitValue * 13 + 9);
                }
                else if (choice[0] == 'A')
                {
                    cardNo = (suitValue * 13);
                }
                else
                {
                    cardNo = (suitValue * 13 + (int)Char.GetNumericValue(choice[0]) - 1);
                }
            }
            
            Card drawCard = new Card(cardNo);
            return drawCard;


#else //release mode draw
            System.Threading.Thread.Sleep(5);
            int drawValue = random.Next(_avail.Count);
            Card drawCard = new Card(drawValue);
            return drawCard;
#endif
        }

        /// <summary>
        /// Method to reset list
        /// </summary>
        void Reset()
        {
            _avail = new List<int>();
        }
    }
}
