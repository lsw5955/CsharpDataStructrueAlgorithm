using System;
using System.Collections;
using System.Text.RegularExpressions;

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
    //存储计算结果
    float expResult;
    public Exercise4Node root;

    //Main函数中直接调用它就可以了
    float Calculation()
    {
        expResult = PostOrderCalculator(root);
        Console.WriteLine();
        return expResult;
    }

    public Exercise4()
    {
        root = null;
    }

    public void CalculateExp()
    {
        Console.WriteLine();
        Console.WriteLine("请输入数学表达式, 只支持加减乘除, 支持括号, 注意不要带空格, 也不要除0:");
        ArrayList expList = new ArrayList();
        Expression2Array(expList, Console.ReadLine());
        //foreach (object item in expList) {
        //    Console.Write(item);
        //}
        InsertFromList(expList);
        //通过输出, 惊奇的发现我无意中实现了中缀表达式转后缀表达式...
        Console.WriteLine("结算结果是 :" + Calculation());
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
        //顾名思义, 记录current的父节点
        Exercise4Node currentParent = current;
        //存储每次遍历到的公式片段字符串
        string nextPart = "";
        foreach (object item in expList) {
            nextPart = item.ToString();
            //如果是数字, 插到最后加入的符号节点右侧
            if (reg.IsMatch(nextPart)) {
                current.Right = new Exercise4Node(nextPart.ToString());
            }
            //nextPart不是数字, 就一定是符号了
            else {
                //1+((2+(3+4)+5)+6)
                /*简陋的草稿
                                          +
                                +                   6
                           1         +
                                  +      5
                                2   +
                                   3 4

                 */
                //二叉树完成之后的公式计算要由底层向高层, 由左至右计算, 
                //所以生成树的时候, 会让计算优先级低的符号节点, 成为比它优先级高的符号节点的父节点或祖先节点,
                //CompareSymbol方法返回true表示左侧符号参数的计算优先级大于右侧符号参数
                if (CompareSymbol(current.Data, nextPart)) {
                    //如果nextPart的符号优先级小于最后一次插入的符号节点, 需要将nextPart节点插入root到current的路径中第一个优先级大于nextPart的节点之上
                    //而且要将这个找到的节点设置为nextPart的左子节点

                    //跟节点单独处理, 如果根节点符号优先级大于nextPart,nextPart作为新的根节点, 原根节点作为其左子节点
                    if (CompareSymbol(root.Data, nextPart)) {
                        current = new Exercise4Node(nextPart);
                        current.Left = root;
                        root = current;
                    }
                    //上个加入的符号节点不是根节点的话, 就从根节点开始遍历最右侧子节点, 找到第一个优先级高于nextPart的符号节点并将nextPart设置为它的父节点
                    else {
                        //其实找到的currentParent是目标节点的父节点, 方便进行节点替换
                        currentParent = root;
                        while (!CompareSymbol(currentParent.Right.Data, nextPart)) {
                            currentParent = currentParent.Right;
                        }
                        current = new Exercise4Node(nextPart);
                        current.Left = currentParent.Right;
                        currentParent.Right = current;
                    }
                }
                //如果最后一次加入的符号的优先级小于nextPart所代表的符号的优先级, 
                //那么就将其新增符号节点作为上一次加入的符号节点的右子节点, 并将其原右子节点作为新增节点的左子节点
                else {
                    currentParent = current;
                    current = new Exercise4Node(nextPart);
                    current.Left = currentParent.Right;
                    currentParent.Right = current;
                }
            }
        }
    }

    //处理符号, 判断符号s1的计算优先级是否高于s2
    //高于为true,低于为false
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
                    temp += bracketCount + "&";
                temp += element;
                //符号添加到数组
                targetList.Add(temp);
                temp = "";
            }
        }
        //末尾的数字在foreach中处理不到, 循环结束后处理
        targetList.Add(temp);
    }

    //后序遍历二叉树, 并进行结果计算
    public float PostOrderCalculator(Exercise4Node theRoot)
    {
        float temp = 0f;
        //检查字符串是否算作数字的正则
        reg = new Regex("^[0-9]\\.*[0-9]*$");
        if (theRoot != null) {
            //如果是数字, 直接返回数字值
            if (reg.IsMatch(theRoot.Data))
                temp = float.Parse(theRoot.Data);
            //如果不是数字, 递归
            else {
                if (theRoot.Data.Contains("+"))
                    temp = PostOrderCalculator(theRoot.Left) + PostOrderCalculator(theRoot.Right);
                else if (theRoot.Data.Contains("-"))
                    temp = PostOrderCalculator(theRoot.Left) - PostOrderCalculator(theRoot.Right);
                else if (theRoot.Data.Contains("*"))
                    temp = PostOrderCalculator(theRoot.Left) * PostOrderCalculator(theRoot.Right);
                else
                    temp = PostOrderCalculator(theRoot.Left) / PostOrderCalculator(theRoot.Right);
            }
        }
        theRoot.DisplayNode();
        return temp;
    }
}