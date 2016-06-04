using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.events.messages
{
    public class PrintSettingsMesage : IMessage
    {
    }

    public class RelThicknessChangedMessage : PrintSettingsMesage
    {
        public float relThickness
        {
            get; set;
        }

    }

    public class RowsPerPageChangedMessage : PrintSettingsMesage
    {
        public int RowsPerPage
        {
            get; set;
        }
    }
}
