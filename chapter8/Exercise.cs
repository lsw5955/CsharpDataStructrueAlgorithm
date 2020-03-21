using System;
using System.Text.RegularExpressions;

class Exercise {

    //练习1
    /*
     * 请编写正则表达式来匹配下列内容:    
     * a. 由一个字母"x", 跟着任意三个字符, 然后是一个字母"y"组成的字符串.    
     * b. 以"ed"结尾的一个单词.    
     * c. 一个电话号码.    
     * d. 一个HTML链接标记.
     */
    public static void Exercise1()
    {
        Console.WriteLine("练习1");
        string target = "xabcy xdefy walked bed 010-5233 322-7866 <a>百度</a> <a>谷歌</a>";
        //正则a
        string regexA = "x\\w{3}y";
        //正则b
        string regexB = "\\w+ed";
        //正则c
        string regexC = "[0-9]{3}-[0-9]{4}";
        //正则d
        string regexD = "<a>\\w+?<a>";
        MatchCollection matchSet = Regex.Matches(target, regexA);
        foreach (Match aMatch in matchSet)
            Console.WriteLine("正则a捕获: " + aMatch.ToString());
        matchSet = Regex.Matches(target, regexB);
        foreach (Match aMatch in matchSet)
            Console.WriteLine("正则b捕获: " + aMatch.ToString());
        matchSet = Regex.Matches(target, regexC);
        foreach (Match aMatch in matchSet)
            Console.WriteLine("正则c捕获: " + aMatch.ToString());
        matchSet = Regex.Matches(target, regexD);
        foreach (Match aMatch in matchSet)
            Console.WriteLine("正则d捕获: " + aMatch.ToString());
        Console.WriteLine("====================");
    }
    //练习2
    //请编写一个正则表达式用来在字符串中找到所有包含两个重复字母的单词, 比如单词"deep"和单词"book"
    public static void Exercise2()
    {
        Console.WriteLine("练习2");
        string target = "book broke good god seed sad collect close HELLO WORLD";
        //正则, \1, 表示与正则表达式中第一个组的内容相同, 本例的第一个组是([a-zA-Z]), 即任意大小写字母
        string regex = "\\w*([a-zA-Z])\\1\\w*";
        MatchCollection matchSet = Regex.Matches(target, regex);
        foreach (Match aMatch in matchSet)
            Console.WriteLine("正则捕获: " + aMatch.ToString());
        Console.WriteLine("====================");
    }
    //练习3
    //请编写一个正则表达式用来在字符串中找到所有包含两个重复字母的单词, 比如单词"deep"和单词"book"
    public static void Exercise3()
    {
        Console.WriteLine("练习3");
        string target = "<h1><h2><h3><h4><h5><h6><h7><h8><h9><h0>";
        string regex = "<h[0-9]>";
        MatchCollection matchSet = Regex.Matches(target, regex);
        foreach (Match aMatch in matchSet)
            Console.WriteLine("正则捕获: " + aMatch.ToString());
        Console.WriteLine("====================");
    }
    //练习4
    //请编写一个正则表达式用来在字符串中找到所有包含两个重复字母的单词, 比如单词"deep"和单词"book"
    public static void Exercise4(string target, string oldRegex, string newStr)
    {
        Console.WriteLine("练习4");
        Console.WriteLine($"字符串[{target}]通过正则[{oldRegex}]替换[{newStr}]的结果是");
        MatchCollection matchSet = Regex.Matches(target, oldRegex);
        foreach (Match aMatch in matchSet) 
            //将符合正则规则的内容全部替换为指定字符串
            target = target.Replace(aMatch.ToString(), newStr);
        Console.WriteLine(target);
        Console.WriteLine("====================");
    }
}