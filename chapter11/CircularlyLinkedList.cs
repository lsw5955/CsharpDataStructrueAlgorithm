using System;

class CircularlyLinkedList {
    protected Node header;
    //标记一个节点作为当前操作的起点位置
    public Node current;
    //计数链表数据数量
    private int count;
    public CircularlyLinkedList()
    {
        //头节点只是用来标记链表的开始位置而不是有逻辑意义的数据, 所以初始化时count设为0.
        count = 0;
        header = new Node("header");
        header.Flink = header;
        current = header.Flink;
    }

    public bool IsEmpty()
    {
        //如果头节点的Flink为null, 等于说链表是空的
        return (header.Flink == null);
    }

    public void MakeEmpty()
    {
        //头节点的Flink设置为null, 链表原有的所有其他节点都无法访问了. 链表也就表现为空了
        header.Flink = null;
    }
    //打印链表内容
    public void PrintList()
    {
        Node current = new Node();
        current = header;
        //如果某个节点的Flink的Element为"header", 说明已经到达了链表末尾
        while (current.Flink.Element.ToString() != "header") {
            Console.WriteLine(current.Flink.Element);
            current = current.Flink;
        }
    }
    //寻找指定item数据节点的上一个节点
    private Node FindPrevious(Object item)
    {
        Node target = current;
        //原文代码还判断了current.Flink != null, 应该改成current.Flink != current
        //否则, 对于循环列表, 如果只有一个头节点, 而且其Element还不等于item, 这个while就死循环了
        while (target.Flink != current && target.Flink.Element != item)
            target = target.Flink;
        return target;
    }
    //寻找指定节点
    private Node Find(Object item)
    {
        Node target = current;
        //一个一个节点的寻找Element字段与item参数一致的节点
        //原文没有考虑item与current导致死循环的情况, 我加上了target != current的判断
        while ((target != current) && (target.Element != item)) {
            target = target.Flink;
        }
        return target;
    }

    public void Remove(Object n)
    {
        //原文没加这个count>0的判断
        if (count > 0) {
            Node targetPrevious = FindPrevious(n);
            if (targetPrevious.Flink != null) {
                //这里有趣的地方就是, 如果只剩下一个节点了, 始终也不会移除掉的
                targetPrevious.Flink = targetPrevious.Flink.Flink;
                //下面这句我新增的, 移除一个节点之后, 将其原来的下一个节点设置为当前节点
                //也方便做练习2
                current = targetPrevious.Flink;
                //原文代码的count--在if之外, 逻辑不对
                count--;
            }
        }
    }

    public void Insert(Object newValue, Object targetValue)
    {
        //修改了原文代码, 让插入节点后, current等于新节点
        current = Find(targetValue);
        Node newnode = new Node(newValue);
        current.Flink = newnode;
        newnode.Flink = current.Flink;
        count++;
    }

    public void InsertFirst(Object n)
    {
        //修改了原文代码, 让插入节点后, current等于新节点
        current = new Node(n);
        //原文写的current.Flink = header, 逻辑不对, 已修正
        current.Flink = header.Flink;
        header.Flink = current;        
        count++;
    }
    //跟原文代码出入较大, 原文始终从头结点开始找第n个元素, 
    //我改成了从current节点向后找第n个元素
    //这也方便做练习2的题目
    public Node Move(int n)
    {
        //以current为起点的第n个节点设置为current
        for (int i = 0; i < n; i++)
            current = current.Flink;
        //如果最后指向的是头节点, 无数据意义, 向后移动一位
        //如果表中只有头节点, 那么最后还是只能得到头节点
        if (current.Element.ToString() == "header")
            current = current.Flink;
        //前面任何分支都没有用到temp, 方法返回前把current赋值给temp? 直接返回current不好吗?
        //已修改, 注释的是原文代码
        //temp = current;
        //return temp;
        return current;
    }

    public Node getFirst()
    {
        return header;
    }
    //新增, 方便做练习2
    //让current指向第一个有数据意义的节点
    public void Reset()
    {
        current = header.Flink;
    }
}