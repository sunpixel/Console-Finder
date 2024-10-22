using static System.Console;
using System.Linq;
using Lab5;
using Lab5.Main;

namespace Lab5.UI;


class User_Profile
{
    private int index;
    private int Admin;
    private int SelectedIndex = 0;
    private bool Conditions = true;
    private List<string> Profile = new();
    List<string[]> data;


    ReadWrite rw = new();
    DataBase db;

    private void Naming()
    {
        WriteLine(
            "\n\n" +
            "\t\t░█▀█░█▀▄░█▀█░█▀▀░▀█▀░█░░░█▀▀░░\n" +
            "\t\t░█▀▀░█▀▄░█░█░█▀▀░░█░░█░░░█▀▀░░\n" +
            "\t\t░▀░░░▀░▀░▀▀▀░▀░░░▀▀▀░▀▀▀░▀▀▀░░\n" +
            "\n\n");
    }

    // Starting from here modifications will be made
    private string title(int i)
    {
        string naming;
        if (i == 0) { naming = "Name:     "; }
        else if (i == 1) { naming = "Age:      "; }
        else if (i == 2) { naming = "Grades:   "; }
        else if (i == 3) { naming = "Mobile:   "; }
        else if (i == 4) { naming = "BirthDate:"; }
        else if (i == 5) { naming = "Adress:   "; }
        else if (i == 6) { naming = "Stud.ID:  "; }
        else { naming = "----->    "; }

        return naming;
    }

    private void DisplayProfile()
    {
        Naming();
        WriteLine("-------------------------------------------------------");
        string prefix;

        for (int i = 0; i < Profile.Count; i++)
        {
            if (i == SelectedIndex)
            {
                prefix = ">";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            WriteLine($"{title(i)} {prefix} {Profile[i]} \n");
        }
        ResetColor();
    }

    private void Edit_data(int Index)
    {
        // Working on checking input data
        do
        {
            string new_data;
            string currentValue = Profile[Index];
            WriteLine($"Текущее значение: {currentValue}\n");
            WriteLine("Введите новое значение:");
            new_data = ReadLine();

            if (Index == 0)         // Name
            {
                if (!string.IsNullOrEmpty(new_data))
                {
                    Profile[Index] = new_data;
                    db.data_s_modification(Profile, index);
                    rw.WriteData();
                    break;
                }
                else { WriteLine("\nДанные отсутствуют!!"); }
            }

            else if (Index == 1)    // Age
            {
                if (int.TryParse(new_data, out int data))
                {
                    Profile[Index] = new_data;
                    db.data_s_modification(Profile, index);
                    rw.WriteData();
                    break;
                }
                else { WriteLine("\nТип данных не совпадает с заданным"); }
            }

            else if (Index == 2)    // Grades
            {
                if (double.TryParse(new_data, out double data))
                {
                    if (2.0 <= data & data <= 5.0)
                    {
                        Profile[Index] = new_data;
                        db.data_s_modification(Profile, index);
                        rw.WriteData();
                        break;
                    }
                    else { WriteLine("\nДанные в не рабочего диапозона. Диапозон (2.0-5.0)"); }
                }
                else { WriteLine("\nТип данных не совпадает с заданным"); }
            }

            else if (Index == 3)    // Mobile
            {
                if (!string.IsNullOrEmpty(new_data))
                {
                    if (new_data.Length == 11)
                    {
                        string m_mobile = new_data.Insert(0, "+");
                        string mod_mobile = m_mobile.Insert(2, "(");
                        string mod_mobile1 = mod_mobile.Insert(6, ")");
                        string mod_mobile2 = mod_mobile1.Insert(10, "-");
                        new_data = mod_mobile2.Insert(13, "-");

                        Profile[Index] = new_data;
                        db.data_s_modification(Profile, index);
                        rw.WriteData();
                        break;
                    }
                    else if (new_data.Length == 12)
                    {
                        string mod_mobile = new_data.Insert(2, "(");
                        string mod_mobile1 = mod_mobile.Insert(6, ")");
                        string mod_mobile2 = mod_mobile1.Insert(10, "-");
                        new_data = mod_mobile2.Insert(13, "-");
                        Profile[Index] = new_data;
                        db.data_s_modification(Profile, index);
                        rw.WriteData();
                        break;
                    }

                    else { WriteLine("\nМобильный телефон должен быть следующим:\n+79997770000\nили\n79995551111"); }
                }
                else { WriteLine("\nДанные отсутствуют!!"); }
            }

            else if (Index == 4)    // BirthDate
            {
                if (!string.IsNullOrEmpty(new_data))
                {
                    Profile[Index] = new_data;
                    db.data_s_modification(Profile, index);
                    rw.WriteData();
                    break;
                }
                else { WriteLine("\nДанные отсутствуют!!"); }
            }

            else if (Index == 5)    // Adress
            {
                if (!string.IsNullOrEmpty(new_data))
                {
                    Profile[Index] = new_data;
                    db.data_s_modification(Profile, index);
                    rw.WriteData();
                    break;
                }
                else { WriteLine("\nДанные отсутствуют!!"); }
            }

        } while (true);
    }

    public void Run(int index, int admin)
    {
        Profile.Clear();
        SelectedIndex = 0;
        Admin = admin;
        this.index = index;
        data = db.data_retrival(); // HERE
        Conditions = true;

        var per = data[index];
        for (int j = 0; j < per.Length; j++)
        {
            Profile.Add(per[j]);
        }
        Profile.Add("Удалить");
        Profile.Add("Выход");


        //-----------------------------------------------------------------

        ConsoleKey keypressed;
        do
        {
            Clear();

            DisplayProfile();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keypressed = keyInfo.Key;
            if (keypressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Profile.Count) { SelectedIndex = 0; }

            }

            else if (keypressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1) { SelectedIndex = Profile.Count - 1; }
            }

            else if (keypressed == ConsoleKey.Enter & Admin == 1 & SelectedIndex != Profile.Count - 1)
            {
                int[] vals = { 0, 1, 2, 3, 4, 5 };

                if (vals.Contains(SelectedIndex))
                {
                    Edit_data(SelectedIndex);
                }
                else
                {
                    string x;
                    Clear();
                    WriteLine("Вы уверены, что хотите удалить профиль? y/n");
                    x = ReadLine();
                    if (x == "y")       // Counted as YES
                    {
                        db.data_deletion(index);
                        rw.WriteData();
                        Conditions = false;
                    }

                    else                // Counted as NO
                    {
                        if (x == "n")
                        {
                            Conditions = true;
                        }
                        else
                        {
                            WriteLine("Не коректный ответ. Применение стандартного решения");
                            Conditions = true;
                        }
                    }
                }
            }

            else if (keypressed == ConsoleKey.Enter & SelectedIndex == Profile.Count - 1)       // exit program
            { Conditions = false; rw.WriteData(); }

            else { Conditions = true; }

        } while (Conditions);
    }

    // Ending here

}