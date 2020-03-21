using System;
using System.Diagnostics;

//用于进行基于线程的代码执行计时
public class Timing {
    //记录开始时间
    TimeSpan startingTime;
    //记录经过时间
    TimeSpan duration;
    public Timing()
    {
        startingTime = new TimeSpan(0);
        duration = new TimeSpan(0);
    }

    public void StopTime()
    {
        //获得指定线程从startingTime开始, 经过的时间
        duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingTime);
    }

    public void StartTime()
    {
        //手动调用GC过程, 降低程序运行期间发生GC的可能性
        GC.Collect();
        //等待GC结束的信号 再继续执行代码
        GC.WaitForPendingFinalizers();
        //记录指定线程的当前时间
        startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
    }
    public TimeSpan Result()
    {
        //返回计时结果
        return duration;
    }
}