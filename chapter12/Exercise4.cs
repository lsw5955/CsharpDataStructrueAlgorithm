using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Exercise4Node {
    public string Data;
    public Exercise4Node Left;
    public Exercise4Node Right;
    public void DisplayNode()
    {
        Console.Write(Data + " ");
    }
    public Exercise4Node(string Data)
    {
        this.Data = Data;
        Left = null;
        Right = null;
    }
}

//思路: 只有叶子节点是计算数字, 非叶子节点全部都是运算符号
//两个节点都是叶子的运算符最先计算, 构建二叉树时需要让优先级高的运算符满足这一点
class Exercise4 {
    Regex reg;
    public Exercise4Node root;

    public Exercise4()
    {
        root = null;
        Console.WriteLine("请输入数学表达式, 只支持加减乘除, 支持括号, 注意不要带空格 :");
        ArrayList expList = new ArrayList();
        Expression2Array(expList, Console.ReadLine());
        foreach (object item in expList) {
            Console.WriteLine(item);
        }
        InsertFromList(expList);
    }

    void InsertFromList(ArrayList expList)
    {
        Console.WriteLine("开始插入二叉树...");
        //第一个数字和第一个符号特殊处理, 直接加到树中, 减少循环中不必要的判断
        root = new Exercise4Node(expList[1].ToString());//第一个符号        
        root.Left = new Exercise4Node(expList[0].ToString());//第一个数字
        //移除, 循环中不需要重复处理它俩
        expList.RemoveAt(0);
        expList.RemoveAt(0);
        //检查字符串是否算作数字的正则
        reg = new Regex("^[0-9]\\.*[0-9]*$");
        //标记当前最后一个加到二叉树中的算数符号节点
        Exercise4Node current = root;
        //标记当前上一个加入到二叉树中的算数符号节点
        Exercise4Node currentParent = null;
        foreach (object item in expList) {
            //如果是数字, 插到最后加入的符号节点右侧
            if (reg.IsMatch(item.ToString())) {
                current.Right = new Exercise4Node(item.ToString());
                current = current.Right;
            }
            //item不是数字, 就一定是符号了
            else {
                //1+(2+(3+4)+5)+6
                /*
                                          +
                                +                   6
                           1         +
                                  +      5
                                2   +
                                   3 4

                 */
                //如果最后一次加入的符号的优先级大于等于item所代表的符号的优先级, 则CompareSymbol方法返回true
                if (CompareSymbol(currentParent.Data, item.ToString())) {
                    //二叉树完成之后的公式计算要由底层向高层, 由左至右计算, 所以生成树的时候, 计算优先级低的符号节点, 会成为它相邻的, 优先级大于等于, 需要在, 越靠优先级高的符号节点会成为优先级低的符号节点的子节点, 而且是左子节点
                    //lastSymbol是null说明current是根节点
                    if(currentParent == null) {
                        //新增符号节点作为根节点
                        root = new Exercise4Node(item.ToString());
                        //原根节点设置新符号根节点的左子节点
                        root.Left = current;
                        current = root;
                    }
                }
                else {

                }
            }
        }
    }

    //处理符号, 判断符号s1的计算优先级是否高于s2
    //大于为true,小于为false
    bool CompareSymbol(string s1, string s2)
    {
        if (s1 == s2) {
            return true;
        }
        //拆分表达式时, 计算符号会写成 [括号数量]_符号 的形式, 比如(1+2)*3, 加号最终会被解析为 "1_+" 
        //普通的计算符号没有前面的代表括号数量的标记, 所以如果两个符号数据长度不等, 谁长谁的优先级高
        else if (s1.Length != s2.Length)
            return s1.Length > s2.Length;
        //如果长度一致,再比较下前面有几个括号, 括号越多, 优先级越高
        else if (s1.Length > 1) {
            int b1 = int.Parse(s1.Substring(0, 1));
            int b2 = int.Parse(s2.Substring(0, 1));
            //如果括号数量不一致, 直接比较括号数量来得到计算优先级
            if (b1 != b2)
                return b1 > b2;
            //如果符号字符串长度相等, 且大于1, 且括号数量也相等, 那就需要截取出数学符号, 进行符号之间的比较了
            else {
                s1 = s1.Substring(1, 1);
                s2 = s2.Substring(1, 1);
            }
        }

        switch (s1) {
            case "*":
                return true;
            case "/":
                return true;
            case "+":
                return (s2 == "+" || s2 == "-");
            case "-":
                return (s2 == "+" || s2 == "-");
            default:
                Console.WriteLine("CompareSymbol方法 : 参数s1不是加减乘除任何一个, 可能出问题了");
                return true;
        }
    }

    private void Expression2Array(ArrayList targetList, string exp)
    {
        //数学公式解析为字符数组, 注意, 不要带空格
        char[] elements = exp.ToCharArray();
        string temp = "";
        //用来标记括号的数量
        int bracketCount = 0;
        //检查单个字符是否算作数字的正则
        reg = new Regex("[0-9]|\\.");
        foreach (char element in elements) {
            if (reg.IsMatch(element.ToString())) {
                //是数字就不断地连接到temp字符串中
                temp += element;
            }
            else if (element == '(') {
                bracketCount++;
            }
            else if (element == ')') {
                bracketCount--;
            }
            //不是数字, 也不是左右括号, 那就是计算符号了
            else {
                //首先把temp中记录的计算数存到ArrayList
                targetList.Add(temp);
                temp = "";
                //如果在括号内, 则需要将括号信息加到符号字符串中
                if (bracketCount > 0)
                    temp += bracketCount + "_";
                temp += element;
                //符号添加到数组
                targetList.Add(temp);
                temp = "";
            }
        }
        //末尾的数字在foreach中处理不到, 循环结束后处理
        targetList.Add(temp);
    }
}
 