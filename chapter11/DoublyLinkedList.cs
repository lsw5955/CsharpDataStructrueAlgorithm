using System;


public class DoublyLinkedList {
    protected Node header;
    public DoublyLinkedList()
    {
        header = new Node("header");
    }

    public void InsertEnd(object item)
    {
        Node end = header;
        while(end.Flink != null){
            end = end.Flink;
        }
        end.Flink = new Node(item);
        end.Flink.Blink = end;
    }

    private Node Find(Object item)
    {
        Node current = new Node();
        //从头结点开始
        current = header;
        //一个一个节点的寻找Element字段与item参数一致的节点
        //原文没有考虑item对应的节点不存在的情况, 会出问题,我加上了current==null的判断
        while (!(current == null) && (current.Element != item)) {
            current = current.Flink;
        }
        return current;
    }

    public void Insert(Object newItem, Object after)
    {
        Node current = Find(after);
        Node newNode = new Node(newItem);
        //要在after代表的Node后插入值为newItem的节点
        //第一步就是找到after代表的节点
        //原文代码没有考虑after代表的节点不存在的情况, 我加上了对应的判断
        if (current != null) {
            //新节点的下一个节点链接指向after所对应节点的下一个节点链接
            newNode.Flink = current.Flink;
            //新节点的上一个链接指向after对应的节点, 也就是current
            newNode.Blink = current;
            //after对应的节点, 也就是current, 下一个节点链接指向新节点
            current.Flink = newNode;
        }
        else
            Console.WriteLine("插入新节点失败! 没有找到指定的前置节点");
    }
    //对于双向链表来说不需要该方法了
    private Node FindPrevious(Object item)
    {
        Node current = header;
        //如果current.link为null. 说明找到末尾了, 不存在这个节点
        //否则只要当前节点的link指向节点的Element与item参数不一致, 就继续向后找
        while (!(current.Flink == null) && (current.Flink.Element != item))
            current = current.Flink;
        return current;
    }

    public void Remove(Object n)
    {
        Node p = Find(n);
        if (p != null) {
            p.Blink.Flink = p.Flink;
            p.Flink.Blink = p.Blink;
            //以下两句存疑, 对于C#来说应该是没必要的, 因为GC机制会自动清理不被任何地方引用的引用类型
            //通过上面那两步操作, p节点已经没有任何地方引用了
            p.Flink = null;
            p.Blink = null;
        }
        Console.WriteLine("移除节点失败! 没有找到要移除的节点");
    }
    //寻找最后一个节点
    private Node FindLast()
    {
        Node current = new Node();
        current = header;
        while (current.Flink != null)
            current = current.Flink;
        return current;
    }
    //反向输出链表内容
    public void PrintReverse()
    {
        Node current = new Node();
        current = FindLast();
        while (current.Blink != null) {
            Console.WriteLine(current.Element);
            current = current.Blink;
        }
    }

    public Node GetFirst()
    {
        return header;
    }
}