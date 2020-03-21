using System;

class CArray {
    private int[] arr;
    private int upper;
    private int numElements;
    public int compCount;//用于记录顺序查找与二叉查找的比较次数
    public CArray(int size)
    {
        arr = new int[size];
        upper = size - 1;
        numElements = 0;
    }
    //内置的二叉搜索
    public int Bsearh(int value)
    {
        return Array.BinarySearch(arr, value);
    }

    //常规的顺序算法只会寻找第一个满足条件的元素, 
    //请设计一种新的顺序搜索算法, 该算法可以指定要搜索第几次出现的目标值.
    public int TimesSequentialSearch(int value, int times)
    {
        //顺序遍历
        for (int i = 0; i < arr.Length; i++) {            
            if (arr[i] == value) {
                //找到一个值就将time-1
                times--;
                if (times == 0) {     
                    //如果times变成0了说明已经找到了
                    return i;
                }                
            }
        }
        return -1;
    }


    /// <summary>
    /// 递归的二叉搜索, 后两个参数让你手动指定在数据的哪一段执行二叉搜索
    /// </summary>    
    public int RbinSearch(int value, int lower, int upper)
    {
        //如果下限大于上限了, 说明已经全部搜索完成, 没有找到目标数据        
        if (lower > upper)
            return -1;
        else {
            int mid;
            mid = (int)(upper + lower) / 2;
            if (value < arr[mid])
                //将原来循环迭代的方式, 改成递归的方式, 使用新的搜索范围作为参数再次调用自身
                return RbinSearch(value, lower, mid - 1);
            else if (value == arr[mid])
                return mid;
            else
                //将原来循环迭代的方式, 改成递归的方式, 使用新的搜索范围作为参数再次调用自身
                return RbinSearch(value, mid + 1, upper);
        }
    }

    /// <summary>
    /// 循环迭代的二叉搜索
    /// </summary>    
    public int binSearch(int value)
    {
        compCount = 0;
        int upperBound, lowerBound, mid;
        //上限索引初始为最后一个索引
        upperBound = arr.Length - 1;
        //下限索引初始为第一个索引
        lowerBound = 0;
        //一直搜索到上下限索引重合
        while (lowerBound <= upperBound) {
            compCount++;
            //寻找中间点位置
            mid = (upperBound + lowerBound) / 2;
            //Console.Write($"搜索第{mid}位...");
            if (arr[mid] == value) {
                //搜索到元素后返回索引
                //Console.WriteLine();
                return mid;
            }
            else if (value < arr[mid])
                //本轮没搜索到, 如果搜索的值偏小, 则将中间索引前面的索引作为新的上限
                upperBound = mid - 1;
            else
                //本轮没搜索到, 如果搜索的值偏大会, 则将中间索引后面的索引作为新的下限
                lowerBound = mid + 1;
        }
        //执行到这里表示没找到
        //Console.WriteLine();
        return -1;
    }

    public int SeqSearch(int sValue)
    {
        compCount = 0;
        for (int index = 0; index < arr.Length; index++) {
            compCount++;
            if (arr[index] == sValue) {
                //如果搜到了, 还需要检查是否远于指定位置,                 
                if (index > arr.Length * 0.2) {
                    //如果远于指定位置, 则进行数据自组织交换优化
                    swap(index);
                    //优化后始终位于第一位
                    return 0;
                }
                else if (arr[index] == sValue)
                    //如果已经比较靠前, 搜索速度可以接受, 不进行自组织优化, 直接返回索引
                    return index;
            }
        }
        return -1;
    }

    void swap(int index)
    {
        int temp = arr[index];
        //类似冒泡排序的移动方法, 接将指定位置的元素冒泡到第一位
        for (int i = index; i > 0; i--) {
            arr[i] = arr[i - 1];
        }
        arr[0] = temp;
    }

    public void Insert(int item)
    {
        arr[numElements] = item;
        numElements++;
    }

    public void DisplayElements()
    {
        for (int i = 0; i <= upper; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
    public void Clear()
    {
        for (int i = 0; i <= upper; i++)
            arr[i] = 0;
        numElements = 0;
    }

    public void BubbleSort()
    {
        int temp;
        for (int outer = upper; outer >= 1; outer--) {
            for (int inner = 0; inner <= outer - 1; inner++) {
                if ((int)arr[inner] > arr[inner + 1]) {
                    temp = arr[inner];
                    arr[inner] = arr[inner + 1];
                    arr[inner + 1] = temp;
                }
            }
            //this.DisplayElements();
        }
    }

    //添加到CArray类的选择排序函数
    public void SelectionSort()
    {
        int min, temp;
        //外层循环从0开始, 到upper-1结束,
        //此处原文代码写错了, 写的是outer<=upper, 外循环多了
        for (int outer = 0; outer <= upper - 1; outer++) {
            min = outer; //先将最小值索引指向当前外层循环的索引处
                         //内层循环从外层循环的索引后面一位开始, 到upper结束
            for (int inner = outer + 1; inner <= upper; inner++) {
                //在内层循环中找到从outer位开始到upper位之间的最小元素的索引
                if (arr[inner] < arr[min])
                    min = inner;
            }
            //内层循环结束后, 找到的最小元素与outer索引位置的元素进行位置交换
            temp = arr[outer];
            arr[outer] = arr[min];
            arr[min] = temp;
            //this.DisplayElements();
        }
    }
    //添加到CArray类的插入排序函数
    public void InsertionSort()
    {
        int inner, temp;
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