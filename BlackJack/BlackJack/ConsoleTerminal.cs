using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace BlackJack
{
    public class ConsoleTerminal : ITerminal
    {
        void ITerminal.Display(string s)
        {
            Console.WriteLine(s);
        }

        public char GetChar(string prompt, string chars)
        {

            string readChar;
            while (true)
            {
                Console.Write(prompt);
                readChar = Console.ReadLine().ToUpper();

                if(chars.Contains(readChar) && readChar.Length == 1)
                {
                    return readChar[0];
                }
            }
        }

        public int GetInt(string prompt, int min, int max)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            int value;
            bool check = !int.TryParse(input, out value);
            

            while(check || (min != 0 && max != 0 && min <= max) && (value <= min || value >= max))
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                check = !int.TryParse(input, out value);
            }
            return value;
        }

        public string GetString(string prompt, int length)
        {
            string read;
            while(true)
            {
                Console.Write(prompt);
                read = Console.ReadLine();
                if(read.Length == length || length == 0)
                {
                    return read;
                }
            }
        }
    }
}
