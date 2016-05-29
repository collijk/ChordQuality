using Janus.ManagedMIDI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordQuality.Services
{
    public class AnalysisFileWriter
    {
        public AnalysisFileWriter(string filename)
        {
            sw = File.CreateText(filename);
        }
        public void WriteTracks(MidiFile f, int t)
        {
            sw.WriteLine("<<< SOURCE FILE >>>");
            sw.WriteLine(f.name);
            sw.WriteLine();
            sw.WriteLine("<<< TRANSPOSE >>>");
            sw.WriteLine(t);
            sw.WriteLine();
            sw.WriteLine("<<< TRACKS >>>");
            for(int i = 0; i < f.tracks.Length; i++)
            {
                sw.Write("[");
                if(f.tracks[i].enabled)
                    sw.Write("X");
                else
                    sw.Write(" ");
                sw.WriteLine("] #" + (i + 1) + ": " + f.tracks[i].name);
            }
            sw.WriteLine();
        }
        public void WriteTunings(TuningScheme[] tun)
        {
            sw.WriteLine("<<< TUNINGS >>>");
            for(int i = 0; i < tun.Length; i++)
            {
                if(tun[i].enabled)
                    sw.WriteLine(tun[i].ToString());
            }
            sw.WriteLine();
        }
        public void WriteTuningTranspose(int t)
        {
            sw.WriteLine("<<< TUNING TRANSPOSE >>>");
            sw.WriteLine(t);
            sw.WriteLine();
        }
        public void WriteWeights(QualityWeights w, DomainUpDown tud)
        {
            sw.WriteLine("<<< QUALITY WEIGHTS >>>");
            sw.WriteLine("INTERVALS:");
            sw.WriteLine("6M:\t" + w.M6);
            sw.WriteLine("6m:\t" + w.m6);
            sw.WriteLine("5:\t" + w.fifth);
            sw.WriteLine("4:\t" + w.fourth);
            sw.WriteLine("3M:\t" + w.M3);
            sw.WriteLine("3m:\t" + w.m3);
            sw.WriteLine("CHORDS:");
            sw.WriteLine("5:\t" + w.Ch5);
            sw.WriteLine("3M:\t" + w.Ch3);
            sw.WriteLine();
            sw.WriteLine("<<< PENALTIES >>>");
            sw.WriteLine("Additional Notes:\t" + w.Add);
            sw.WriteLine("Short Notes:\t" + w.Short);
            sw.WriteLine("Threshold for Short Notes:\t" + tud.Text);
            sw.WriteLine();
        }
        public void WriteChords(ArrayList chords, MidiFile f, TuningScheme[] t, QualityWeights w)
        {
            sw.WriteLine();
            sw.WriteLine("<<< CHORDS & INTERVALS >>>");
            sw.WriteLine();
            sw.Write("POS\tNAME\tDUR");
            for(int i = 0; i < t.Length; i++)
                if(t[i].enabled)
                    sw.Write("\t" + t[i].Name);
            sw.WriteLine();
            foreach(TimeInfo c in chords)
            {
                if(!w.enabled(c))
                    continue;
                sw.Write(Math.Round(c.Time / 4.0 / f.timing, 2) + "\t" + c.Name + "\t" + Math.Round(c.Duration / 4.0 / f.timing, 2));
                for(int i = 0; i < t.Length; i++)
                    if(t[i].enabled)
                        sw.Write("\t" + t[i].Quality(c, w));
                sw.WriteLine();
            }
            sw.Write("POS\tNAME\tDUR");
            for(int i = 0; i < t.Length; i++)
                if(t[i].enabled)
                    sw.Write("\t" + t[i].Name);
            sw.WriteLine();
            sw.Write("AVERAGE:\t\t");
            for(int i = 0; i < t.Length; i++)
                if(t[i].enabled)
                    sw.Write("\t" + Math.Round(t[i].AvgQuality(chords, w), 1));
        }
        public void Close()
        {
            sw.Close();
        }
        protected StreamWriter sw;
    }
}
