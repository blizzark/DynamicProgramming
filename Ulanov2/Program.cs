using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace Ulanov2
{
    static class Program
    {

        public static List<string> names = new List<string>();
        public static List<int> znach = new List<int>();
        public static List<string> otvet = new List<string>();
        public static List<string> path = new List<string>();

        sealed public class Node
        {
            public List<Link> Links { get; set; }

            public Node()
            {
                Links = new List<Link>();
            }
        }

        sealed public class Link
        {
            public double Distance { get; set; }
            public string Node { get; set; }
        }

        sealed public class Description
        {
            public bool Visited { get; set; }
            public double Distance { get; set; }

            public Description()
            {
                Visited = false;
                Distance = double.PositiveInfinity;
            }
        }

        sealed public class Graph
        {
            private Dictionary<string, Node> nodes;

            public Graph()
            {
                nodes = new Dictionary<string, Node>();
            }

            public void AddNode(string name)
            {
                nodes.Add(name, new Node());
            }
            public void AddLinkToNode(string start, string end, double distance, bool isOriented)
            {
                nodes[start].Links.Add(new Link { Node = end, Distance = distance });
                if (!isOriented)
                    nodes[end].Links.Add(new Link { Node = start, Distance = distance });
            }

            public double FindShortestDistance(string start, string end)
            {
               
                // Алгоритм Дейкстры.
                Dictionary<string, Description> info = new Dictionary<string, Description>(this.nodes.Count);
                foreach (string current in this.nodes.Keys)
                    info.Add(current, new Description());
                info[start].Distance = 0;

                // Пока все вершины непосещенные.
                while (!info.Select(x => x.Value.Visited).Aggregate((x, y) => x & y))
                {
                    bool yes = true;
                    // Находим непосещенную вершину с минимальной меткой.
                    string current = info.Where(x => !x.Value.Visited && x.Value.Distance == info.Where(y => !y.Value.Visited).Min(y => y.Value.Distance)).First().Key;
                    // Находим все непосещенные соседние вершины для текущей вершины.
                    List<Link> neighbors = nodes[current].Links.Where(x => !info[x.Node].Visited).ToList();
                    // Рассматриваем новую длину пути для каждой соседней вершины.
                    foreach (Link link in neighbors)
                    {
                        double distance = info[current].Distance + link.Distance;
                        if (info[link.Node].Distance > distance)
                        {
                            info[link.Node].Distance = distance;
                            
                        }
                    }
                    path.Add(current);
                 
                    // Отмечаем текущую вершину как посещенная.
                    info[current].Visited = true;
                }

                return info[end].Distance;
            }
        }


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /*
       public static void prog()
        {


           
            Graph graph = new Graph();

            // Заполнение графа вершинами.
            for (int i = 1; i < dannie.kolichestvolines+1; i++)
                graph.AddNode(Convert.ToString(i));

            // Создание у вершин связей.
            // Последнее значение говорит о том, что эта связь двунаправленная.

            //  


           

            int j = 0;
            for (int i = 0; i < dannie.kolichestvolines*2-1; i+=2)
            {
               // MessageBox.Show(Convert.ToString(names[i]));
                graph.AddLinkToNode(names[i], names[i+1], znach[j], false);
                j++;
            }

            j = 0;
           
            
            for (int i = 1; i <= dannie.colum*dannie.rows; i++)
            {
                otvet.Add(Convert.ToString(graph.FindShortestDistance(names[0], Convert.ToString(i))));
            }
             */
            
       public static void prog()
        {


           
            Graph graph = new Graph();

            // Заполнение графа вершинами.
            for (int i = 1; i < dannie.kolichestvolines+1; i++)
                graph.AddNode(Convert.ToString(i));

            // Создание у вершин связей.
            // Последнее значение говорит о том, что эта связь двунаправленная.

            //  


           

            int j = 0;
            for (int i = 0; i < dannie.kolichestvolines*2-1; i+=2)
            {
               // MessageBox.Show(Convert.ToString(names[i]));
                graph.AddLinkToNode(names[i + 1], names[i], znach[j], false);
                j++;
            }

            j = 0;
            /*
            for (int i = 0; i < dannie.kolichestvolines * 2 - 1; i += 2)
            {
                otvet.Add(Convert.ToString(graph.FindShortestDistance(names[0], names[i + 1])));
            }
            */
            for (int i = dannie.colum * dannie.rows; i >=1 ; i--)
            {
                otvet.Add(Convert.ToString(graph.FindShortestDistance(Convert.ToString(dannie.colum * dannie.rows), Convert.ToString(i))));
            }
            
            
            //Console.WriteLine(graph.FindShortestDistance("A", "C")); // Ответ 9.
            // Console.WriteLine(graph.FindShortestDistance("A", "D")); // Ответ 20.
            // Console.WriteLine(graph.FindShortestDistance("A", "E")); // Ответ 20.
            //  Console.WriteLine(graph.FindShortestDistance("A", "F")); // Ответ 11.

        }

            //Console.WriteLine(graph.FindShortestDistance("A", "C")); // Ответ 9.
            // Console.WriteLine(graph.FindShortestDistance("A", "D")); // Ответ 20.
            // Console.WriteLine(graph.FindShortestDistance("A", "E")); // Ответ 20.
            //  Console.WriteLine(graph.FindShortestDistance("A", "F")); // Ответ 11.

        }

   
    }

