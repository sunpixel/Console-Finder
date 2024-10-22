using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Lab5.Abstarcts;

namespace Lab5.Protection
{

    // Used before you get onto the actual screen

    class View : Access_Check
    {

        protected string password { get; set; }
        protected string userName { get; set; }


        public override bool Check_Access(string username, string Password)
        {
            WriteLine("11");
            return true;
        }

        public override void Display_Page()
        {

        }

        public override void Display_Admin(int SelectedIndex, List<string> Profile)
        {
            /*
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
            */
        }


        public override void Display_Student(int SelectedIndex, List<string> Profile)
        {
            /*            Naming();
                        WriteLine("-------------------------------------------------------");
                        string prefix;

                        for (int i = 0; i < 2; i++)
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
                        ResetColor();*/
        }


        public override void Display_Login_Password()
        {
            Naming();
        }


        private void Naming()
        {
            WriteLine(
                "\n\n" +
                "\t\t░█▀█░█▀▄░█▀█░█▀▀░▀█▀░█░░░█▀▀░░\n" +
                "\t\t░█▀▀░█▀▄░█░█░█▀▀░░█░░█░░░█▀▀░░\n" +
                "\t\t░▀░░░▀░▀░▀▀▀░▀░░░▀▀▀░▀▀▀░▀▀▀░░\n" +
                "\n\n");
        }


        private void Naming_Login()
        {
            WriteLine(
                "\n" +
                " ██▓     ▒█████    ▄████     ██▓ ███▄    █ \n" +
                "▓██▒    ▒██▒  ██▒ ██▒ ▀█▒   ▓██▒ ██ ▀█   █ \n" +
                "▒██░    ▒██░  ██▒▒██░▄▄▄░   ▒██▒▓██  ▀█ ██▒\n" +
                "▒██░    ▒██   ██░░▓█  ██▓   ░██░▓██▒  ▐▌██▒\n" +
                "░██████▒░ ████▓▒░░▒▓███▀▒   ░██░▒██░   ▓██░\n" +
                "░ ▒░▓  ░░ ▒░▒░▒░  ░▒   ▒    ░▓  ░ ▒░   ▒ ▒ \n" +
                "░ ░ ▒  ░  ░ ▒ ▒░   ░   ░     ▒ ░░ ░░   ░ ▒░\n" +
                "  ░ ░   ░ ░ ░ ▒  ░ ░   ░     ▒ ░   ░   ░ ░ \n" +
                "    ░  ░    ░ ░        ░     ░           ░ \n"
                );
        }

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
    }
}
