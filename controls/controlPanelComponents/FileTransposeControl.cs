using System.Windows.Forms;
using ChordQuality.model;

namespace ChordQuality.controls
{
    public partial class FileTransposeControl : UserControl
    {
        private MidiDataModel _dataModel;
        private MidiDisplayModel _displayModel;

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

        public MidiDisplayModel DisplayModel
        {
            get { return _displayModel; }
            set
            {
                if (value == _displayModel)
                    return;

                _displayModel = value;
                EnableControl();
            }
        }

        public FileTransposeControl()
        {
            InitializeComponent();
        }

        private void EnableControl()
        {
            if (_displayModel == null || _dataModel == null)
                return;

            fileTransposeUpDown.Maximum = 127 - _dataModel.MaxNote;
            fileTransposeUpDown.Minimum = 0 - _dataModel.MinNote;
            fileTransposeUpDown.DataBindings.Add("Value", DataModel, "Transpose");
            fileTransposeUpDown.Enabled = true;

            var offsetBinding = new Binding("Text", DisplayModel, "FirstBar");
            offsetBinding.Format += BarToOffsetLabel;
            offsetLabel.DataBindings.Add(offsetBinding);
        }

        private static void BarToOffsetLabel(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(string))
                return;

            e.Value = ((int) e.Value - 1) + " Bars";

        }
    }
}