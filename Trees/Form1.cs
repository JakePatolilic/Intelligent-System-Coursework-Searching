using System.Xml.Linq;
using System.Drawing;
using System;
using SearchAlgo;

namespace SearchVisual
{
    public partial class Form1 : Form
    {
        private Dictionary<char, Point> vertexLocations = new Dictionary<char, Point>();
        public List<Tuple<char, int>> heuristic;
        private Pen edgePen = new Pen(Color.Black, 2);
        private Search search;
        private bool isPaused = false;

        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_TextChanged;
            textBox2.KeyPress += textBox2_TextChanged;
            textBox4.KeyPress += textBox4_TextChanged;
            panel1.MouseClick += panel1_MouseClick;
            comboBox1.Items.Add("BFS");
            comboBox1.Items.Add("DFS");
            comboBox1.Items.Add("BB");

            search = new Search(100);
        }

        private void textBox1_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && textBox1.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && textBox2.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && textBox4.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char vertex1 = textBox1.Text.ToUpper()[0];
            char vertex2 = textBox2.Text.ToUpper()[0];
            int weight = int.Parse(textBox4.Text);

            ConnectVertices(vertex1, vertex2, weight);

            char v, w;
            int x;
            if (char.TryParse(vertex1.ToString(), out v) && char.TryParse(vertex2.ToString(), out w))
            {
                search.AddEdge(v, w, weight);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickLocation = e.Location;
            char newVertexLabel = (char)('A' + vertexLocations.Count);

            // position size ellipse
            int ellipseSize = 48;
            float labelX = clickLocation.X - ellipseSize / 4;
            float labelY = clickLocation.Y - ellipseSize / 3;

            using (Graphics g = panel1.CreateGraphics())
            {
                Font letter = new Font(Font.FontFamily, 16);
                g.FillEllipse(Brushes.Green, clickLocation.X - ellipseSize / 2, clickLocation.Y - ellipseSize / 2, ellipseSize, ellipseSize);
                g.DrawString(newVertexLabel.ToString(), letter, Brushes.Red, labelX, labelY);
            }

            vertexLocations[newVertexLabel] = clickLocation;
        }


        private void ConnectVertices(char vertex1, char vertex2, int weight)
        {
            if (vertexLocations.ContainsKey(vertex1) && vertexLocations.ContainsKey(vertex2))
            {
                using (Graphics g = panel1.CreateGraphics())
                {
                    Point point1 = vertexLocations[vertex1];
                    Point point2 = vertexLocations[vertex2];

                    g.DrawLine(edgePen, point1, point2);

                    // weight label
                    float midX = (point1.X + point2.X) / 2f;
                    float midY = (point1.Y + point2.Y) / 2f;

                    g.DrawString(weight.ToString(), Font, Brushes.Black, midX, midY);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            char startVertex = textBox3.Text.ToUpper()[0];
            char end = textBox5.Text.ToUpper()[0];

            string selectedAlgorithm = comboBox1.SelectedItem.ToString();

            if (selectedAlgorithm == "BFS")
            {
                search.BFS(startVertex, end);
            }
            else if (selectedAlgorithm == "DFS")
            {
                search.DFS(startVertex, end);
            }
            else if (selectedAlgorithm == "BB")
            {
                search.BranchAndBound(startVertex, end);
            }

            List<Tuple<char, int>> heuristics = CalculateHeuristics(end);

            VisualizeSteps();

        }
        int i = 0;
        private async Task VisualizeSteps()
        {
            foreach (char step in search.steps)
            {
                ChangeVertexColor(step, Color.Red);
                if (isPaused)
                {
                    while (isPaused)
                    {
                        await Task.Delay(50);
                        Application.DoEvents();
                    }
                }
                //ChangeVertexColor(step, Color.Red);
                await Task.Delay(500);
                Application.DoEvents();
                i++;
            }
        }

        private void ChangeVertexColor(char vertex, Color color)
        {
            if (vertexLocations.ContainsKey(vertex))
            {
                using (Graphics g = panel1.CreateGraphics())
                {
                    Point vertexLocation = vertexLocations[vertex];

                    Font labelFont = new Font(Font.FontFamily, 16);

                    g.FillEllipse(new SolidBrush(color), vertexLocation.X - 25, vertexLocation.Y - 25, 50, 50);
                    g.DrawString(vertex.ToString(), labelFont, Brushes.Black, vertexLocation.X - 12, vertexLocation.Y - 15);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            foreach (char step in search.steps)
            {
                ChangeVertexColor(step, Color.Green);
                Application.DoEvents();
            }
            search.steps.Clear();
            search.dfsFlag = false;
            search.qSteps.Clear();
        }

        public List<Tuple<char, int>> CalculateHeuristics(char endVertex)
        {
            List<Tuple<char, int>> heuristicList = new List<Tuple<char, int>>();

            foreach (var vertexLocation in vertexLocations)
            {
                char vertex = vertexLocation.Key;
                Point location = vertexLocation.Value;

                // Calculate Euclidean distance as a heuristic
                int distance = (int)Math.Sqrt(Math.Pow(location.X - vertexLocations[endVertex].X, 2) +
                                              Math.Pow(location.Y - vertexLocations[endVertex].Y, 2));

                heuristicList.Add(Tuple.Create(vertex, distance));
            }

            // Sort the heuristicList by distance in ascending order
            heuristicList.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            search.heuristic = this.heuristic;
            return heuristicList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                button4.Text = "Resume";
            }
            else
            {
                button4.Text = "Pause";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}