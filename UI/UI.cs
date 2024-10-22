using System;
using System.Collections.Generic;
using static System.Console;
using Lab5.Main;
using Lab5.Protection;

namespace Lab5.UI;

class Menu
{
    private int SelectedInex;
    private int SelectedLayer = 0;
    private int Entry;
    private bool LayerDisplayed = false;
    private int Admin = 0;

    private int Coordinates;
    private List<string> Options;
    private List<string[]> data;

    User_Profile Profile = new();
    DataBase db = new();

    public Menu(List<string> options)   // Class constructor
    {
        SelectedInex = 0;
        Options = options;
        Options.Add("Выйти");
    }

    private static void Name()
    {
        WriteLine(
            "\n\n" +
            "\t░█▀▀░█▀▀░█░█░█▀█░█▀█░█░░\n" +
            "\t░▀▀█░█░░░█▀█░█░█░█░█░█░░\n" +
            "\t░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀▀▀\n" +
            "\n\n");
    }

    private void DisplayOptions()
    {

        bool usedOnce = false;

        WriteLine("-------------------------------------------------------");
        for (int i = 0; i < Options.Count; i++)
        {
            string currentOption = Options[i];
            string prefix;

            if (i == SelectedInex & SelectedLayer == 0)
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
            WriteLine($"{prefix} {currentOption} ");
            if (!usedOnce)
            {
                Coordinates = CursorTop;
                usedOnce = true;
            }
        }


        // First goes Column, second goes row

        if (LayerDisplayed)
        {
            int origCoordinates = Coordinates;
            int row = 15;

            for (int i = 0; i < data.Count; i++)
            {
                string prefix;

                if (i % 10 == 0 & i != 0)   // How many displayed in one column
                {
                    row += 40;
                    Coordinates = origCoordinates;
                }

                SetCursorPosition(row, Coordinates);
                Coordinates++;
                if (i == SelectedInex & SelectedLayer == 1)
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
                WriteLine($"{prefix} {data[i][0]}");
            }
        }


        ResetColor();

    }


    public void Run()
    {
        data = db.data_retrival();
        bool Conditions = true;
        int[] returnable = new int[2];

        User_Profile profile = new();
        View view = new();



        ConsoleKey keypressed;
        do
        {
            Clear();
            Name();
            DisplayOptions();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keypressed = keyInfo.Key;

            // Update seletedIndex based on user input

            if (keypressed == ConsoleKey.DownArrow)
            {
                SelectedInex++;
                if (SelectedInex == Options.Count & SelectedLayer == 0)
                {
                    SelectedInex = 0;
                }
                else if (SelectedInex == data.Count & SelectedLayer == 1)
                {
                    SelectedInex = 0;
                }
            }

            else if (keypressed == ConsoleKey.UpArrow)
            {
                SelectedInex--;
                if (SelectedInex == -1 & SelectedLayer == 0)
                {
                    SelectedInex = Options.Count - 1;
                }
                else if (SelectedInex == -1 & SelectedLayer == 1)
                {
                    SelectedInex = data.Count - 1;

                }
            }

            else if (keypressed == ConsoleKey.LeftArrow)    // needs modification
            {
                if (SelectedInex != Options.Count - 1)
                {
                    SelectedLayer = 0;
                    SelectedInex = Entry;
                    LayerDisplayed = false;
                }

                else
                {
                    SelectedLayer = 0;
                    LayerDisplayed = false;
                }
            }

            else if (keypressed == ConsoleKey.RightArrow)   // needs modification
            {
                if (SelectedInex != Options.Count - 1 & SelectedInex != Options.Count - 2)
                {

                    if (SelectedInex == 0) { Admin = 0; }

                    else if (SelectedInex == 1) { Admin = 1; }

                    SelectedLayer = 1;
                    Entry = SelectedInex;
                    SelectedInex = 0;
                    LayerDisplayed = true;

                }

                else
                {
                    SelectedLayer = 0;
                    LayerDisplayed = false;
                }
            }

            // Checking conditions
            if (SelectedLayer == 0)
            {
                if (keypressed == ConsoleKey.Enter & SelectedInex == 0 & SelectedInex == 1)
                {
                    // Implementing Login 
                    if (SelectedInex == 1)
                    {
                        /*         if(view.Check_Access())
                                 {
                                     view.Display_Admin(SelectedInex);
                                 }*/
                        Admin = 1;

                    }
                    else { Admin = 0; }
                    SelectedLayer = 1;
                    Entry = SelectedInex;
                    SelectedInex = 0;
                    LayerDisplayed = true;
                }
                //
                //  ADDING new STUDENT
                //
                else if (keypressed == ConsoleKey.Enter & SelectedInex == 2)
                {
                    db.add_data();
                    Clear();
                    WriteLine("Профиль успешно создан. Профиль не будет записан в БД, пока не будут внесены какие либо изменения. Продолжить?");
                    string x = ReadLine();
                }
                //
                else if (keypressed == ConsoleKey.Enter & SelectedInex == 3)
                {
                    Clear();
                    bool m = true;
                    do
                    {
                        WriteLine("\nВведите ID студента для поиска");
                        try
                        {
                            int id = int.Parse(ReadLine());
                            int count = 0;
                            bool f = false;
                            foreach (string[] s in data)
                            {
                                if (id == int.Parse(s[6])) { profile.Run(count, Admin); m = false; f = true; }
                                count++;
                            }
                            if (!f) { throw new Exception(); }
                        }
                        catch { WriteLine("\nСопадений не найдено."); }

                    } while (m);


                }
                //
                else if (keypressed == ConsoleKey.Enter && SelectedInex == 4)
                {
                    Environment.Exit(0);
                }
            }
            // Working here
            else if (keypressed == ConsoleKey.Enter & SelectedLayer == 1)
            {
                SetCursorPosition(0, 20);
                profile.Run(SelectedInex, Admin);
            }

        } while (Conditions);
    }
}