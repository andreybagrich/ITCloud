using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            

            DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            Directory.CreateDirectory(directory + "test");
            string path = directory + @"test" + @"test.txt";

            File.Create(path);

            //using (Stream s = new FileStream("text.txt", FileMode.Create))
            //{

            //    string text = "Here be some text";
            //    byte[] arrBytes = text.SelectMany(c => BitConverter.GetBytes(c)).ToArray(); //единый массив > select

            //    //s.Write(arrBytes, 0, arrBytes.Length);
            //    //s.Flush();

            //    s.Write(arrBytes, 0, arrBytes.Length);

            //    s.Position = 0;
            //    s.Write(arrBytes, 0, arrBytes.Length);
            //    s.Flush();
            //}


        }
    }
}
