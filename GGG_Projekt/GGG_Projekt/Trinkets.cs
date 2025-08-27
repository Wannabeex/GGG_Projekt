using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public class Trinkets
    {
        public string TrinketName { get; set; }
        public bool InPossession { get; set; }
        public int DmgMultiplier { get; set; }
        public int HealthRegen { get; set; }
        public string TrinketType { get; set; }
        public int I { get; set; }

        public Trinkets(string trinketName, string trinketType, bool inPossession)
        {
            //Necessary Parameters
            TrinketName = trinketName;
            InPossession = inPossession;
            TrinketType = trinketType;

            //Base Method
        }

        public Trinkets(string trinketName, string trinketType, bool inPossession, int dmgMultiplier)
        {
            //Necessary Parameters
            TrinketName = trinketName;
            InPossession = inPossession;
            TrinketType = trinketType;

            //Optional Parameters
            DmgMultiplier = dmgMultiplier;
        }

        public Trinkets(string trinketName, string trinketType, bool inPossession, int healthRegen, int i)
        {
            //Necessary Parameters
            TrinketName = trinketName;
            InPossession = inPossession;
            TrinketType = trinketType;
            //i = Variable to Differentiate
            I = i;

            //Optional Parameters
            HealthRegen = healthRegen;
        }
    }
}