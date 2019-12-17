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
        public void testStuff()
        {
            WareHouseLocation[,] storageShelf = new WareHouseLocation[3, 101];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    storageShelf[i, j] = new WareHouseLocation();
                }
            }
            Blob testBlob = new Blob(1, 2, "3", 4);
            Cube testCube = new Cube(5, 6, "7", 8);

            storageShelf[1, 50].TryAdd(testBlob);
            storageShelf[2, 33].TryAdd(testCube);
            storageShelf[1, 50].TestMethodPrintAllId();
            storageShelf[2, 33].TestMethodPrintAllId();

            //storageSpaceTest.Content();
            //storageSpaceTest.ReCalculate();
            //storageSpaceTest.TryAdd();
        }
        
        
        
    }
}
