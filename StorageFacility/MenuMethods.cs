using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{
    /// <summary>
    /// Handles logical methods in use by the main menu
    /// </summary>
    internal class MenuMethods
    {
        PrintTexts printText = new PrintTexts();
        UserInputs userInputs = new UserInputs();
        /// <summary>
        /// Handles the creation of a new box. Calls methods for user input and delives a newboxinput object to the users specification
        /// </summary>
        /// <returns>A NewBoxInput object used to create a new I3DObject inherited object in facorty WareHouse.</returns>
        internal NewBoxInput CreateNewBox()
        {
            NewBoxInput newBox = new NewBoxInput();
            printText.PrintCreateNewBoxInputCHoice();
            int userChoice = userInputs.UserInputOneToFour();

            Console.Clear();

            switch (userChoice)
            {
                case 1:
                    {
                        string description = "Blob";
                        decimal weight = userInputs.UserWeightOfBoxInput();
                        bool isFragile = true;
                        Console.WriteLine("What is the length of one side?");
                        int lengthSideX = userInputs.UserLengthInput();

                        NewBoxInput newBlob = new NewBoxInput(weight, description, isFragile, lengthSideX);
                        return newBlob;
                    }
                case 2:
                    {
                        string description = "Cube";
                        decimal weight = userInputs.UserWeightOfBoxInput();
                        bool isFragile = IsTheBoxFragileUserInput();
                        Console.WriteLine("What is the length of one side?");
                        int lengthSideX = userInputs.UserLengthInput();

                        NewBoxInput newCube = new NewBoxInput(weight, description, isFragile, lengthSideX);
                        return newCube;
                    }
                case 3:
                    {
                        string description = "Cuboid";
                        decimal weight = userInputs.UserWeightOfBoxInput();
                        bool isFragile = IsTheBoxFragileUserInput();
                        Console.WriteLine("What is the length of side X?");
                        int lengthSideX = userInputs.UserLengthInput();
                        Console.WriteLine("What is the length of side Y?");
                        int lengthSideY = userInputs.UserLengthInput();
                        Console.WriteLine("What is the length of side Z?");
                        int lengthSideZ = userInputs.UserLengthInput();

                        NewBoxInput newCuboid = new NewBoxInput(weight, description, isFragile, lengthSideX, lengthSideY, lengthSideZ);
                        return newCuboid;
                    }
                case 4:
                    {
                        string description = "Sphere";
                        decimal weight = userInputs.UserWeightOfBoxInput();
                        bool isFragile = IsTheBoxFragileUserInput();
                        Console.WriteLine("What is the length of the radius?");
                        int radius = userInputs.UserLengthInput();

                        NewBoxInput newSphere = new NewBoxInput(weight, description, isFragile, radius);
                        return newSphere;
                    }
            }

            return newBox;
        }
        /// <summary>
        /// Handles user input if a box is considerd fragile or not. 
        /// </summary>
        /// <returns>A bool indicating if object is fragile or not.</returns>
        private bool IsTheBoxFragileUserInput()
        {
            Console.Clear();
            bool isFragile = false;

            Console.WriteLine("Is the box fragile?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            Console.Write("\nEnter menu choice: ");

            int userChoice = userInputs.UserYesNoInput();


            if (userChoice == 1)
            {
                isFragile = true;
            }

            Console.Clear();
            return isFragile;
        }
        /// <summary>
        /// Handles method calls for a user to input id number to search for. 
        /// </summary>
        /// <returns>An int holding the information about which ID user want to search for</returns>
        internal int GetSearchIdForBox()
        {
            Console.Clear();
            printText.PrintSearchForBoxById();
            int searchThisId = userInputs.UserInputAnyNumber();

            return searchThisId;
        }

        /// <summary>
        /// Gets a ID number of the box the user wants to remove. 
        /// </summary>
        /// <returns>An int holding the information about which ID user want to remove</returns>
        internal int GetRemoveIdOfBox()
        {
            Console.Clear();
            printText.PrintWhichIdToRemove();
            int searchThisIdToRemove = userInputs.UserInputAnyNumber();

            return searchThisIdToRemove;
        }

        /// <summary>
        /// Get the ID number the user wants to move. Returns int array with [0] = id of box to move, [1] = level, [2] = rack
        /// </summary>
        /// <returns>Returns int array with [0] = id of box to move, [1] = level, [2] = rack</returns>
        internal int[] GetSearchIDAndPlaceForBoxToMove()
        {
            Console.Clear();
            printText.PrintSearchForBoxByIdAndMove();
            int moveThisId = userInputs.UserInputAnyNumber();
            printText.PrintWhichLevelToMoveTo();
            int[] levelAndRackPosition = userInputs.UserLevelAndRackInputForBoxAddition();

            int[] positionAndIdOfOldBox = new int[3] { moveThisId, levelAndRackPosition[0], levelAndRackPosition[1] };

            return positionAndIdOfOldBox;
        }
        /// <summary>
        /// Method used to shorteing the code. Each switch case statement in main menu ends with the same call and messsage.
        /// </summary>
        public void ContinueToMainMenu()
        {
            Console.WriteLine("\nPress any key to continue to main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

