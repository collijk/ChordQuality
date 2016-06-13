using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class QualityWeightsControl : UserControl
    {
        private MidiQualityModel _qualityModel;

        public MidiQualityModel QualityModel
        {
            get { return _qualityModel; }
            set
            {
                if (value == _qualityModel)
                    return;

                _qualityModel = value;
                EnableControl();
            }
        }

        public QualityWeightsControl()
        {
            InitializeComponent();
        }

        private void EnableControl()
        {
            sixthMajorIntervalVScroll.Enabled = true;
            sixthMajorIntervalVScroll.DataBindings.Add("Value", QualityModel, "SixthMajorInterval");

            sixthMinorIntervalVScroll.Enabled = true;
            sixthMinorIntervalVScroll.DataBindings.Add("Value", QualityModel, "SixthMinorInterval");

            fifthIntervalVScroll.Enabled = true;
            fifthIntervalVScroll.DataBindings.Add("Value", QualityModel, "FifthInterval");

            fourthIntervalVScroll.Enabled = true;
            fourthIntervalVScroll.DataBindings.Add("Value", QualityModel, "FourthInterval");

            thirdMajorIntervalVScroll.Enabled = true;
            thirdMajorIntervalVScroll.DataBindings.Add("Value", QualityModel, "ThirdMajorInterval");

            thirdMinorIntervalVScroll.Enabled = true;
            thirdMinorIntervalVScroll.DataBindings.Add("Value", QualityModel, "ThirdMinorInterval");

            fifthChordVScroll.Enabled = true;
            fifthChordVScroll.DataBindings.Add("Value", QualityModel, "FifthChord");

            thirdMajorChordVScroll.Enabled = true;
            thirdMajorChordVScroll.DataBindings.Add("Value", QualityModel, "ThirdMajorChord");
        }
    }
}