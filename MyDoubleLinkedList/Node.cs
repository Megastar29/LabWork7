namespace MyDoubleLinkedList;

public class Node
{
    public Node()
    {
        Prev = null;
        Next = null;
    }

    public Node(double data)
    {
        Prev = null;
        Next = null;
        Data = data;
    }

    public Node? Prev {  get; set; }
    public Node? Next {  get; set; }
    public double Data { get; set; }
}
