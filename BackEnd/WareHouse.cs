using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BoxesObject;

namespace BackEnd
{
    public class WareHouse
    {
        private WareHouseLocation[,] StorageShelf { get; }

        public WareHouse()
        {
            this.StorageShelf = new WareHouseLocation[3, 101];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    this.StorageShelf[i, j] = new WareHouseLocation();
                }
            }

        }

        public void TestStuff()
        {
            foreach (var box in this.StorageShelf)
            {
                if (box != null)
                {
                    foreach (var individualBoxes in box)
                    {
                        Console.WriteLine(individualBoxes.Description);
                    }
                }
            }
        }
        
        /// <summary>
        /// Accepts a NewBoxInput object and converts it to a object of corresponding type. Calls method TryAddBoxStorage if no specified place is given.
        /// If firstFreeSpace is true, then it's added to first free space. Otherwise it tries on given index.
        /// </summary>
        /// <param name="userInputNewBox"></param>
        /// <returns></returns>
        public bool ConvertAndAddFromUserInput (NewBoxInput userInputNewBox, bool addToFirstFreeSpace, int level, int rack)
        {
            bool boxSucessFullyAdded = false;

            if (userInputNewBox.Description == "Blob")
            {
                Blob newBlob = new Blob(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.LengthX);
                if (addToFirstFreeSpace)
                {
                    boxSucessFullyAdded = TryAddBoxToStorage(newBlob);
                }
                else
                {
                    boxSucessFullyAdded = TryAddBoxToSpecifiedRack(newBlob, level, rack);
                }
            }
            else if (userInputNewBox.Description == "Cube")
            {
                Cube newCube = new Cube(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.isFragile, userInputNewBox.LengthX);
                if (addToFirstFreeSpace)
                {
                    boxSucessFullyAdded = TryAddBoxToStorage(newCube);
                }
                else
                {
                    boxSucessFullyAdded = TryAddBoxToSpecifiedRack(newCube, level, rack);
                }
            }
            else if (userInputNewBox.Description == "Cuboid")
            {
                Cuboid newCuboid = new Cuboid(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.isFragile, userInputNewBox.LengthX, userInputNewBox.LengthY, userInputNewBox.LengthZ);
                if (addToFirstFreeSpace)
                {
                    boxSucessFullyAdded = TryAddBoxToStorage(newCuboid);
                }
                else
                { 
                    boxSucessFullyAdded = TryAddBoxToSpecifiedRack(newCuboid, level, rack);
                }
            }
            else if (userInputNewBox.Description == "Sphere")
            {
                Sphere newSphere = new Sphere(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.isFragile, userInputNewBox.LengthX);
                if (addToFirstFreeSpace)
                {
                    boxSucessFullyAdded = TryAddBoxToStorage(newSphere);
                }
                else
                {
                    boxSucessFullyAdded = TryAddBoxToSpecifiedRack(newSphere, level, rack);
                }

            }

            return boxSucessFullyAdded;
        }
        /// <summary>
        /// Loops through the storageshelf and find the first eligable position for the box thorough the method TryAdd in WareHouseLocation
        /// </summary>
        /// <param name="newBox"></param>
        /// <returns></returns>
        internal bool TryAddBoxToStorage(I3DObject newBox)
        {
            bool sucessfullyAdded = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    sucessfullyAdded = this.StorageShelf[i, j].TryAdd(newBox);
                    if (sucessfullyAdded)
                    {
                        return sucessfullyAdded;
                    }
                }
            }
            return sucessfullyAdded;
        }

        internal bool TryAddBoxToSpecifiedRack(I3DObject newBox, int level, int rack)
        {
            bool sucessfullyAdded = false;

            sucessfullyAdded = this.StorageShelf[level, rack].TryAdd(newBox);

            return sucessfullyAdded;
        }
        /// <summary>
        /// Takes an ID and removes the specified box if found through a method in WareHouseLocation
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool if sucessfull</returns>
        public bool RemoveThisBox(int id)
        {
            bool boxRemoved = false;

            int[] indexOfBoxId = FindBox(id);
            int level = indexOfBoxId[0];
            int rack = indexOfBoxId[1];
            int rackPosition = indexOfBoxId[2];

            if (indexOfBoxId[0] >= 0)
            {
                this.StorageShelf[level, rack].RemoveBoxByIndex(rackPosition);
                boxRemoved = true;
            }

            return boxRemoved;
        }
        /// <summary>
        /// Tries tp move a box to specified place, i
        /// </summary>
        /// <param name="id"></param>
        /// <param name="level"></param>
        /// <param name="rack"></param>
        /// <returns></returns>
        public bool MoveBoxToSpecifiedRack(int id, int level, int rack)
        {
            bool boxSucessfullyMoved = false;

            int[] boxIndexPosition = FindBox(id);
            int oldLevel = boxIndexPosition[0];
            int oldRack = boxIndexPosition[1];
            int oldRackPosition = boxIndexPosition[2];

            if (oldLevel >= 0)      //If position is negative, then speicified box ID is not present
            {
                I3DObject boxToBeMoved = this.StorageShelf[oldLevel, oldRack].Content().StorageSpace[oldRackPosition];
                boxSucessfullyMoved = TryAddBoxToSpecifiedRack(boxToBeMoved, level, rack);
                if (boxSucessfullyMoved)
                {
                    this.StorageShelf[oldLevel, oldRack].RemoveBoxByIndex(oldRackPosition);
                }
            }

            return boxSucessfullyMoved;
        }

        /// <summary>
        /// Searches for a unique ID number and returns the index position. If positons equals negative, then no box is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int[] FindBox(int id)
        {
            int boxFound = -1;
            int[] boxIndexPosition = new int[3] { -1, -1, -1 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    boxFound = this.StorageShelf[i, j].FindBoxInWarehouseLocation(id);
                    if (boxFound >= 0)
                    {
                        boxIndexPosition[0] = i;
                        boxIndexPosition[1] = j;
                        boxIndexPosition[2] = boxFound;
                        return boxIndexPosition;
                    }
                }
            }

            return boxIndexPosition;
        }


    }
}
