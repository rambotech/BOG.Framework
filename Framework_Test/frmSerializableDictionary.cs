using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
    public partial class frmSerializableDictionary : Form
    {
        SerializableDictionary<string, Fuse> fuses = new SerializableDictionary<string, Fuse>();
        public frmSerializableDictionary()
        {
            InitializeComponent();
            fuses.Add("porch light", new Fuse(
                Fuse.FuseBehavior.Hits_Only, 5, 0, new TimeSpan(0, 0, 60, 0), false));
            fuses.Add("refrigerator", new Fuse(
                Fuse.FuseBehavior.Volume_Only, 0, 10000, new TimeSpan(0, 0, 60, 0), false));
            fuses.Add("tv", new Fuse(
                Fuse.FuseBehavior.Hits_OR_Volume, 2, 100, new TimeSpan(0, 2, 0, 0), false));
            fuses["tv"].RecordFuseEvent(65);
            fuses["tv"].RecordFuseEvent(44);
            fuses["tv"].RecordFuseEvent(17);

            this.txtSerializedXML.Text =
                ObjectXMLSerializer<SerializableDictionary<string, Fuse>>
                .CreateDocumentFormat(fuses);
        }
    }
}
