using System;
using System.Collections.Generic;

namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // This is an "immutable" property. It only has a "get".
        // The only place the Name can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public string Name { get; set; }

        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public Robe ColorfulRobe { get; set; }
        public int Awesomeness { get; set; }
        public Hat ShinyHat { get; set; }
        public int CorrectAnswers { get; set; }
        public bool MultipleQuest { get; set; }

        public string GetDescription()
        {
            return ($"The Intrepid Adventurer {Name}, donned an illustrious {ColorfulRobe.Colors[0]}, {ColorfulRobe.Colors[1]}, and {ColorfulRobe.Colors[2]} colored robe with a magnificent length of {ColorfulRobe.Length} inches.\nThe Hat perched upon the head of {Name} was nothing less than {ShinyHat.GetShininessDescription()}.\nIt's Adventure Time!\n");
        }

        // A constructor to make a new Adventurer object with a given name
        public Adventurer(string name, Robe colorfulRobe, Hat shinyHat, int CorrectAnswers)
        {
            Name = name;
            ColorfulRobe = colorfulRobe;
            ShinyHat = shinyHat;
            Awesomeness = 50;
            CorrectAnswers = 0;
            MultipleQuest = false;


        }

        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is:
        //   it transforms the Awesomeness integer into a status string
        public string GetAdventurerStatus()
        {
            string status = "okay";
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"The Adventurer, {Name}, is {status}";
        }
    }
}
