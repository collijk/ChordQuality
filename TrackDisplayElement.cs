/*
 * Created by SharpDevelop.
 * User: AaronDay
 * Date: 11/27/2006
 * Time: 6:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Drawing;

namespace ChordQuality
{
	/// <summary>
	/// Description of TrackDisplayElement.
	/// </summary>
	public class TrackDisplayElement
	{
		public TrackDisplayElement(int time1, int time2, int y,
		                            System.Drawing.Color color, float width)
		{
			m_time1 = time1;
			m_time2 = time2;
			m_y = y;
			
			m_colorList = new ArrayList();
			m_widthList = new ArrayList();
			
			m_colorList.Add(color);
			m_widthList.Add(width);
		}
		
		public TrackDisplayElement(int time1, int time2, int y,
		                           ArrayList colorList, ArrayList widthList)
		{
			m_time1 = time1;
			m_time2 = time2;
			m_y = y;
			m_colorList = colorList;
			m_widthList = widthList;
		}
		
		public void AddOverlappingData(System.Drawing.Color color, float width)
		{
			m_colorList.Add(color);
			m_widthList.Add(width);
		}
		
		public void Draw(Graphics gr, int grw, int y0, byte maxNote, int offset,
		                 ushort timing, int zoomScrollValue, int vscale, float rf)
		{
			int x1=grw*(m_time1-4*offset*timing)/timing/4/zoomScrollValue;
			int x2=grw*(m_time2-4*offset*timing)/timing/4/zoomScrollValue;
			int y=vscale*(maxNote-m_y)+y0;
					
			// All overlapping lines are recorded here
			// however, only the first two will be drawn
			if (m_colorList.Count >= 2 && m_widthList.Count >= 2)
			{
				if ((float)m_widthList[0] == (float)m_widthList[1])
				{
					Pen pen = new Pen((Color)m_colorList[0], ((float)m_widthList[0]*vscale*rf)/2);
					gr.DrawLine(pen,x1,y-((float)m_widthList[0]*vscale*rf)/4,x2,y-((float)m_widthList[0]*vscale*rf)/4);
					
					pen.Color = (Color)m_colorList[1];
					gr.DrawLine(pen,x1,y+((float)m_widthList[0]*vscale*rf)/4,x2,y+((float)m_widthList[0]*vscale*rf)/4);
				}
				else if ((float)m_widthList[0] < (float)m_widthList[1])
				{
					// draw the thicker line first
					Pen pen = new Pen((Color)m_colorList[1], (float)m_widthList[1]*vscale*rf);
					gr.DrawLine(pen, x1, y, x2, y);
					
					pen.Color = (Color)m_colorList[0];
					pen.Width = (float)m_widthList[0]*vscale*rf;
					gr.DrawLine(pen, x1, y, x2, y);
				}
				else // ((float)m_widthList[0] > (float)m_widthList[1])
				{
					// Draw the thicker line first
					Pen pen = new Pen((Color)m_colorList[0], (float)m_widthList[0]*vscale*rf);
					gr.DrawLine(pen,x1,y,x2,y);
					
					pen.Color = (Color)m_colorList[1];
					pen.Width = (float)m_widthList[1]*vscale*rf;
					gr.DrawLine(pen,x1,y,x2,y);
				}
			}
			else
			{
				Pen pen = new Pen((Color) m_colorList[0], (float)m_widthList[0]*vscale*rf);
				gr.DrawLine(pen,x1,y,x2,y);
			}
		}
		
		public int                  m_time1;
		public int                  m_time2;
		public int                  m_y;
		
		public ArrayList            m_widthList;
		public ArrayList            m_colorList;
	}
}
