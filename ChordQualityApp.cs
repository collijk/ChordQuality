using System;
using System.Windows.Forms;
using ChordQuality.views;

namespace ChordQuality
{
    internal class ChordQualityApp
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var view = new MainForm();
            Application.Run(view);
        }
    }
}