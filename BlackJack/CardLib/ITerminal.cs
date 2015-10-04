using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public interface ITerminal
    {
        /// <summary>
        /// Display String s
        /// </summary>
        /// <param name="s"></param>
        void Display(string s);

        /// <summary>
        /// keep readlinga  line until user types exactly one character and the character is in "Chars"
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        char GetChar(string prompt, string chars);

        /// <summary>
        /// keep readlinga  line using "prompt" until the user types
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        int GetInt(string prompt, int min, int max);

        /// <summary>
        /// keep reading a string using prompt
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        string GetString(string prompt, int length);
    }
}
