using System;
using System.Linq;
using System.Collections.Generic;

namespace Quest
{

    public class Reward
    {
        public Reward(string text)
        {
            _text = text;
            // RewardMultiplyer = rewardMultiplyer;
        }
        private string _text { get; set; }
        // public int RewardMultiplyer { get; set; }
        public void ShowReward(Adventurer theAdventurer)
        {
            if (theAdventurer.Awesomeness > 0)
            {

                Console.WriteLine(_text);
            }
            else
            {
                Console.WriteLine("I pity the fool.");
            }
        }















    }




}