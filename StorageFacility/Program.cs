using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouse storageFacility = new WareHouse();

            NewBoxInput testBox = new NewBoxInput(1, 2, "Blob", 4);     // lägger till en låda i systemet, kollar om det finnns plats i hyllorna för en av den sagda typen
            storageFacility.ConvertAndAddFromUserInput(testBox);    // vilken typ det är bestäms av fleravals val av användaren som är hårdkodade.

            int id = 1;
            int[] index = storageFacility.FindBox(id);

            if (index[0] >= 0)
            {
                Console.WriteLine("Level: {0} Rackstoragespace: {1}", index[0]+1, index[1]);
            }
            else 
            {
                Console.WriteLine("Package not found");
            }
                
            storageFacility.TestStuff();

            //foreach (var box in storageFacility) { } //Fixa så att det går och köra foreach på storagefacility för att loopa igenom allt i multi-arrayen.

            storageFacility.RemoveThisBox(1);
            index = storageFacility.FindBox(1);
            if (index[0] >= 0)
            {
                Console.WriteLine("Level: {0} Rackstoragespace: {1}", index[0] + 1, index[1]);
            }
            else
            {
                Console.WriteLine("Package not found");
            }



            Console.ReadKey();
        }
    }
}
