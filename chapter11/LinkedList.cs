using System;

public class LinkedList {
    private Node header;
    public LinkedList()
    {
        header = new Node("header");
    }

    public bool IsEmpty()
    {
        return (header.Flink == null);
    }

    public Node GetFirst()
    {
        return header;
    }

    public void ShowList()
    {
        Node current = header.Flink;
        while (current != null) {
            Console.WriteLine(current.Element);
            current = current.Flink;
        }
    }
}