using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Introductieproject.UI.Controls
{
    public partial class ZoomControl : UserControl
    {
        public EventHandler zoom;
        public ZoomControl()
        {
            InitializeComponent();
        }
        public int zoomLevel
        {
            get { return trackBar1.Value; }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            zoom(this, e);
        }
    }
}
