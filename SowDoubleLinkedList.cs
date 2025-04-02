using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
public class NodeCircular<T>
{
    #region Private Variables
    private T value;
    private NodeCircular<T> next;
    private NodeCircular<T> previous;
    #endregion

    #region Public Properties
    public T Value => value;
    public NodeCircular<T> Next => next;
    public NodeCircular<T> Previous => previous;
    #endregion

    #region Constructors
    public NodeCircular(T value)
    {
        this.value = value;
        this.next = this;
        this.previous = this;
    }
    #endregion

    #region Public Methods
    public void SetNext(NodeCircular<T> value)
    {
        next = value;
    }
    public void SetPrevious(NodeCircular<T> value)
    {
        previous = value;
    }
    #endregion
}

public  class SowDoubleLinkedList<T> : MonoBehaviour
{
    public NodeCircular<T> Root;

    public NodeCircular<T> Last;

    public int count = 0;

    public virtual void Add(T value)
    {
        NodeCircular<T> newNode = new NodeCircular<T>(value);
        count++;

        if (Root == null)
        {
            Root = newNode;

            Root.SetNext(Root);
            Root.SetPrevious(Root);

            Last = Root;
            return;
        }
        
        
        Last.SetNext(newNode);

        newNode.SetPrevious(Last);
        newNode.SetNext(Root);

        Root.SetPrevious(newNode);

        Last = newNode;


        print("The Root is " + Root.Value.ToString() +"And the lenght of the list is : " +count);
        print("New head is " + Last.Value.ToString());
        print("Head next is " + Last.Next.Value.ToString());
        print("Head previous is " + Last.Previous.Value.ToString());

    }
    /// <summary>
    /// Hola chicos! estamos personalisando aun mas un metodo!!!!!!!!!
    /// </summary>
    /// <param name="CurrentHead">
    /// </param>
    /// <param name="depth"></param>
    public virtual void ReadAllList(NodeCircular<T> CurrentHead = null ,int depth = 0)
    {
        if (Root == null)
        {
            print("List is empty");
            return;
        }
        if (depth >= count)
        {
            print("DONE");
            return;

        }

        if (CurrentHead == null)
            CurrentHead = Root;


         print("" + CurrentHead.Value.ToString());
        print(" ↓ ");

        ReadAllList(CurrentHead.Next, depth + 1);

    }
    public virtual void ClearAll()
    {
        Root = null;
        Last = null;
        count = 0;
    }
    [Button]
    public virtual void Search(T value , NodeCircular<T> CurrentHead = null , int depth = 0)
    {
        if(Root == null)
        {
            print("List is empty");
            return;
        }
        
        if (CurrentHead == null)
            CurrentHead  =  Root;


        print("New head is " + CurrentHead.Value.ToString());
        print("Head next is " + CurrentHead.Next.Value.ToString());

        if (depth > count)
        {
            print("Value not found");
            return;
        }
        if (CurrentHead.Value.Equals(value))
        {
            print("Origin value found: " + value.ToString());
            print("After: " + depth + " Iterations");
            return;
        }

        Search(value, CurrentHead.Next ,depth+1);
    }
}
