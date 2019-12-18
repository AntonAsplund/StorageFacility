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

            return 
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
        
        
        
    }
}
