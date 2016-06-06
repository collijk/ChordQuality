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

    public class BarsPerRowChangedMessage : PrintSettingsMesage
    {
        public int BarsPerRow
        {
            get; set;
        }
    }
}
