﻿using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestGeneratorLib;

namespace MainPart
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToFolder = "D:\\BSUIR\\TEMPORAL_SHIT\\lab4\\MainPart\\Files";
            var pathToGenerated = "D:\\BSUIR\\TEMPORAL_SHIT\\lab4\\GeneratedTests\\GeneratedFiles";
            
            if (!Directory.Exists(pathToFolder))
            {
                Console.WriteLine($"Couldn't find directory {pathToFolder}");
                return;
            }
            if (!Directory.Exists(pathToGenerated))
            {
                Directory.CreateDirectory(pathToGenerated);
            }

            var allFiles = Directory.GetFiles(pathToFolder);

            var files = from file in allFiles
                    where file.Substring(file.Length - 3) == ".cs"
                    select file;

            Task task =  new Pipeline().Generate(files, pathToGenerated, new TestsGenerator());
            task.Wait();
            //Thread.Sleep(2000);
            Console.WriteLine("end.");
        }
    }
}
