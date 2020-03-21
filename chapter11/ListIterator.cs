using System;

class InsertBeforeHeaderException : Exception {
    public InsertBeforeHeaderException() : base("向前插入节点失败! 当前已是头节点")
    {
    }
}

public class ListIterator {
    //代表当前节点
    private Node current;
    //代表前一个节点
    private Node previous;
    LinkedList theList;
    public ListIterator(LinkedList list)
    {
        theList = list;
        //自己在;链表类添加一个GetFirst方法, 返回header即可
        current = theList.GetFirst();
        previous = null;
    }

    public void Reset()
    {
        current = theList.GetFirst();
        previous = null;
    }

    public bool AtEnd()
    {
        return (current.Flink == null);
    }

    public void Remove()
    {
        //原文代码只写了一句previous.Flink = current.Flink;
        //没有在移除节点后设置current, 这样会出错
        //如果只是让previous的Flink的引用不再指向current, current依然还在引用被移除的节点, 这样没有删除掉
        current = current.Flink;
        previous.Flink = current;
    }

    public void InsertAfter(Object theElement)
    {
        Node newnode = new Node(theElement);
        newnode.Flink = current.Flink;
        current.Flink = newnode;
        Nextlink();
    }

    public void Nextlink()
    {
        previous = current;
        current = current.Flink;
    }

    public Node GetCurrent()
    {
        return current;
    }

    public void InsertBefore(Object theElement)
    {
        Node newNode = new Node(theElement);
        if (current == theList.GetFirst())
            throw new InsertBeforeHeaderException();
        else {
            //新节点指向current, 此处用previous.Flink和current结果都是一样
            //但是用current应该更快
            newNode.Flink = previous.Flink;
            previous.Flink = newNode;
            current = newNode;
        }
    }
}