/*
 * Created by SharpDevelop.
 * User: AaronDay
 * Date: 11/27/2006
 * Time: 9:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Collections;
using System.Drawing;

using Janus.ManagedMIDI;

namespace ChordQuality
{
	/// <summary>
	/// Description of TrackDisplay.
	/// </summary>
	public class TrackDisplay
	{
		public TrackDisplay(MidiTrack[] tracks, Color[] trackColors)
		{
			m_displayElementList = new ArrayList();
			
			// store notes-
			ArrayList evts=new ArrayList();
			for (int n=0;n<tracks.Length;n++)//MidiTrack t in f.tracks)
			{
				MidiTrack t=tracks[n];
				if (!t.enabled) continue;
				evts.Clear();
				float width = 1;
				
				for (int i=0;i<t.events.Count;i++)
				{
                    if (t.get_e(i).IsMidi)
					{
                        TimedMidiMsg m=(TimedMidiMsg)t.get_e(i);
						if (m.m.IsNoteOn) evts.Add(m);
						else if (m.m.IsNoteOff)
						{
							TimedMidiMsg e1=null;
							TimedMidiMsg e2=m;
							foreach (TimedMidiMsg mm in evts)
								if (mm.m.Byte2==e2.m.Byte2)
								{
									e1=mm;
                                    evts.Remove(mm);
									break;
								}
							if (e1!=null)
							{

								TrackDisplayElement element =
									new TrackDisplayElement(e1.Time, e2.Time, e2.m.Byte2, 
									                        trackColors[Array.IndexOf(tracks,t)], width);
								
								AddElement(element, n==0, 0);
							}
						}
					}
                    else if (t.get_e(i).IsMeta)
                    {
                        MetaMsg m = (MetaMsg)t.get_e(i);
                        if (m.Type == 6)	// "Marker"
                        {
                            if (m.Txt.ToLower() == "bold")
                                width = 2;
                            else if (m.Txt.ToLower() == "stop")
                                width = 1;
                        }
                    }
				}
			}
		}
		
		private void AddElement(TrackDisplayElement element, bool isFirstTrack, int startIndex)
		{
			if (isFirstTrack)
			{
				m_displayElementList.Add(element);
			}
			else
			{
				for (int i = startIndex; i < m_displayElementList.Count; ++i)
				{
					TrackDisplayElement iter = (TrackDisplayElement)m_displayElementList[i];
					
					if (iter.m_colorList.Count == 1 && iter.m_colorList[0] == element.m_colorList[0])
					{
						// The two elements are of the same color, they cannot overlap
						continue;
					}
					
			  		if (element.m_y == iter.m_y &&
			  		    iter.m_time2 > element.m_time1 &&
			  		    iter.m_time1 < element.m_time2)
			  		{
			  			// These elements overlap
			  			int overlapTime1 = iter.m_time1;
						int overlapTime2 = iter.m_time2;
									
			  			if (iter.m_time1 < element.m_time1)
			  			{
			  				// This is the piece of the already existing element
			  				// that does not overlap to the left
			  				m_displayElementList.Add(new TrackDisplayElement(iter.m_time1, element.m_time1, 
                                iter.m_y, new ArrayList(iter.m_colorList), new ArrayList(iter.m_widthList)));
			  				
			  				overlapTime1 = element.m_time1;
			  			}
			  			else if (iter.m_time1 > element.m_time1)
			  			{
			  				// call this method recursively for the nonoverlapping part
			  				// start at index i, since we already checked all the elements before that
			  				AddElement(new TrackDisplayElement(element.m_time1, iter.m_time1, element.m_y, 
                                (Color)element.m_colorList[0], (float)element.m_widthList[0]), false, i+1);
			  			}
			  			
			  			if (iter.m_time2 > element.m_time2)
			  			{
			  				// This is the piece of the already existing element
			  				// that does not overlap to right
			  				m_displayElementList.Add(new TrackDisplayElement(element.m_time2, iter.m_time2, iter.m_y, 
                                new ArrayList(iter.m_colorList), new ArrayList(iter.m_widthList)));
			  			
			  				overlapTime2 = element.m_time2;
			  			}
			  			else if (iter.m_time2 < element.m_time2)
			  			{
			  				// call this method recursively for the nonoverlapping part
			  				// start at index i, since we already checked all the elements before that
			  				AddElement(new TrackDisplayElement(iter.m_time2, element.m_time2, element.m_y, 
                                (Color)element.m_colorList[0], (float)element.m_widthList[0]), false, i+1);
			  			}
			  			
			  			// update iter for the overlapping data
			  			iter.m_time1 = overlapTime1;
			  			iter.m_time2 = overlapTime2;
			  			iter.AddOverlappingData((Color)element.m_colorList[0], (float)element.m_widthList[0]);
			  		
			  			// All the elements have been added, return
			  			return;
					}
				}

				// Can only get here if there was no overlap
				// Add the element as is
				m_displayElementList.Add(element);
			}
		}
		
		// This method is useful for debugging
		// It writes out the display elements to a file
		public void WriteToFile()
		{
			StreamWriter ostream = new StreamWriter("C:\\ChordQuality\\Test.txt", true);
			foreach (TrackDisplayElement element in m_displayElementList)
			{
				string outputString = element.m_time1.ToString() + ", " + element.m_time2.ToString() + "," + element.m_y.ToString();
				
				foreach (Color color in element.m_colorList)
				{
					outputString += "," + color.ToString();
				}
				
				ostream.WriteLine(outputString);
			}
			
			ostream.Close();
		}
		
		public void Draw(Graphics gr, int grw, int y0, byte maxNote, int offset,
		                 ushort timing, int zoomScrollValue, int vscale, float rf)
		{
			int mintime=offset*4*timing;
			int maxtime=(offset+zoomScrollValue+1)*4*timing;
			
			foreach (TrackDisplayElement element in m_displayElementList)
			{
				if (element.m_time2>mintime && element.m_time1 <=maxtime)
				{
					element.Draw(gr, grw, y0, maxNote, offset,
					             timing, zoomScrollValue, vscale, rf);
				}
			}
		}
		
		private ArrayList m_displayElementList;
	}
}
