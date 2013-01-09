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

namespace Introductieproject.UI.Controls
{
    public partial class MapControl : UserControl
    {
        Airport.Airport airport;

        double drawingScale = 1;
        Parser parser = new Parser();
        double maxXCoord = 0;
        double maxYCoord = 0;

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
        private void drawWays(Graphics g)
        {
            calculateScaling();
            List<Taxiway> taxiWayList = new List<Taxiway>();
            List<Runway> runWayList = new List<Runway>();
            List<Gateway> gateWayList = new List<Gateway>();
            List<Gate> gateList = new List<Gate>();
            List<Node> nodeList = new List<Node>();
            parser.getWays(nodeList, runWayList, taxiWayList, gateWayList, gateList);
            Bitmap bmp = new Bitmap((int)maxXCoord, (int)maxYCoord);
            Graphics bMap = Graphics.FromImage(bmp);
            foreach (Runway runway in runWayList)
            {
                int y1 = (int)(runway.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(runway.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(runway.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(runway.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Red, 5);
                bMap.DrawLine(pen, point1, point2);
            }
             foreach (Taxiway taxiWay in taxiWayList)
            {
                int y1 = (int)(taxiWay.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(taxiWay.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(taxiWay.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(taxiWay.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Blue, 5);
                bMap.DrawLine(pen, point1, point2);

        }
             foreach (Gateway gateway in gateWayList)
            {
                int y1 = (int)(gateway.nodeConnections[0].location[1] * drawingScale);
                int y2 = (int)(gateway.nodeConnections[1].location[1] * drawingScale);
                int x1 = (int)(gateway.nodeConnections[0].location[0] * drawingScale);
                int x2 = (int)(gateway.nodeConnections[1].location[0] * drawingScale);
                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Pen pen = new Pen(Color.Green, 5);
                bMap.DrawLine(pen, point1, point2);

            }
             foreach (Gate gate in gateList)
             {
                 int y1 = (int)(gate.nodeConnections[0].location[1] * drawingScale);
                 int y2 = (int)(gate.nodeConnections[1].location[1] * drawingScale);
                 int x1 = (int)(gate.nodeConnections[0].location[0] * drawingScale);
                 int x2 = (int)(gate.nodeConnections[1].location[0] * drawingScale);
                 Point point1 = new Point(x1, y1);
                 Point point2 = new Point(x2, y2);
                 Pen pen = new Pen(Color.Yellow, 5);
                 bMap.DrawLine(pen, point1, point2);

             }
             
             g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }
       
        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            if (airport == null)
            {

            }
            else
            {
                drawWays(e.Graphics);
                drawAirport(e.Graphics);
                

                
            }
        }

        private void MapControl_Load(object sender, EventArgs e)
        {

        }
    }
}
