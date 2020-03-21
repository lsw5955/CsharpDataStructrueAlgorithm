using System;
using System.Collections;

class chapter6 {
    static void Main()
    {
        int numCount = 10000;
        Timing tm = new Timing();
        CArray ca = new CArray(numCount);
        BitArray bitArr = new BitArray(numCount);
        tm.StartTime();
        ca.GenPrimes();
        tm.StopTime();
        Console.WriteLine($"常规数组筛选{numCount}以内素数耗时{tm.Result().TotalMilliseconds}毫秒");
        tm.StartTime();
        BitArrayGetPrime1(bitArr);
        tm.StopTime();
        Console.WriteLine($"BitArr无脑遍历筛选{numCount}以内素数耗时{tm.Result().TotalMilliseconds}毫秒");
        tm.StartTime();
        BitArrayGetPrime2(bitArr);
        tm.StopTime();
        Console.WriteLine($"BitArr使用平方根遍历筛选{numCount}以内素数耗时{tm.Result().TotalMilliseconds}毫秒");
        Console.ReadLine();
    }
    //使用无脑遍历方法
    static void BitArrayGetPrime1(BitArray bits)
    {
        for (int i = 0; i < bits.Count; i++)
            bits.Set(i, true);
        for (int outer = 2; outer < bits.Count; outer++)
            for (int inner = outer + 1; inner < bits.Count; inner++)
                if (bits.Get(inner))
                    if (inner % outer == 0)
                        bits.Set(inner, false);
    }
    //使用平方根方法
    static void BitArrayGetPrime2(BitArray bits)
    {
        for (int i = 0; i < bits.Count; i++)
            bits.Set(i, true);
        int bit = Convert.ToInt32(Math.Sqrt(bits.Count));
        for (int outer = 2; outer <= bit; outer++)
            for (int inner = 2; inner * outer < bits.Count; inner++)
                if (bits.Get(inner * outer))
                    bits.Set(inner * outer, false);
    }
}
