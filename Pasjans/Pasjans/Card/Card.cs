using System;
using System.Collections.Generic;
using System.Text;

namespace Pasjans
{
   public class Card
    {
        public Color Color { get; private set; }
        public CardValue CardValue { get; private set; }

        public Card(CardValue value, Color color)
        {
            Color = color;
            CardValue = value;
        }
    }
}
