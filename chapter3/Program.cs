using System;

namespace chapter3 {
    class Program {
        static void Main()
        {
            //原文用的100, 1000和10000, 我的电脑已经是成书10年后的电脑了太快, 1000个元素的话时间全是0
            //我改成了5000, 50000, 500000
            int numItems = 100000;
            TimingComparison(numItems,"顺序");
            TimingComparison(numItems,"倒序");
            TimingComparison(numItems,"随机");
            Console.ReadLine();
        }

        static void TimingComparison(int numItems, string mode)
        {
            Console.WriteLine(numItems + "个"+ mode + "元素排序时:");
            Timing sortTime = new Timing();
            CArray theArray = CreateCArray(numItems, mode);
            sortTime.StartTime();
            theArray.SelectionSort();//注释掉方法里的this.DisplayElements(), 不然运行到天荒地老
            sortTime.StopTime();
            Console.WriteLine("选择排序耗时:" + sortTime.Result().TotalMilliseconds + "毫秒");
            theArray.Clear();
            theArray = CreateCArray(numItems, mode);
            sortTime.StartTime();
            theArray.BubbleSort();//注释掉方法里的this.DisplayElements(), 不然运行到天荒地老
            sortTime.StopTime();
            Console.WriteLine("冒泡排序耗时:" + sortTime.Result().TotalMilliseconds + "毫秒");
            theArray.Clear();
            theArray = CreateCArray(numItems, mode);
            sortTime.StartTime();
            theArray.InsertionSort();//注释掉方法里的this.DisplayElements(), 不然运行到天荒地老
            sortTime.StopTime();
            Console.WriteLine("插入排序耗时:" + sortTime.Result().TotalMilliseconds + "毫秒");
            Console.WriteLine();
        }

        static CArray CreateCArray(int numItems, string mode)
        {
            CArray theArray = new CArray(numItems);
            Random rnd = new Random(100);
            switch (mode) {
                case "随机":
                    for (int i = 0; i < numItems; i++) {
                        theArray.Insert(rnd.Next());
                    }
                    break;
                case "顺序":
                    for (int i = 0; i < numItems; i++) {
                        theArray.Insert(i);
                    }
                    break;
                case "倒序":
                    for (int i = 0; i < numItems; i++) {
                        theArray.Insert(numItems - i);
                    }
                    break;
                default:
                    break;
            }
            return theArray;
        }

    }
}
