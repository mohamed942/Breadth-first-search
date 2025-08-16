namespace Breadth_first_search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // represent the graph by hashtable 
            // the key is the node and the value is a list of the nodes that are connected to the key node
            // in breadth first search we visit all the nodes at the same level before moving to the next level
            // use a queue to keep track of the nodes that are yet to be visited
            // dequeue the first node from the queue and check if it is seller mango
            // if dequeued node is visited, move to the next node
            // if it is not, add all the nodes that are connected to the current node to the queue
            // continue this process until the queue is empty

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            graph["you"] = new List<string> { "alice", "bob", "claire" };
            graph["bob"] = new List<string> { "anuj", "peggy" };
            graph["alice"] = new List<string> { "peggy" };
            graph["claire"] = new List<string> { "thom", "jonny" };
            graph["anuj"] = new List<string> { };
            graph["peggy"] = new List<string> { };
            graph["thom"] = new List<string> { };
            graph["jonny"] = new List<string> { };

            Console.WriteLine(search("you", graph));
            Console.ReadKey();
        }
        public static bool isSeller(string name)
        {
            return name.EndsWith("m");
        }
        public static bool search(string name, Dictionary<string, List<string>> graph)
        {
            Queue<string> queue = new Queue<string>();

            queue = new Queue<string>(queue.Concat(graph[name]));
            
            while (queue.Count > 0)
            {
                string person = queue.Dequeue();
                if (isSeller(person))
                {
                    Console.WriteLine(person + " is a mango seller");
                    return true;
                }
                foreach (string neighbor in graph[person])
                {
                    queue.Enqueue(neighbor);
                }
            }
            return false;
        }
    }
}
