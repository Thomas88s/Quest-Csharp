using System;
using System.Linq;
using System.Collections.Generic;

namespace Quest
{
    public class Robe
    {
        public List<string> Colors { get; set; }
        public int Length { get; set; }

        public Robe(List<string> colors, int length)
        {
            Colors = colors;
            Length = length;
        }
    }
}