using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{
    class AddTestCases
    {
        public void AddTestBoxes(WareHouse storageFacility)
        {
            NewBoxInput testBox = new NewBoxInput(1, "Blob", true, 10);    // lägger till en låda i systemet, kollar om det finnns plats i hyllorna för en av den sagda typen
            storageFacility.ConvertAndAddFromUserInput(testBox, true, 0, 0);    // vilken typ det är bestäms av fleravals val av användaren som är hårdkodade.
            NewBoxInput testBox2 = new NewBoxInput(1001, "Cube", true, 10);
            storageFacility.ConvertAndAddFromUserInput(testBox2, true, 0, 0);
            NewBoxInput testBox3 = new NewBoxInput(9, "Cube", true, 10);
            storageFacility.ConvertAndAddFromUserInput(testBox3, true, 0, 0);
            NewBoxInput testBox4 = new NewBoxInput(9, "Cube", true, 10);
            storageFacility.ConvertAndAddFromUserInput(testBox4, false, 2, 50);
            NewBoxInput testBox5 = new NewBoxInput(9, "Cube", true, 10);
            storageFacility.ConvertAndAddFromUserInput(testBox5, false, 2, 99);
        }
    }
}
