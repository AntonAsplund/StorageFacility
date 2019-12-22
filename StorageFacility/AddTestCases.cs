using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{/// <summary>
/// Class that holds information about and adds boxes according to users och testers choosen options. Uses "Random" class to generate test cases with random parameters.
/// </summary>
    class AddTestCases
    {
        public void AddTestBoxes(WareHouse storageFacility)
        {
            Random randomizer = new Random();
            UserInputs userInputs = new UserInputs();
            MenuMethods menuMethods = new MenuMethods();


            bool testCaseGenerationComplete = false;
            int numberOfTestCasesConstructed = 0;

            bool sucessfullyAdded = false;
            int numberOfBoxesSucessfullyAdded = 0;

            Console.WriteLine("How many testcases do you want to create?");

            int numberOfTestcasesChoosen = userInputs.UserInputAnyNumber();

            while (testCaseGenerationComplete == false)
            {
                sucessfullyAdded = false;
                int menuChoiceTestCase = randomizer.Next(1, 4);

                switch (menuChoiceTestCase)
                {
                    case 1:
                        {
                            decimal weight = (randomizer.Next(1, 1000) / 100);
                            int length = randomizer.Next(5, 100);
                            NewBoxInput testBoxBlob = new NewBoxInput(weight, "Blob", true, length);

                            int randomNumberIfFIrstFree = randomizer.Next(1, 16);
                            int calculateRandomForFirstFreeSpaceOrNot = randomNumberIfFIrstFree % 8 == 0 ? 1 : 2;
                            bool firstFreeSpaceOrSpecifiedRandomizer = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForFirstFreeSpaceOrNot);

                            sucessfullyAdded = storageFacility.ConvertAndAddFromUserInput(testBoxBlob, firstFreeSpaceOrSpecifiedRandomizer, randomizer.Next(0, 3), randomizer.Next(1, 101));
                            if (sucessfullyAdded)
                            {
                                numberOfBoxesSucessfullyAdded++;
                            }
                            break;
                        }
                    case 2:
                        {
                            decimal weight = (randomizer.Next(1, 10000) / 100);
                            int length = randomizer.Next(5, 100);

                            int randomNumberIfFragile = randomizer.Next(1, 16);
                            int calculateRandomForIfFragile = randomNumberIfFragile % 16 == 0 ? 1 : 2;
                            bool isFragile = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForIfFragile);

                            NewBoxInput testBoxCube = new NewBoxInput(weight, "Cube", isFragile, length);

                            int randomNumberIfFIrstFree = randomizer.Next(1, 16);
                            int calculateRandomForFirstFreeSpaceOrNot = randomNumberIfFIrstFree % 8 == 0 ? 1 : 2;
                            bool firstFreeSpaceOrSpecifiedRandomizer = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForFirstFreeSpaceOrNot);

                            sucessfullyAdded = storageFacility.ConvertAndAddFromUserInput(testBoxCube, firstFreeSpaceOrSpecifiedRandomizer, randomizer.Next(0, 3), randomizer.Next(1, 101));
                            if (sucessfullyAdded)
                            {
                                numberOfBoxesSucessfullyAdded++;
                            }
                            break;
                        }
                    case 3:
                        {
                            decimal weight = (randomizer.Next(1, 10000) / 100);
                            int lengthX = randomizer.Next(5, 100);
                            int lengthY = randomizer.Next(5, 100);
                            int lengthZ = randomizer.Next(5, 100);

                            int randomNumberIfFragile = (randomizer.Next(1, 16));
                            int calculateRandomForIfFragile = randomNumberIfFragile % 16 == 0 ? 1 : 2;
                            bool isFragile = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForIfFragile);

                            NewBoxInput testBoxCube = new NewBoxInput(weight, "Cuboid", isFragile, lengthX, lengthY, lengthZ);

                            int randomNumberIfFIrstFree = randomizer.Next(1, 16);
                            int calculateRandomForFirstFreeSpaceOrNot = randomNumberIfFIrstFree % 8 == 0 ? 1 : 2;
                            bool firstFreeSpaceOrSpecifiedRandomizer = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForFirstFreeSpaceOrNot);

                            sucessfullyAdded = storageFacility.ConvertAndAddFromUserInput(testBoxCube, firstFreeSpaceOrSpecifiedRandomizer, randomizer.Next(0, 3), randomizer.Next(1, 101));
                            if (sucessfullyAdded)
                            {
                                numberOfBoxesSucessfullyAdded++;
                            }
                            break;
                        }
                    case 4:
                        {
                            decimal weight = (randomizer.Next(1, 10000) / 100);
                            int radius = randomizer.Next(5, 100);

                            int randomNumberIfFragile = (randomizer.Next(1, 16));
                            int calculateRandomForIfFragile = randomNumberIfFragile % 16 == 0 ? 1 : 2;
                            bool isFragile = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForIfFragile);

                            NewBoxInput testBoxSphere = new NewBoxInput(weight, "Sphere", isFragile, radius);

                            int randomNumberIfFIrstFree = randomizer.Next(1, 16);
                            int calculateRandomForFirstFreeSpaceOrNot = randomNumberIfFIrstFree % 8 == 0 ? 1 : 2;
                            bool firstFreeSpaceOrSpecifiedRandomizer = userInputs.ConvertUserInputFromNumberToBool(calculateRandomForFirstFreeSpaceOrNot);

                            sucessfullyAdded = storageFacility.ConvertAndAddFromUserInput(testBoxSphere, firstFreeSpaceOrSpecifiedRandomizer, randomizer.Next(0, 3), randomizer.Next(1, 101));
                            if (sucessfullyAdded)
                            {
                                numberOfBoxesSucessfullyAdded++;
                            }
                            break;
                        }
                }
                numberOfTestCasesConstructed++;
                if (numberOfTestCasesConstructed >= numberOfTestcasesChoosen)
                {
                    testCaseGenerationComplete = true;
                    Console.WriteLine("{0} test boxes have now been sucessfully added to storage facility", numberOfBoxesSucessfullyAdded);
                }
            }

        }
    }
}
