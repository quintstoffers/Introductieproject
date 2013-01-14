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
        bool firstPaint = true;
        double drawingScale = 1;
        Parser parser = new Parser();
        double maxXCoord = 0;
        double maxYCoord = 0;
        int zoomlevelX;
        int zoomlevelY;
        bool airportDirty;
        public Point lastPanlocation;
        public Point mouseLocation;
        public Point mapLocation;
        public MapControl()
        {
            InitializeComponent();
            Cursor = Cursors.Hand;
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
                drawAirportToBitmap(airport);
            }
            airplanesDrawThread.Join();

            Graphics graphics = this.CreateGraphics();

            graphics.Clear(Color.DarkBlue);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.DrawImage(bmpAirport, mapLocation.X, mapLocation.Y, zoomlevelX, zoomlevelY);
            graphics.DrawImage(bmpAirplanes, mapLocation.X, mapLocation.Y, zoomlevelX, zoomlevelY);

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
        public void zoom(int zoomLevel)
        {
            zoomlevelX = (int)(bmpAirport.Width * (1 + 0.1225 *zoomLevel));
            zoomlevelY = (int)(bmpAirport.Height * (1 + 0.1225 * zoomLevel));
        }
        public void pan(Point panStart, Point mouseLocation, Airport.Airport airport)
        {
            mapLocation.X = lastPanlocation.X +  (mouseLocation.X - panStart.X);
            mapLocation.Y = lastPanlocation.Y +(mouseLocation.Y - panStart.Y);
            panStart = mouseLocation;
            update(airport);

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
                drawWay(graphics, Color.Red, point1, point2, runway.name);
                
            }
            foreach (Taxiway taxiWay in airport.taxiways)
            {
                int y1 = (int)(taxiWay.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(taxiWay.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(taxiWay.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(taxiWay.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                drawWay(graphics,Color.Gray, point1, point2, taxiWay.name);

            }
            foreach (Gateway gateway in airport.gateways)
            {
                int y1 = (int)(gateway.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(gateway.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(gateway.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(gateway.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                drawWay(graphics,Color.Green, point1, point2);

            }
            foreach (Gate gate in airport.gates)
            {
                int y1 = (int)(gate.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(gate.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(gate.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(gate.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Yellow, 2);
                graphics.DrawLine(pen, point1, point2);

            }
            if (firstPaint)
            {
               zoomlevelX = bmpAirport.Width;
               zoomlevelY = bmpAirport.Height;
               firstPaint = false;
            }
            
            airportDirty = false;
        }
        public void drawWay(Graphics g, Color color, Point start, Point end, String name)
        {
            Pen pen = new Pen(color,7);
            g.DrawLine(pen, start, end);
            Point namePos = new Point();
            namePos.Y = (int)(start.Y + 0.5 * (end.Y - start.Y) - 20);
            if (Math.Min(start.X, end.X) == start.X)
                namePos.X = start.X + 60;
            else
                namePos.X = start.X - 60;
            g.DrawString(name, SystemFonts.DefaultFont, Brushes.White, namePos);

        }
        public void drawWay(Graphics g, Color color, Point start, Point end)
        {
            Pen pen = new Pen(color, 7);
            g.DrawLine(pen, start, end);
            Point namePos = new Point();
            namePos.Y = (int)(start.Y + 0.5 * (end.Y - start.Y) - 20);
            if (Math.Min(start.X, end.X) == start.X)
                namePos.X = start.X + 60;
            else
                namePos.X = start.X - 60;
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

        private void MapControl_Load(object sender, EventArgs e)
        {

        }
        
    }
}
