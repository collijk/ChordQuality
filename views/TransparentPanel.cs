using System;
using System.Windows.Forms;

namespace ChordQuality.views
{
    internal class TransparentPanel : Panel
    {
        //from http://stackoverflow.com/questions/547172/pass-through-mouse-events-to-parent-control
        protected override void WndProc(ref Message m)
        {
            const int wmNchittest = 0x0084;
            const int httransparent = -1;

            if (m.Msg == wmNchittest)
            {
                m.Result = (IntPtr) httransparent;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}