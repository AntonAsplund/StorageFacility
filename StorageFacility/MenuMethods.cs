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
            int[] levelAndRackPosition = userInputs.UserLevelAndRackInputForBoxAddition();

            int[] positionAndIdOfOldBox = new int[3] { moveThisId, levelAndRackPosition[0], levelAndRackPosition[1] };

            return positionAndIdOfOldBox;
        }

        public void PrintAllRacksBasicList(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    Console.WriteLine("Level: {0} Rack: {1}", i + 1, j);
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        Console.WriteLine("Id: " + boxes.Id.ToString() + "Description" + boxes.Description + "\n---");
                    }
                    if (j % 5 == 0)
                    {
                        Console.WriteLine("Press any key to continue to the next 5 racks");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        public void PrintContentsInDetailedListOneByOne(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    bool gotContent = false;
                    Console.WriteLine("Level: {0} Rack: {1}", i + 1, j);
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        Console.WriteLine(boxes.ToString());
                        Console.WriteLine("---");
                        gotContent = true;
                    }
                    if (gotContent == false)
                    {
                        Console.WriteLine("This rack contains no boxes.");
                    }
                    Console.WriteLine("Press any key to continue to the next rack");
                    Console.ReadKey();
                    Console.Clear();

                }
            }

        }

        public void PrintSimpleListNumberOfBoxes(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    int numberOfBoxesInRack = 0;
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        numberOfBoxesInRack++;
                    }
                    Console.WriteLine("Level: {0} Rack: {1} - {2} number of boxes", i+1, j, numberOfBoxesInRack);
                    if (j % 25 == 0)
                    {
                        Console.WriteLine("Press any key to continue to the next 25 racks.");
                        Console.ReadKey();
                        Console.Clear();
                    }
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

