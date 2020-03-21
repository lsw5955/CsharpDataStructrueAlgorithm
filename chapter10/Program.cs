using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

class Program {
    static void Main()
    {
        Application.Run(new Glossary());
        //ArrayList a = new ArrayList(5);
        //Console.WriteLine(a.Count + " " + a.Capacity);
        Console.ReadLine();
    }

    /*练习2请利用Hashtable类来编写一个拼写检查程序.
     * 它从文本文件中读取数据, 并且检查拼写错误.
     * 当然, 大家会需要把词典限制在几个常用单词内.*/
     static void Exercise2(string sentence)
    {
        Hashtable g = new Hashtable();
        StreamReader inFile;
        inFile = File.OpenText(@"WordList.txt");
        //只要文件流没有到末尾, 就一行行读取文本
        while (inFile.Peek() != -1) {
            //只保存了单词做为key, 不需要value, 随便保存了个空格
            g.Add(inFile.ReadLine()," ");
        }
        inFile.Close();
        //分割用户输入内容
        String[] words = sentence.Split(' ');
        foreach(string word in words) {
            Console.WriteLine($"{word}===拼写{(g[word] == null ? "***不正确***":"[正确]")}");
        }
    }



}