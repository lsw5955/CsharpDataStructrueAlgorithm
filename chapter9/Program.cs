using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program {
    static void Main()
    {
        //IPAddresses ip = new IPAddresses("Test.txt");
        //ip.Exercise1();
        Exercise6();
        Console.ReadLine();
    }

    /*请编写一个用字典存储名字和电话号码的程序, 
     * 其中把名字作为关键字. 并且编写方法来进行反向搜索, 
     * 也就是说根据电话号码来找到名字. 还要编写一个窗口应用程序来测试实现.
     */
    static void Exercise2()
    {        
        string line;
        string[] words;
        Dictionary<string, string> dic = new Dictionary<string, string>();
        StreamReader inFile;
        inFile = File.OpenText("Test1.txt");
        Console.WriteLine("电话本内容 : ");
        while (inFile.Peek() != -1) {            
            line = inFile.ReadLine();            
            words = line.Split(',');
            Console.WriteLine($"{words[0]}{words[1]}");
            dic.Add(words[0], words[1]);
        }
        inFile.Close();
        Console.Write("请输入电话查询姓名 : ");
        string value = Console.ReadLine();
        foreach (KeyValuePair<string,string> item in dic) {
            if(item.Value== value) { 
                Console.WriteLine(item.Key);
                break;
            }
        }
    }
    /*请利用字典编写一个程序用来显示一条句子内单词出现的次数. 
     * 要把出现在句内的所有单词和它们出现的次数全部显示出来.
     */
     static void Exercise3()
    {
        Console.WriteLine("请输入句子, 每个词用空格间隔");
        string sentence = Console.ReadLine();
        string[] words = sentence.Split(' ');
        Dictionary<string, int> dic = new Dictionary<string, int>();
        foreach(string word in words) {
            if (dic.ContainsKey(word))
                dic[word]++;
            else
                dic.Add(word, 1);
        }
        Console.WriteLine("全部词出现的次数如下 :");
        foreach(KeyValuePair<string,int> item in dic)
            Console.WriteLine($"{item.Key}出现了{item.Value}次");
    }
    //请重新编写练习3 的程序使得它可以处理字母而不是单词.
    static void Exercise4()
    {
        Console.WriteLine("请输入句子");
        StringBuilder sentence = new StringBuilder(Console.ReadLine());        
        Dictionary<string, int> dic = new Dictionary<string, int>();
        Regex r = new Regex("[A-Za-z]");
        string character;
        for (int i = 0; i < sentence.Length; i++) {
            character = sentence[i].ToString();
            if (r.IsMatch(character)) { 
            if (dic.ContainsKey(sentence[i].ToString()))
                dic[character]++;
            else
                dic.Add(character, 1);
            }
        }
        Console.WriteLine("全部字母出现的次数如下 :");
        foreach (KeyValuePair<string, int> item in dic)
            Console.WriteLine($"{item.Key}出现了{item.Value}次");
    }
    //请利用SortedList类来重新编写练习2 的程序.
    static void Exercise5()
    {
        string line;
        string[] words;
        SortedList<string, string> sList = new SortedList<string, string>();
        StreamReader inFile;
        inFile = File.OpenText("Test1.txt");
        Console.WriteLine("电话本内容 : ");
        while (inFile.Peek() != -1) {
            line = inFile.ReadLine();
            words = line.Split(',');
            Console.WriteLine($"{words[0]}{words[1]}");
            sList.Add(words[0], words[1]);
        }
        inFile.Close();
        Console.Write("请输入电话查询姓名 : ");
        string value = Console.ReadLine();
        Console.WriteLine(sList.Keys[sList.IndexOfValue(value)]);        
    }

    //请利用SortedList类来重新编写练习2 的程序.
    static void Exercise6()
    {
        string line;
        string[] words;
        Exercise6<string, string> mySortedList = new Exercise6<string, string>();
        StreamReader inFile;
        inFile = File.OpenText("Test1.txt");
        Console.WriteLine("使用两数组实现的自定义SortedList, 电话本内容 : ");
        while (inFile.Peek() != -1) {
            line = inFile.ReadLine();
            words = line.Split(',');
            Console.WriteLine($"{words[0]}{words[1]}");
            mySortedList.Add(words[0], words[1]);
        }
        inFile.Close();
        Console.Write("请输入电话查询姓名 : ");
        string value = Console.ReadLine();
        Console.WriteLine(mySortedList.Keys[mySortedList.IndexOfValue(value)]);
    }
}