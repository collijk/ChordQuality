using System.Windows.Forms;

namespace ChordQuality.services.io
{
    internal class PrintDocumentPrinter
    {
        // Thread safe singleton pattern for PrintDocumentPrinter construction.
        private static PrintDocumentPrinter _instance;
        private static readonly object Padlock = new object();
        private PrintDialog _printDialog;
        private PrintDocumentProvider _printDocProvider;

        private PrintDocumentPrinter()
        {
            InitializeServices();
            InitializeDialog();
        }

        public static PrintDocumentPrinter Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new PrintDocumentPrinter();
                    }
                    return _instance;
                }
            }
        }

        private void InitializeDialog()
        {
            _printDialog = new PrintDialog {AllowSomePages = true};
        }

        private void InitializeServices()
        {
            _printDocProvider = PrintDocumentProvider.Instance;
        }

        public void Print()
        {
            _printDialog.Document = _printDocProvider.GetPrintDoc();
            if (_printDialog.ShowDialog() == DialogResult.OK)
                _printDialog.Document.Print();
        }
    }
}