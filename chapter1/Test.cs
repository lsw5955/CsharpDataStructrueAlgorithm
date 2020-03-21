/*
 请创建一个名为Test的类. 此类包含的数据成员有学生姓名和试卷整数编号. 这个类会在下述情况下使用：
 当学生提交测试时, 他们会把试卷面朝下放到桌子上. 
 如果某位学生需要检查自己试卷的答案, 那么老师就需要把试卷堆反过来以便第一份试卷在上面. 然后从第一份试卷开始顺次查找, 直到找到需要的试卷. 
 随后, 就把找到的试卷从试卷堆中取出来. 当学生检查完自己的试卷后, 再把此试卷重新放到试卷堆的末尾.
下面请编写一个窗口应用程序来模拟这种情况. 程序包含用户录入姓名和试卷编号的文本框. 还要有
一个格式列表框用来显示试卷的最终列表. 应用窗口需要提供四个操作按钮：
1. 提交试卷；
2. 学生查看试卷；
3. 返回一份试卷；
4. 退出.
请执行下列操作来测试你的应用程序：
1. 录入某姓名和试卷编号. 并且把试卷插入到名为submittedTests的群集里.
2. 录入某姓名, 从submittedTests中删除相关试卷, 并且把此试卷插入到名为outForChecking的群集里.
3. 录入学生姓名, 从outForChecking中删除相应试卷, 并且把此试卷插入到submittedTests中.
4, 点击退出按钮. 退出按钮不会终止应用程序, 而是从outForChecking中删除所有试
卷, 并且把它们全部插入到submittedTests中, 同时显示所有已提交的试卷列表.
 */

using System;

class Test {
    //试卷id
    public int id;
    //学生姓名
    public string studentName;
    
    public Test(int id,string studentName)
    {
        this.id = id;
        this.studentName = studentName;
    }

    static int InputId()
    {
        while (true) {
            try {
                Console.WriteLine("请输入试卷号 :");
                return int.Parse(Console.ReadLine());
            }
            catch {
                Console.Write("只能输入纯数字! ");
            }
        }
    }

    static string InputName()
    {
        Console.WriteLine("请输入学生名 :");
        return Console.ReadLine();
    }

    //1. 录入某姓名和试卷编号.并且把试卷插入到名为submittedTests的群集里.
    public static void Submit(Collection submittedTests)
    {
        Console.WriteLine("===录入试卷===");
        submittedTests.Add(new Test(InputId(), InputName()));
        Console.WriteLine("成功录入试卷");
    }

    //2. 录入某姓名, 从submittedTests中删除相关试卷, 并且把此试卷插入到名为outForChecking的群集里.
    public static void Check(Collection submittedTests, Collection outForChecking)
    {
        Console.WriteLine("===检阅试卷===");
        string targetName = InputName();
        //找到目标试卷
        foreach(Test test in submittedTests) {
            if(test.studentName == targetName) {
                outForChecking.Add(test);
                submittedTests.Remove(test);
                Console.WriteLine("成功检阅试卷");
                return;
            }
        }
        Console.WriteLine("试卷不存在");
    }

    //3. 录入学生姓名, 从outForChecking中删除相应试卷, 并且把此试卷插入到submittedTests中.
    public static void ReSubmit(Collection outForChecking, Collection submittedTests)
    {
        Console.WriteLine("===归还试卷===");
        string targetName = InputName();
        //找到目标试卷
        foreach (Test test in outForChecking) {
            if (test.studentName == targetName) {
                submittedTests.Add(test);
                outForChecking.Remove(test);
                Console.WriteLine("成功归还试卷");
                return;
            }
        }
        Console.WriteLine("试卷不存在");
    }

    //4, 点击退出按钮.退出按钮不会终止应用程序, 而是从outForChecking中删除所有试卷, 并且把它们全部插入到submittedTests中, 同时显示所有已提交的试卷列表.
    public static void MakePublic(Collection submittedTests , Collection outForChecking)
    {
        Console.WriteLine("===公示试卷===");
        foreach (Test test in submittedTests) {
            Console.Write($"[{test.id}号 : {test.studentName}] ");
        }

        foreach (Test test in outForChecking) {
            Console.Write($"[{test.id}号 : {test.studentName}] ");
            submittedTests.Add(test);
        }
        //不可以在foreach时候remove, 会导致foreach无法遍历报错
        outForChecking.Clear();

        Console.WriteLine();
        Console.WriteLine("成功公示试卷");
    }
}