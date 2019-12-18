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
        /// Accepts a NewBoxInput object and converts it to a object of corresponding type
        /// </summary>
        /// <param name="userInputNewBox"></param>
        /// <returns></returns>
        public bool ConvertAndAddFromUserInput (NewBoxInput userInputNewBox)
        {
            bool boxSucessfullyAdded = false;

            if (userInputNewBox.Description == "Blob")
            {
                Blob newBlob = new Blob(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.LengthX);
                boxSucessfullyAdded = TryAddBoxToStorage(newBlob);
            }
            else if (userInputNewBox.Description == "Cube")
            {
                Cube newCube = new Cube(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.isFragile, userInputNewBox.LengthX);
                boxSucessfullyAdded = TryAddBoxToStorage(newCube);
            }
            else if (userInputNewBox.Description == "Cuboid")
            {
                Cuboid newCuboid = new Cuboid(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.isFragile, userInputNewBox.LengthX, userInputNewBox.LengthY, userInputNewBox.LengthZ);
                boxSucessfullyAdded = TryAddBoxToStorage(newCuboid);
            }
            else if (userInputNewBox.Description == "Sphere")
            {
                Sphere newSphere = new Sphere(userInputNewBox.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.isFragile, userInputNewBox.LengthX);
                boxSucessfullyAdded = TryAddBoxToStorage(newSphere);
            }

            return boxSucessfullyAdded;
        }

        internal bool TryAddBoxToStorage(I3DObject newBox)
        {
            bool sucessfullyAdded = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; i++)
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
        /// Searches for a unique ID number and returns the index position. If positons equals negative, then no box is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int[] FindBox(int id)
        {
            int boxFound = -1;
            int[] boxPosition = new int[3] { -1, -1, -1 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    boxFound = this.StorageShelf[i, j].FindBoxInWarehouseLocation(id);
                    if (boxFound >= 0)
                    {
                        boxPosition[0] = i;
                        boxPosition[1] = j;
                        boxPosition[2] = boxFound;
                        return boxPosition;
                    }
                }
            }

            return boxPosition;
        }


    }
}
