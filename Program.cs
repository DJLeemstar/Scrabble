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

            // Declare/Assign local structures/variables
            char[] rgchLetters = new char[7];
            int iScore = 0;
            int iRounds = 0;
            bool bGameOver = false;
            string strUserInput;

            // Introduce player to the game
            Console.WriteLine("Welcome to Mini-Scrabble! Try to see how many words you can make with the letters given!" +
                "\nLetter case does not matter!");

            // Randomise a list of letters
            pcRandomList(ref rgchLetters);

            // Tell the user their random letters
            Console.WriteLine("Your letters are:");
            Console.WriteLine(string.Join(" ", rgchLetters));
            Console.WriteLine("What words can you make?" +
                "\nType '!exit' if you can no longer think of any words!");

            while (bGameOver == false)              // The main portion of the game's interactivity.
            {

                strUserInput = Console.ReadLine();  // Takes the user's input

                if (strUserInput == "!exit")        // Condition for the player to finish the game. Checked first to avoid being mistaken for a Scrabble word attempt.
                {

                    Console.WriteLine("Your final score is: " + iScore);    

                    bGameOver = true;               // The game officially ends here.

                }

                else if (fnWordTrue(strUserInput, rgchLetters)) // The player has made a correct input with the given characters.
                {

                    iScore += fnCountScore(strUserInput);       // Keep track of the total score.
                    iRounds++;                                  // Allow for continuous count of number of game rounds.

                    Console.WriteLine("You have input " + iRounds + " words so far, for a total current score of " + iScore);

                }

                else        // The player has entered an arbitrary word, and will gain no score.
                {

                    Console.WriteLine("That is not a word that can be spelled with what you have been given. Please try again.");

                }

            }

            Console.ReadKey();

        }

        int fnCountScore(string strInput)   // A function to count each letter and returns the total Scrabble value as an integer.
        {
            int iCount = 0;

            Dictionary<char, int> dictScrabbleValues = new Dictionary<char, int> { { 'A', 1 },      // Initialise a dictionary to efficiently search the letter's numeric Scrabble values.
                                                                                 { 'E', 1 },        // From what I can tell, this is the most efficient way to complete this search without too much work and without excess conditionals.
                                                                                 { 'I', 1 },        // Please tell me if I am wrong about this - I am eager to learn more about the most efficient/maintainable methods of data store and search.
                                                                                 { 'O', 1 },
                                                                                 { 'U', 1 },
                                                                                 { 'L', 1 },
                                                                                 { 'N', 1 },
                                                                                 { 'S', 1 },
                                                                                 { 'T', 1 },
                                                                                 { 'R', 1 },
                                                                                 { 'D', 2 },
                                                                                 { 'G', 2 },
                                                                                 { 'B', 3 },
                                                                                 { 'C', 3 },
                                                                                 { 'M', 3 },
                                                                                 { 'P', 3 },
                                                                                 { 'F', 4 },
                                                                                 { 'H', 4 },
                                                                                 { 'V', 4 },
                                                                                 { 'W', 4 },
                                                                                 { 'Y', 4 },
                                                                                 { 'K', 5 },
                                                                                 { 'J', 8 },
                                                                                 { 'X', 8 },
                                                                                 { 'Z', 10 },
                                                                                 { 'Q', 10 } };

            foreach (char chLetter in strInput)     // Iterate each letter in the successful word.
            {

                iCount += dictScrabbleValues[Char.ToUpper(chLetter)];     // Get the integer value from dict using uppercase character as a key.

            }

            Console.WriteLine("Nice job! You scored " + iCount + " for " + strInput);

            return iCount;

        }

        bool fnWordTrue(string strInput, char[] rgchLetters)        // Function to return whether the user's input can be made with the given characters.
        {

            strInput = strInput.ToUpper();                           // All letters are uppercase, so the game is not case-sensitive.

            char[] rgchDupeLetters = rgchLetters;

            for (int iLetter = 0; iLetter < strInput.Length; iLetter++)     // Iterate through the range of the user's string input.
            {

                if (!(rgchDupeLetters.Contains(strInput[iLetter])))      // If the random letters do not contain whatever was typed:
                {

                    return false;                                    // This means the user has made up a letter that isn't present.

                }

                rgchDupeLetters[Array.IndexOf(rgchDupeLetters, strInput[iLetter])] = ' ';  // Removes the letter so that it can't be found again.

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
