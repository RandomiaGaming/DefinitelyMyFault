using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefinitelyMyFault
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}