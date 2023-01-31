using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Controllers.NavalBattleController
{
    internal class ArmadaController
    {
        public string[] AircraftCarrierArray = new string[5];
        public string[] BattleshipArray = new string[4];
        public string[] CruiserArray = new string[3];
        public string[] SubmarineArray = new string[3];
        public string[] DestroyerArray = new string[2];
        private static string[] _ArmadaCodes = new string[6] {"  ", "CV", "BB", "CC", "SB", "DD"};

        public static string GetArmadaCodes(int codeNumber)
        {
            return _ArmadaCodes[codeNumber];
        }


        


    }
}
