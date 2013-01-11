using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Objects;
using Introductieproject.Simulation;
using Introductieproject.Airport;
using System.Threading;

namespace Introductieproject.UI.Controls
{
    public partial class MapControl : UserControl
    {
        Bitmap bmpAirplanes;
        Bitmap bmpAirport;

        double drawingScale = 1;
        Parser parser = new Parser();
        double maxXCoord = 0;
        double maxYCoord = 0;

        bool airportDirty;

        public MapControl()
        {
            InitializeComponent();
        }

        public void init(Airport.Airport airport)
        {
            airportDirty = true;
        }

        public void update(Airport.Airport airport)
        {
            Thread airplanesDrawThread = new Thread(() => drawAirplanesToBitmap(airport));
            airplanesDrawThread.Start();
            if (airportDirty)
            {
                Thread airportDrawThread = new Thread(() => drawAirportToBitmap(airport));
                airportDrawThread.Start();
                airportDrawThread.Join();
            }
            airplanesDrawThread.Join();

            Graphics graphics = this.CreateGraphics();

            graphics.Clear(Color.Black);
            graphics.DrawImage(bmpAirport, 0, 0, bmpAirport.Width, bmpAirport.Height);
            graphics.DrawImage(bmpAirplanes, 0, 0, bmpAirplanes.Width, bmpAirplanes.Height);
        }

        /*
         * Berekent op welke schaal het vliegveld getekend zal worden
         */
        public void calculateScaling(Airport.Airport airport)
        {
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

        private void drawAirportToBitmap(Airport.Airport airport)
        {
            calculateScaling(airport);

            bmpAirport = new Bitmap((int)maxXCoord, (int)maxYCoord);
            Graphics graphics = Graphics.FromImage(bmpAirport);

            graphics.Clear(Color.Transparent);

            foreach (Runway runway in airport.runways)
            {
                int y1 = (int)(runway.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(runway.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(runway.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(runway.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawLine(pen, point1, point2);
            }
            foreach (Taxiway taxiWay in airport.taxiways)
            {
                int y1 = (int)(taxiWay.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(taxiWay.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(taxiWay.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(taxiWay.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Blue, 5);
                graphics.DrawLine(pen, point1, point2);

            }
            foreach (Gateway gateway in airport.gateways)
            {
                int y1 = (int)(gateway.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(gateway.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(gateway.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(gateway.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Green, 5);
                graphics.DrawLine(pen, point1, point2);

            }
            foreach (Gate gate in airport.gates)
            {
                int y1 = (int)(gate.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(gate.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(gate.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(gate.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Yellow, 5);
                graphics.DrawLine(pen, point1, point2);

            }

            airportDirty = false;
        }
        private void drawAirplanesToBitmap(Airport.Airport airport)
        {
            calculateScaling(airport);

            bmpAirplanes = new Bitmap((int)maxXCoord, (int)maxYCoord);
            Graphics graphics = Graphics.FromImage(bmpAirplanes);

            graphics.Clear(Color.Transparent);

            foreach (Airplane currentAirplane in airport.airplanes)
            {
                if (currentAirplane.status != Airplane.Status.APPROACHING && currentAirplane.status != Airplane.Status.DEPARTED)
                {
                    int drawingLocationX = (int)(currentAirplane.location[0] * drawingScale);
                    int drawingLocationY = (int)(currentAirplane.location[1] * drawingScale);

                    graphics.FillEllipse(Brushes.White, drawingLocationX-2, drawingLocationY-2, 5, 5);
                }
            }
        }

        private void MapControl_SizeChanged(object sender, EventArgs e)
        {
            airportDirty = true;
        }
    }
}
