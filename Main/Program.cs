using static System.Console;
using System.Collections.Generic;
using System.Reflection;
using Lab5.UI;

namespace Lab5.Main;


public class Base
{
    public static List<string> Options = new();
    private static List<string[]> Data;

    static void Main()
    {
        List_appender.Append();

        ReadWrite rw = new();
        rw.Run();
        Data = rw.Data;
        DataBase db;
        db.data_modifier(Data);


        // Writes data to the file
        rw.WriteData();

        Menu main_menu = new(Options);
        main_menu.Run();
    }
}

class List_appender
{
    public static void Append()
    {
        Base.Options.Add("Студент");
        Base.Options.Add("Админ");
        Base.Options.Add("Добавить");
        Base.Options.Add("Найти");
    }
}

// All data is actually stored here!!!
public struct DataBase
{
    static private List<string[]> data;
    public List<string[]> data_retrival()
    {
        return data;
    }
    public void data_modifier(List<string[]> Data)
    {
        data = Data;
    }
    public void data_s_modification(List<string> Data, int index)
    {
        for (int i = 0; i < Data.Count - 2; i++)
        {
            data[index][i] = Data[i];
        }
    }
    public void data_deletion(int index)
    {
        data.RemoveAt(index);
    }
    public void add_data()
    {
        string Full_Name = "Ivan Ivanovich";
        string age = "18";
        string mark = "2.0";
        string mobile = "+7(YYY)XXX-XX-XX";
        string BDate = "01.01.1990";
        string adress = "Moscow Arbat 24A 16";
        string ID = "";
        data.Add(new[] { Full_Name, age, mark, mobile, BDate, adress, ID });
    }
}