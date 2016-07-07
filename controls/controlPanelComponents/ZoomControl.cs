using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;

namespace ChordQuality.controls
{
    public partial class ZoomControl : UserControl
    {
        private MidiPlaybackModel _playbackModel;
        private MidiDisplayModel _displayModel;

        public MidiPlaybackModel PlaybackModel
        {
            get { return _playbackModel; }
            set
            {
                if (value == _playbackModel)
                    return;

                _playbackModel = value;
                EnableControls();
            }
        }

        public MidiDisplayModel DisplayModel
        {
            get { return _displayModel; }
            set
            {
                if (value == _displayModel)
                    return;

                _displayModel = value;
                EnableControls();
            }
        }


        public ZoomControl()
        {
            InitializeComponent();
        }

        private void EnableControls()
        {
            if (_playbackModel == null || _displayModel == null)
                return;

            zoomTrackBar.DataBindings.Add("Value", DisplayModel, "NumberOfBars");
            zoomTrackBar.Enabled = true;
        }

        
    }
}