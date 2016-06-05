using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChordQuality.controls
{
    public partial class TrackControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;

        private MidiFile currentFile;
        private CheckBox[] trackChecks;
        Color[] trackColors = new Color[19] {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black };
        private ColorDialog colorDialog;
        

        public TrackControl()
        {
            InitializeComponent();
            initializeSubscriptions();
            initializeDialog();
        }

        private void initializeDialog()
        {
            this.colorDialog = new ColorDialog();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            fileUpdatedSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;
                onFileUpdated();
            });
        }

        private void onFileUpdated()
        {
            trackPanel.Controls.Clear();
            trackChecks = new CheckBox[currentFile.tracks.Length];
            for(int n = 0; n < currentFile.tracks.Length; n++)
            {
                trackChecks[n] = new CheckBox();
                trackChecks[n].Location = new Point(4, 4 + n * 16);
                trackChecks[n].Size = new Size(192, 16);
                trackChecks[n].ForeColor = trackColors[n];
                trackChecks[n].Text = "#" + (n + 1).ToString() + ": " + currentFile.tracks[n].name;
                trackChecks[n].Checked = true;
                trackChecks[n].CheckedChanged += new System.EventHandler(TrackCheckedChanged);
                trackChecks[n].ContextMenuStrip = colorContextMenu;
                trackPanel.Controls.Add(trackChecks[n]);
            }
        }

        void TrackCheckedChanged(object sender, EventArgs e)
        {
            if(currentFile != null)
            {
                for(int i = 0; i < currentFile.tracks.Length; i++)
                    currentFile.tracks[i].enabled = trackChecks[i].Checked;

                eventAggregator.Publish(new TracksChangedMessage());                
            }
        }

        

        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < currentFile.tracks.Length; i++)
            {
                if(colorContextMenu.SourceControl == trackChecks[i])
                {
                    colorDialog.Color = trackColors[i];
                }
            }              
                    
            colorDialog.ShowDialog();

            for(int i = 0; i < currentFile.tracks.Length; i++)
            {
                if(colorContextMenu.SourceControl == trackChecks[i])
                {
                    trackColors[i] = colorDialog.Color;
                    trackChecks[i].ForeColor = colorDialog.Color;
                }
            }
            eventAggregator.Publish(new TrackColorChangedMessage());
        }
    }
}
