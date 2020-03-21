using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class IPAddresses : DictionaryBase {

    /*练习1
     * 请利用本章开发的IPAddress 类的实现来编写一个显示IP 地址的方法, 
     * 其中那个IP 地址是按照升序方式存储在类中的. 
     */
    public void Exercise1()
    {
        Console.WriteLine("练习1");
        Console.WriteLine("排序前 :");        
        SortedList<int, string> sList = new SortedList<int, string>();
        foreach (DictionaryEntry item in InnerHashtable) {
            Console.WriteLine(item.Key + " : " + item.Value);
            //将IP去掉点, 转换为整数, 作为到了SortedList的key,要利用它的key有序性
            //注意, 在IPAddresses中ip是值, 现在到SortedList中要作为key, 然后把InnerHashtable的键和值用#分割存储起来
            //注意, 我简单的去掉了点, 所以要保障去掉点之后的IP不可以重复, 另外你的人名中不可以出现#
            sList.Add(int.Parse(item.Value.ToString().Replace(".", "")), item.Key.ToString()+"#"+item.Value.ToString());            
        }
        string[] keyValueArray;
        //开始有序输出
        Console.WriteLine("排序后 :");
        foreach (KeyValuePair<int, string> item in sList) {
            keyValueArray = item.Value.Split('#');
            Console.WriteLine($"{keyValueArray[0]} : {keyValueArray[1]}");
        }

    }


    public IPAddresses(string txtFile)
    {
        string line;
        string[] words;
        StreamReader inFile;
        inFile = File.OpenText(txtFile);
        while (inFile.Peek() != -1) {
            line = inFile.ReadLine();
            words = line.Split(',');
            this.InnerHashtable.Add(words[0], words[1]);
        }
        inFile.Close();
    }

    public void Add(string name, string ip)
    {
        base.InnerHashtable.Add(name, ip);
    }

    public string Item(string name)
    {
        return base.InnerHashtable[name].ToString();
    }

    public void Remove(string name)
    {
        base.InnerHashtable.Remove(name);
    }
}