namespace BibliotecaApp.DataStructures
{
    public class DNode<T>
    {
        public T Data { get; set; }
        public DNode<T> Next { get; set; }
        public DNode<T> Prev { get; set; }

        public DNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
