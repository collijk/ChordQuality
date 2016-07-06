using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class PrintingControl : UserControl
    {
        private MidiDisplayModel _displayModel;
        private int _barsPerRow;
        private int _rowsPerPage;
        private int _barsPerPage;
        private MidiDataModel _dataModel;

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

        public int BarsPerRow
        {
            get { return _barsPerRow; }
            set
            {
                if (value == _barsPerRow)
                    return;

                _barsPerRow = value;
                // Manually update the text since we're bound to an external data source.
                barsPerRowTextBox.Text = _barsPerRow.ToString();

                BarsPerPage = _barsPerRow*_rowsPerPage;
            }
        }

        public int RowsPerPage
        {
            get { return _rowsPerPage; }
            set
            {
                if (value == _rowsPerPage)
                    return;

                _rowsPerPage = value;

                BarsPerPage = _rowsPerPage*_barsPerRow;
            }
        }

        public int BarsPerPage
        {
            get { return _barsPerPage; }
            set
            {
                if (value == _barsPerPage)
                    return;

                _barsPerPage = value;

                var pages = (int)Math.Ceiling((double)_dataModel.TotalBars / _barsPerPage);
                pagesTextBox.Text = pages.ToString();
            }
        }


        public PrintingControl()
        {
            InitializeComponent();
        }

        private void EnableControl()
        {
            if (_displayModel == null)
                return;

            this.DataBindings.Add("BarsPerRow", DisplayModel, "NumberOfBars");
            this.DataBindings.Add("RowsPerPage", rowsPerPageTextBox, "Text");
            relativeThicknessTextBox.DataBindings.Add("Text", DisplayModel, "RelThickness");
        }
    }
}