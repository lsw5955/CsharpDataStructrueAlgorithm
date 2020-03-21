using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program {
    static void Main()
    {
        Exercise3BST nums = new Exercise3BST();
        nums.InsertFromFile("Test.txt");
        Console.WriteLine($"{nums.root.Data}是根节点, 先序遍历节点顺序 : ");
        nums.InOrder(nums.root);
        while (true) {
            Console.WriteLine();
            Console.Write($"请输入要搜索的数字节点 : ");
            string Data = Console.ReadLine();
            nums.Exercise1(Data, 0);
            nums.Exercise1(Data, 1);
            nums.Exercise1(Data, 2);
        }

        //List<int> l = new List<int>();
        //int randomIndex = 0;
        //int count = 10;
        //for (int i = 0; i < count; i++) {
        //    l.Add(i + 1);
        //}
        ////不重复随机数
        //for (int i = 0; i < count; i++) {
        //    randomIndex = rnd.Next(0, l.Count);
        //    nums.Insert(l[randomIndex]);
        //    l.RemoveAt(randomIndex);
        //}
        //while (true) {
        //    Console.WriteLine();
        //    Console.Write($"请输入要删除的数字节点 : ");
        //    nums.Delete(int.Parse(Console.ReadLine()));
        //    Console.WriteLine($"删除后, {nums.root.Data}是根节点, 先序遍历节点顺序 : ");
        //    nums.InOrder(nums.root);
        //}

        Console.ReadLine();
    }
}