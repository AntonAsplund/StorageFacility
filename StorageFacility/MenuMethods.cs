using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{
    internal class MenuMethods
    {
        PrintTexts printText = new PrintTexts();
        UserInputs userInputs = new UserInputs();

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
                else if (userChoice < 1 || userChoice > 6)
                {
                    Console.WriteLine("Please enter a valid menu choice");
                    sucessfullConversion = false;
                }
            }

            return userChoice;
        }
        internal NewBoxInput CreateNewBox()
        {
            NewBoxInput newBox = new NewBoxInput();
            printText.PrintCreateNewBoxInputCHoice();
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

            Console.Clear();

            switch (userChoice)
            {
                case 1:
                    {
                        string description = "Blob";
                        decimal weight = UserWeightOfBoxInput();
                        bool isFragile = true;
                        Console.WriteLine("What is the length of one side?");
                        int lengthSideX = UserLengthInput();

                        NewBoxInput newBlob = new NewBoxInput(weight, description, isFragile, lengthSideX);
                        return newBlob;
                    }
                case 2:
                    {
                        string description = "Cube";
                        decimal weight = UserWeightOfBoxInput();
                        bool isFragile = IsTheBoxFragileUserInput();
                        Console.WriteLine("What is the length of one side?");
                        int lengthSideX = UserLengthInput();

                        NewBoxInput newCube = new NewBoxInput(weight, description, isFragile, lengthSideX);
                        return newCube;
                    }
                case 3:
                    {
                        string description = "Cuboid";
                        decimal weight = UserWeightOfBoxInput();
                        bool isFragile = IsTheBoxFragileUserInput();
                        Console.WriteLine("What is the length of side X?");
                        int lengthSideX = UserLengthInput();
                        Console.WriteLine("What is the length of side Y?");
                        int lengthSideY = UserLengthInput();
                        Console.WriteLine("What is the length of side Z?");
                        int lengthSideZ = UserLengthInput();

                        NewBoxInput newCuboid = new NewBoxInput(weight, description, isFragile, lengthSideX, lengthSideY, lengthSideZ);
                        return newCuboid;
                    }
                case 4:
                    {
                        string description = "Sphere";
                        decimal weight = UserWeightOfBoxInput();
                        bool isFragile = IsTheBoxFragileUserInput();
                        Console.WriteLine("What is the length of the radius?");
                        int radius = UserLengthInput();

                        NewBoxInput newSphere = new NewBoxInput(weight, description, isFragile, radius);
                        return newSphere;
                    }
            }

            return newBox;
        }
        private int UserLengthInput()
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
        private decimal UserWeightOfBoxInput()
        {
            Console.Clear();
            Console.Write("Please enter weight of box");

            decimal weightOfBox = 0;
            bool sucessfullConversion = false;

            while (sucessfullConversion == false)
            {
                sucessfullConversion = decimal.TryParse(Console.ReadLine(), out weightOfBox);
                if (sucessfullConversion == false)
                {
                    Console.Write("Please enter a valid number, try again...");
                }
                else if (weightOfBox < 0 || weightOfBox > 1000)
                {
                    Console.Write("Please enter a valid weight in kilograms");
                    sucessfullConversion = false;
                }
            }

            return weightOfBox;
        }
        /// <summary>
        /// Handles method calls for a user to input id number to search for. Return int searchThisId
        /// </summary>
        internal int GetSearchIdForBox()
        {
            Console.Clear();
            printText.PrintSearchForBoxById();
            int searchThisId = userInputs.UserInputAnyNumber();

            return searchThisId;
        }

        /// <summary>
        /// Gets a ID number of the box the user wants to remove. Returns int searchThisIdToRemove
        /// </summary>
        /// <returns></returns>
        internal int GetRemoveIdOfBox()
        {
            Console.Clear();
            printText.PrintWhichIdToRemove();
            int searchThisIdToRemove = userInputs.UserInputAnyNumber();

            return searchThisIdToRemove;
        }
        public void MoveBox()
        {

        }

        /// <summary>
        /// Get the ID number the user wants to move. Returns int array with [0] = id of box to move, [1] = level, [2] = rack
        /// </summary>
        /// <returns></returns>
        internal int[] GetSearchIDAndPlaceForBoxToMove()
        {
            Console.Clear();
            printText.PrintSearchForBoxByIdAndMove();
            int moveThisId = userInputs.UserInputAnyNumber();
            printText.PrintWhichLevelToMoveTo();
            int[] levelAndRackPosition = userInputs.UserLevelAndRackInput();

            int[] positionAndIdOfOldBox = new int[3] { moveThisId, levelAndRackPosition[0], levelAndRackPosition[1] };

            return positionAndIdOfOldBox;
        }

        public void PrintContentsOfEntireStorageShelf(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    WareHouseLocation fack = storageFacility[i, j];
                    Console.WriteLine(fack.ToString());

                }
            }
         
        }

        public void ContinueToMainMenu()
        {
            Console.WriteLine("\nPress any key to continue to main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

