using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace MedalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a medal object
            Medal m1 = new Medal("Horace Gwynne", "Boxing", MedalColor.Gold, 2012, true);
            //print the object
            Console.WriteLine(m1);
            //print only the name of the medal holder
            Console.WriteLine(m1.Name);

            //create another object
            Medal m2 = new Medal("Michael Phelps", "Swimming", MedalColor.Gold, 2012, false);
            //print the updated m2
            Console.WriteLine(m2);


            //create a list to store the medal objects
            List<Medal> medals = new List<Medal>() { m1, m2 };

            medals.Add(new Medal("Ryan Cochrane", "Swimming", MedalColor.Silver, 2012, false));
            medals.Add(new Medal("Adam van Koeverden", "Canoeing", MedalColor.Silver, 2012, false));
            medals.Add(new Medal("Rosie MacLennan", "Gymnastics", MedalColor.Gold, 2012, false));
            medals.Add(new Medal("Christine Girard", "Weightlifting", MedalColor.Bronze, 2012, false));
            medals.Add(new Medal("Charles Hamelin", "Short Track", MedalColor.Gold, 2014, true));
            medals.Add(new Medal("Alexandre Bilodeau", "Freestyle skiing", MedalColor.Gold, 2012, true));
            medals.Add(new Medal("Jennifer Jones", "Curling", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Charle Cournoyer", "Short Track", MedalColor.Bronze, 2014, false));
            medals.Add(new Medal("Mark McMorris", "Snowboarding", MedalColor.Bronze, 2014, false));
            medals.Add(new Medal("Sidney Crosby ", "Ice Hockey", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Brad Jacobs", "Curling", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Ryan Fry", "Curling", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Antoine Valois-Fortier", "Judo", MedalColor.Bronze, 2012, false));
            medals.Add(new Medal("Brent Hayden", "Swimming", MedalColor.Bronze, 2012, false));

            //prints a numbered list of 16 medals.
            Console.WriteLine("\n\nAll 16 medals");

            for (int i = 0; i < medals.Count; i++)
                Console.WriteLine($"{i + 1, 2}. {medals[i].ToString()}");

            //prints a numbered list of 16 names (ONLY)
            Console.WriteLine("\n\nAll 16 names");

            for (int i = 0; i < medals.Count; i++)
                Console.WriteLine($"{i + 1}. {medals[i].Name}");

            //prints a numbered list of 9 gold medals
            Console.WriteLine("\n\nAll 9 gold medals");

            int counter = 0;
            foreach (Medal m in medals)
                if (m.Color == MedalColor.Gold)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {m.ToString()}");
                }

            //prints a numbered list of 9 medals in 2012
            Console.WriteLine("\n\nAll 9 medals");
            counter = 0;
            foreach (Medal m in medals)
                if (m.Year == 2012)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {m.ToString()}");
                }

            //prints a numbered list of 4 gold medals in 2012
            Console.WriteLine("\n\nAll 4 gold medals");
            counter = 0;
            foreach (Medal m in medals)
                if ((m.Color == MedalColor.Gold) && (m.Year == 2012))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {m.ToString()}");
                }

            //prints a numbered list of 3 world record medals
            Console.WriteLine("\n\nAll 3 records");
            counter = 0;
            foreach (Medal m in medals)
                if (m.IsRecord)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {m.ToString()}");
                }

            //saving first the medal to file Medals.txt. Inserted the name of list(medals).
            SaveFirstMedal(medals);
            //read the firs file
            ReadFirstMedal();
        }
        static void SaveFirstMedal(List<Medal> medals) //because this method is outside of main,we need to pass an parameter to it.
        {

            string Jsonstring = JsonSerializer.Serialize<Medal>(medals[0]);
            StreamWriter writer = new StreamWriter("one.Json");
            writer.WriteLine(Jsonstring);
            writer.Close();
        }
        static void ReadFirstMedal() // we dont need to get list of medal because it is already wrote in the file.
        {
            var options = new JsonSerializerOptions { IncludeFields = true, };
            StreamReader reader = new StreamReader("one.Json");
            string line = reader.ReadLine();
            Medal a = JsonSerializer.Deserialize<Medal>(line,options);
            Console.WriteLine(a.ToString());
            reader.Close();

        }
    }
}
