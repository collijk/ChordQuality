using System;
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
