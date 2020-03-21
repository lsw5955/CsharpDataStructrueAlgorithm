using System;

class CArray {
    private int[] arr;
    private int upper;
    private int numElements;
    public CArray(int size)
    {
        arr = new int[size];
        upper = size - 1;
        numElements = 0;
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
        for (int outer = 0; outer <= upper-1; outer++) {
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