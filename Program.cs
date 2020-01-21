using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleProject
{
    class Program
    {
        void pcMyMain()     // Main Procedure. 
        {
            // Notation Reference used:: http://web.mst.edu/~cpp/common/hungarian.html

            // Declare empty array
            char[] rgchLetters = new char[7];

            // Introduce player to the game
            Console.WriteLine("Welcome to Mini-Scrabble! Try to see how many words you can make with the letters given!");

            // Randomise a list of letters
            pcRandomList(ref rgchLetters);

            Console.WriteLine("Your letters are:");
            Console.WriteLine(string.Join(" ", rgchLetters));
            Console.WriteLine("What words can you make?");

            if (fnWordTrue(Console.ReadLine(), rgchLetters))
            {
                


            }

            else
            {
                


            }



            
            Console.ReadKey();

        }

        int fnCountScore(string strInput)
        {



            return true;

        }

        bool fnWordTrue(string strInput, char[] rgchLetters)
        {

            for (int iLetter = 0; iLetter < strInput.Length; iLetter++)
            {

                if (!(rgchLetters.Contains(strInput[iLetter])))      // If the random letters do not contain whatever was typed.
                {
                    
                    return false;                                   // This means the user has made up a letter that isn't present.

                }

                rgchLetters[Array.IndexOf(rgchLetters, strInput[iLetter])] = ' ';  // Removes the letter so that it can't be found again.


            }

            return true;

        }
        
        void pcRandomList(ref char[] rrgLetters)  // Modifies original Char Array by reference
        {

            Random rnRnd = new Random();            // Establish Random for use with character array randomisation

            // List with every scrabble letter. Not done with iteration, as it would take longer and likely be less efficient
            // Ordered List instead of Array to make locating specific letters simpler for removal.

            List<char> rgchScrabbleValues = new List<char>{'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A',
                                'B', 'B',
                                'C', 'C',
                                'D', 'D', 'D', 'D',
                                'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E',
                                'F', 'F',
                                'G', 'G', 'G',
                                'H', 'H',
                                'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I',
                                'J',
                                'K',
                                'L', 'L', 'L', 'L',
                                'M', 'M',
                                'N', 'N', 'N', 'N', 'N', 'N',
                                'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O',
                                'P', 'P',
                                'Q',
                                'R', 'R', 'R', 'R', 'R', 'R',
                                'S', 'S', 'S', 'S',
                                'T', 'T', 'T', 'T', 'T', 'T',
                                'U', 'U', 'U', 'U',
                                'V', 'V',
                                'W', 'W',
                                'X',
                                'Y', 'Y',
                                'Z'};

            for (int i = 0; i <= 6; i++)    // Use of iteration
            {

                int iIndex = (rnRnd.Next(rgchScrabbleValues.Count));    // Picks a random number as an index from the Scrabble letters
                rrgLetters[i] = rgchScrabbleValues[iIndex];             // Places char value from random index into parameter array
                rgchScrabbleValues.RemoveAt(iIndex);                    // Removes random character, so it can't be rerolled.
                
            }
        }



        static void Main(string[] args) // Instantiates the rest of the program
        {

            Program progProgram = new Program();
            progProgram.pcMyMain();     // Ensures rest of the program doesn't need to be a Static structure.

        }
    }
}