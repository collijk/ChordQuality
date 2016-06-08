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
                    return _instance ?? (_instance = new PrintDocumentPrinter());
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