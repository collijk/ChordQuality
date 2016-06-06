using System.Windows.Forms;

namespace ChordQuality.services.io
{
    class PrintDocumentPrinter
    {
        private PrintDialog printDialog;
        private PrintDocumentProvider printDocProvider;

        // Thread safe singleton pattern for PrintDocumentPrinter construction.
        private static PrintDocumentPrinter instance = null;
        private static readonly object padlock = new object();

        public static PrintDocumentPrinter Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new PrintDocumentPrinter();
                    }
                    return instance;
                }
            }
        }

        private PrintDocumentPrinter()
        {
            initializeServices();
            initializeDialog();
        }

        private void initializeDialog()
        {
            printDialog = new PrintDialog();
            printDialog.AllowSomePages = true;
        }

        private void initializeServices()
        {
            printDocProvider = PrintDocumentProvider.Instance;
        }

        public void print()
        {
            printDialog.Document = printDocProvider.getPrintDoc();
            if(printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }
    }
}
