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
    public partial class MapControl : UserControl
    {
        Airport.Airport airport;

        double drawingScale = 1;

        public MapControl()
        {
            InitializeComponent();
        }

        public void init(Airport.Airport airport)
        {
            this.airport = airport;
        }

        /*
         * Berekent op welke schaal het vliegveld getekend zal worden
         */
        public void calculateScaling()
        {
            double maxXCoord = 0;
            double maxYCoord = 0;

            foreach (Airport.Node currentNode in airport.nodes)
            {
                if (currentNode.location[0] > maxXCoord)
                {
                    maxXCoord = currentNode.location[0];
                }
                if (currentNode.location[1] > maxYCoord)
                {
                    maxYCoord = currentNode.location[0];
                }
            }

            double xScale = this.Width / maxXCoord;
            double yScale = this.Height / maxYCoord;

            drawingScale = Math.Min(xScale, yScale);
        }

        /*
        * Het vaste vliegveld tekenen, bij laden en resizen van het scherm
        */
        public void drawAirport(Graphics graphics)
        {
            calculateScaling();

            graphics.FillRectangle(Brushes.LawnGreen, 0, 0, this.Width, this.Height);

            foreach (Airport.Node currentNode in airport.nodes)
            {
                int drawingLocationX = (int) (currentNode.location[0] * drawingScale);
                int drawingLocationY = (int) (currentNode.location[1] * drawingScale);
                
                graphics.FillEllipse(Brushes.Black, drawingLocationX, drawingLocationY, 5, 5);
            }

            foreach (Airplane currentAirplane in airport.airplanes)
            {
                if (currentAirplane.wasSetup)
                {
                    int drawingLocationX = (int)(currentAirplane.location[0] * drawingScale);
                    int drawingLocationY = (int)(currentAirplane.location[1] * drawingScale);

                    graphics.FillEllipse(Brushes.Red, drawingLocationX, drawingLocationY, 5, 5);
                }
            }
        }

        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            if (airport == null)
            {

            }
            else
            {
                drawAirport(e.Graphics);
            }
        }
    }
}
