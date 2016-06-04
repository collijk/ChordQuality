using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordQuality.services
{
    class PrintPreviewProvider
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileOpenedMessage> midiFileSubscription;
        private ISubscription<ZoomScrollChangedMessage> zoomValueSubscription;
        private ISubscription<TrackDisplayChangedMessage> trackDisplaySubscription;
        private ISubscription<RelThicknessChangedMessage> relThicknessSubscription;
        private ISubscription<RowsPerPageChangedMessage> rowsPerPageSubscription;
        private MidiFile currentFile;
        private PrintDocumentProvider printDocProvider;
        private int zoomScrollValue = 0;
        private int RowsPerPage = 5;
        private float relThickness = 0.5f;
        private TrackDisplay trackDisplay = null;

        // Thread safe singleton pattern for PrintPreviewProvider construction.
        private static PrintPreviewProvider instance = null;
        private static readonly object padlock = new object();        

        public static PrintPreviewProvider Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new PrintPreviewProvider();
                    }
                    return instance;
                }
            }
        }

        private PrintPreviewProvider()
        {
            initializeSubscriptions();
            initializeServices();        
        }

        private void initializeServices()
        {
            printDocProvider = PrintDocumentProvider.Instance;
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                currentFile = Message.file;
            });
            zoomValueSubscription = eventAggregator.Subscribe<ZoomScrollChangedMessage>(Message =>
            {
                zoomScrollValue = Message.zoomValue;
            });
            trackDisplaySubscription = eventAggregator.Subscribe<TrackDisplayChangedMessage>(Message =>
            {
                trackDisplay = Message.trackDisplay;
            });
            relThicknessSubscription = eventAggregator.Subscribe<RelThicknessChangedMessage>(Message =>
            {
                relThickness = Message.relThickness;
            });
            rowsPerPageSubscription = eventAggregator.Subscribe<RowsPerPageChangedMessage>(Message =>
            {
                RowsPerPage = Message.RowsPerPage;
            });
        }

        public void showPreview()
        {
            PrintDocument printDoc = printDocProvider.getPrintDoc();
            PrintPreviewForm ppf = new PrintPreviewForm(RowsPerPage, printDoc.DefaultPageSettings.PrinterSettings.ToPage, 
                zoomScrollValue, currentFile.name, currentFile, trackDisplay, relThickness, printDoc);
            ppf.Show();           
        }
    }
}
