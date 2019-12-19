using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BoxesObject;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BackEnd
{   
    [Serializable]
    public class WareHouse 
    {
        private WareHouseLocation[,] StorageShelf { get; }

        public WareHouse()
        {
            try
            {
                this.StorageShelf = DeserializeObject();
            }
            catch
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
        }

        public string this[int level, int rack]
        {
            get
            {
                return StorageShelf[level, rack].ToString();
            }
        }

        public void TestStuff(int level, int rack)
        {
            foreach (var shelf in this.StorageShelf[level,rack])
            {
               Console.WriteLine(shelf.ToString());
               Console.WriteLine("TestStuff");
               
            }
        }

        /// <summary>
        /// Accepts a NewBoxInput object and converts it to a object of corresponding type. Calls method TryAddBoxStorage if no specified place is given.
        /// If firstFreeSpace is true, then it's added to first free space. Otherwise it tries on given index.
        /// </summary>
        /// <param name="userInputNewBox">Holds information needed to create a user specified object </param>
        /// <param name="addToFirstFreeSpace">A bool value which dictates the way the created object is added</param>
        /// <param name="level">The index position of the level which intended destination rack is located on if such parameter is given<</param>
        /// <param name="rack">The index position of the intended destination rack if such parameter is given<</param>
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
        /// <summary>
        /// Takes an I3DObject and tries to add it to a specific rackposition
        /// </summary>
        /// <param name="newBox">The object that contains the new box</param>
        /// <param name="level">The index position of the level that intended rack is on</param>
        /// <param name="rack">The index position of the intended rack</param>
        /// <returns></returns>
        internal bool TryAddBoxToSpecifiedRack(I3DObject newBox, int level, int rack)
        {
            bool sucessfullyAdded = false;

            sucessfullyAdded = this.StorageShelf[level, rack].TryAdd(newBox);

            return sucessfullyAdded;
        }
        /// <summary>
        /// Takes an ID and removes the specified box if found through a method in WareHouseLocation
        /// </summary>
        /// <param name="id">ID number of the box that user wants to be removed</param>
        /// <returns>bool if a sucessfull removal is made</returns>
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
        /// Tries to move a specified box to a place of the users choice. 
        /// If unsucessful no move is made, and box is at it's original place.
        /// </summary>
        /// <param name="id">ID number of the box that user wants moved</param>
        /// <param name="level">The index position of the level that intended destination rack is on</param>
        /// <param name="rack">The index position of the intended destination rack</param>
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

        public void PrintContentsOfEntireStorageShelf()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    Console.WriteLine("\n Level: {0}  Storage Rack: {1}", i + 1, j);
                    Console.WriteLine("\n -----------------------------");
                    Console.WriteLine(this.StorageShelf[i, j].ToString());

                    if (j % 5 == 0)
                    {
                        Console.Write("\n Please enter any key to continue to next five storage racks...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        public void SerializeObject()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("wareHouseSaveFile.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, this.StorageShelf);
            stream.Close();
        }

        internal WareHouseLocation[,] DeserializeObject()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("wareHouseSaveFile.txt", FileMode.Open, FileAccess.Read);

            WareHouseLocation[,] wareHouseFromSaveFile = (WareHouseLocation[,])formatter.Deserialize(stream);

            return wareHouseFromSaveFile;
        }
    }
}
