using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class CardGame
    {

        private ITerminal _terminal;
        private Deck _deck;

        public Deck deck
        {
            get { return _deck; }

        }

        public CardGame(ITerminal terminal)
        {
            _deck = new Deck(this);
            _terminal = terminal;

        }

        public string GetCardString(string prompt)
        {
            // this is used by Deck.Deal() in the Debug mode
            // This keeps reading a string with 2 characters from  
            // terminal until the string  is “XX” or (1st character is in
            //  “A23456789TJQK” and 2nd character is in “HDSC”
            // return the string
            string read;
            string ranks = "A23456789TJQK";
            string suits = "HDSC";
            while (true)
            {
                read = _terminal.GetString(prompt, 2).ToUpper();
                if(read == "XX" || ranks.Contains(read[0]) && suits.Contains(read[1]))
                {
                    return read;
                }
            }
        }

        void Display(string s)
        {
            _terminal.Display(s);
        }
    }
}
