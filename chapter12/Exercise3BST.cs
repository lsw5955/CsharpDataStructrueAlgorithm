using System;
using System.Collections;
using System.IO;

public class Exercise3Node {
    public string Data;
    public Exercise3Node Left;
    public Exercise3Node Right;
    public void DisplayNode()
    {
        Console.Write(Data + " ");
    }
}

public class Exercise3BST {
    public Exercise3Node root;
    public Exercise3BST()
    {
        //初始化, 没有任何节点
        root = null;
    }

    //从指定路径文件读取内容
    public void InsertFromFile(string filePath)
    {
        ArrayList words = new ArrayList();
        string reader = "";
        using (StreamReader sr = new StreamReader(filePath)) {
            while(sr.Peek() != -1) {
                reader = sr.ReadLine();
                words.AddRange(reader.Split(' '));
            }
        }
        foreach (object word in words) {
            Insert(word.ToString());
        }
    }

    public void Insert(string Data)
    {
        Exercise3Node newNode = new Exercise3Node();
        newNode.Data = Data;
        //如果没有root节点, 新节点将作为root节点
        if (root == null)
            root = newNode;
        else {
            Exercise3Node current = root;
            while (true) {
                //用compare比较两个字符串, 相等会返回0, 否则会返回-1或1
                if (String.Compare(Data, current.Data) < 0) {
                    if (current.Left == null) {
                        current.Left = newNode;
                        break;
                    }
                    else {
                        current = current.Left;
                    }
                }
                else {
                    if (current.Right == null) {
                        current.Right = newNode;
                        break;
                    }
                    else {
                        current = current.Right;
                    }
                }
            }
        }
    }

    //练习3
    //为练习3增加的计数变量
    int count;
    public void Exercise1(string Data, int arithmetic)
    {
        count = 0;
        switch (arithmetic) {
            case 0:
                PreOrder(Data, Find(Data));
                Console.Write($"前序遍历找到[{Data}]{count}个 || ");
                break;
            case 1:
                InOrder(Data, Find(Data));
                Console.Write($"中序遍历找到[{Data}]{count}个 || ");
                break;
            default:
                PostOrder(Data, Find(Data));
                Console.Write($"后序遍历找到[{Data}]{count}个 || ");
                break;
        }
    }

    //练习3专用后序遍历
    public void PostOrder(string Data, Exercise3Node theRoot)
    {
        if (!(theRoot == null)) {
            //这个二叉搜索数的小于值都会放在左侧, 如果搜索目标值小于当前遍历的节点值, 右侧是不会有该值的, 只看左侧
            if (string.Compare(Data, theRoot.Data) < 0)
                PreOrder(Data, theRoot.Left);
            //这个二叉搜索数的大于等于值都会放在右侧, 如果搜索目标值大于等于当前遍历的节点值, 左侧是不会有该值的, 只看右侧
            else
                PreOrder(Data, theRoot.Right);
            //找到一个相等的, 计数就+1
            if (string.Compare(Data, theRoot.Data) == 0)
                count++;
        }
    }

    //练习3专用先序遍历
    public void PreOrder(string Data, Exercise3Node theRoot)
    {
        if (!(theRoot == null)) {
            //找到一个相等的, 计数就+1
            if (string.Compare(Data, theRoot.Data) == 0)
                count++;
            //这个二叉搜索数的小于值都会放在左侧, 如果搜索目标值小于当前遍历的节点值, 右侧是不会有该值的, 只看左侧
            if (string.Compare(Data, theRoot.Data) < 0)
                PreOrder(Data,theRoot.Left);
            //这个二叉搜索数的大于等于值都会放在右侧, 如果搜索目标值大于等于当前遍历的节点值, 左侧是不会有该值的, 只看右侧
            else
                PreOrder(Data,theRoot.Right);
        }
    }

    //练习3专用中序遍历
    public void InOrder(string Data, Exercise3Node theRoot)
    {
        if (theRoot != null) {
            if (string.Compare(Data, theRoot.Data) < 0)
                InOrder(Data, theRoot.Left);
            if (string.Compare(Data, theRoot.Data) == 0)
                count++;
            if (string.Compare(Data, theRoot.Data) >= 0)
                InOrder(Data, theRoot.Right);
        }
    }

    //搜索指定的值在二叉树中是否存在
    public Exercise3Node Find(string key)
    {
        Exercise3Node current = root;
        while (current.Data != key) {
            if (string.Compare(key, current.Data) < 0)
                current = current.Left;
            else
                current = current.Right;
            if (current == null)
                return null;
        }
        return current;
    }

    //中序遍历
    public void InOrder(Exercise3Node theRoot)
    {
        if (theRoot != null) {
            InOrder(theRoot.Left);
            theRoot.DisplayNode();
            InOrder(theRoot.Right);
        }
    }
}