using System;

public class Node {
    public Object Element;
    //指向下一个节点
    public Node Flink;
    //指向上一个节点
    public Node Blink;
    public Node()
    {
        Element = null;
        Flink = null;
        Blink = null;
    }

    public Node(Object theElement)
    {
        Element = theElement;
        Flink = null;
        Blink = null;
    }
}