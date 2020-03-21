using System;
using System.IO;
using System.Collections;

//获取工作信息, 并且展示, 并进行优先级排序的类
class ToDoHelper {
    public void GetData()
    {
        PQueue toDoList = new PQueue();
        StreamReader numFile = File.OpenText("ToDoList.txt");
        WorkInfo wi;
        while (toDoList.Count < 5 && !numFile.EndOfStream) {
            wi = new WorkInfo(int.Parse(numFile.ReadLine()), int.Parse(numFile.ReadLine()), numFile.ReadLine());
            toDoList.Enqueue(wi);
            Console.WriteLine($"{wi.priority.ToString("D3")}--{wi.id.ToString("D5")}--{wi.date}");
        }
        toDoList.PrioritySort();
    }
}

//存储工作信息的类
class WorkInfo {
    public int priority;
    public int id;
    public string date;
    public WorkInfo(int p, int i, string d)
    {
        priority = p;
        id = i;
        date = d;
    }
    //重写了大于小于大于等于小于等于运算符, 为了利用CArray<T>进行排序
    public static bool operator >(WorkInfo self, WorkInfo other)
    {
        return self.priority > other.priority;
    }
    public static bool operator <(WorkInfo self, WorkInfo other)
    {
        return self.priority < other.priority;
    }
    public static bool operator >=(WorkInfo self, WorkInfo other)
    {
        return self.priority >= other.priority;
    }
    public static bool operator <=(WorkInfo self, WorkInfo other)
    {
        return self.priority <= other.priority;
    }
}

//非泛型的Queue才提供了可继承的各种虚方法
public class PQueue : Queue {

    public void PrioritySort()
    {
        Console.WriteLine("按照优先级排序了昂");
        //将当队列的数据转换为数组
        object[] temp = this.ToArray();
        CArray<WorkInfo> items = new CArray<WorkInfo>(temp.Length);
        for (int i = 0; i < temp.Length; i++) {
            items.arr[i] = (WorkInfo)temp[i];
        }
        //排序
        items.InsertionSort();
        for (int i = 0; i <= items.arr.GetUpperBound(0); i++) {
            //最高优先级, 也就是priority值最小的元素, 不加入队列, 它已经被Dequeue了
            Console.WriteLine($"{items.arr[i].priority.ToString("D3")}--{items.arr[i].id.ToString("D5")}--{items.arr[i].date}");
            this.Enqueue(items.arr[i]);
        }
    }
}

//用来给工作信息排序
class CArray<T> where T : WorkInfo {
    public T[] arr;
    private int upper;
    public CArray(int size)
    {
        arr = new T[size];
        upper = size - 1;
    }
    //添加到CArray类的插入排序函数
    public void InsertionSort()
    {
        int inner;
        T temp;
        //最外层循环从第二个元素开始, 到最后一个元素结束
        for (int outer = 1; outer <= upper; outer++) {
            temp = arr[outer]; //用中间变量hold住本次要插入的值
            inner = outer; //outer要标记循环的进度, 所以不能直接操作, 也用中间变量hold住 
            while (inner > 0 && arr[inner - 1] >= temp) {
                //只要是从本次要插入的值向前看, 但凡有比它大的数, 就往后移, 准备给它插入让出位置
                arr[inner] = arr[inner - 1];
                inner -= 1; //让位后索引向前移动一位
            }
            //最后一次让位后, inner也减了1, 所以正好指向空出来的位置, 狠狠插入
            arr[inner] = temp;
            //this.DisplayElements();
        }
    }
}