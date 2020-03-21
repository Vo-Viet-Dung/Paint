using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Jokedst.GetOpt;
using System.Text;
using WindowsFormsAppPaint;

namespace WindowsFormsAppPaint
{
     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // For the sake of this example, we're just printing the arguments to the console.
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("args[{0}] == {1}", i, args[i]);
            }
            string paramFileName = string.Empty;
            bool paramAll = false;
            var opt = new GetOpt("Chuong trinh ky ten",
            new[] {
                 new CommandLineOption('s', "save", "Luu file voi ten da duoc quy uoc", ParameterType.String, o => paramFileName = (string)o),
                 new CommandLineOption('a', "all", "Tai ve tat ca cac file",         ParameterType.None, o => paramAll = true),
            });
            try
            {
                opt.ParseOptions(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Form1 myForm = new Form1();
            myForm.DestinationFileName = paramFileName;
            
            // Tim hieu va phan tich bang GetOpt
            Application.Run(myForm);
        }
    }
}
