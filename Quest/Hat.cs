using System;
using System.Linq;
using System.Collections.Generic;


namespace Quest
{

    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription { get; set; }


        public Hat(int shininessLevel)
        {
            ShininessLevel = shininessLevel;
        }

        public string GetShininessDescription()
        {

            string shininess = "shiny";
            if (ShininessLevel < 2)
            {
                shininess = "dull";
            }
            else if (ShininessLevel >= 2 && ShininessLevel <= 5)
            {
                shininess = "noticeable";
            }
            else if (ShininessLevel >= 6 && ShininessLevel <= 9)
            {
                shininess = "bright";
            }
            else if (ShininessLevel > 9)
            {
                shininess = "blinding";
            }

            return $"{shininess}";
        }
    }
}