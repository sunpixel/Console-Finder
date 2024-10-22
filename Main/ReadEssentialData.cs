using Lab5.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5.Main
{
    internal class ReadEssentialData : IReadWrite
    {

        readonly string filepath = Path.GetFullPath(@"..\..\..\Users.txt");
        private string? username;
        private string? password;

        public List<string[]> UserData = new();

        public void Run()
        {
            throw new NotImplementedException();
        }
        public void ReadData()
        {
            using FileStream fs = new(filepath, FileMode.Open);
            using StreamReader sr = new(fs);
            var R_Data = sr.ReadToEnd();
            string[] File_Data = R_Data.Split("\r\n");

            foreach (string data in File_Data)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    string[] values = data.Split(' ');

                    try
                    {
                        username = values[0];
                    }
                    catch
                    {
                        throw new Exception("There is no value to assign.\n");
                    }

                    try
                    {
                        password = values[1];
                    }
                    catch
                    {
                        throw new Exception("There is no value to assign.\n");
                    }


                    UserData.Add(new[] { username, password });    // The correct order of things.

                }
            }
        }
        public void WriteData()
        {
            throw new NotImplementedException();
        }
    }
}
