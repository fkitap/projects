using System;

namespace QutChampionship
{
    class Athlete
    {
        // Arrays that hold the event codes and their description
        public static readonly char[] codes = { 'T', 'B', 'S', 'R', 'O' };
        public static readonly string[] descriptions = { "Tennis", "Badminton", "Swimming", "Running", "Other" };

        // Declaring the fields
        private char code;
        private string description;

        // Creating properties for the fields
        public string Name { get; set; }

        public char Code
        {
            get
            {
                return code;
            }

            set
            {
                for (int k = 0; k < codes.Length; k++)
                {
                    if (value == codes[k])
                    {
                        code = value;
                        description = descriptions[k];
                        break;
                    }
                    else
                    {
                        code = 'I';
                        description = "Invalid";
                    }
                }

            }
        }

        public string Description
        {
            get
            {
                return description;
            }

        }

        // Constructors
        public Athlete()
        {

        }

        public Athlete(string name, char aCode)
        {
            Name = name;
            Code = aCode;
        }
    }
}