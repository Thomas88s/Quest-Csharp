using System;
using System.Linq;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
", 4, 20);

            Challenge wouldYouRather1 = new Challenge(
                @"Would you rather be in jail for five years or be in a coma for a decade?
    1) jail for five years
    2) coma for a decade
", 2, 15);

            Challenge wouldYouRather2 = new Challenge(
                 @"Would you rather walk to work in heels or drive to work in reverse?
    1) work in heels
    2) drive to work in reverse
", 1, 15);

            Challenge wouldYouRather3 = new Challenge(
                @"Would you rather walk in on your parents or have them walk in on you?
    1) walk in on your parents
    2) have them walk in on you
", 2, 15);

            Challenge wouldYouRather4 = new Challenge(
                @"Would you rather be forced to sing along or dance to every single song you hear?
    1) sing along to every single song
    2) dance to every single song
", 1, 15);

            Challenge wouldYouRather5 = new Challenge(
                 @"Would you rather have to buy all used underwear or all used toothbrushes?
    1) underwear
    2) toothbrushes
", 1, 15);



            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Hat Bycocket = new Hat(
                9
            );
            Robe RobeOfHolding = new Robe(
                new List<string>() { "Blue", "Green", "Gold" },
                48
            );
            Adventurer theAdventurer = new Adventurer(
                "",
                RobeOfHolding,
                Bycocket,
                0
            );
            Reward QuestReward = new Reward(
                $"You received {100 * theAdventurer.Awesomeness} Gold."

            );


            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                wouldYouRather1,
                wouldYouRather2,
                wouldYouRather3,
                wouldYouRather4,
                wouldYouRather5,

            };

            var randomChallenge = new Random();
            var randomizedChallenges = challenges.OrderBy(challenge => randomChallenge.Next());
            var questionPack5 = randomizedChallenges.Take(5);



            AdventureTime();

            void AdventureTime()
            {
                if (theAdventurer.MultipleQuest == true)
                {
                    theAdventurer.Awesomeness += theAdventurer.CorrectAnswers * 10;
                }


                // Loop through all the challenges and subject the Adventurer to them


                foreach (Challenge challenge in questionPack5)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!\n   ...Triumphant Music Plays...\n");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight. \nMaybe an easier quest would suit you...");
                }
                Console.WriteLine($"{theAdventurer.Name} has successfully completed {theAdventurer.CorrectAnswers} challenges!");
                QuestReward.ShowReward(theAdventurer);
                if (theAdventurer.MultipleQuest == true)
                {
                    theAdventurer.Awesomeness += theAdventurer.CorrectAnswers * 10;
                }
                Console.WriteLine($"Now {theAdventurer.Name}, would you like to embark on another adventure?\n Type Yes to embark or enter quit");



                string Input = Console.ReadLine().ToLower();

                if (Input.Equals(""))
                {
                    Environment.Exit(-1);
                }
                else
                {
                    if (Input == "yes" || Input == "y")
                    {
                        AdventureTime();
                        theAdventurer.MultipleQuest = true;
                    }
                    else if (Input == "no" || Input == "n")
                    {
                        Console.WriteLine("No wasn't an option! ADVENTURE TIME!!!");
                        Console.WriteLine("Stupidity Bonus: Awesomeness -10");
                        theAdventurer.Awesomeness = theAdventurer.Awesomeness - 10;
                        if (theAdventurer.MultipleQuest == true)
                        {
                            theAdventurer.Awesomeness += theAdventurer.CorrectAnswers * 10;
                        }
                        AdventureTime();
                    }
                    else
                    {
                        Console.WriteLine($"{theAdventurer.Name} you are a foolish imbecile!\nAnswer the Question!");
                        Input = Console.ReadLine().ToLower();
                        if (Input == "yes" || Input == "y")
                        {
                            AdventureTime();
                            theAdventurer.MultipleQuest = true;
                        }
                        else if (Input.Equals(""))
                        {
                            Environment.Exit(-1);
                        }
                        else if (Input == "no" || Input == "n")
                        {
                            Console.WriteLine("No wasn't an option! ADVENTURE TIME!!!");
                            Console.WriteLine($"{theAdventurer.Name} is Completely Inept Bonus: Awesomeness -25");
                            theAdventurer.Awesomeness = theAdventurer.Awesomeness - 25;
                            AdventureTime();
                        }
                        else
                        {
                            Console.WriteLine($"Infuriated by {theAdventurer.Name}'s denseness, which is a kind the world has never seen before, the voice thunders. The world quakes as {theAdventurer.Name} is swallowed by the crevasse that tears open under the earth.");
                            Console.WriteLine("fin");
                        }
                    }

                }
            }
        }
    }
}