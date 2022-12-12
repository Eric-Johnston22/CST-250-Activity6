using System.Reflection.Metadata;

namespace TextFileDataAccessDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\test.txt");
            List<Person> people = new List<Person>();

            try
            {
                List<String> lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    string[] entries = line.Split(',');

                    Person p = new Person();
                    if (entries.Length != 3)
                    {
                        Console.WriteLine("A line does not have 3 items");
                        return;
                    }
                    else
                    {
                        p.firstName = entries[0];
                        p.lastName = entries[1];
                        p.Url = entries[2];
                    }

                    people.Add(p);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found, check path");
            }

            List<string> outputLines = new List<string>();

            Console.WriteLine("Here is the list of people I have: ");
            foreach(Person p in people)
            {
                // first print to console
                Console.WriteLine("First name: " + p.firstName + " Last name: " + p.lastName + " URL: " + p.Url);

                // add another line for the file output.
                outputLines.Add("First name: " + p.firstName + " Last name: " + p.lastName + " URL: " + p.Url + "\n");
            }

            // write to another file
            string outPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\peopleOut.txt");
            File.WriteAllLines(outPath, outputLines);

            Console.ReadKey();
        }
    }
}