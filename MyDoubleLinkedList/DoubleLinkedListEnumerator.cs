using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyDoubleLinkedList;

public class DoubleLinkedListEnumerator : IEnumerator<double>
{
    private Node? currentEl;
    private Node? head;

    public DoubleLinkedListEnumerator(Node? head)
    {
        this.head = head;
        this.Reset();
    }

    public double Current
    {
        get
        {
            if (this.currentEl is null)
            {
                throw new InvalidOperationException("The current element is null");
            }

            return this.currentEl.Data;
        }
    }

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {        
    }

    public bool MoveNext()
    {
        if (this.currentEl is not null && this.head is not null)
        {
            this.currentEl = this.currentEl?.Next;
            
            if (this.currentEl is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public void Reset()
    {
        Node? beginNode = new Node();
        beginNode.Next = this.head;
        this.currentEl = beginNode;
    }
}
