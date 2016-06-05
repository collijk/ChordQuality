using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Misc;

namespace ChordQuality.Services
{
    public class AnalysisFileWriter
    {
        private IEventAggregator eventAggregator;
        private SaveFileDialog saveAnalysisDialog;
        private ISubscription<FileUpdatedMessage> midiFileSubscription;
        private ISubscription<TuningsUpdatedMessage> tuningsSubscription;
        private ISubscription<TuningsTransposedMessage> tuningsTransposedSubscription;
        private ISubscription<QualityWeightsUpdatedMessage> qualityWeightsSubscription;
        private ISubscription<PenaltiesChangedMessage> penaltiesSubscription;
        private MidiFile currentFile;
        private TuningScheme[] tunings;
        private int tuningTransposeValue = 0;
        private QualityWeights qualityWeights;
        private String penaltiesValue = "1";

        // Thread safe singleton pattern for MidiToTextWriter construction.
        private static AnalysisFileWriter instance = null;
        private static readonly object padlock = new object();

        public static AnalysisFileWriter Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new AnalysisFileWriter();
                    }
                    return instance;
                }
            }
        }

        
        private AnalysisFileWriter()
        {
            initializeSubscriptions();
            initializeDialog();
        }

        private void initializeDialog()
        {
            saveAnalysisDialog = new SaveFileDialog();
            saveAnalysisDialog.DefaultExt = "txt";
            saveAnalysisDialog.Filter = "TXT-Files|*.txt";
            saveAnalysisDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogFileOk);
        }

        private void SaveFileDialogFileOk(object sender, CancelEventArgs e)
        {
            WriteTracks(currentFile);
            WriteTunings(tunings);
            WriteTuningTranspose(tuningTransposeValue);
            WriteWeights(qualityWeights, penaltiesValue);
            WriteChords(currentFile.FindChords(), currentFile, tunings, qualityWeights);
            Close();
            Shell.Execute(saveAnalysisDialog.FileName);
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;
            });
            tuningsSubscription = eventAggregator.Subscribe<TuningsUpdatedMessage>(Message =>
            {
                tunings = Message.tunings;
            });
            tuningsTransposedSubscription = eventAggregator.Subscribe<TuningsTransposedMessage>(Message =>
            {
                tuningTransposeValue = Message.transposeValue;
            });
            qualityWeightsSubscription = eventAggregator.Subscribe<QualityWeightsUpdatedMessage>(Message =>
            {
                qualityWeights = Message.qualityWeights;
            });
            penaltiesSubscription = eventAggregator.Subscribe<PenaltiesChangedMessage>(Message =>
            {
                penaltiesValue = Message.penalties;
            });
        }

        public void writeAnalysis()
        {
            saveAnalysisDialog.FileName = Path.ChangeExtension(currentFile.name, null);
            saveAnalysisDialog.FileName += "_analysis.txt";
            saveAnalysisDialog.ShowDialog();
        }

        public void WriteTracks(MidiFile f)
        {
            sw.WriteLine("<<< SOURCE FILE >>>");
            sw.WriteLine(f.name);
            sw.WriteLine();
            sw.WriteLine("<<< TRANSPOSE >>>");
            sw.WriteLine(f.transpose);
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
        public void WriteWeights(QualityWeights w, String penalties)
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
            sw.WriteLine("Threshold for Short Notes:\t" + penalties);
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
