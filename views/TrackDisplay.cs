/*
 * Created by SharpDevelop.
 * User: AaronDay
 * Date: 11/27/2006
 * Time: 9:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Janus.ManagedMIDI;

namespace ChordQuality.views
{
    /// <summary>
    ///     Description of TrackDisplay.
    /// </summary>
    public class TrackDisplay
    {
        private readonly ArrayList _mDisplayElementList;

        public TrackDisplay(MidiTrack[] tracks, Color[] trackColors)
        {
            _mDisplayElementList = new ArrayList();

            // store notes-
            var evts = new ArrayList();
            for (var n = 0; n < tracks.Length; n++) //MidiTrack t in f.tracks)
            {
                //bool wasPreviousElementBolded = false;
                //bool wasLastElementBolded = false;

                MidiTrack t = tracks[n];
                if (!t.enabled) continue;
                evts.Clear();
                float width = 1;
                //float previousWidth = 1;

                for (var i = 0; i < t.events.Count; i++)
                {
                    if (t.get_e(i).IsMidi)
                    {
                        TimedMidiMsg m = (TimedMidiMsg)t.get_e(i);
                        if (m.m.IsNoteOn)
                            evts.Add(m);
                        else if (m.m.IsNoteOff)
                        {
                            TimedMidiMsg e1 = null;
                            TimedMidiMsg e2 = m;
                            foreach (TimedMidiMsg mm in evts)
                                if (mm.m.Byte2 == e2.m.Byte2)
                                {
                                    e1 = mm;
                                    evts.Remove(mm);
                                    break;
                                }
                            if (e1 != null)
                            {
                                // partially selected elements never get bolded because elements are handled
                                // from note OFF to note OFF, which means they are all or nothing.

                                // because of this, if an element is bolded, we're going to bold the one before
                                // and the one after

                                // if the previous element was bolded, and the current one is not,
                                // bold the current one, since it's the last one
                                //if (width == 1 && previousWidth == 2 && !wasLastElementBolded)
                                //{
                                //    width = 2;
                                //    wasLastElementBolded = true;
                                //}

                                //// 
                                var element =
                                    new TrackDisplayElement(e1.Time, e2.Time, e2.m.Byte2,
                                        trackColors[Array.IndexOf(tracks, t)], width);

                                // if the current width is 2, modify the width of the previous trackdisplayelement
                                // to be 2 as well. Pass in the color of the current track so we can find the
                                // correct previous one
                                if (width == 2)
                                {
                                    TrackDisplayElement matchingElement = null;
                                    foreach (TrackDisplayElement tre in _mDisplayElementList)
                                    {
                                        // this is a matching track, so store it
                                        if ((Color)tre.MColorList[0] == trackColors[Array.IndexOf(tracks, t)])
                                        {
                                            matchingElement = tre;
                                        }
                                    }

                                    // if there was a matching element, modify the width
                                    if (matchingElement != null)
                                    {
                                        matchingElement.MWidthList[0] = 2.0f;
                                    }
                                }

                                AddElement(element, n == 0, 0);
                            }
                        }
                    }
                    else if (t.get_e(i).IsMeta)
                    {
                        MetaMsg m = (MetaMsg)t.get_e(i);
                        if (m.Type == 6) // "Marker"
                        {
                            if (m.Txt.ToLower() == "bold")
                            {
                                //previousWidth = 2;
                                width = 2;
                            }
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
                _mDisplayElementList.Add(element);
            }
            else
            {
                for (var i = startIndex; i < _mDisplayElementList.Count; ++i)
                {
                    var iter = (TrackDisplayElement)_mDisplayElementList[i];

                    if (iter.MColorList.Count == 1 && iter.MColorList[0] == element.MColorList[0])
                    {
                        // The two elements are of the same color, they cannot overlap
                        continue;
                    }

                    if (element.My == iter.My &&
                        iter.MTime2 > element.MTime1 &&
                        iter.MTime1 < element.MTime2)
                    {
                        // These elements overlap
                        var overlapTime1 = iter.MTime1;
                        var overlapTime2 = iter.MTime2;

                        if (iter.MTime1 < element.MTime1)
                        {
                            // This is the piece of the already existing element
                            // that does not overlap to the left
                            _mDisplayElementList.Add(new TrackDisplayElement(iter.MTime1, element.MTime1,
                                iter.My, new ArrayList(iter.MColorList), new ArrayList(iter.MWidthList)));

                            overlapTime1 = element.MTime1;
                        }
                        else if (iter.MTime1 > element.MTime1)
                        {
                            // call this method recursively for the nonoverlapping part
                            // start at index i, since we already checked all the elements before that
                            AddElement(new TrackDisplayElement(element.MTime1, iter.MTime1, element.My,
                                (Color)element.MColorList[0], (float)element.MWidthList[0]), false, i + 1);
                        }

                        if (iter.MTime2 > element.MTime2)
                        {
                            // This is the piece of the already existing element
                            // that does not overlap to right
                            _mDisplayElementList.Add(new TrackDisplayElement(element.MTime2, iter.MTime2, iter.My,
                                new ArrayList(iter.MColorList), new ArrayList(iter.MWidthList)));

                            overlapTime2 = element.MTime2;
                        }
                        else if (iter.MTime2 < element.MTime2)
                        {
                            // call this method recursively for the nonoverlapping part
                            // start at index i, since we already checked all the elements before that
                            AddElement(new TrackDisplayElement(iter.MTime2, element.MTime2, element.My,
                                (Color)element.MColorList[0], (float)element.MWidthList[0]), false, i + 1);
                        }

                        // update iter for the overlapping data
                        iter.MTime1 = overlapTime1;
                        iter.MTime2 = overlapTime2;
                        iter.AddOverlappingData((Color)element.MColorList[0], (float)element.MWidthList[0]);

                        // All the elements have been added, return
                        return;
                    }
                }

                // Can only get here if there was no overlap
                // Add the element as is
                _mDisplayElementList.Add(element);
            }
        }

        // This method is useful for debugging
        // It writes out the display elements to a file
        public void WriteToFile()
        {
            var ostream = new StreamWriter("C:\\ChordQuality\\Test.txt", true);
            foreach (TrackDisplayElement element in _mDisplayElementList)
            {
                var outputString = element.MTime1 + ", " + element.MTime2 + "," + element.My;

                foreach (Color color in element.MColorList)
                {
                    outputString += "," + color;
                }

                ostream.WriteLine(outputString);
            }

            ostream.Close();
        }

        public void Draw(Graphics gr, int grw, int y0, byte maxNote, int offset,
            ushort timing, int zoomScrollValue, int vscale, float rf)
        {
            var mintime = offset * 4 * timing;
            var maxtime = (offset + zoomScrollValue + 1) * 4 * timing;

            foreach (TrackDisplayElement element in _mDisplayElementList)
            {
                if (element.MTime2 > mintime && element.MTime1 <= maxtime)
                {
                    element.Draw(gr, grw, y0, maxNote, offset,
                        timing, zoomScrollValue, vscale, rf);
                }
            }
        }
    }
}