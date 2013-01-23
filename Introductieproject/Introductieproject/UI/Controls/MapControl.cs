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
        Bitmap bmpAirplanes;
        Bitmap bmpAirport;

        Airport.Airport airport;

        Parser parser = new Parser();
        double drawingScale = 1;
        double maxXCoord = 0;
        double maxYCoord = 0;
        int maxScreenPixels = 0;

        int zoomlevelX;
        int zoomlevelY;

        public static bool airportDirty;
        public static bool airplanesDirty = false;
        bool firstPaint = true;

        public Point lastPanLocation;
        public Point mouseLocation;
        public Point mapLocation;

        public static bool alwaysShowFlight = false;
        public static bool showLabels = true;
        public static bool showEfficiency = true;
        public static bool showRunways = true;
        public static bool showTaxiways = true;
        public static bool showGateways = true;
        public static bool showGates = true;

        public MapControl()
        {
            InitializeComponent();

            Cursor = Cursors.Hand;

            MouseDown += new MouseEventHandler(MapControlClick);
            MouseMove += new MouseEventHandler(MapControlMouseMove);
            MouseUp += new MouseEventHandler(MapControlMouseUp);

            this.Paint += MapControl_Paint;
            this.DoubleBuffered = true;

            zoomControl1.zoom += new EventHandler(zoomEvent);
        }

        public void init(Airport.Airport airport)
        {
            this.airport = airport;

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
            this.lastPanLocation = this.mapLocation;
        }

        public void update()
        {
            draw(airport);
            this.Invalidate();
        }
                
        void MapControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.DarkGray);
            if (bmpAirport != null)
            {
                e.Graphics.DrawImage(bmpAirport, mapLocation.X, mapLocation.Y, zoomlevelX, zoomlevelY);
            }
            if (bmpAirplanes != null)
            {
                e.Graphics.DrawImage(bmpAirplanes, mapLocation.X, mapLocation.Y, zoomlevelX, zoomlevelY);
            }
        }
        
        public void draw(Airport.Airport airport)
        {
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

            double xScale = (this.Width - zoomControl1.Width) / (maxXCoord * 2);
            double yScale = this.Height / (maxYCoord * 2);

            maxScreenPixels = Math.Min(this.Width - zoomControl1.Width, this.Height) + 100;

            drawingScale = Math.Min(xScale, yScale) * 2;
        }

        public void zoom(int zoomLevel)
        {
            zoomlevelX = (int)(bmpAirport.Width * (1 + 0.1225 *zoomLevel));
            zoomlevelY = (int)(bmpAirport.Height * (1 + 0.1225 * zoomLevel));

            update();
        }

        public void pan(Point panStart, Point mouseLocation)
        {
            mapLocation.X = lastPanLocation.X +  (mouseLocation.X - panStart.X);
            mapLocation.Y = lastPanLocation.Y +(mouseLocation.Y - panStart.Y);
            panStart = mouseLocation;
            this.Invalidate();
        }

        private void drawAirportToBitmap(Airport.Airport airport)
        {
            calculateScaling(airport);

            Graphics graphics = null;
            if (bmpAirport == null || bmpAirport.Size.Width != maxScreenPixels)
            {
                bmpAirport = new Bitmap(maxScreenPixels, maxScreenPixels);
                graphics = Graphics.FromImage(bmpAirport);
            }
            else
            {
                graphics = Graphics.FromImage(bmpAirport);
            }
            graphics.Clear(Color.DarkGray);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (Way way in airport.ways)
            {
                if (way is Runway && showRunways)
                {
                    drawWay(graphics, Color.Red, way);
                }
                else if(way is Taxiway && showTaxiways)
                {
                    drawWay(graphics, Color.Black, way);
                }
                else if (way is Gateway && showGateways)
                {
                    drawWay(graphics, Color.Green, way);
                }
                else if (way is Gate && showGates)
                {
                    drawGate(graphics, Color.Gray, (Gate) way, way.name);
                }
            }
            if (firstPaint)
            {
               zoomlevelX = bmpAirport.Width;
               zoomlevelY = bmpAirport.Height;
               mapLocation = new Point(-50, this.Height / 4);
               lastPanLocation = new Point(-50, this.Height / 4) ;
               firstPaint = false;
            }
            airportDirty = false;
        }

        public void drawWay(Graphics g, Color color, Way way)
        {
            int x1 = (int)(way.nodeConnections[0].location[0] * drawingScale + 10);
            int y1 = (int)(way.nodeConnections[0].location[1] * drawingScale + 10);
            int y2 = (int)(way.nodeConnections[1].location[1] * drawingScale + 10);
            int x2 = (int)(way.nodeConnections[1].location[0] * drawingScale + 10);

            if (showLabels && !(way is Gateway))
            {
                int textYPos;
                int textXPos;
                int minY = Math.Min(y1, y2);
                int maxY = Math.Max(y1, y2);
                if (y1 >= y2)
                {
                    textYPos = (int)(y1 + 0.5 * (y2 - y1));
                    textXPos = (int)(x1 + 0.5 * (x2 - x1) + 3);
                }
                else
                {
                    textYPos = (int)(y1 + 0.5 * (y2 - y1));
                    textXPos = (int)(x1 + 0.5 * (x2 - x1) + 12);
                }
                g.DrawString(way.name, SystemFonts.DefaultFont, Brushes.Black, textXPos, textYPos);
            }

            Pen pen = new Pen(color, 2);
            g.DrawLine(pen, x1, y1, x2, y2);
            if(!(way is Gateway))
            {
                g.FillEllipse(Brushes.Black, x1 - 5, y1- 5, 10, 10);
                g.FillEllipse(Brushes.Black, x2 - 5, y2 - 5, 10, 10);
            }
        }
        public void drawGate(Graphics g, Color color, Gate gate, String name)
        {
            Pen pen = new Pen(color, 2);

            int x1 = (int)(gate.nodeConnections[0].location[0] * drawingScale + 10);
            int y1 = (int)(gate.nodeConnections[0].location[1] * drawingScale + 10);
            int y2 = (int)(gate.nodeConnections[1].location[1] * drawingScale + 10);
            int x2 = (int)(gate.nodeConnections[1].location[0] * drawingScale + 10);

            g.DrawLine(pen, x1, y1, x2, y2);

            if (showLabels)
            {
                int textWidth = (int)g.MeasureString(gate.name, SystemFonts.DefaultFont).Width;
                if (y1 > y2)
                {
                    g.DrawString(name, SystemFonts.DefaultFont, Brushes.Black, x1 - textWidth / 2, y2 - 15);
                }
                else
                {
                    g.DrawString(name, SystemFonts.DefaultFont, Brushes.Black, x1 - textWidth / 2, y1 + 15);
                }
            }

            g.FillEllipse(Brushes.Gray, x1 - 3, y1 - 3, 6, 6);
        }

        private void drawAirplanesToBitmap(Airport.Airport airport)
        {
            calculateScaling(airport);
            Graphics graphics = null;
            if (bmpAirplanes == null || bmpAirplanes.Size.Width != maxScreenPixels)
            {
                bmpAirplanes = new Bitmap(maxScreenPixels, maxScreenPixels);
                graphics = Graphics.FromImage(bmpAirplanes);
            }
            else
            {
                graphics = Graphics.FromImage(bmpAirplanes);
                graphics.Clear(Color.Transparent);
            }

            for (int i = 0; i < airport.airplanes.Count; i++ )
            {
                Airplane currentAirplane = airport.airplanes[i];
                if (currentAirplane.isOnAirport())
                {
                    int drawingLocationX = (int)(currentAirplane.location[0] * drawingScale + 10);
                    int drawingLocationY = (int)(currentAirplane.location[1] * drawingScale + 10);

                    if (i == AirplaneStatsControl.currentSelectedRow)
                    {
                        graphics.FillEllipse(Brushes.LightBlue, drawingLocationX - 3, drawingLocationY - 3, 6, 6);
                        graphics.DrawString(currentAirplane.flight, SystemFonts.DefaultFont, Brushes.Black, drawingLocationX + 2, drawingLocationY - 14);
                    }
                    else
                    {
                        graphics.FillEllipse(Brushes.White, drawingLocationX - 3, drawingLocationY - 3, 6, 6);
                        if (alwaysShowFlight)
                        {
                            graphics.DrawString(currentAirplane.flight, SystemFonts.DefaultFont, Brushes.Black, drawingLocationX + 2, drawingLocationY - 14);
                        }
                    }
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

        private void zoomEvent(object sender, EventArgs e)
        {
            this.zoom(zoomControl1.zoomLevel);
        }
    }
}
