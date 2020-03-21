using System;
using System.Collections;

class CollectionVSArrayList1000000Int {

    Collection collection;
    ArrayList arrayList;
    Timing timing;
    int[] a = new int[] { 1,2,3};
    public CollectionVSArrayList1000000Int()
    {
        collection = new Collection();
        arrayList = new ArrayList();
        timing = new Timing();
    }

    public void TimeTest()
    {
        TimeSpan temp;
        timing.StartTime();
        for(int i= 0; i < 1000000; i++) {
            collection.Add(i);
            //Console.Write($"{i} ");
        }
        timing.StopTime();
        temp = timing.Result();
        timing.StartTime();
        for (int i = 0; i < 1000000; i++) {
            arrayList.Add(i);
            //Console.Write($"{i} ");
        }
        timing.StopTime();
        Console.WriteLine("");
        Console.WriteLine($"添加1000000个整数对决! collection耗时{temp.TotalSeconds}秒,arrayList耗时{timing.Result().TotalSeconds}秒");
        Console.ReadKey();
    }
}
