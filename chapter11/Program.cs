using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program {

    static void Main()
    {
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("张三");
        linkedList.AddLast("李四");
        linkedList.AddLast("王五");
        linkedList.AddLast("赵六");
        linkedList.AddLast("陈七");
        Exercise4(linkedList);
        Console.Read();
    }
    /*请设计并实现ToArray方法, 来把内置的泛型LinkedList类对象数据转换为一个数组. 
     * 此方法需要一个接受一个泛型LinkedList实例参数并且返回一个数组, 
     * 不可以使用泛型LinkedList类的CopyTo函数.
     */
    static object[] Exercise4<T>(LinkedList<T> linkedList)
    {
        object[] arr = new object[linkedList.Count];
        LinkedListNode<T> tempNode = linkedList.First;
        for (int i = 0; i < linkedList.Count; i++) {
            arr[i] = tempNode.Value;
            tempNode = tempNode.Next;
            Console.WriteLine($"数组第{i}个元素是:{arr[i].ToString()}");
        }
        return arr;
    }

    /*根据传说, 第一世纪的犹太历史学家 Flavius Josephus 在犹太人与罗马人的战争中
     * 和40 名同胞一起被罗马士兵抓获. 这些被俘的士兵宁愿自杀也不愿当俘虏, 
     * 而且他们还设计一种方案来依次自杀. 他们站成一个圈, 然后每隔三名士兵就有一位自杀, 
     * 直到所有人都死掉为止. Joseph和另外一个人不想这样死去, 
     * 他们快速地计算出自己在圈中所站的位置以便他俩都可以幸存下来. 
     * 请编写一个程序允许由n 个人围成一个圈, 而且指定每隔m个人就会杀死一位. 
     * 这个程序应该确定出留在圈中最后两人的编号. 请用循环链表来解决这个问题.
     */
    //n个人, 每隔m升天一个
    static void Exercise2(int n, int m)
    {
        CircularlyLinkedList cll = new CircularlyLinkedList();
        //按照12345...的值增加节点, 注意我是从大到循环的,所以每次都是插入在首位
        for (int i = n; i > 0; i--) {
            cll.InsertFirst(i);
        }
        Console.WriteLine($"{n}个熊弟整整齐齐站一排 :");
        for (int i = 0; i < n; i++) {
            Console.Write($"[{cll.current.Element}] ");
            cll.Move(1);
        }
        //从头开始挑人, 第一个不击毙, 往后数第m个人升天
        cll.Reset();
        //最后两个不干死, 看看到底是谁这么幸运
        for (int i = 0; i < n - 2; i++) {
            cll.Move(m);
            cll.Remove(cll.current.Element);
        }
        cll.Reset();
        Console.WriteLine();
        Console.WriteLine($"大家说好每隔{m}个人就一头磕死到地上, 直到全都见上帝");
        Console.WriteLine($"结果{n - 2}个熊弟英勇就义后,还剩下[{cll.current.Element}]和[{cll.current.Flink.Element}]这俩鸡贼回家了");
    }

    /*请编写一个程序可以读取C#代码的不确定行数, 
     * 并且把保留字(reserved words)存储在一个链表内, 
     * 而把标识符( identifiers)和字面量(literals)存储在另一个链表里. 
     * 当程序完成读取输入的时候, 显示出每个链表的内容.
     */
    static void Exercise3()
    {
        //利用正则, 列出几种作为示意
        Regex regReserved = new Regex(@"int|float|string");
        Regex regIdentifierAndLiteral = new Regex(@"(?<=((int|float|string)\s)).+(?=;)");
        LinkedList<string> linkedList1 = new LinkedList<string>();
        LinkedList<string> linkedList2 = new LinkedList<string>();
        string temp = "";
        using (StreamReader sr = new StreamReader("Test.txt")) {
            while (sr.Peek() != -1) {
                temp = sr.ReadLine();
                linkedList1.AddLast(regReserved.Match(temp).ToString());
                Console.Write("保留字 :" + regReserved.Match(temp).ToString());
                linkedList2.AddLast(regIdentifierAndLiteral.Match(temp).ToString());
                Console.WriteLine(" || 标识符和字面量 :" + regIdentifierAndLiteral.Match(temp).ToString());
            }
        }
    }
}