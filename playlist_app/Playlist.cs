namespace playlist_app
{
    public class Playlist
    {
        public Node Head => head;
        public Node Current
        {
            get => current;
            set => current = value;
        }

        private Node head;
        private Node tail;
        private Node current;

        public void AddTrack(string name)
        {
            var newNode = new Node(name);

            if (head == null)
            {
                head = tail = current = newNode;
                head.Next = head.Prev = head;  
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;  
                head.Prev = newNode;   
                tail = newNode;
            }
        }

        public void RemoveCurrentTrack()
        {
            if (current == null) return;

            if (head == tail) // Only one node
            {
                head = tail = current = null;
            }
            else
            {
                if (current == head)
                {
                    head = head.Next;
                    head.Prev = tail;
                    tail.Next = head;
                }
                else if (current == tail)
                {
                    tail = tail.Prev;
                    tail.Next = head;
                    head.Prev = tail;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                current = current.Next ?? head;
            }
        }

        public void MoveNext()
        {
            if (current != null)
            {
                current = current.Next;
            }
        }

        public void MovePrev()
        {
            if (current != null)
            {
                current = current.Prev;
            }
        }

        public string GetCurrentTrack()
        {
            return current?.Data;
        }
    }
}
