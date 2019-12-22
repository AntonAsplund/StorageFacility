using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageFacility
{
    /// <summary>
    /// Holds the user input methods used by front-end. With exception of a few "Console.ReadKey();".
    /// </summary>
    class UserInputs
    {
        PrintTexts printTexts = new PrintTexts();
        /// <summary>
        /// Method which lets user input a 1 for yes choice and 2 for no choice
        /// </summary>
        /// <returns>Int, either 1 or 2</returns>
        public int UserYesNoInput()
        {
            int userChoice = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out userChoice);
                if (sucessfullConversion == false)
                {
                    Console.Write("Please enter a valid number, try again: ");
                }
                else if (userChoice < 1 || userChoice > 2)
                {
                    sucessfullConversion = false;
                    Console.Write("Please enter a valid menu choice: ");
                }
            }

            return userChoice;
        }

        /// <summary>
        /// Converts a int input of 1 or 2 into a true and false value
        /// </summary>
        /// <param name="userChoice">Int value to bool converted</param>
        /// <returns>True / False bool</returns>
        public bool ConvertUserInputFromNumberToBool(int userChoice)
        {
            bool oneForTrueTwoForFalseConversion = false;

            if (userChoice == 1)
            {
                oneForTrueTwoForFalseConversion = true;
            }

            return oneForTrueTwoForFalseConversion;
        }
        /// <summary>
        /// Handles users input of choosen level and rack position. Level is zero based, thus users choice is decreased by one. While rack position is same as users input
        /// </summary>
        /// <returns>int array with [0] being level position zero based, and [1] rack position user based</returns>
        public int[] UserLevelAndRackInputForBoxAddition()
        {
            printTexts.PrintAddBoxToSpecifiedLevel();
            int level = 0;
            bool sucessfullConversionLevel = false;

            while (sucessfullConversionLevel == false)
            {
                sucessfullConversionLevel = int.TryParse(Console.ReadLine(), out level);
                level--;
                if (sucessfullConversionLevel == false)
                {
                    Console.Write("Invalid number, please try again: ");
                }
                else if (level < 0 || level > 2)
                {
                    Console.Write("Choosen number is not within scope, please try again: ");
                    sucessfullConversionLevel = false;
                }
            }

            printTexts.PrintAddBoxToSpecifiedRack();
            int rack = 0;
            bool sucessfullConversionRack = false;

            while (sucessfullConversionRack == false)
            {
                sucessfullConversionRack = int.TryParse(Console.ReadLine(), out rack);
                if (sucessfullConversionRack == false)
                {
                    Console.Write("Invalid number, please try again: ");
                }
                else if (rack < 1 || rack > 100)
                {
                    Console.WriteLine("Choosen number is not within scope, please try again: ");
                    sucessfullConversionRack = false;
                }
            }

            int[] result = new int[2] { level, rack };
            Console.Clear();
            return result;
        }
        /// <summary>
        /// Input method that handles for when the user is supposed to input a number. Ensures no faulty data is entered in the program.
        /// </summary>
        /// <returns>Int with the number entered by user</returns>
        public int UserInputAnyNumber()
        {
            int number = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out number);
                if (sucessfullConversion == false)
                {
                    Console.Write("Invalid number, try again: ");
                }
            }
            Console.Clear();
            return number;
        }
        /// <summary>
        /// Input handling for when user needs to input a length measurement.
        /// </summary>
        /// <returns>A int value holding the user weight input.</returns>
        internal int UserLengthInput()
        {
            bool sucessfullConversion = false;
            int measurement = 0;

            Console.Write("Enter measurement in nearest centimeter: ");

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out measurement);
                if (sucessfullConversion == false)
                {
                    Console.Write("Enter a valid number, try again: ");
                }
                else if (measurement < 1 || measurement > 220)
                {
                    Console.Write("Please enter a value in between 1 and 220 centimeters");
                    sucessfullConversion = false;
                }
            }

            Console.Clear();
            return measurement;
        }
        /// <summary>
        /// Input handling when user needs to input a number from 1 to 4.
        /// </summary>
        /// <returns></returns>
        internal int UserInputOneToFour()
        {
            int userChoice = 0;

            bool sucessfullConversion = false;
            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out userChoice);
                if (sucessfullConversion == false)
                {
                    Console.WriteLine("Please enter a valid number, try again...");
                }
                else if (userChoice < 1 || userChoice > 4)
                {
                    Console.WriteLine("Please enter a valid menu choice");
                    sucessfullConversion = false;
                }
            }

            return userChoice;
        }
        /// <summary>
        /// User inputs for when acess cases in the main menu.
        /// </summary>
        /// <returns>A int value with the users main menu choice</returns>
        internal int GetUserInputsForMainMenu()
        {
            int userChoice = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out userChoice);
                if (sucessfullConversion == false)
                {
                    Console.WriteLine("Please do only write numbers");
                }
                else if (userChoice < 1 || userChoice > 8)
                {
                    Console.WriteLine("Please enter a valid menu choice");
                    sucessfullConversion = false;
                }
            }
            Console.Clear();
            return userChoice;
        }
        /// <summary>
        /// User input handling when a number from 1 to 3 is needed.
        /// </summary>
        /// <returns></returns>
        internal int GetUserInputOneToThree()
        {
            int userChoice = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out userChoice);
                if (sucessfullConversion == false)
                {
                    Console.WriteLine("Please do only write numbers");
                }
                else if (userChoice < 1 || userChoice > 4)
                {
                    Console.WriteLine("Please enter a valid menu choice");
                    sucessfullConversion = false;
                }
            }

            return userChoice;
        }
        /// <summary>
        /// Inout handling when giving a box a weight value. Handles faulty inputs of a negative number.
        /// </summary>
        /// <returns>A decimal value with the user given weight</returns>
        internal decimal UserWeightOfBoxInput()
        {
            Console.Clear();
            Console.Write("Please enter weight of box: ");

            decimal weightOfBox = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = decimal.TryParse(Console.ReadLine(), out weightOfBox);
                if (sucessfullConversion == false)
                {
                    Console.Write("Please enter a valid number, try again: ");
                }
                else if (weightOfBox < 0.001M )
                {
                    Console.Write("Please enter a valid weight in kilograms: ");
                    sucessfullConversion = false;
                }
            }

            return weightOfBox;
        }
        /// <summary>
        /// Handles input for when user is entering a level to print the rack contents of.
        /// </summary>
        /// <returns></returns>
        public int UserInputVisualizationLevel()
        {
            int userChoice = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out userChoice);
                if (sucessfullConversion == false)
                {
                    Console.Write("Please enter a valid number, try again: ");
                }
                else if (userChoice < 1 || userChoice > 3)
                {
                    Console.Write("Please enter a number within scope 1-3, try again: ");
                    sucessfullConversion = false;
                }
            }

            userChoice--;   //Removes one from userChoice since level handling is zero based
            return userChoice;
        }
        /// <summary>
        /// Handles input for when users is entering rack number, for when user wants its contents.
        /// </summary>
        /// <returns></returns>
        public int UserInputVisualizationRack()
        {
            int userChoice = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = int.TryParse(Console.ReadLine(), out userChoice);
                if (sucessfullConversion == false)
                {
                    Console.Write("Please enter a valid number, try again: ");
                }
                else if (userChoice < 1 || userChoice > 100)
                {
                    Console.Write("Please enter a number within scope 1-100, try again: ");
                    sucessfullConversion = false;
                }
            }

            return userChoice;
        }
    }
}
