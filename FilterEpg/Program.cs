﻿using System.IO;
using System.Xml;

namespace FilterEpg;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.Out.WriteLine("requires a guide file as single parameter");
            return;
        }

        var guideFile = args[0];
        if (!File.Exists(guideFile))
        {
            Console.Out.WriteLine($"The file {guideFile} does not exist");
            return;
        }

        var tmpFile = guideFile + ".tmp";

        Console.Out.WriteLine($"Processing");
        using (StreamWriter writer = new StreamWriter(tmpFile))
        {
            using (StreamReader reader = new StreamReader(guideFile))
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
        Console.Out.WriteLine($"Done");

    }
}

