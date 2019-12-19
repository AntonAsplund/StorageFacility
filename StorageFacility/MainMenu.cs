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
                int userMenuChoice = menuMethods.GetUserInputsForMainMenu();


                switch (userMenuChoice)
                {

                    case 1:
                        {
                            //Store a new box
                            NewBoxInput newBox = menuMethods.CreateNewBox();
                            printTexts.PrintAddBoxToSpecifiedRackOrNotMenu();
                            int userChoice = userInputs.UserYesNoInput();
                            bool addToFirstFreeSpace = userInputs.ConvertUserInputFromNumberToBool(userChoice);

                            if (addToFirstFreeSpace == true)
                            {
                                bool sucessfullAddition = storageFacility.ConvertAndAddFromUserInput(newBox, addToFirstFreeSpace);
                                printTexts.PrintResultOfBoxAdditionToStorage(sucessfullAddition);
                            }
                            else 
                            {
                                int[] userSpecifiedPlace = userInputs.UserLevelAndRackInput(); //Fick input för användare som vill lägga till på specifik plats.
                                bool sucessfullAddition = storageFacility.ConvertAndAddFromUserInput(newBox, addToFirstFreeSpace, userSpecifiedPlace[0], userSpecifiedPlace[1]);
                                printTexts.PrintResultOfBoxAdditionToStorage(sucessfullAddition);
                            }
                            break;
                        }
                    case 2:
                        {
                            //Search for a box through ID number
                            break;
                        }
                    case 3:
                        {
                            //Remove a box from storage facility
                            break;
                        }
                    case 4:
                        {   //Move a box to a new location in storage facility
                            break;
                        }
                    case 5:
                        {   //Print a representation of storage facility or a visualization
                            break;
                        }
                    case 6:
                        {   //Exit the program
                            stayInMenu = false;
                            break;
                        }
                }
            }



            int level = 2;
            int rack = 99;
            Console.WriteLine(storageFacility[level, rack].ToString());     //Anvädning av indexern till att skriva ut vad som finns på platsen
            menuMethods.PrintContentsOfEntireStorageShelf(storageFacility);

            Console.ReadKey();





            
        }


    }
}
