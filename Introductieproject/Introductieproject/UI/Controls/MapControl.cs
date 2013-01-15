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
using System.Diagnostics;

namespace Introductieproject.UI.Controls
{
    public partial class MapControl : UserControl
    {
        object drawingLock = new Object();

        Bitmap bmpAirplanes;
        Bitmap bmpAirport;

        Parser parser = new Parser();
        double drawingScale = 1;
        double maxXCoord = 0;
        double maxYCoord = 0;

        int zoomlevelX;
        int zoomlevelY;

        public bool airportDirty;
        public bool airplanesDirty = false;
        bool firstPaint = true;

        public Point lastPanlocation;
        public Point mouseLocation;
        public Point mapLocation;

        public MapControl()
        {
            InitializeComponent();

            Cursor = Cursors.Hand;

            MouseDown += new MouseEventHandler(MapControlClick);
            MouseMove += new MouseEventHandler(MapControlMouseMove);
            MouseUp += new MouseEventHandler(MapControlMouseUp);
        }

        public void init(Airport.Airport airport)
        {
            airportDirty = true;
            airplanesDirty = true;
        }

        private void MapControlClick(object sender, MouseEventArgs e)
        {
            this.mouseLocation = e.Location;
        }
        private void MapControlMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pan(this.mouseLocation, e.Location);
            }
        }
        private void MapControlMouseUp(object sender, MouseEventArgs e)
        {
            this.lastPanlocation = this.mapLocation;
        }

        public void update(Airport.Airport airport)
        {
            Thread drawThread = new Thread(() => draw(this.CreateGraphics(), airport));
            drawThread.Priority = ThreadPriority.BelowNormal;
            drawThread.Start();
        }

        bool isDrawing;
        public void draw(Graphics graphics, Airport.Airport airport)
        {
            if (isDrawing)
            {
                return;
            }
            else isDrawing = true;

            if (airportDirty)
            {
                Thread airplanesDrawThread = new Thread(() => drawAirplanesToBitmap(airport));
                airplanesDrawThread.Start();

                drawAirportToBitmap(airport);

                airplanesDrawThread.Join();
            }
            else if(airplanesDirty)
            {
                drawAirplanesToBitmap(airport);
            }

            drawBitmaps(graphics);

            isDrawing = false;
        }
        public void drawBitmaps(Graphics graphics)
        {
            lock (drawingLock)
            {
                graphics.Clear(Color.DarkBlue);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.DrawImage(bmpAirport, mapLocation.X, mapLocation.Y, zoomlevelX, zoomlevelY);
                graphics.DrawImage(bmpAirplanes, mapLocation.X, mapLocation.Y, zoomlevelX, zoomlevelY);
            }
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

            double xScale = this.Width / (maxXCoord * 2);
            double yScale = this.Height / (maxYCoord * 2);

            drawingScale = Math.Min(xScale, yScale);
        }

        public void zoom(int zoomLevel)
        {
            zoomlevelX = (int)(bmpAirport.Width * (1 + 0.1225 *zoomLevel));
            zoomlevelY = (int)(bmpAirport.Height * (1 + 0.1225 * zoomLevel));
        }

        public void pan(Point panStart, Point mouseLocation)
        {
            mapLocation.X = lastPanlocation.X +  (mouseLocation.X - panStart.X);
            mapLocation.Y = lastPanlocation.Y +(mouseLocation.Y - panStart.Y);
            panStart = mouseLocation;
            drawBitmaps(this.CreateGraphics());
        }

        private void drawAirportToBitmap(Airport.Airport airport)
        {
            calculateScaling(airport);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bmpAirport = new Bitmap((int)maxXCoord, (int)maxYCoord);

            Graphics graphics = Graphics.FromImage(bmpAirport);
            graphics.Clear(Color.DarkBlue);

            foreach (Way way in airport.ways)
            {
                if (way is Runway)
                {
                    int y1 = (int)(way.nodeConnections[0].location[1] * drawingScale);
                    int y2 = (int)(way.nodeConnections[1].location[1] * drawingScale);
                    int x1 = (int)(way.nodeConnections[0].location[0] * drawingScale);
                    int x2 = (int)(way.nodeConnections[1].location[0] * drawingScale);
                    Point point1 = new Point(x1, y1);
                    Point point2 = new Point(x2, y2);
                    drawWay(graphics, Color.Red, point1, point2, way.name);
                }
                else if(way is Taxiway)
                {
                    int y1 = (int)(way.nodeConnections[0].location[1] * drawingScale);
                    int y2 = (int)(way.nodeConnections[1].location[1] * drawingScale);
                    int x1 = (int)(way.nodeConnections[0].location[0] * drawingScale);
                    int x2 = (int)(way.nodeConnections[1].location[0] * drawingScale);
                    Point point1 = new Point(x1, y1);
                    Point point2 = new Point(x2, y2);
                    drawWay(graphics, Color.Gray, point1, point2, way.name);
                }
                else if (way is Gateway)
                {
                    int y1 = (int)(way.nodeConnections[0].location[1] * drawingScale);
                    int y2 = (int)(way.nodeConnections[1].location[1] * drawingScale);
                    int x1 = (int)(way.nodeConnections[0].location[0] * drawingScale);
                    int x2 = (int)(way.nodeConnections[1].location[0] * drawingScale);
                    Point point1 = new Point(x1, y1);
                    Point point2 = new Point(x2, y2);
                    Pen pen = new Pen(Color.Green, 7);
                    graphics.DrawLine(pen, point1, point2);
                }
                else if (way is Gate)
                {
                    int y1 = (int)(way.nodeConnections[0].location[1] * drawingScale);
                    int y2 = (int)(way.nodeConnections[1].location[1] * drawingScale);
                    int x1 = (int)(way.nodeConnections[0].location[0] * drawingScale);
                    int x2 = (int)(way.nodeConnections[1].location[0] * drawingScale);
                    Point point1 = new Point(x1, y1);
                    Point point2 = new Point(x2, y2);
                    Pen pen = new Pen(Color.Yellow, 2);
                    drawGate(graphics, Color.Gray, point1, point2, way.name);
                }
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
            namePos.Y = (int)(start.Y + 0.5 * (end.Y - start.Y) - 10);
            if (Math.Min(start.X, end.X) == start.X)
                namePos.X = start.X + 10;
            else
                namePos.X = start.X - 10;
            g.DrawString(name, SystemFonts.DefaultFont, Brushes.White, namePos);
        }

        public void drawGate(Graphics g, Color color, Point start, Point end, String name)
        {
            Pen pen = new Pen(color, 2);
            g.DrawLine(pen, start, end);
            Point namePos = new Point();
            if (start.Y >= end.Y)
            {
                namePos.Y = end.Y - 10;
            }
            else
            {
                namePos.Y = start.Y + 20;
            }
            namePos.X = start.X;
            g.DrawString(name, SystemFonts.DefaultFont, Brushes.White, namePos);
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
            airplanesDirty = false;
        }

        private void MapControl_SizeChanged(object sender, EventArgs e)
        {
            airportDirty = true;
            airplanesDirty = true;
        }

        private void MapControl_Load(object sender, EventArgs e)
        {

        }
        
    }
}
