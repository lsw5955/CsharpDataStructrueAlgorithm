using System;
using System.Collections;

class Program {
    static void Main()
    {
        int size = 1000;
        int optTimes = 1000;
        Timing tm = new Timing();
        CSet HashSetA = new CSet();
        CSet HashSetB = new CSet();
        ArrayListCSet ArraySetA = new ArrayListCSet();
        ArrayListCSet ArraySetB = new ArrayListCSet();

        for (int i = 0; i < size; i++) {
            HashSetA.Add(i);
            HashSetB.Add(i + 500);
            ArraySetA.Add(i);
            ArraySetB.Add(i + 500);

        }
        Console.WriteLine($"对比不同实现的集合类, {size}条数据执行{optTimes}次操作 :");
        Console.Write("Hashtable集合 :");
        tm.StartTime();
        for (int i = 0; i < optTimes; i++) {
            HashSetA.Difference(HashSetB);
        }
        tm.StopTime();
        Console.WriteLine($"差集耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.Write("ArrayList集合 :");
        tm.StartTime();
        for (int i = 0; i < optTimes; i++) {
            ArraySetA.Difference(ArraySetB);
        }
        tm.StopTime();
        Console.WriteLine($"差集耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.WriteLine("==========================");
        Console.Write("Hashtable集合 :");
        tm.StartTime();
        for (int i = 0; i < optTimes; i++) {
            HashSetA.Intersection(HashSetB);
        }
        tm.StopTime();
        Console.WriteLine($"交集耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.Write("ArrayList集合 :");
        tm.StartTime();
        for (int i = 0; i < optTimes; i++) {
            ArraySetA.Intersection(ArraySetB);
        }
        tm.StopTime();
        Console.WriteLine($"交集耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.WriteLine("==========================");
        Console.Write("Hashtable集合 :");
        tm.StartTime();
        for (int i = 0; i < optTimes; i++) {
            HashSetA.Union(HashSetB);
        }
        tm.StopTime();
        Console.WriteLine($"并集耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.Write("ArrayList集合 :");
        tm.StartTime();
        for (int i = 0; i < optTimes; i++) {
            ArraySetA.Union(ArraySetB);
        }
        tm.StopTime();
        Console.WriteLine($"并集耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.WriteLine("==========================");

        Console.ReadLine();
    }
}