using System;
using System.Collections;

class Program {
    static void Main()
    {
        Collection submittedTests = new Collection();
        Collection outForChecking = new Collection();

        string command;
        while (true) {
            Console.WriteLine("请输入指令 :");
            Console.Write("===1:录入试卷");
            Console.Write("===2:检阅试卷");
            Console.Write("===3:归还试卷");
            Console.Write("===4:公示试卷");
            Console.WriteLine("===5:100W整数大对决!!!");
            command = Console.ReadLine();
            switch (command) {
                case "1":
                    Test.Submit(submittedTests);
                    break;
                case "2":
                    Test.Check(submittedTests, outForChecking);
                    break;
                case "3":
                    Test.ReSubmit(outForChecking, submittedTests);
                    break;
                case "4":
                    Test.MakePublic(submittedTests, outForChecking);
                    break;
                case "5":
                    CollectionVSArrayList1000000Int ct = new CollectionVSArrayList1000000Int();
                    ct.TimeTest();
                    break;
                case "6":
                    sumNums();
                    break;
                default:
                    Console.Write("指令无效, 请重新录入! ");
                    break;
            }
        }
    }

    static void sumNums()
    {
        ArrayList names = new ArrayList();
        names.Add("名字0");
        names.Add("名字1");
        names.Add("名字2");
        names.Add("名字3");
        names.Add("名字4");
        Object[] arrNames;
        arrNames = names.ToArray();
        Console.WriteLine("ArrayList.ToArray方法转换出来的数组: ");
        for (int i = 0; i <= arrNames.GetUpperBound(0); i++)
            Console.WriteLine(arrNames[i]);
    }
}