/*
 * Created by SharpDevelop.
 * User: AaronDay
 * Date: 11/27/2006
 * Time: 6:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections;
using System.Drawing;

namespace ChordQuality.views
{
    /// <summary>
    ///     Description of TrackDisplayElement.
    /// </summary>
    public class TrackDisplayElement
    {
        public ArrayList MColorList;

        public int MTime1;
        public int MTime2;

        public ArrayList MWidthList;
        public int My;

        public TrackDisplayElement(int time1, int time2, int y,
            Color color, float width)
        {
            MTime1 = time1;
            MTime2 = time2;
            My = y;

            MColorList = new ArrayList();
            MWidthList = new ArrayList();

            MColorList.Add(color);
            MWidthList.Add(width);
        }

        public TrackDisplayElement(int time1, int time2, int y,
            ArrayList colorList, ArrayList widthList)
        {
            MTime1 = time1;
            MTime2 = time2;
            My = y;
            MColorList = colorList;
            MWidthList = widthList;
        }

        public void AddOverlappingData(Color color, float width)
        {
            MColorList.Add(color);
            MWidthList.Add(width);
        }

        public void Draw(Graphics gr, byte maxNote, int offset,
            ushort timing, int zoomScrollValue, float vscale, float rf)
        {
            var grw = gr.VisibleClipBounds.Width;
            const int y0 = 0;
            var x1 = grw*(MTime1 - 4*(offset+1)*timing)/timing/4/zoomScrollValue;
            var x2 = grw*(MTime2 - 4*(offset+1)*timing)/timing/4/zoomScrollValue;
            var y = vscale*(maxNote - My) + y0;

            // All overlapping lines are recorded here
            // however, only the first two will be drawn
            if (MColorList.Count >= 2 && MWidthList.Count >= 2)
            {
                if (MWidthList[0] == MWidthList[1])
                {
                    var pen = new Pen((Color) MColorList[0], (float) MWidthList[0]*vscale*rf/2);
                    gr.DrawLine(pen, x1, y - (float) MWidthList[0]*vscale*rf/4, x2,
                        y - (float) MWidthList[0]*vscale*rf/4);

                    pen.Color = (Color) MColorList[1];
                    gr.DrawLine(pen, x1, y + (float) MWidthList[0]*vscale*rf/4, x2,
                        y + (float) MWidthList[0]*vscale*rf/4);
                }
                else if ((float) MWidthList[0] < (float) MWidthList[1])
                {
                    // draw the thicker line first
                    var pen = new Pen((Color) MColorList[1], (float) MWidthList[1]*vscale*rf);
                    gr.DrawLine(pen, x1, y, x2, y);

                    pen.Color = (Color) MColorList[0];
                    pen.Width = (float) MWidthList[0]*vscale*rf;
                    gr.DrawLine(pen, x1, y, x2, y);
                }
                else // ((float)m_widthList[0] > (float)m_widthList[1])
                {
                    // Draw the thicker line first
                    var pen = new Pen((Color) MColorList[0], (float) MWidthList[0]*vscale*rf);
                    gr.DrawLine(pen, x1, y, x2, y);

                    pen.Color = (Color) MColorList[1];
                    pen.Width = (float) MWidthList[1]*vscale*rf;
                    gr.DrawLine(pen, x1, y, x2, y);
                }
            }
            else
            {
                var pen = new Pen((Color) MColorList[0], (float) MWidthList[0]*vscale*rf);
                gr.DrawLine(pen, x1, y, x2, y);
            }
        }
    }
}