using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;


namespace BlackJack
{
    class BlackJack : CardGame
    {
        private Player user;
        private Player dealer;
        private int betAmount;
        private int numUserWins;
        private int numDealerWins;
        private int NumTies;
        private CardGame _cardGame;
        private Card drawCard;
        private ITerminal _terminal;

        static void Main(string[] args)
        {
            BlackJack newGame = new BlackJack(new ConsoleTerminal());
            newGame.go();
        }

        /// <summary>
        /// Constructor for BlackJack game
        /// </summary>
        /// <param name="terminal"></param>
        public BlackJack(ITerminal terminal) : base(terminal)
        {
            _terminal = terminal;
            user = new Player(100);
            dealer = new Player(9999999);
            _cardGame = new CardGame(terminal);
        }

        /// <summary>
        /// While loop to reinitiate new games
        /// </summary>
        void go()
        {
            while(true)
            {
                playOneGame();
                if(displayStatAndCheckBankrupt())
                {
                    break;
                }
                if(! checkMoregame())
                {
                    break;
                }
                resetGame();
            }
        }

        /// <summary>
        /// Play instance
        /// </summary>
        void playOneGame()
        {
            getUsersBet();
            dealCards();
            if(testNatural21()){
                return;
            }
            if(testSurrender()){
                return;
            }
            if(userTurnAndCheckBust()){
                return;
            }
            if(dealerTurnAndCheckBust()){
                return;
            }
        }

        /// <summary>
        /// Method to take a bet form the user
        /// </summary>
        void getUsersBet()
        {
            _terminal.Display("========== New Game ========== ");
            _terminal.Display("You Have : $" + user.Money);
            betAmount = _terminal.GetInt("How much do you bet : ",1,user.Money);
        }

        /// <summary>
        /// Method to deal cards to both user and dealer
        /// </summary>
        void dealCards()
        {
            drawCard = _cardGame.deck.CardDraw("Input 1st card for user <3H, AD, TC, etc. or XX to draw from deck> ");
            user.Deal(drawCard);
            drawCard = _cardGame.deck.CardDraw("Input 1st card for dealer <3H, AD, TC, etc. or XX to draw from deck> ");
            dealer.Deal(drawCard);
            drawCard = _cardGame.deck.CardDraw("Input 2nd card for user <3H, AD, TC, etc. or XX to draw from deck> ");
            user.Deal(drawCard);
            drawCard = _cardGame.deck.CardDraw("Input 2nd card for dealer <3H, AD, TC, etc. or XX to draw from deck> ");
            dealer.Deal(drawCard);
        }

        /// <summary>
        /// Method to check for Natural 21
        /// </summary>
        /// <returns></returns>
        bool testNatural21()
        {
            _terminal.Display("Your Hand = " + user.HandToString() + " , Hand Value = " + user.HandValue);
            string dealHand = dealer.HandToString();
            _terminal.Display("Dealer's Hand = " + dealHand[0] + dealHand[1] + " XX");

            if (user.HandValue == 21 && dealer.HandValue == 21)
            {
                _terminal.Display("Both Got Natural21");
                _terminal.Display("Standoff");
                NumTies++;
                return true;
            }
            else if(user.HandValue == 21)
            {
                betAmount = (int)(Convert.ToDouble(betAmount) * 1.5);
                _terminal.Display("You got Natural21: $" + betAmount + " Goes to You from Dealer");
                user.Money += betAmount;
                numUserWins++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// method to prompt user asking for surrender
        /// </summary>
        /// <returns></returns>
        bool testSurrender()
        {
            char choice = _terminal.GetChar("Do you want to surrender <Y or N> ? :", "YN");
            if(choice == 'Y')
            {
                betAmount /= 2;
                _terminal.Display("You Surrender: $" + betAmount + " Goes to Dealer");
                user.Money -= betAmount;
                numDealerWins++;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// method to process users turn
        /// </summary>
        /// <returns></returns>
        bool userTurnAndCheckBust()
        {
            char choice = _terminal.GetChar("Will you HIT or STAND <H or S> ? : ", "HS");
            if(choice == 'S')
            {
                return false;
            }

            else
            {
                while(choice == 'H')
                {
                    drawCard = _cardGame.deck.CardDraw("Input next card for user <3H, AD, TC, etc. or XX to draw from deck> ");
                    user.Deal(drawCard);
                    _terminal.Display("Your Hand = " + user.HandToString() + " , Hand Value = " + user.HandValue);
                    _terminal.Display("Dealer's Hand = " + dealer.HandToString());

                    if (user.HandValue > 21)
                    {
                        _terminal.Display("You Bust");
                        Console.WriteLine("Dealer Won and gets $" + betAmount + " from User");
                        user.Money -= betAmount;
                        numDealerWins++;
                        return true;
                    }
                    choice = _terminal.GetChar("Will you HIT or STAND <H or S> ? : ", "HS");
                }
            }
            return false;
        }

        /// <summary>
        /// Method to process dealer's turn
        /// </summary>
        /// <returns></returns>
        bool dealerTurnAndCheckBust()
        {
            _terminal.Display("Now Dealer's turn");
            _terminal.Display("Dealer's hand : " + dealer.HandToString() + " , Hand Value = " + user.HandValue);

            while (dealer.HandValue <= 16)
            {
                dealer.Deal(_cardGame.deck.CardDraw("Input next card for dealer <3H, AD, TC, etc. or XX to draw from deck> "));
                _terminal.Display("Dealer's hand : " + dealer.HandToString() + " , Hand Value = " + user.HandValue);
                if (dealer.HandValue > 21)
                {
                    _terminal.Display("Dealer Busts");
                    _terminal.Display("You Won and get $" + betAmount + " from Dealer");
                    numUserWins++;
                    user.Money += betAmount;
                    return false;
                }
            }

            if(dealer.HandValue > user.HandValue)
            {
                _terminal.Display("Dealer Won and Gets $" + betAmount + " from User");
                user.Money -= betAmount;
                numDealerWins++;
            }
            else if (dealer.HandValue == user.HandValue)
            {
                _terminal.Display("Standoff");
                NumTies++;
            }
            else
            {
                _terminal.Display("You Won and Get $" + betAmount + " from Dealer");
                user.Money += betAmount;
                numUserWins++;
            }
            return true;
        }

        /// <summary>
        /// Method to display player stats and ask for a rematch
        /// </summary>
        /// <returns></returns>
        bool displayStatAndCheckBankrupt()
        {
            _terminal.Display("You Won " + numUserWins+ " times, lost " + numDealerWins + " times, and tied " + NumTies + " times");
            if(user.Money < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkMoregame()
        {
            char choice = _terminal.GetChar("More Game <Y or N> ? : ", "YN");
            if(choice == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to start a new game
        /// </summary>
        void resetGame()
        {
            user.Reset();
            dealer.Reset();
        }

    }
}
