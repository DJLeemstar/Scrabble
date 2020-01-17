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
            // Notation Reference used:: 

            // Declare empty array
            char[] rgchLetters = new char[7];

            // Introduce player to the game
            Console.WriteLine("Welcome to Mini-Scrabble! Try to see how many words you can make with the letters given!");

            // Randomise a list of letters
            pcRandomList(ref rgchLetters);

            Console.WriteLine("Your letters are:" + rgchLetters);
            Console.WriteLine("What words can you make?");

            if (fnWordTrue(Console.ReadLine()))
            {



            }

            else
            {


            }



            
            Console.ReadKey();

        }

        bool fnWordTrue(string strInput)
        {



            return true;
        }
        
        void pcRandomList(ref char[] rrgLetters)  // Edits original Char Array by reference
        {

            Random rnRnd = new Random();            // Establish Random for use with character array randomisation

            // Array with every scrabble letter. Not done with iteration, as it would take longer and likely be less efficient

            char[] rgchScrabbleValues = {'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A',
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

                int iIndex = (rnRnd.Next(rgchScrabbleValues.Length));    // Picks a random number as an index from the Scrabble letters
                rrgLetters[i] = rgchScrabbleValues[iIndex];              // Places char value from random index into parameter array
                rgchScrabbleValues.RemoveAt();
                
            }
        }



        static void Main(string[] args) // Instantiates the rest of the program
        {

            Program progProgram = new Program();
            progProgram.pcMyMain();     // Ensures rest of the program doesn't need to be a Static structure.

        }
    }
}