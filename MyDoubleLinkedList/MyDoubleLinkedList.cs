using System.Collections;
using System.Runtime.InteropServices;

namespace MyDoubleLinkedList;

public class DoubleLinkedList : IEnumerable<double>
{
    public int Count { get; private set; }

    public Node? Head { get; private set; }

    public Node? Tail { get; private set; }

    public DoubleLinkedList()
    {
        this.Head = null;
        this.Tail = null;
        this.Count = 0;
    }

    public void Add(double data)
    {
        Node newNode = new Node(data);

        if (this.Head is null)
        {
            this.Head = newNode;
            this.Tail = newNode;
        }
        else
        {
            this.Head.Prev = newNode;
            newNode.Next = this.Head;
            this.Head = newNode;
        }

        this.Count++;
    }

    public void Remove(int index)
    {
        if (index > this.Count - 1 || index < 0)
        {
            throw new IndexOutOfRangeException("The index in Remove method is out of range");
        }

        int divIndex = this.Count % 2 == 0 ? this.Count / 2 : ((this.Count - 1) / 2) + 1;

        if (index >= divIndex)
        {
            int currentIndex = this.Count - 1;
            Node? currentNode = this.Tail;
            bool isFound = false;

            if (currentNode is null)
            {
                throw new InvalidOperationException("Can't remove an element from empty list");
            }

            do
            {
                if (currentIndex == index)
                {
                    isFound = true;
                    currentNode?.Prev?.Next = currentNode.Next;
                    currentNode?.Next?.Prev = currentNode.Prev;
                    this.Count--;
                }

                currentNode = currentNode?.Prev;
                currentIndex--;
            } while (!isFound || currentNode is null);
        }
        else
        {
            int currentIndex = 0;
            Node? currentNode = this.Head;
            bool isFound = false;

            if (currentNode is null)
            {
                throw new InvalidOperationException("Can't remove an element from empty list");
            }

            do
            {
                if (currentIndex == index)
                {
                    isFound = true;
                    currentNode?.Prev?.Next = currentNode.Next;
                    currentNode?.Next?.Prev = currentNode.Prev;
                    this.Count--;
                }

                currentNode = currentNode?.Next;
                currentIndex++;
            } while (!isFound || currentNode is null);
        }
    }

    public IEnumerator<double> GetEnumerator()
    {
        return new DoubleLinkedListEnumerator(this.Head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("The index is out of range in DoubleLinkedList");
            }

            int currentIndex = 0;

            foreach (var node in this)
            {
                if (currentIndex == index)
                {
                    return node;
                }

                currentIndex++;
            }

            throw new InvalidOperationException($"The index {index} does not exist in the list");
        }
    }

    public double FindMaxEl()
    {
        if (this.Head is null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        double max = this.Head.Data;

        foreach (var item in this)
        {
            if (item > max)
            {
                max = item;
            }
        }

        return max;
    }

    public double FindMinEl()
    {
        if (this.Head is null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        double min = this.Head.Data;

        foreach (var item in this)
        {
            if (item < min)
            {
                min = item;
            }
        }

        return min;
    }

    public double FindAvgVal()
    {
        var min = this.FindMinEl();
        var max = this.FindMaxEl();

        return (max + min) / 2.0;
    }

    public double FindFirstElLessThanAvgVal()
    {
        var avg = this.FindAvgVal();

        foreach (var item in this)
        {
            if (item < avg)
            {
                return item;
            }
        }

        return this.FindMinEl();
    }

    public int FindMaxIndex()
    {
        var max = this.FindMaxEl();
        int i = 0;

        foreach (var item in this)
        {
            if (item == max)
            {
                return i;
            }
            i++;
        }

        return -1;
    }

    public double SumOfElAfterMaxEl()
    {
        int maxIndex = this.FindMaxIndex();
        int i = 0;
        double sum = 0.0;

        foreach (var item in this)
        {
            if (i > maxIndex)
            {
                sum += item;
            }

            i++;
        }

        return sum;
    }

    public DoubleLinkedList GetElementsGraterThanValue(double value)
    {
        DoubleLinkedList newList = new DoubleLinkedList();

        foreach (var item in this)
        {
            if (item > value)
            {
                newList.Add(item);
            }
        }

        DoubleLinkedList resList = new DoubleLinkedList();

        foreach(var item in newList)
        {
            resList.Add(item);
        }

        return resList;
    }

    public void DeleteAllElBeforeMax()
    {
        var maxIndex = this.FindMaxIndex();
        Node? current = this.Tail;
        int i = this.Count - 1;

        do
        {
            if (i == maxIndex)
            {
                if (this.Head != current)
                {
                    this.Head?.Next = null;
                    this.Head = current;
                    this.Head?.Prev = null;
                }                
            }

            i--;
            current = current?.Prev;
        } while (current is not null);
    }
}
