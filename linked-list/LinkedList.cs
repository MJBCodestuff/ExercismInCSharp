public class Deque<T>
{
    private Node? _head;
    private Node? _tail;

    public void Push(T value)
    {
        Node newNode = new Node(value, null, _tail);
        _head ??= newNode;
        if (_tail != null)
        {
            _tail.Next =  newNode;
        }

        _tail =  newNode;
    }

    public T Pop()
    {
        T temp;
        if (_tail == null) throw new InvalidOperationException();
        if (_tail.Prev == null)
        {
            temp = _tail.Value;
            _head = null;
            _tail = null;
            return temp;
        }
        temp = _tail.Value;
        _tail.Prev.Next = null;
        _tail = _tail.Prev;
        return temp;

    }

    public void Unshift(T value)
    {
        Node newNode = new Node(value, _head, null);
        _tail ??= newNode;
        if (_head != null)
        {
            _head.Prev =  newNode;
        }

        _head =  newNode;
    }

    public T Shift()
    {
        T temp;
        if (_head == null) throw new InvalidOperationException();
        if (_head.Next == null)
        {
            temp = _head.Value;
            _head = null;
            _tail = null;
            return temp;
        }
        temp = _head.Value;
        _head.Next.Prev = null;
        _head = _head.Next;
        return temp;
    }

    private class Node(T value, Node? next, Node? prev)
    {
        public T Value { get; }= value;
        public Node? Next { get; set; } = next;
        public Node? Prev { get; set; }= prev;
    }
}