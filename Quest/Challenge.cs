using System;
using System.Collections.Generic;

namespace Quest
{
    // An instance of the Challenge class is an occurrence of a single challenge
    public class Challenge
    {
        // These private fields hold the "state" of an individual challenge object.
        // The values stored in these fields are not accessible outside the class,
        //  but can be used by methods or properties within the class
        private string _text;
        private int _correctAnswer;
        private int _awesomenessChange;


        // A constructor for the Challenge
        // We can tell it's a constructor because it has the same name as the class 
        //   and it doesn't specify a return type
        // Note the constructor parameters and what is done with them
        public Challenge(string text, int correctAnswer, int awesomenessChange)
        {
            _text = text;
            _correctAnswer = correctAnswer;
            _awesomenessChange = awesomenessChange;
        }


        // This method will take an Adventurer object and make that Adventurer perform the challenge
        public void RunChallenge(Adventurer theAdventurer)
        {
            int nameNotEntered = 0;
            void EnterName()
            {
                if (theAdventurer.Name == "")
                {
                    Console.WriteLine("Enter your name");
                    theAdventurer.Name = Console.ReadLine();
                    Console.WriteLine(@"  +     +            +      +     + +       +  ");
                    Console.WriteLine(@"/\/\/\  /\/\/\  /\/\/\  /\/\/\  /\/\/\  /\/\/\");
                    Console.WriteLine(@"|_<>_|  |_<>_|  |_<>_|  |_<>_|  |_<>_|  |_<>_|");
                    Console.WriteLine(@"  +        +       ++       +             +    ");
                    Console.WriteLine(theAdventurer.GetDescription());
                    if (theAdventurer.Name == "")
                    {
                        nameNotEntered++;

                        if (nameNotEntered == 2)
                        {


                            Console.WriteLine("\nI picked a name for you 'ButterCup'. MWAHAHAHA\n");

                            theAdventurer.Name = "ButterCup";
                            Console.WriteLine(@"  +     +            +      +     + +       +  ");
                            Console.WriteLine(@"/\/\/\  /\/\/\  /\/\/\  /\/\/\  /\/\/\  /\/\/\");
                            Console.WriteLine(@"|_<>_|  |_<>_|  |_<>_|  |_<>_|  |_<>_|  |_<>_|");
                            Console.WriteLine(@"  +        +       ++       +             +    ");
                            Console.WriteLine(theAdventurer.GetDescription());
                        }
                        EnterName();
                    }

                }

            }
            EnterName();
            Console.Write($"{_text}: ");
            string answer = Console.ReadLine();

            int numAnswer;
            bool isNumber = int.TryParse(answer, out numAnswer);

            Console.WriteLine();
            if (isNumber && numAnswer == _correctAnswer)
            {
                Console.WriteLine("Well Done!");
                // Note how we access an Adventurer object's property
                theAdventurer.CorrectAnswers++;

                theAdventurer.Awesomeness += _awesomenessChange;
            }
            else
            {
                Console.WriteLine("You have failed the challenge, there will be consequences.");
                theAdventurer.Awesomeness -= _awesomenessChange;
            }

            // Note how we call an Adventurer object's method
            Console.WriteLine(theAdventurer.GetAdventurerStatus());
            Console.WriteLine();
        }
    }
}
