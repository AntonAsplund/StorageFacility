﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{
    class MainMenu
    {
        /// <summary>
        /// Holds the main and start of program. As well as a switch case menu used to call all methods. 
        /// Here a new object of WareHouse type is new:ed, and that object is the core storage of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WareHouse storageFacility = new WareHouse();
            MenuMethods menuMethods = new MenuMethods();
            PrintTexts printTexts = new PrintTexts();
            UserInputs userInputs = new UserInputs();

            bool stayInMenu = true;


            while (stayInMenu)
            {
                printTexts.PrintMainMenu();
                int userMenuChoice = userInputs.GetUserInputsForMainMenu();


                switch (userMenuChoice)
                {

                    case 1:
                        {   //Store a new box
                            NewBoxInput newBox = menuMethods.CreateNewBox();
                            printTexts.PrintAddBoxToSpecifiedRackOrNotMenu();
                            int userChoice = userInputs.UserYesNoInput();
                            bool addToFirstFreeSpace = userInputs.ConvertUserInputFromNumberToBool(userChoice);

                            if (addToFirstFreeSpace == true)
                            {
                                bool sucessfullAddition = storageFacility.ConvertAndAddFromUserInput(newBox, addToFirstFreeSpace);
                                int[] positionOfBox = storageFacility.FindBox(storageFacility.Id - 1);
                                printTexts.PrintResultOfBoxAdditionToStorage(sucessfullAddition, positionOfBox, storageFacility.Id-1);
                            }
                            else 
                            {
                                int[] userSpecifiedPlace = userInputs.UserLevelAndRackInputForBoxAddition(); //Fick input för användare som vill lägga till på specifik plats.
                                bool sucessfullAddition = storageFacility.ConvertAndAddFromUserInput(newBox, addToFirstFreeSpace, userSpecifiedPlace[0], userSpecifiedPlace[1]);
                                printTexts.PrintResultOfBoxAdditionToStorage(sucessfullAddition,userSpecifiedPlace, storageFacility.Id-1);
                            }
                            storageFacility.SerializeObject();
                            break;
                        }
                    case 2:
                        {   //Search for a box through ID number
                            int searchThisId = menuMethods.GetSearchIdForBox();
                            int[] positionOfBox = storageFacility.FindBox(searchThisId);
                            if (positionOfBox[0] < 0)
                            {
                                printTexts.PrintNoBoxIsFound(searchThisId);
                                menuMethods.ContinueToMainMenu();
                            }
                            else
                            {
                                printTexts.PrintPositionOfBox(positionOfBox);
                                menuMethods.ContinueToMainMenu();
                            }
                            storageFacility.SerializeObject();
                            break;
                        }
                    case 3:
                        {   //Remove a box from storage facility
                            int searchAndRemoveThisId = menuMethods.GetRemoveIdOfBox();
                            bool sucessfulltRemoved = storageFacility.RemoveThisBox(searchAndRemoveThisId);
                            if (sucessfulltRemoved == false)
                            {
                                printTexts.PrintNoBoxIsFound(searchAndRemoveThisId);
                                menuMethods.ContinueToMainMenu();
                            }
                            else
                            {
                                printTexts.PrintSucessfullRemovalOfBox(searchAndRemoveThisId);
                                menuMethods.ContinueToMainMenu();
                            }
                            storageFacility.SerializeObject();
                            break;
                        }
                    case 4:
                        {   //Move a box to a new location in storage facility
                            int[] idOfBoxAndNewPosition = menuMethods.GetSearchIDAndPlaceForBoxToMove();
                            bool sucessfullMoveOfBox = storageFacility.MoveBoxToSpecifiedRack(idOfBoxAndNewPosition[0], idOfBoxAndNewPosition[1], idOfBoxAndNewPosition[2]);
                            if (sucessfullMoveOfBox == false)
                            {
                                printTexts.PrintNoBoxHasBeenMoved();
                                menuMethods.ContinueToMainMenu();
                            }
                            else
                            {
                                printTexts.PrintBoxHasBeenMoved(idOfBoxAndNewPosition);
                                menuMethods.ContinueToMainMenu();
                            }
                            storageFacility.SerializeObject();
                            break;
                        }
                    case 5:
                        {   //Print a representation of storage facility or a visualization
                            printTexts.PrintMenuChoicePrintVisualization();
                            int userPrintMenuChoice = userInputs.GetUserInputOneToThree();

                            switch (userPrintMenuChoice)
                            {
                                case 1:
                                    {
                                        printTexts.PrintAllRacksBasicList(storageFacility);
                                        menuMethods.ContinueToMainMenu();
                                        break;
                                    }
                                case 2:
                                    {
                                        printTexts.PrintContentsInDetailedListOneByOne(storageFacility);
                                        menuMethods.ContinueToMainMenu();
                                        break;
                                    }
                                case 3:
                                    {
                                        printTexts.PrintLevelChoiceVisualizationSpecificLevel();
                                        int levelChoice = userInputs.UserInputVisualizationLevel();
                                        printTexts.PrintLevelChoiceVisualizationSpecificRack();
                                        int rackChoice = userInputs.UserInputVisualizationRack();

                                        Console.Clear();
                                        storageFacility[levelChoice, rackChoice].ToString();

                                        menuMethods.ContinueToMainMenu();
                                        break;
                                    }
                                case 4:
                                    {
                                        printTexts.PrintSimpleListNumberOfBoxes(storageFacility);
                                        menuMethods.ContinueToMainMenu();
                                        break;
                                    }
                            }
                            
                            break;
                        }
                    case 6:
                        {   //Saves the program
                            printTexts.PrintSaveMainMenuOptionChoice();
                            storageFacility.SerializeObject();
                            break;
                        }
                    case 7:
                        {   //Exit the program
                            printTexts.PrintExitProgramMessage();
                            stayInMenu = false;
                            break;

                        }
                }
            }
        }
    }
}
