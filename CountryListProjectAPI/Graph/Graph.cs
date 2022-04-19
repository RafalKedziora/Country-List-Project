namespace CountryListProjectAPI
{
    public class Graph
    {
        int V;
        List<List<int>> adj;
        public List<int> results;

        public Graph(int v)
        {
            results = new List<int>();
            V = v;
            adj = new List<List<int>>(V);
            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
            }
        }

        public void AddEdge(int i, int j)
        {
            adj[i].Add(j);
            adj[j].Add(i);
        }

        public void ShortesPath(int src, int dest)
        {
            int[] pred = new int[V];
            int[] dist = new int[V];

            if (BFS(src, dest, pred, dist) == false)
            {
                Console.WriteLine("Given source and destination are not connected");
                return;
            }

            List<int> path = new List<int>();
            int crawl = dest;
            path.Add(crawl);

            while (pred[crawl] != -1)
            {
                path.Add(pred[crawl]);
                crawl = pred[crawl];
            }

            path.ForEach(x => results.Add(x));
        }

        private bool BFS(int src, int dest, int[] pred, int[] dist)
        {
            List<int> queue = new List<int>();
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
                dist[i] = int.MaxValue;
                pred[i] = -1;
            }
            visited[src] = true;
            dist[src] = 0;
            queue.Add(src);
            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);

                for (int i = 0;
                         i < adj[u].Count; i++)
                {
                    if (visited[adj[u][i]] == false)
                    {
                        visited[adj[u][i]] = true;
                        dist[adj[u][i]] = dist[u] + 1;
                        pred[adj[u][i]] = u;
                        queue.Add(adj[u][i]);

                        if (adj[u][i] == dest)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
