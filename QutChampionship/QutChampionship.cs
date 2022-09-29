using System;
using static System.Console;

namespace QutChampionship
{
    class QutChampionship
    {
        static void Main()
        {
            WriteLine("*** Task 2a ***\n");
            // Method that prompts the user to input the number of participants

            int num_of_participants = InputNumberOfParticipants();

            // An array of objects (athletes)

            Athlete[] participants = new Athlete[num_of_participants];

            WriteLine("-------------------------");

            WriteLine("\n*** Task 2b ***\n");

            // Method to calculate the expected revenue

            double expectedRevenue = CalculateRevenue(num_of_participants);

            WriteLine("Expected revenue is {0}", expectedRevenue.ToString("C"));

            WriteLine("-------------------------");

            WriteLine("\n*** Task 2c ***\n");

            // Method that prompts the user to input the name of the athlete and their event codes

            InputData(participants);

            WriteLine("-------------------------");

            WriteLine("\n*** Task 2d ***\n");

            // Method for displaying the information of all participants

            DisplayData(participants);

            WriteLine("--------------------------------------");

            WriteLine("\n*** Task 2e ***\n");

            // Method for displaying participants' names in the category

            DisplayNames(participants);

        }

        // Task 2a
        private static int InputNumberOfParticipants()
        {
            int num;
            const int min = 0;
            const int max = 40;

            Write("Enter number of participants between 0 to 40 (inclusive): ");
            num = Convert.ToInt32(ReadLine());
            while (num < min || num > max)
            {
                Console.Write("Number must be between 0 to 40 (inclusive). Try again: ");
                num = Convert.ToInt32(ReadLine());
            }
            return num;
        }

        // Task 2b. Calculating expected revenue
        private static double CalculateRevenue(int num_of_participants)
        {
            const int cost = 30;
            return (cost * num_of_participants);
        }

        // Task 2c
        // Method to display the list of events and the categories they correspond to
        private static void DisplayList()
        {
            WriteLine("Event codes are:\n");
            for (int x = 0; x < Athlete.codes.Length; x++)
            {
                WriteLine(Athlete.codes[x] + " : " + Athlete.descriptions[x]);
            }
        }

        private static void InputData(Athlete[] participants)
        {
            for (int x = 0; x < participants.Length; x++)
            {
                Write("\nEnter participant's name: ");
                participants[x] = new Athlete();
                participants[x].Name = ReadLine();
                WriteLine();
                DisplayList();
                Write("\nEnter event code: ");
                participants[x].Code = char.Parse(ReadLine());
            }
        }

        // Task 2d
        private static void DisplayData(Athlete[] participants)
        {
            WriteLine("Athlete Name | Event Code | Event Name");
            WriteLine("--------------------------------------");


            for (int x = 0; x < participants.Length; x++)

            {
                WriteLine("{0,-12} | {1,-10} | {2,-12}", participants[x].Name, participants[x].Code, participants[x].Description);
            }

        }

        // Task 2e
        private static void DisplayNames(Athlete[] participants)
        {
            string entry;
            char aCode;

            DisplayList();
            Write("\nEnter code or Z to stop : ");

            entry = ReadLine();
            // Checking if the entered code is a character using TryParse() method
            while (char.TryParse(entry, out aCode) == false)
            {
                Write("The code must be a character. Try again");
                Write("\nEnter code or Z to stop : ");
                entry = ReadLine();
            }

            aCode = char.Parse(entry);

            // Checking if the code is valid
            while (aCode != 'Z')
            {
                string aDescription = "invalid";

                for (int k = 0; k < Athlete.codes.Length; k++)
                {
                    if (aCode == Athlete.codes[k])
                    {
                        aDescription = Athlete.descriptions[k];
                        break;
                    }
                }

                if (aDescription == "invalid")
                {
                    Write("{0} is not a valid event code. Try again", aCode);
                }

                else
                {
                    WriteLine("\nParticipants with talent {0} are:\n", aDescription);

                    for (int x = 0; x < participants.Length; x++)
                    {
                        if (participants[x].Code == aCode)
                        {
                            WriteLine("{0}\n", participants[x].Name);
                        }
                    }
                }

                Write("\nEnter code or Z to stop : ");

                entry = ReadLine();

                while (char.TryParse(entry, out aCode) == false)
                {
                    Write("The code must be a character. Try again");
                    Write("\nEnter code or Z to stop : ");
                    entry = ReadLine();
                }

                aCode = char.Parse(entry);
            }
        }
    }
}