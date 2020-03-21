using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Calculator {
    //数字堆栈
    Stack<int> num;
    //公式字符串
    string expression;

    public Calculator()
    {
        num = new Stack<int>();
    }

    public void Calculate()
    {
        expression = Infix2Postfix();
        string token = "";
        foreach (char item in expression) {
            if (IsNumeric(item.ToString()))
                //如果是数字, 连接到临时字符串token中
                token += item;
            else if (item == ' ') {
                if(token != "") {
                    num.Push(int.Parse(token));
                    token = "";
                }
            }
            //不是数字也不是空格, 则表示是个计算符号
            else {
                Compute(num, item.ToString());
            }
        }
        Console.WriteLine($"使用一个堆栈结合后置表达式的计算结果是 : {num.Pop()}");
    }

    //计算两个数字结果的方法
    void Compute(Stack<int> N, string O)
    {
        int oper1, oper2;
        oper2 = Convert.ToInt32(N.Pop());//第二个数后入栈, 在栈顶, 所以先出栈的是oper2
        oper1 = Convert.ToInt32(N.Pop());//第一个数先入栈, 在栈底, 所以后出栈的是oper1        
        //按照加减乘除, 计算结果, 并将结果压入数字栈
        switch (O) {
            case "+":
                N.Push(oper1 + oper2);
                break;
            case "-":
                N.Push(oper1 - oper2);
                break;
            case "*":
                N.Push(oper1 * oper2);
                break;
            case "/":
                N.Push(oper1 / oper2);
                break;
        }
    }

    //转换中缀表达式为后缀表达式
    public string Infix2Postfix()
    {
        //临时存一下数学符号
        char tempOpt = ' ';
        //存放转换后的后缀表达式字符串
        string result = "";
        Console.WriteLine("你好, 赶紧输入算数题好吗?");
        expression = Console.ReadLine();
        foreach (char item in expression) {
            if (IsNumeric(item.ToString())) {
                //如果是数字, 加到result中
                result += item;
            }
            //不是数字也不是空格, 则表示是个计算符号
            else if (item != ' ') {
                //如果已经有一个存在的计算符号了, 则先把符号拼上
                if (tempOpt != ' ')
                    result += " " + tempOpt;
                //设置tempOpt为新的计算符号
                tempOpt = item;
            }
            else {
                result += item;
            }
        }
        result += " " + tempOpt;
        result = result.Replace("  ", " ");
        Console.WriteLine("转换为后缀表达式后是 :");
        Console.WriteLine(result);
        return result;
    }

    //自定义的用来判断字符串是否是数字的函数
    static bool IsNumeric(string input)
    {
        bool flag = true;
        //匹配全数字的正则表达式
        string pattern = (@"^\d+$");
        Regex validate = new Regex(pattern);
        if (!validate.IsMatch(input)) {
            //如果匹配不上, 说明不是数字字符串
            flag = false;
        }
        return flag;
    }
}