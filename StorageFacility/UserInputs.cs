using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageFacility
{
    class UserInputs
    {
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
                if (userChoice < 1 || userChoice > 2)
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
    }
}
