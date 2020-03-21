using System;

public class Chapter4 {
    static void Main()
    {
        Random rnd = new Random();
        int num = 1000;                
        CArray ca = new CArray(num);
        for (int i = 0; i < num; i++) {
            //既然要用二叉, 那就得有序, 稍作处理, 随机且有序
            ca.Insert(i+rnd.Next(i));
        }
        ca.SeqSearch(734);
        Console.WriteLine($"顺序查找总共比较了{ca.compCount}次");
        ca.binSearch(734);
        Console.WriteLine($"二叉查找总共比较了{ca.compCount}次");
        Console.ReadLine();
    }
}