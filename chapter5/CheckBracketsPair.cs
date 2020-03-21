using System;
using System.Collections.Generic;

//只实现对于圆括号的匹配, 其他的括号原理类似
class CheckBracketsPair {
    //原始字符串
    public string sourceString;
    //记录全部字符的堆栈
    Stack<char> stackOrigin;
    //运算时有不同作用的中间堆栈
    Stack<int> tempBracketsMark;
    //专存右括号
    Stack<int> rightBracketsMark;
    public CheckBracketsPair()
    {
        stackOrigin = new Stack<char>();
        tempBracketsMark = new Stack<int>();
        rightBracketsMark = new Stack<int>();
    }
    public string Check()
    {
        //该堆栈多次运行期间, 如果不清空, 有可能留有上一次运行的脏数据, 导致结果错误
        tempBracketsMark.Clear();
        Console.WriteLine("请输入想要检查圆括号匹配情况的字符串");
        sourceString = Console.ReadLine();
        //标记左括号数量, 也代表了左括号的位置
        int leftBracketsNum = 0;
        foreach (char item in sourceString) {
            //所有字符全部放入一个堆栈
            stackOrigin.Push(item);
            //新发现的左括号, 放入tempBracketsMark
            if (item == '(') {
                //第一次字符遍历时候, tempBracketsMark用于存储左括号标记
                //左括号标记使用正整数代表, 与之匹配的右括号是对应的负整数
                //leftBracketsNum需要自增, 以区分不同位置的左括号
                tempBracketsMark.Push(++leftBracketsNum);
            }
            else if (item == ')') {
                if (tempBracketsMark.Count > 0) {
                    //如果是右括号, 就寻找与之距离最近的左括号, 这个左括号就应该是tempBracketsMark的栈顶
                    //根据本算法的对应规则, 右括号如果有对应的左括号, 则使用该左括号的标记数字的负数作为标记, 在后面需要根据这些数字来确定有问题的括号是哪个
                    //注意, 这个找到了对应右括号的左括号, 被出栈了, 这样保证栈内只要有剩余的左括号, 都是还没有找到对应的右括号的
                    rightBracketsMark.Push(0 - tempBracketsMark.Pop());
                }
                else {
                    //如果是右括号, tempBracketsMark内又没有数据, 说明是一个不匹配的右括号
                    //本算法使用0代表没有匹配的右括号
                    rightBracketsMark.Push(0);
                }
            }
        }
        //将所有括号的位置信息都标记之后, 要开始检查括号的匹配状态了
        //tempBracketsMark的用途也将变化, 它代表的不再是左括号, 
        //清不清空都可以
        tempBracketsMark.Clear();
        //原字符串所有内容都已经在stackOrigin中了, 所以sourceString可以用于存储检查结果
        sourceString = "";
        //开始检查代表完整原文的stackOrigin中括号的匹配情况
        //注意, 字符出栈的顺序, 跟原字符串字符的顺序是反的, 所以结果字符串要倒着拼
        while (stackOrigin.Count > 0) {
            if (stackOrigin.Peek() == ')') {
                //stackOrigin中遇到的每个右括号, 都与当前rightBracketsMark栈顶对应
                if (rightBracketsMark.Peek() == 0) {
                    //rightBracketsMark中对应的右括号标记等于零, 
                    //说明这右括号没有匹配的左括号, 检查不通过, 拼接结果字符串时在左侧加标记
                    sourceString = "[少]" + stackOrigin.Pop() + sourceString;
                    //已经检查完的右括号要在rightBracketsMark出栈
                    rightBracketsMark.Pop();
                }
                else {
                    //rightBracketsMark中对应的右括号标记不等于零, 
                    //说明存在与之对应的左括号, 要将其保留, 以备检查, 这就用到了tempBracketsMark
                    //在检查匹配情况时, tempBracketsMark用于存储还没有被检查到的左括号所匹配的右括号
                    //已经检查完的右括号要在rightBracketsMark出栈
                    tempBracketsMark.Push(rightBracketsMark.Pop());
                    //拼接结果字符串
                    sourceString = stackOrigin.Pop() + sourceString;
                }
            }
            else if (stackOrigin.Peek() == '(') {
                if (tempBracketsMark.Contains(0 - leftBracketsNum)) {
                    //leftBracketsNum始终代表最新检查到的左括号的位置, 
                    //如果rightBracketsMark中存在一个对应的负数, 表示就存在匹配的右括号, 检查通过
                    //为什么不检查rightBracketsMark中有没有匹配的右括号? 因为倒着检查字符串, 如果一个左括号有右括号, 
                    //那么一定是先检查到右括号, 也就是必定已经在上面的if中被移动到了tempBracketsMark中
                    sourceString = stackOrigin.Pop() + sourceString;
                }
                else {
                    //如果没有在tempBracketsMark中找到对应的右括号, 该左括号缺少右括号, 检查不通过
                    sourceString = "[少]" + stackOrigin.Pop() + sourceString;
                }
                //每检查完一次左括号, leftBracketsNum都要-1, 来代表下一个左括号的位置
                leftBracketsNum--;
            }
            else {
                //不是左括号, 也不是右括号, 直接拼到结果中
                sourceString = stackOrigin.Pop() + sourceString;
            }
        }
        Console.WriteLine(sourceString);
        return sourceString;
    }
}
