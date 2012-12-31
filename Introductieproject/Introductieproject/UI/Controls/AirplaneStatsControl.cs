using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Objects;

namespace Introductieproject.UI.Controls
{
    public partial class AirplaneStatsControl : UserControl
    {
        public AirplaneStatsControl()
        {
            InitializeComponent(); 
        }

        public void setDataBinding(BindingList<Airplane> airplanes)
        {
            dataGrid.DataSource = airplanes;
        }
    }
}
