namespace P03_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Cards
    {
        static void Main()
        {
            Encoding utf8 = Encoding.UTF8;
            string[] cardsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < cardsInfo.Length; i++)
            {
                string[] card = cardsInfo[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    cards.Add(new Card(card[0], card[1][0]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }
    }
    internal class Card
    {
        private string _face;
        private char _suit;
        public Card(string face, char suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => this._face;
            private set
            {
                if (value[0] != 'J' && value[0] != 'Q' && value[0] != 'J' && value[0] != 'K' && value[0] != 'A')
                {
                    int number = 0;
                    if (int.TryParse(value, out number))
                    {
                        if (number < 2 && number > 10)
                        {
                            throw new Exception("Invalid card!");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid card!");
                    }
                }
                this._face = value;
            }
        }
        public char Suit
        {
            get => this._suit;
            private set
            {
                switch (value)
                {
                    case 'S':
                        this._suit = '\u2660';
                        break;
                    case 'H':
                        this._suit = '\u2665';
                        break;
                    case 'D':
                        this._suit = '\u2666';
                        break;
                    case 'C':
                        this._suit = '\u2663';
                        break;
                    default:
                        throw new Exception("Invalid card!");
                }
            }
        }
        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}