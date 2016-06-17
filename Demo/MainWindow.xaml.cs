using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Map;
using System.Windows.Forms;
using System.IO;
using Triangulator;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow m_MainWindow;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mainCanvas.Cursor = System.Windows.Input.Cursors.Arrow;
            MapTools.DefaultCursor = mainCanvas.Cursor;
            this.m_PointVisualHost.RenderTransform = Map.Map.m_TransformGroup;
            this.m_LineVisualHost.RenderTransform = Map.Map.m_TransformGroup;
            GenMap();
        }

        public void GenMap()
        {
            string[] lines = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, "xy.txt"), Encoding.Default);
            double maxE = double.MinValue;
            double maxN = double.MinValue;
            double minE = double.MaxValue;
            double minN = double.MaxValue;
            List<Triangulator.Geometry.Point> Vertex = new List<Triangulator.Geometry.Point>();
            foreach (string line in lines)
            {
                double N = Convert.ToDouble(line.Split(',')[1].Trim());
                double E = Convert.ToDouble(line.Split(',')[2].Trim());
                if (N > maxN)
                    maxN = N;
                if (N < minN)
                    minN = N;
                if (E > maxE)
                    maxE = E;
                if (E < minE)
                    minE = E;
                Vertex.Add(new Triangulator.Geometry.Point(E, N));
                this.m_PointVisualHost.Add(new Map.Point(Brushes.Red, new Pen(Brushes.Red, 20 * Map.Map.m_ScalarBar),
                     new System.Windows.Point(E, N), 300 * Map.Map.m_ScalarBar));
            }
            List<Triangulator.Geometry.Triangle> triangles = Triangulator.Delauney.Triangulate(Vertex);
            System.Windows.MessageBox.Show(triangles.Count.ToString());
            List<Triangulator.Geometry.Edge> edges = new List<Triangulator.Geometry.Edge>();
            for (int i = 0; i < triangles.Count; i++)
            {
                Triangulator.Geometry.Triangle triangle = triangles[i];
                Triangulator.Geometry.Edge edge1 = new Triangulator.Geometry.Edge(triangle.p1, triangle.p2);
                Triangulator.Geometry.Edge edge2 = new Triangulator.Geometry.Edge(triangle.p2, triangle.p3);
                Triangulator.Geometry.Edge edge3 = new Triangulator.Geometry.Edge(triangle.p3, triangle.p1);
                if (!edges.Contains(edge1))
                    edges.Add(edge1);
                if (!edges.Contains(edge2))
                    edges.Add(edge2);
                if (!edges.Contains(edge3))
                    edges.Add(edge3);
            }
            double maxLength = double.MinValue;
            double sumLength = 0.0;
            double minLength = double.MaxValue;
            foreach (Triangulator.Geometry.Edge edge in edges)
            {
                System.Windows.Point ptStart = new System.Windows.Point(Vertex[edge.p1].X, Vertex[edge.p1].Y);
                System.Windows.Point ptEnd = new System.Windows.Point(Vertex[edge.p2].X, Vertex[edge.p2].Y);
                System.Windows.Vector delta = ptStart - ptEnd;
                double length = Math.Abs(delta.Length);
                if ( length > maxLength)
                    maxLength = length;
                if (length < minLength)
                    minLength = length;
                sumLength += length;
                this.m_LineVisualHost.Add(new Map.Line(Brushes.Red, new Pen(Brushes.Red, 100 * Map.Map.m_ScalarBar),
                  ptStart, ptEnd));
            }
            System.Windows.MessageBox.Show(string.Format("MAX:{0},MIN:{1},COUNT:{2},AVG:{3}", maxLength, minLength, edges.Count, sumLength / (edges.Count * 1.0)));

            Map.Map.Center((minE + maxE) * 0.5, (maxN + maxN) * 0.5);
            Map.Map.SetMapEnvelope(minE, minN, maxE, maxN);
        }

        private void btnWholeMap_Click(object sender, RoutedEventArgs e)
        {
            Map.Map.FullExtent();
        }

        private void btnTranslate_Click(object sender, RoutedEventArgs e)
        {
            MapTools.StartCommand(Pan.Instance, mainCanvas);
        }

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            MapTools.StartCommand(Scale.Instance, mainCanvas);
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            MapTools.StartCommand(WindowMax.Instance, mainCanvas);
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            MapTools.StartCommand(WindowMin.Instance, mainCanvas);
        }

        private void mainCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.lblCoordinate.Content = mainCanvas.m_Coordinate.ToString();
        }

        private void menuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            GenMap();
        }

        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            Pick.TargetType = VisualHostType.POINT;
            MapTools.StartCommand(Pick.Instance, mainCanvas);
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            MapTools.StartCommand(Select.Instance, mainCanvas);
        }

        private void btnReversSelect_Click(object sender, RoutedEventArgs e)
        {
            MapTools.StartCommand(ReverseSelect.Instance, mainCanvas);
        }
    }
}
