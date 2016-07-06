using System;
using System.Windows.Forms;
using ChordQuality.model;

namespace ChordQuality.controls
{
    public partial class PenaltiesControl : UserControl
    {
        private MidiQualityModel _qualityModel;
        private MidiDataModel _dataModel;

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

        public MidiDataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                if (value == _dataModel)
                    return;

                _dataModel = value;
                EnableControl();
            }
        }

        public PenaltiesControl()
        {
            InitializeComponent();
        }

        private void EnableControl()
        {
            if(_dataModel == null || _qualityModel == null)
                return;

            thresholdUpDown.Enabled = true;
            var thresholdBinding = new Binding("SelectedIndex", QualityModel, "Threshold");
            thresholdBinding.Format += ThresholdToSelectedIndex;
            thresholdBinding.Parse += SelectedIndexToThreshold;
            thresholdUpDown.DataBindings.Add(thresholdBinding);

            penaltyAddVScroll.Enabled = true;
            var addBinding = new Binding("Value", QualityModel, "Add");
            addBinding.Format += AddShortToVScrollValue;
            addBinding.Parse += VScrollValueToAddShort;
            penaltyAddVScroll.DataBindings.Add(addBinding);
            
            penaltyShortVScroll.Enabled = true;
            var shortBinding = new Binding("Value", QualityModel, "Short");
            shortBinding.Format += AddShortToVScrollValue;
            shortBinding.Parse += VScrollValueToAddShort;
            penaltyAddVScroll.DataBindings.Add(shortBinding);
        }

        private void ThresholdToSelectedIndex(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(int))
                return;
            e.Value = (int) Math.Log(4*_dataModel.Timing/((double) e.Value));
        }

        private void SelectedIndexToThreshold(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(double))
                return;
            e.Value = (double) 4*_dataModel.Timing/Math.Pow(2.0, (int) e.Value);
        }

        private void AddShortToVScrollValue(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(int))
                return;
            e.Value = (int) -10*((double) e.Value) + 10;
        }

        private void VScrollValueToAddShort(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(double))
                return;
            e.Value = (double) (10 - (int) e.Value)/10.0;
        }
    }
}