using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Abstarcts
{
    abstract class Access_Check
    {
        abstract public bool Check_Access(string username, string Password);
        abstract public void Display_Page();
        abstract public void Display_Admin(int SelectedIndex, List<string> Profile);
        abstract public void Display_Student(int SelectedIndex, List<string> Profile);
        abstract public void Display_Login_Password();
    }






}
