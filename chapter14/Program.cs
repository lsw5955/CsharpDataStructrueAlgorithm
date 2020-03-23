using System;

class Program {
    static void Main()
    {
        CArray nums = new CArray(10);
        Random rnd = new Random(100);
        for (int i = 0; i < 10; i++) {
            nums.Insert(rnd.Next(0, 100));
        }
        Console.WriteLine("归并排序前: ");
        nums.DisplayElements();
        Console.WriteLine("归并排序中...: ");
        nums.MergeSort();
        Console.WriteLine("归并排序后: ");
        nums.DisplayElements();
        //rnd = new Random(100);
        //for (int i = 0; i < 10; i++) {
        //    nums[i]=rnd.Next(0, 100);
        //}
        //Console.WriteLine("插入排序前: ");
        //nums.DisplayElements();
        //Console.WriteLine("插入排序中...: ");
        //nums.InsertionSort();
        //Console.WriteLine("插入排序后: ");
        //nums.DisplayElements();
        Console.ReadLine();
    }
}