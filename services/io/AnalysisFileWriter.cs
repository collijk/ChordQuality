using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using Janus.Misc;

namespace ChordQuality.services.io
{
    public class AnalysisFileWriter
    {
        // Thread safe singleton pattern for MidiToTextWriter construction.
        private static AnalysisFileWriter _instance;
        private static readonly object Padlock = new object();
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;
        private ISubscription<PenaltiesChangedMessage> _penaltiesSubscription;
        private string _penaltiesValue = "1";
        private QualityWeights _qualityWeights;
        private ISubscription<QualityWeightsUpdatedMessage> _qualityWeightsSubscription;
        private SaveFileDialog _saveAnalysisDialog;
        protected StreamWriter Sw;
        private TuningScheme[] _tunings;
        private ISubscription<TuningsUpdatedMessage> _tuningsSubscription;
        private ISubscription<TuningsTransposedMessage> _tuningsTransposedSubscription;
        private int _tuningTransposeValue;


        private AnalysisFileWriter()
        {
            InitializeSubscriptions();
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
            WriteTracks(_currentFile);
            WriteTunings(_tunings);
            WriteTuningTranspose(_tuningTransposeValue);
            WriteWeights(_qualityWeights, _penaltiesValue);
            WriteChords(_currentFile.FindChords(), _currentFile, _tunings, _qualityWeights);
            Close();
            Shell.Execute(_saveAnalysisDialog.FileName);
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
            _tuningsSubscription =
                _eventAggregator.Subscribe<TuningsUpdatedMessage>(message => { _tunings = message.Tunings; });
            _tuningsTransposedSubscription =
                _eventAggregator.Subscribe<TuningsTransposedMessage>(
                    message => { _tuningTransposeValue = message.TransposeValue; });
            _qualityWeightsSubscription =
                _eventAggregator.Subscribe<QualityWeightsUpdatedMessage>(
                    message => { _qualityWeights = message.QualityWeights; });
            _penaltiesSubscription =
                _eventAggregator.Subscribe<PenaltiesChangedMessage>(message => { _penaltiesValue = message.Penalties; });
        }

        public void WriteAnalysis()
        {
            _saveAnalysisDialog.FileName = Path.ChangeExtension(_currentFile.name, null);
            _saveAnalysisDialog.FileName += "_analysis.txt";
            _saveAnalysisDialog.ShowDialog();
        }

        public void WriteTracks(MidiFile f)
        {
            Sw.WriteLine("<<< SOURCE FILE >>>");
            Sw.WriteLine(f.name);
            Sw.WriteLine();
            Sw.WriteLine("<<< TRANSPOSE >>>");
            Sw.WriteLine(f.transpose);
            Sw.WriteLine();
            Sw.WriteLine("<<< TRACKS >>>");
            for (var i = 0; i < f.tracks.Length; i++)
            {
                Sw.Write("[");
                Sw.Write(f.tracks[i].enabled ? "X" : " ");
                Sw.WriteLine("] #" + (i + 1) + ": " + f.tracks[i].name);
            }
            Sw.WriteLine();
        }

        public void WriteTunings(TuningScheme[] tun)
        {
            Sw.WriteLine("<<< TUNINGS >>>");
            foreach (TuningScheme t in tun)
            {
                if (t.enabled)
                    Sw.WriteLine(t.ToString());
            }
            Sw.WriteLine();
        }

        public void WriteTuningTranspose(int t)
        {
            Sw.WriteLine("<<< TUNING TRANSPOSE >>>");
            Sw.WriteLine(t);
            Sw.WriteLine();
        }

        public void WriteWeights(QualityWeights w, string penalties)
        {
            Sw.WriteLine("<<< QUALITY WEIGHTS >>>");
            Sw.WriteLine("INTERVALS:");
            Sw.WriteLine("6M:\t" + w.M6);
            Sw.WriteLine("6m:\t" + w.m6);
            Sw.WriteLine("5:\t" + w.fifth);
            Sw.WriteLine("4:\t" + w.fourth);
            Sw.WriteLine("3M:\t" + w.M3);
            Sw.WriteLine("3m:\t" + w.m3);
            Sw.WriteLine("CHORDS:");
            Sw.WriteLine("5:\t" + w.Ch5);
            Sw.WriteLine("3M:\t" + w.Ch3);
            Sw.WriteLine();
            Sw.WriteLine("<<< PENALTIES >>>");
            Sw.WriteLine("Additional Notes:\t" + w.Add);
            Sw.WriteLine("Short Notes:\t" + w.Short);
            Sw.WriteLine("Threshold for Short Notes:\t" + penalties);
            Sw.WriteLine();
        }

        public void WriteChords(ArrayList chords, MidiFile f, TuningScheme[] t, QualityWeights w)
        {
            Sw.WriteLine();
            Sw.WriteLine("<<< CHORDS & INTERVALS >>>");
            Sw.WriteLine();
            Sw.Write("POS\tNAME\tDUR");
            foreach (TuningScheme t1 in t)
                if (t1.enabled)
                    Sw.Write("\t" + t1.Name);
            Sw.WriteLine();
            foreach (TimeInfo c in chords)
            {
                if (!w.enabled(c))
                    continue;
                Sw.Write(Math.Round(c.Time/4.0/f.timing, 2) + "\t" + c.Name + "\t" +
                         Math.Round(c.Duration/4.0/f.timing, 2));
                foreach (TuningScheme t1 in t)
                    if (t1.enabled)
                        Sw.Write("\t" + t1.Quality(c, w));
                Sw.WriteLine();
            }
            Sw.Write("POS\tNAME\tDUR");
            foreach (TuningScheme t1 in t)
                if (t1.enabled)
                    Sw.Write("\t" + t1.Name);
            Sw.WriteLine();
            Sw.Write("AVERAGE:\t\t");
            foreach (TuningScheme t1 in t)
                if (t1.enabled)
                    Sw.Write("\t" + Math.Round(t1.AvgQuality(chords, w), 1));
        }

        public void Close()
        {
            Sw.Close();
        }
    }
}