using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageFacility
{
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
        public int[] UserLevelAndRackInput()
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

            return result;
        }
    }
}
