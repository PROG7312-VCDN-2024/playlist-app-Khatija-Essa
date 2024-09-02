using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist_app
{
    public class Node
    {
        public string Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(string data)
        {
            Data = data;
        }
    }

}
