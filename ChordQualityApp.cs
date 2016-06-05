using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordQuality
{
    class ChordQualityApp
    {
        [STAThread]
        public static void Main(string[] args)
        {
            MainForm view = new MainForm();
            Application.Run(view);
        }
    }
}
