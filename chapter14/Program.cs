using System;

class Program {
    static void Main()
    {
        Timing tm = new Timing();
        Random rnd = new Random();        
        int dataCount = 1000;
        //要循环多次的时间才能看到差异, 根据自己电脑性能选择适合你的次数
        int loopTimes = 20;
        TimeSpan ts1 = new TimeSpan();
        TimeSpan ts2 = new TimeSpan();
        int temp;
        CArray quickData = new CArray(dataCount);
        CArray insertionData = new CArray(dataCount);   
        for (int i = 0; i < dataCount; i++) {
            quickData.Insert(i);
            insertionData.Insert(i);
        }
        for (int i = 0; i < loopTimes; i++) {
            //每次都打乱顺序
            for (int j = 0; j < dataCount/2; j++) {
                temp = rnd.Next(dataCount);
                quickData.Swap(j,temp);
                insertionData.Swap(j, temp);
            }
            //记得注释掉所有排序函数中显示每一步排序结果的代码
            tm.StartTime();
            quickData.QSort();
            tm.StopTime();
            ts1 += tm.Result();
            tm.StartTime();
            quickData.InsertionSort();
            tm.StopTime();
            ts2 += tm.Result();
        }
        Console.WriteLine($"===={loopTimes}次排序{dataCount}条随机数据====");
        Console.WriteLine($"快速排序耗时{ts1.TotalMilliseconds}毫秒");
        Console.WriteLine($"插入排序耗时{ts2.TotalMilliseconds}毫秒");
        Console.ReadLine();
    }
    static void SortAlgorithmsCompare(int dataCount, Random rnd,Timing tm)
    {
        CArray shellData = new CArray(dataCount);
        CArray mergeData = new CArray(dataCount);
        Heap heapData = new Heap(dataCount);
        CArray quickData = new CArray(dataCount);
        CArray testData = new CArray(dataCount);
        int temp;
        for (int i = 0; i < dataCount; i++) {
            temp = rnd.Next(100);
            shellData.Insert(temp);
            mergeData.Insert(temp);
            heapData.Insert(temp);
            quickData.Insert(temp);
            testData.Insert(temp);
        }
        //记得注释掉所有排序函数中显示每一步排序结果的代码
        tm.StartTime();
        shellData.ShellSort();
        tm.StopTime();
        Console.WriteLine($"希尔排序耗时{tm.Result().TotalMilliseconds}毫秒");
        tm.StartTime();
        mergeData.MergeSort();
        tm.StopTime();
        Console.WriteLine($"归并排序耗时{tm.Result().TotalMilliseconds}毫秒");
        tm.StartTime();
        heapData.HeapSort();
        tm.StopTime();
        Console.WriteLine($"堆排序耗时{tm.Result().TotalMilliseconds}毫秒");
        tm.StartTime();
        quickData.QSort();
        tm.StopTime();
        Console.WriteLine($"快速排序耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.WriteLine();
    }
}