﻿using System;
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
    /// <summary>
    /// Holds a multidimensional array of WareHouseLocation objects. The storage shelf and its racks.
    /// </summary>
    [Serializable]
    public class WareHouse 
    {
        private WareHouseLocation[,] StorageShelf { get; }
        public int Id { get; set; }
        public WareHouse()
        {
            try
            {
                this.StorageShelf = DeserializeObject();
                this.Id = GetHighestCurrentId();
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

                this.Id = GetHighestCurrentId();
            }
        }
        /// <summary>
        /// Indexer that could be used by the front-end to acess a specific rack in the multi dimensional array. Delivers a complete deep copy of the storage rack to the front-end
        /// </summary>
        /// <param name="level">Level where the rack is situated. Zero based</param>
        /// <param name="rack">Rack number on the correct level. Based on 1 - 100. Not zero based.</param>
        /// <returns></returns>
        public WareHouseLocation this[int level, int rack]
        {
            get
            {
                return StorageShelf[level, rack].Content();
            }
        }
        /// <summary>
        /// Gets the highest current ID number of a box in the storage. Used in the constructor of WareHouse, as ID numbers lies as a property in WareHouse and is not saved on the serialized save file.
        /// </summary>
        /// <returns></returns>
        internal int GetHighestCurrentId()
        {
            int highestCurrentId = 0;

            for (int level = 0; level < 3; level++)
            {
                for (int rack = 1; rack < 101; rack++)
                {
                    foreach (I3DObject box in this.StorageShelf[level,rack])
                    {
                        highestCurrentId = Math.Max(highestCurrentId, box.Id);
                    }
                }
            }
            highestCurrentId++;
            return highestCurrentId;
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
        public bool ConvertAndAddFromUserInput (NewBoxInput userInputNewBox, bool addToFirstFreeSpace, int level = 0, int rack = 0)
        {
            bool boxSucessFullyAdded = false;

            if (userInputNewBox.Description == "Blob")
            {
                Blob newBlob = new Blob(this.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.LengthX);
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
                Cube newCube = new Cube(this.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.IsFragile, userInputNewBox.LengthX);
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
                Cuboid newCuboid = new Cuboid(this.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.IsFragile, userInputNewBox.LengthX, userInputNewBox.LengthY, userInputNewBox.LengthZ);
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
                Sphere newSphere = new Sphere(this.Id, userInputNewBox.Weight, userInputNewBox.Description, userInputNewBox.IsFragile, userInputNewBox.LengthX);
                if (addToFirstFreeSpace)
                {
                    boxSucessFullyAdded = TryAddBoxToStorage(newSphere);
                }
                else
                {
                    boxSucessFullyAdded = TryAddBoxToSpecifiedRack(newSphere, level, rack);
                }

            }

            this.Id++; // Adds one to Id each time a box has been added or have been tried to be added to the storagerack facility. This ensuring that every box in storage has a unique ID number

            return boxSucessFullyAdded;
        }
        /// <summary>
        /// Loops through the storageshelf and find the first eligable position for the box thorough the method TryAdd in WareHouseLocation
        /// </summary>
        /// <param name="newBox">The box of a I3DObject inherited type object, supposed to be added to storage</param>
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
        /// <param name="rack">The index position of the intended rack not zero based</param>
        /// <returns>Gives a bool that tells if the addition to specified rack was sucessfull or not.</returns>
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
        /// If unsucessful no move is made, and box is at it's original place. Returns a bool, true = sucessfull move, false = no move of box.
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
        /// Searches for a unique ID number and returns the index position as an int array. If any positon equals negative, then no box is found.
        /// Else [0] = level, [1] = rack, [2] = rack slot
        /// </summary>
        /// <param name="id">int number of box id user want to find</param>
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
        /// <summary>
        /// Saves the contents of the collection "WhareHouseLocation[,]" that holds the information about the storagefacility
        /// </summary>
        public void SerializeObject()
        {
            IFormatter formatter = new BinaryFormatter();
            //File.Delete("wareHouseSaveFile.txt");
            Stream stream = new FileStream("wareHouseSaveFile.txt", FileMode.OpenOrCreate, FileAccess.Write);

            formatter.Serialize(stream, this.StorageShelf);
            stream.Close();
        }
        /// <summary>
        /// Loads the contents of the collection "WhareHouseLocation[,]" that holds the information about the storagefacility
        /// </summary>
        internal WareHouseLocation[,] DeserializeObject()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("wareHouseSaveFile.txt", FileMode.Open, FileAccess.Read);

            WareHouseLocation[,] wareHouseFromSaveFile = (WareHouseLocation[,])formatter.Deserialize(stream);
            stream.Close();
            return wareHouseFromSaveFile;
        }


        
    }
}
