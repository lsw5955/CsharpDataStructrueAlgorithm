using System;
using System.Text;

class Exercise {
    //练习1 颠倒输入
    public void Inverse()
    {
        Console.WriteLine("练习1 : 请输入要颠倒的字符串");
        StringBuilder sb = new StringBuilder(Console.ReadLine());
        int count = sb.Length;
        Console.WriteLine("颠倒后的字符串如下 :");
        for (int i = 0; i < count; i++) {
            Console.Write(sb[count - i - 1]);
        }
        Console.WriteLine("ay");
        Console.WriteLine("===============");
    }
    //练习2 单词次数
    public void WordCount<T>(T strObj)
    {
        if (typeof(T) == typeof(StringBuilder) || typeof(T) == typeof(String)) {
            //不管你是string还是StringBuilder, 都先转成StringBuilder
            //这样两者就都可以用同样的逻辑了
            StringBuilder sb = new StringBuilder(strObj.ToString());
            //这里包含的字符都不作为单词或字母判断
            String characters = ",.:!? ";
            //临时存储单词的对象
            StringBuilder temp = new StringBuilder();
            Console.WriteLine("练习2 : 以下字符串中");
            Console.WriteLine(sb);
            int wordCount = 0;
            for (int i = 0; i < sb.Length; i++) {
                if (characters.IndexOf(sb[i]) == -1) {
                    temp.Append(sb[i]);
                }
                //如果当前元素是characters字符串中指定的非单词内容
                //并且temp中有暂存的单词, 则单词数量+1
                else if (temp.Length > 0) {
                    temp.Clear();
                    wordCount++;
                }
            }
            //如果遍历结束, temp还有内容, 说明是以单词结尾的, 单词数量还要+1
            if (temp.Length > 0)
                wordCount++;
            Console.WriteLine($"共含有单词{wordCount}个");
        }
        else {
            Console.WriteLine("参数类型错误, 必须是String或StringBuilder");
        }
        Console.WriteLine("===============");
    }
    //练习3 数字转文字
    //只搞一百以内的做个示意
    public void Num2Word(int num)
    {        
        StringBuilder numWord = new StringBuilder("零一二三四五六七八九");
        Console.WriteLine($"练习3 : {num}转化为汉字是:");
        if (num == 0) {
            Console.Write(numWord[num]);
        }
        else {
            if (num < 0) {
                Console.Write("负");
            }
            if (Math.Abs(num) > 9) {
                Console.Write($"{numWord[Convert.ToInt32(Math.Abs(num) / 10)]}十");
            }
            if (Math.Abs(num) % 10 > 0) {
                Console.Write($"{numWord[Convert.ToInt32(Math.Abs(num) % 10)]}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("===============");
    }
    //练习4 主谓宾简单句    
    public void SimpleSentenceSlice<T>(T strObj)
    {
        if (typeof(T) == typeof(StringBuilder) || typeof(T) == typeof(String)) {
            //不管你是string还是StringBuilder, 都先转成StringBuilder
            //这样两者就都可以用同样的逻辑了
            String str = strObj.ToString();
            Console.WriteLine("练习4 : 以下简单句中");
            Console.WriteLine(str);
            String temp = str.Substring(0, str.IndexOf(" "));
            Console.Write($"主语 : {temp} || ");
            str = str.Replace(temp + " ", "");
            temp = str.Substring(0, str.IndexOf(" "));
            Console.Write($"谓语 : {temp} || ");
            str = str.Replace(temp + " ", "");
            temp = str.Substring(0, str.Length);
            Console.WriteLine($"宾语 : {temp}");
            str = str.Replace(temp + " ", "");
        }
        else {
            Console.WriteLine("参数类型错误, 必须是String或StringBuilder");
        }
        Console.WriteLine("===============");
    }
}