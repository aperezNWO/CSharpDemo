using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Exam70483Library.Managers
{
    public class AlgorithmManager
    {
        #region "Campos"
        //
        int[] arreglo;
        string randomValues;
        int arraySize;
        static List<int> sortedList = new List<int>();
        List<string> sortSteps = new List<string>();
        #endregion

        #region "Propiedades"
        public List<string> SortSteps
        {
            get
            {
                return this.sortSteps;
            }
        }
        #endregion

        #region "Constructor"
        public AlgorithmManager()
        {

        }
        //
        public AlgorithmManager(string p_randomValues, int p_arraySize)
        {
            //-----------------------------------------------------
            // INICIAR VARIABLES
            //-----------------------------------------------------
            this.randomValues = p_randomValues;
            this.arraySize = p_arraySize;
            this.arreglo = new int[arraySize];
            this.sortSteps = new List<string>();
            //
            //-----------------------------------------------------
            // INICIAR ARREGLO
            //-----------------------------------------------------
            string[] randomValuesArray = randomValues.Split('|');
            //
            for (int i = 0; i < arraySize; i++)
            {
                //
                string randomValue = randomValuesArray[i];
                //
                arreglo[i] = Convert.ToInt32(randomValue);
                //
            }
        }
        #endregion

        #region "Metodos"
        //
        public static string GetUnsortedList(int p_arraySize)
        {
            //-----------------------------------------------------
            // DECLARACION DE VARIABLES
            //-----------------------------------------------------
            string randomValues = string.Empty;
            int[] arreglo = new int[p_arraySize];

            //-----------------------------------------------------
            // GENERACION ALEATORIA DE NUMEROS
            //-----------------------------------------------------
            arreglo = FisherYates(p_arraySize);
            //-----------------------------------------------------
            // JUNTAR ARREGLO EN CADENA
            //-----------------------------------------------------
            for (int j = 0; j < p_arraySize; j++)
            {
                string separator = (j == 0) ? string.Empty : "|";

                randomValues += separator + arreglo[j];
            }
            //
#if DEBUG
            LogModel.Log(string.Format("SORT_BENCHMARK. RANDOM_LIST : {0} ", randomValues));
#endif

            //
            return randomValues;
        }
        //
        public string BubbleSort()
        {
            //-----------------------------------------------------
            // DECLARACION DE VARIABLES
            //-----------------------------------------------------
            string sortedValues = string.Empty;
            //-----------------------------------------------------
            // ORDENAR ARREGLO
            //-----------------------------------------------------
            int temp = 0;
            //
            for (int write = 0; write < arreglo.Length; write++)
            {
                //
                for (int sort = 0; sort < arreglo.Length - 1; sort++)
                {
                    //
                    if (arreglo[sort] > arreglo[sort + 1])
                    {
                        //
                        temp = arreglo[sort + 1];
                        arreglo[sort + 1] = arreglo[sort];
                        arreglo[sort] = temp;

                        //-----------------------------------------------------
                        // GUARDAR PASO DEL ARREGLO EN MATRIZ DE PASOS
                        //-----------------------------------------------------
                        //
                        string tempValues = string.Empty;
                        //
                        for (int j = 0; j < arraySize; j++)
                        {
                            //
                            string separator = (j == 0) ? string.Empty : "|";
                            //
                            tempValues += separator + arreglo[j];
                        }
                        //
                        sortSteps.Add(tempValues);
                    }
                }
                //
            }
            //-----------------------------------------------------
            // JUNTAR ARREGLO EN CADENA
            //-----------------------------------------------------
            for (int j = 0; j < arraySize; j++)
            {
                string separator = (j == 0) ? string.Empty : "|";

                sortedValues += separator + arreglo[j];
            }
#if DEBUG 
            //
            LogModel.Log(string.Format("BUBBLE SORT. STEPS  : {0} ", sortSteps.Count));
            //
            LogModel.Log(string.Format("BUBBLE SORT. SORTED : {0} ", sortedValues.ToString()));
#endif
            //
            return sortedValues;
        }
        //
        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;

                    //-----------------------------------------------------
                    // GUARDAR PASO DEL ARREGLO EN MATRIZ DE PASOS
                    //-----------------------------------------------------
                    //
                    string tempValues = string.Empty;
                    //
                    for (int j = 0; j < this.arraySize; j++)
                    {
                        //
                        string separator = (j == 0) ? string.Empty : "|";
                        //
                        tempValues += separator + arreglo[j];
                    }
                    //
                    sortSteps.Add(tempValues);
                }
                else
                {
                    return right;
                }
            }
        }
        //
        private void Quick_Sort(int[] arr, int left, int right)
        {
            //
            if (left < right)
            {
                //
                int pivot = Partition(arr, left, right);
                //
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }
        //
        public string QuickSort()
        {
            //
            string sortedValues = string.Empty;
            //
            Quick_Sort(arreglo, 0, arreglo.Length - 1);
            //
            //-----------------------------------------------------
            // JUNTAR ARREGLO EN CADENA
            //-----------------------------------------------------
            for (int j = 0; j < arraySize; j++)
            {
                string separator = (j == 0) ? string.Empty : "|";

                sortedValues += separator + arreglo[j];
            }
#if DEBUG
            //
            LogModel.Log(string.Format("QUICK SORT. STEPS  : {0} ", sortSteps.Count));
            //
            LogModel.Log(string.Format("QUICK SORT. SORTED : {0} ", sortedValues.ToString()));
#endif
            //
            return sortedValues;
        }
        //
        public void BinaryTreeSort(int[] array)
        {
            //
            var binarySortTreeNode = new BinarySortTreeNode(array[0]);
            //
            for (int i = 1; i < array.Length; i++)
            {
                binarySortTreeNode.Insert(array[i]);
            }
            //
            binarySortTreeNode.InorderTraversal();
            //
        }
        //
        public string TreeSort()
        {
            //
            string sortedValues = string.Empty;
            //
            BinaryTreeSort(arreglo);
            //
            int[] sortedArray = sortedList.ToArray();
            //
            //-----------------------------------------------------
            // JUNTAR ARREGLO EN CADENA
            //-----------------------------------------------------
            for (int j = 0; j < sortedArray.Length; j++)
            {
                //
                string separator = (j == 0) ? string.Empty : "|";
                //
                sortedValues += separator + sortedArray[j];
            }
#if DEBUG
            //
            LogModel.Log(string.Format("TREE SORT. SORTED : {0} ", sortedValues.ToString()));
#endif
            //
            return sortedValues;
        }
        //
        public static int[] FisherYates(int count)
        {
            //
            Random rand = new Random();
            //
            int[] deck = new int[count];
            //
            for (byte i = 0; i < count; i++)
                deck[i] = i;
            //
            for (byte i = 0; i <= count - 2; i++)
            {
                int j = rand.Next(count - i);
                if (j > 0)
                {
                    int curVal = deck[i];
                    deck[i] = deck[i + j];
                    deck[i + j] = curVal;
                }
            }
            //
            for (int i = count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                if (j != i)
                {
                    int curVal = deck[i];
                    deck[i] = deck[j];
                    deck[j] = curVal;
                }
            }
            //
            return deck;
        }
        //
        public static int[] FisherYates(int count, Random rand)
        {
            //
            int[] deck = new int[count];
            //
            for (byte i = 0; i < count; i++)
                deck[i] = i;
            //
            for (byte i = 0; i <= count - 2; i++)
            {
                int j = rand.Next(count - i);
                if (j > 0)
                {
                    int curVal = deck[i];
                    deck[i] = deck[i + j];
                    deck[i + j] = curVal;
                }
            }
            //
            for (int i = count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                if (j != i)
                {
                    int curVal = deck[i];
                    deck[i] = deck[j];
                    deck[j] = curVal;
                }
            }
            //
            return deck;
        }
        //
        public static string Dijkstra()
        {
            //
            StringBuilder status = new StringBuilder();
            //
            int vertexSize = 9;

            /* Let us create the example  graph discussed above */
            int[,] graph = new int[,]  {  { 0,  4,  0,  0,  0,  0,  0,  8,  0 },
                                          { 4,  0,  8,  0,  0,  0,  0,  11, 0 },
                                          { 0,  8,  0,  7,  0,  4,  0,  0,  2 },
                                          { 0,  0,  7,  0,  9,  14, 0,  0,  0 },
                                          { 0,  0,  0,  9,  0,  10, 0,  0,  0 },
                                          { 0,  0,  4,  14, 10, 0,  2,  0,  0 },
                                          { 0,  0,  0,  0,  0,  2,  0,  1,  6 },
                                          { 8,  11, 0,  0,  0,  0,  1,  0,  7 },
                                          { 0,  0,  2,  0,  0,  0,  6,  7,  0 } };

            // Driver Code 
            GFG t = new GFG();
            t.Dijkstra(graph, 0, vertexSize);
            //
            string integerFormat = @"00";
            //
            for (int index = 0; index < t.dist.Length; index++)
            {
                //
                string separator = (index < (t.dist.Length - 1)) ? "," : string.Empty;
                //
                status.Append(string.Format(@"{0}\t\t\t{1}\t{2}", index.ToString(integerFormat), t.dist[index].ToString(integerFormat), separator));
            }
            //
            return status.ToString();
        }
        //
        public static string Dijkstra(List<string> vertex, int[,] graph, int vertexSize, int sampleSize, int sourcePoint)
        {
            // Driver Code 
            GFG t = new GFG();
            t.Dijkstra(graph, sourcePoint, vertexSize);

            //
            string integerFormat = @"00";
            StringBuilder status = new StringBuilder();
            
            //
            for (int index = 0; index < t.dist.Length; index++)
            {
                // CORREGIR VALORES
                if (t.dist[index] >= Int32.MaxValue)
                {
                    t.dist[index] = 0;
                }

                //
                string separator = (index < (t.dist.Length - 1)) ? "," : string.Empty;
                //
                status.Append
                    (
                        string.Format(@"{0}<{1}>-{2}-{3}{4}"
                                    , index.ToString(integerFormat)
                                    , vertex[index].Replace(",", ";").Replace("|", "")
                                    , t.dist[index].ToString(integerFormat)
                                    , t.path[index].Replace(",", ";")
                                    , separator
)
                    );
            }

            //
            return status.ToString();
        }

        private static double Pitagorean(double coord_x, double coord_y)
        {
            //
            double pitagorean = 0;
            double power      = 2;

            pitagorean        = Math.Sqrt(
                                                    Math.Pow(coord_x, power)
                                                    +
                                                    Math.Pow(coord_y, power)
                                         );

            //
            return pitagorean;
        }
        //
        private static double GetHipotemuza(List<string> vertexString, int index_x, int index_y)
        {
            //
            string[] coord_source = vertexString[index_y].Replace("|", "").Replace("[", "").Replace("]", "").Split(',');
            string[] coord_dest   = vertexString[index_x].Replace("|", "").Replace("[", "").Replace("]", "").Split(',');

            //
            double coord_source_x = Convert.ToDouble(coord_source[0]);
            double coord_source_y = Convert.ToDouble(coord_source[1]);
            double coord_dest_x = Convert.ToDouble(coord_dest[0]);
            double coord_dest_y = Convert.ToDouble(coord_dest[1]);
            double coord_x = Math.Abs(coord_dest_x - coord_source_x);
            double coord_y = Math.Abs(coord_dest_y - coord_source_y);
            //
            double hipotemuza = Pitagorean(coord_x, coord_y);
            //
            // LogModel.Log(string.Format("DIJSTRA_DEMO. GENERATE_RANDOM_MATRIX : ({0},{1}) ({2}, {3}) = {4} ", coord_source[0], coord_source[1], coord_dest[0], coord_dest[1], hipotemuza));
            //

            return hipotemuza;
        }

        public static string GenerateRandomPoints(int vertexSize, int sampleSize, int sourcePoint)
        {
            //
            int[,] graph         = new int[vertexSize, vertexSize];
            // 
            string statusMessage = string.Empty;
            DateTime dt          = DateTime.Now;
            //
            Random rand_x = new Random(dt.Millisecond / 2);
            Random rand_y = new Random(dt.Millisecond * 2);
            //
            int[] vertex_X            = FisherYates(sampleSize, rand_x);
            int[] vertex_Y            = FisherYates(sampleSize, rand_y);
            List<string> vertexArray  = new List<string>();
            //
            for (int index = 0; index < vertexSize; index++)
            {
                //
                string separator_1 = (index < vertexSize - 1) ? "|" : "";
                //
                vertexArray.Add(string.Format("[{0},{1}]{2}", vertex_X[index], vertex_Y[index], separator_1));
            }
            //
            StringBuilder vertexArrayString = new StringBuilder();
            //
            for (int index = 0; index < vertexSize; index++)
            {
                vertexArrayString.Append(vertexArray[index]);
            }
            //
            string separator_2  = "■";
            //
            string vertexMatrix = GenerateRandomMatrix(vertexArray, graph,vertexSize);
            //
            string vertexList   = Dijkstra(vertexArray, graph, vertexSize, sampleSize, sourcePoint);
            //
            string sortedListEncoded = string.Empty;
            sortedListEncoded = HttpUtility.HtmlEncode(vertexList);
            sortedListEncoded = sortedListEncoded.Replace(@",", @"<br/>");
            sortedListEncoded = sortedListEncoded.Replace(@"\t", @"&nbsp;");
            //
            statusMessage = string.Format("{0}{1}{2}{1}{3}", vertexArrayString, separator_2, vertexMatrix, sortedListEncoded);
            //
            //LogModel.Log(string.Format("DIJSTRA_DEMO. GENERATE_RANDOM_VERTEX : {0}", statusMessage));
            //
            return statusMessage;
        }
        //
        public static string GenerateRandomMatrix(List<string> vertexString, int[,] graph, int vertexSize)
        {
            //--------------------------------------------------------------
            // DECLARACION DE VARIABLES
            //--------------------------------------------------------------
            StringBuilder statusMessage = new StringBuilder();
            //
            //--------------------------------------------------------------
            // LA PARTE DIAGONAL DE LA MATRIZ SIEMPRE SERA 0
            //--------------------------------------------------------------
            for (int index = 0; index < vertexSize; index++)
            {
                graph[index, index] = 0;
            }
            //--------------------------------------------------------------
            // LLENAR EL RESTO DE LA MATRIZ DE FORMA ALEATORIA
            //--------------------------------------------------------------
            //
            DateTime dt = DateTime.Now;
            Random rnd  = new Random(dt.Millisecond * 3);
            //
            for (int index_x = 0; index_x < vertexSize; index_x++)
            {
                
                //
                for (int index_y = (index_x + 1); index_y < vertexSize; index_y++)
                {
                    //
                    double randomValue = rnd.Next(0, 2);

                    //--------------------------------------------------------------
                    // EN VALORES POSITIVOS LLENAR LA MATRIZ CON DISTANCIAS
                    //--------------------------------------------------------------

                    if (randomValue == 1)
                    {
                        //
                        randomValue = GetHipotemuza(vertexString, index_x, index_y);
                    }

                    //
                    graph[index_x, index_y] = Convert.ToInt32(randomValue);
                    graph[index_y, index_x] = Convert.ToInt32(randomValue);
                }
            }

            //----------------------------------------------------
            // GARANTIZAR CONECTIVIDAD DE AL MENOS UN PUNTO
            //----------------------------------------------------
            for (int index_x = 0; index_x < vertexSize; index_x++)
            {
                //
                int zeroCount = 0;

                //
                for (int index_y = 0; index_y < vertexSize; index_y++)
                {
                    // DESCARTA DIAGONAL Y VERIFICAR EXISTENCIA DE VALOR "CERO"
                    if ((index_x != index_y) && (graph[index_x,index_y] == 0))
                    {
                        //
                        zeroCount++;

                        // GARANTIZAR CONECTIVIDAD DE AL MENOS UN PUNTO
                        if (zeroCount == (vertexSize - 1))
                        {
                            //
                            int hipotemuza          = Convert.ToInt32(GetHipotemuza(vertexString, index_x, index_y));
                            graph[index_x, index_y] = hipotemuza;
                            graph[index_y, index_x] = hipotemuza;
                        }
                    }
                }
            }


            //--------------------------------------------------------------------
            // REPRESENTAR MATRIZ EN CADENA
            //--------------------------------------------------------------------
            //
            for (int index_x = 0; index_x < vertexSize; index_x++)
            {
                //
                string separator_1 = (index_x < vertexSize - 1) ? "|" : "";
                //
                StringBuilder stringArray = new StringBuilder();
                //
                string stringArrayValues = string.Empty;
                //
                for (int index_y = 0; index_y < vertexSize; index_y++)
                {
                    //
                    string separator_2 = (index_y < vertexSize - 1) ? "," : "";
                    //
                    stringArray.Append(string.Format("{0}{1}", graph[index_x, index_y].ToString(), separator_2));
                }
                //
                stringArrayValues = string.Format("{{{0}}}", stringArray.ToString());
                //
                //LogModel.Log(string.Format("DIJSTRA_DEMO. GENERATE_RANDOM_MATRIX : {0}|{1} ", index_x, stringArrayValues));
                //
                statusMessage.Append(string.Format(@"{0}{1}", stringArrayValues, separator_1));
            }
            return statusMessage.ToString();
        }
#endregion

        #region "Clases"   
        public class BinarySortTreeNode
        {
            public int Key { get; set; }

            public BinarySortTreeNode Left { get; set; }

            public BinarySortTreeNode Right { get; set; }

            public BinarySortTreeNode(int key)
            {
                Key = key;
            }

            public void Insert(int key)
            {
                var tree = new BinarySortTreeNode(key);
                if (tree.Key <= Key)
                {
                    if (Left == null)
                    {
                        Left = tree;
                    }
                    else
                    {
                        Left.Insert(key);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = tree;
                    }
                    else
                    {
                        Right.Insert(key);
                    }
                }
            }

            /// <summary>
            /// In-order traversal
            /// </summary>
            public void InorderTraversal()
            {
                Left?.InorderTraversal();
                sortedList.Add(Key);
                Right?.InorderTraversal();
            }
        }
        //
        public class GFG
        {
#region "Campos"
            public int[] dist;       // The output array. dist[i] 
                                     // will hold the shortest 
                                     // distance from src to i 
            private int _vertexSize;

            public List<string> path;
#endregion

#region "Metodos"
            // A utility function to find the 
            // vertex with minimum distance 
            // value, from the set of vertices 
            // not yet included in shortest 
            // path tree 
            int minDistance(int[] dist,
                            bool[] sptSet)
            {
                // Initialize min value 
                int min = int.MaxValue, min_index = -1;

                for (int v = 0; v < _vertexSize; v++)
                    if (sptSet[v] == false && dist[v] <= min)
                    {
                        min       = dist[v];
                        min_index = v;
                    }

                return min_index;
            }


            // Function that implements Dijkstra's 
            // single source shortest path algorithm 
            // for a graph represented using adjacency 
            // matrix representation 
            public void Dijkstra(int[,] graph, int src, int vertexSize)
            {
                _vertexSize = vertexSize;
                dist        = new int[vertexSize]; // The output array. dist[i] 
                                            // will hold the shortest 
                                            // distance from src to i 
                path         = new List<string>(vertexSize);

                // sptSet[i] will true if vertex 
                // i is included in shortest path 
                // tree or shortest distance from 
                // src to i is finalized 
                bool[] sptSet = new bool[vertexSize];

                // Initialize all distances as 
                // INFINITE and stpSet[] as false 
                for (int i = 0; i < vertexSize; i++)
                {
                    path.Add(string.Empty);
                }
                
                for (int i = 0; i < vertexSize; i++)
                {
                    dist[i]   = int.MaxValue;
                    sptSet[i] = false;
                }

                // Distance of source vertex 
                // from itself is always 0 
                dist[src] = 0;

                // Find shortest path for all vertices 
                for (int count = 0; count < vertexSize - 1; count++)
                {
                    // Pick the minimum distance vertex 
                    // from the set of vertices not yet 
                    // processed. u is always equal to 
                    // src in first iteration. 
                    int u = minDistance(dist, sptSet);

                    // Mark the picked vertex as processed 
                    sptSet[u] = true;

                    // Update dist value of the adjacent 
                    // vertices of the picked vertex. 
                    for (int v = 0; v < _vertexSize; v++)

                        // Update dist[v] only if is not in 
                        // sptSet, there is an edge from u 
                        // to v, and total weight of path 
                        // from src to v through u is smaller 
                        // than current value of dist[v] 
                        if (!sptSet[v] 
                            && 
                            graph[u, v] != 0 
                            &&
                            dist[u] != int.MaxValue 
                            && 
                            dist[u] + graph[u, v] < dist[v])
                        {
                            dist[v] = dist[u] + graph[u, v];
                            path[v] = path[u] + string.Format("[{0},{1}]≡", u,v);
                        }
                }

            }
#endregion
        }
#endregion
    }
}
