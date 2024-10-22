using static System.Console;
using System.IO;
using Lab5.Abstarcts;
namespace Lab5.Main;



public class ReadWrite : IReadWrite
{
    private static int ID_I = 1;

    readonly string filepath = Path.GetFullPath(@"..\..\..\Data.txt");



    public List<string[]> Data = new();
    private string adress;
    private string age;
    private string BDate;

    DataBase db = new();
    private string Full_Name;
    private string ID;
    private string mark;
    private string mobile;

    public void Run()
    {
        ReadData();
    }

    public void WriteData()
    {
        Data = db.data_retrival();
        File.WriteAllText(filepath, string.Empty);  // Clearing a file

        using FileStream fs = new(filepath, FileMode.Open);
        using StreamWriter sw = new(fs);
        foreach (string[] s in Data)
        {
            string new_data = null;
            foreach (string s2 in s)
            {
                new_data += s2 + " ";
            }
            sw.WriteLine(new_data.TrimEnd());
        }
    }

    private bool ID_check(string s, int index)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (int.Parse(s) == int.Parse(Data[i][6]))
            {
                if (i == index) { continue; }
                else { return false; }
            }
        }
        return true;
    }


    public void ReadData()  // Better Make it Private or Protected in the future
    {
        using (FileStream fs = new(filepath, FileMode.Open))
        {
            using StreamReader sr = new(fs);
            var R_Data = sr.ReadToEnd();
            string[] File_Data = R_Data.Split("\r\n");

            foreach (string data in File_Data)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    string[] values = data.Split(' ');

                    Full_Name = values[0] + " " + values[1];
                    // AGE conversion
                    try
                    {
                        int.TryParse(values[2], out int number);
                        age = number.ToString();
                    }
                    catch { age = "18"; }

                    // Mark conversion
                    try
                    {
                        double.TryParse(values[3], out double number);
                        mark = number.ToString();
                    }
                    catch { mark = "2.0"; }


                    // Mobile Phone Beautifier
                    try { mobile = values[4]; }
                    catch { mobile = "++7(YYY)XXX-XX-XX"; }


                    // Birth Date
                    try { BDate = values[5]; }
                    catch { BDate = "01.01.1990"; }

                    // Adress

                    try
                    {
                        adress = values[6];
                        for (int i = 7; i < 10; i++)
                        {
                            if (!(values[i] == " " & values[i] == values[i - 1]))
                                adress += " " + values[i];
                            else { break; }
                        }
                    }
                    catch { adress = "Moscow Arbat 24A 46"; }

                    try
                    {
                        if (int.TryParse(values[10], out int number))
                        {
                            ID = values[10];
                        }
                    }
                    catch { ID = ID_I.ToString(); ID_I++; }


                    Data.Add(new[] { Full_Name, age, mark, mobile, BDate, adress, ID });    // The correct order of things.

                }
            }
        }
        //
        ID_I = 1;
        foreach (string[] s in Data)
        {
            int counter = 0;
            if (ID_check(s[6], counter))
            {

            }
            else
            {
                s[6] = ID_I.ToString();
            }
            ID_I++;
        }
        //
    }
}