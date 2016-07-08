using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;
using Janus.Misc;

namespace ChordQuality.services.io
{
    public class AnalysisFileWriter
    {
        // Thread safe singleton pattern for MidiToTextWriter construction.
        private static AnalysisFileWriter _instance;
        private static readonly object Padlock = new object();
        private SaveFileDialog _saveAnalysisDialog;
        protected StreamWriter Sw;

        public MidiDataModel DataModel { get; set; }
        public MidiTuningModel TuningModel { get; set; }
        public MidiQualityModel QualityModel { get; set; }

        private AnalysisFileWriter()
        {
            InitializeDialog();
        }

        public static AnalysisFileWriter Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new AnalysisFileWriter());
                }
            }
        }

        private void InitializeDialog()
        {
            _saveAnalysisDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = @"TXT-Files|*.txt"
            };
            _saveAnalysisDialog.FileOk += SaveFileDialogFileOk;
        }

        private void SaveFileDialogFileOk(object sender, CancelEventArgs e)
        {
            WriteTracks();
            WriteTunings();
            WriteTuningTranspose();
            WriteWeights();
            WriteChords();
            Close();
            Shell.Execute(_saveAnalysisDialog.FileName);
        }

        public void WriteAnalysis()
        {
            _saveAnalysisDialog.FileName = Path.ChangeExtension(DataModel.MidiFileName, null);
            _saveAnalysisDialog.FileName += "_analysis.txt";
            _saveAnalysisDialog.ShowDialog();
        }

        public void WriteTracks()
        {
            Sw.WriteLine("<<< SOURCE FILE >>>");
            Sw.WriteLine(DataModel.MidiFileName);
            Sw.WriteLine();
            Sw.WriteLine("<<< TRANSPOSE >>>");
            Sw.WriteLine(DataModel.Transpose);
            Sw.WriteLine();
            Sw.WriteLine("<<< TRACKS >>>");
            for (var i = 0; i < DataModel.Tracks.Length; i++)
            {
                Sw.Write("[");
                Sw.Write(DataModel.Tracks[i].enabled ? "X" : " ");
                Sw.WriteLine("] #" + (i + 1) + ": " + DataModel.Tracks[i].name);
            }
            Sw.WriteLine();
        }

        public void WriteTunings()
        {
            Sw.WriteLine("<<< TUNINGS >>>");
            foreach (var tuning in TuningModel.Tunings)
            {
                if (tuning.enabled)
                    Sw.WriteLine(tuning.ToString());
            }
            Sw.WriteLine();
        }

        public void WriteTuningTranspose()
        {
            Sw.WriteLine("<<< TUNING TRANSPOSE >>>");
            Sw.WriteLine(TuningModel.Transpose);
            Sw.WriteLine();
        }

        public void WriteWeights()
        {
            Sw.WriteLine("<<< QUALITY WEIGHTS >>>");
            Sw.WriteLine("INTERVALS:");
            Sw.WriteLine("6M:\t" + QualityModel.SixthMajorInterval);
            Sw.WriteLine("6m:\t" + QualityModel.SixthMinorInterval);
            Sw.WriteLine("5:\t"  + QualityModel.FifthInterval);
            Sw.WriteLine("4:\t"  + QualityModel.FourthInterval);
            Sw.WriteLine("3M:\t" + QualityModel.ThirdMajorInterval);
            Sw.WriteLine("3m:\t" + QualityModel.ThirdMinorInterval);
            Sw.WriteLine("CHORDS:");
            Sw.WriteLine("5:\t"  + QualityModel.FifthChord);
            Sw.WriteLine("3M:\t" + QualityModel.ThirdMajorChord);
            Sw.WriteLine();
            Sw.WriteLine("<<< PENALTIES >>>");
            Sw.WriteLine("Additional Notes:\t" + QualityModel.Add);
            Sw.WriteLine("Short Notes:\t" + QualityModel.Short);
            Sw.WriteLine("Threshold for Short Notes:\t" + QualityModel.Threshold);
            Sw.WriteLine();
        }

        public void WriteChords()
        {
            Sw.WriteLine();
            Sw.WriteLine("<<< CHORDS & INTERVALS >>>");
            Sw.WriteLine();
            Sw.Write("POS\tNAME\tDUR");
            foreach (var tuning in TuningModel.Tunings)
                if (tuning.enabled)
                    Sw.Write("\t" + tuning.Name);
            Sw.WriteLine();
            foreach (TimeInfo chord in DataModel.Chords)
            {
                if (!QualityModel.QualityWeights.enabled(chord))
                    continue;
                Sw.Write(Math.Round(chord.Time/4.0/DataModel.Timing, 2) + "\t" + 
                         chord.Name + "\t" +
                         Math.Round(chord.Duration/4.0/DataModel.Timing, 2));
                foreach (var tuning in TuningModel.Tunings)
                    if (tuning.enabled)
                        Sw.Write("\t" + tuning.Quality(chord, QualityModel.QualityWeights));
                Sw.WriteLine();
            }
            Sw.Write("POS\tNAME\tDUR");
            foreach (var tuning in TuningModel.Tunings)
                if (tuning.enabled)
                    Sw.Write("\t" + tuning.Name);
            Sw.WriteLine();
            Sw.Write("AVERAGE:\t\t");
            foreach (var tuning in TuningModel.Tunings)
                if (tuning.enabled)
                    Sw.Write("\t" + Math.Round(tuning.AvgQuality(DataModel.Chords, QualityModel.QualityWeights), 1));
        }

        public void Close()
        {
            Sw.Close();
        }
    }
}