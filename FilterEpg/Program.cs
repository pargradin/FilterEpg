using System.Xml;

namespace FilterEpg;

class Program
{
    static void Main(string[] args)
    {
        using (StreamWriter writer = new StreamWriter("/Users/pargradin/Projects/FilterEpg/FilterEpg/TestData/guidese.xml"))
        {
            using (StreamReader reader = new StreamReader("/Users/pargradin/Projects/FilterEpg/FilterEpg/TestData/guide.xml"))
            {
                writer.WriteLine(reader.ReadLine());

                // Code to read from the file
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Contains(".se\""))
                    {
                        writer.WriteLine(line);
                    }
                }
                reader.Close();
            }

            writer.WriteLine("</tv>");
            writer.Close();
        }
    }
}

