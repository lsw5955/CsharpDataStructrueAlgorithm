using System;

class Program {
    static void Main()
    {
        for (int x = 0; x < 3; x++) {
            int dataCount = 10;
            Heap heap = new Heap(dataCount);
            Random rnd = new Random(x);
            int temp = 0;
            Console.Write("随机数据为 : ");
            for (int i = 0; i < dataCount; i++) {
                temp = rnd.Next(100);
                Console.Write($"[{temp}]");
                heap.Insert(temp);
            }
            Console.WriteLine();
            Console.Write("堆当前顺序 : ");
            heap.ShowArray();
            Console.WriteLine();
            Console.Write("堆排序后为 : ");
            heap.HeapSort();
            heap.ShowArray();
            Console.WriteLine();
            Console.WriteLine("=================");
        }
        Console.ReadLine();
    }
}