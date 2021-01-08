using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceDesigner
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InterfaceDesigner view = new InterfaceDesigner();
            Model mdl = new Model();
            Controller cnt = new Controller(view, mdl);
            Application.Run(view);
        }
    }
}
