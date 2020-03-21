using System;

public class Node {
    public int Data;
    public Node Left;
    public Node Right;
    public void DisplayNode()
    {
        Console.Write(Data + " ");
    }
}

public class BinarySearchTree {
    public Node root;
    public BinarySearchTree()
    {
        //初始化, 没有任何节点
        root = null;
    }
    //移除一个带有两个子节点的节点时, 寻找替代的后继节点的方法
    public Node GetSuccessor(Node delNode)
    {
        //现在想来, 作者使用多个看似多余的临时Node对象, 其实是为了方便体现出代码的思路
        //为我之前说作者临时变量多余的莽撞, 自罚三杯, 吱- 吱- 吱- 啊~
        //代表要删除的节点
        Node successorParent = delNode;
        //代表替代删除节点的后继节点
        Node successor = delNode;
        //标记当前遍历位置的临时节点
        //遍历的起始位置就是要删除节点的右子节点
        Node current = delNode.Right;
        while (!(current == null)) {
            //只要当前遍历到的节点不为空, 则一直向左深入
            successorParent = current;
            successor = current;
            current = current.Left;
        }
        //while循环结束后, 表示找到了右子树中的最小值节点, 
        if (!(successor == delNode.Right)) {
            successorParent.Left = successor.Right;
            successor.Right = delNode.Right;
        }
        return successor;
    }

    //将之前的几部分Delete代码合并在了一起, 原文的代码存在的逻辑问题一并修正了
    public bool Delete(int key)
    {
        //此处依然可以只使用一个临时Node对象, 但是这并不影响此处要关注的重点, 所以不做修改了
        Node current = root;
        Node parent = root;
        bool isLeftChild = true;
        //从根节点开始, 比较节点数据与关键字, 先定位到要删除的节点位置
        while (current.Data != key) {
            parent = current;
            if (key < current.Data) {
                isLeftChild = true;
                current = current.Left;
            }
            else {
                isLeftChild = false;
                current = current.Right;
            }
            //如果current为null了, 说明要删除的关键字对应的节点数据不存在, 返回false表示移除失败
            if (current == null)
                return false;
        }
        //while循环正常结束, 说明找到了要删除的节点
        //只可以删除叶子节点, 所以必须其左右子节点都为null
        if ((current.Left == null) & (current.Right == null)) {
            //如果要删除的节点是根节点, 直接让根节点为null
            if (current == root)
                root = null;
            //如果要删除的更不是根节点, 则根据其位置将其父节点的左或右子节点设置为null
            else if (isLeftChild)
                parent.Left = null;
            else
                parent.Right = null;
        }
        //如果要删除的不是叶子节点, 则先检查要其右子节点是不是null
        else if (current.Right == null) {
            //右节点为null再看看该节点是不是根节点
            if (current == root)
                //如果是, 则将根节点设置为自身的左子节点. 这样原来的根节点对象就被移除了
                root = current.Left;
            else if (isLeftChild)
                //如果要移除节点的不是根节点, 且自身是一个左子节点
                //则设置其父节点的左子节点等于自身的左子节点, 自身也就被移除了
                //这一步可以保障有序, 因为一个节点的左子节点下的所有节点值, 一定都比自己小
                parent.Left = current.Left;
            else
                //如果要移除节点的不是根节点, 且自身是一个右子节点, 
                ////则设置其父节点的右子节点等于自身的左子节点, 自身也就被移除了
                //这一步可以保障有序, 因为一个节点的右子节点下的所有节点值, 一定都比自己大
                //parent.Right = current.Right;  左侧原文代码写错了, 应该写成下面这句
                parent.Right = current.Left;
        }
        //原理与上面类似, 只不过处理的是被移除节点的左子节点为空的情况
        else if (current.Left == null) {
            if (current == root)
                root = current.Right;
            else if (isLeftChild)
                parent.Left = parent.Right;
            else
                //parent.Right = current.Right; 左侧原文代码写错了, 应该写成下面这句
                parent.Right = current.Right;
        }
        else {
            Node successor = GetSuccessor(current);
            //原文下面这句代码放在最末尾执行的, 但是本着不让原本的current.Left对象不会短暂的失去被引用
            //我把它提到了最前面, 无论要删除的节点current是什么位置, 都需要将它的左子节点设置为替代它的节点的左子节点
            successor.Left = current.Left;
            if (current == root)
                //1如果被删除后继节点是根节点, 则直接将后继节点设置为新的根节点即可
                root = successor;
            else if (isLeftChild)
                //2否则, 如果被删除节点是一个左子节点, 则将其父节点的左子节点设置为后继节点
                parent.Left = successor;
            else
                //3否则, 如果被删除节点是一个右子节点, 则将其父节点的右子节点设置为后继节点
                parent.Right = successor;
        }
        return true;
    }

    //搜索指定的值在二叉树中是否存在
    public Node Find(int key)
    {
        //用于遍历的临时Node节点
        Node current = root;
        //只要没有找到key对应的数据, 就while循环
        while (current.Data != key) {
            //如果关键字较小, 则继续查看下一个左子节点
            if (key < current.Data)
                current = current.Left;
            //如果关键字较大, 则继续查看下一个右子节点
            else
                current = current.Right;
            //如果已经没有可继续深入的子节点了, 表示没有找到符合关键字的节点数据
            //返回null , 表示搜索失败
            if (current == null)
                return null;
        }
        //如果while循环正常结束, 则current中存储的就是搜索的结果.
        return current;
    }

    //搜索最大值
    public int FindMax()
    {
        Node current = root;
        //从根节点开始找到最右侧叶子节点, 就是最大值
        while (!(current.Right == null))
            current = current.Right;
        return current.Data;
    }

    //搜索最小值
    public int FindMin()
    {
        Node current = root;
        //从根节点开始找到最左侧叶子节点, 就是最小值
        while (!(current.Left == null))
            current = current.Left;
        return current.Data;
    }

    //练习1
    //为练习1增加的计数变量
    int count;
    public void Exercise1(int Data, int arithmetic)
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

    //练习1专用后序遍历
    public void PostOrder(int Data, Node theRoot)
    {
        if (!(theRoot == null)) {
            //这个二叉搜索数的小于值都会放在左侧, 如果搜索目标值小于当前遍历的节点值, 右侧是不会有该值的, 只看左侧
            if (Data < theRoot.Data)
                PostOrder(Data, theRoot.Left);
            //这个二叉搜索数的大于等于值都会放在右侧, 如果搜索目标值大于等于当前遍历的节点值, 左侧是不会有该值的, 只看右侧
            else
                PostOrder(Data, theRoot.Right);
            //找到一个相等的, 计数就+1
            if (Data == theRoot.Data)
                count++;
        }
    }

    //练习1专用先序遍历
    public void PreOrder(int Data, Node theRoot)
    {
        if (!(theRoot == null)) {
            //找到一个相等的, 计数就+1
            if (Data == theRoot.Data)
                count++;
            //这个二叉搜索数的小于值都会放在左侧, 如果搜索目标值小于当前遍历的节点值, 右侧是不会有该值的, 只看左侧
            if (Data < theRoot.Data)
                PreOrder(Data,theRoot.Left);
            //这个二叉搜索数的大于等于值都会放在右侧, 如果搜索目标值大于等于当前遍历的节点值, 左侧是不会有该值的, 只看右侧
            else
                PreOrder(Data,theRoot.Right);
        }
    }

    //练习1专用中序遍历
    public void InOrder(int Data, Node theRoot)
    {
        if (theRoot != null) {
            //这个二叉搜索数的小于值都会放在左侧, 如果搜索目标值小于当前遍历的节点值, 右侧是不会有该值的, 只看左侧
            if (Data < theRoot.Data)
                InOrder(Data, theRoot.Left);
            //找到一个相等的, 计数就+1
            if (Data == theRoot.Data)
                count++;
            //这个二叉搜索数的大于等于值都会放在右侧, 如果搜索目标值大于等于当前遍历的节点值, 左侧是不会有该值的, 只看右侧
            if (Data >= theRoot.Data)
                InOrder(Data, theRoot.Right);
        }
    }

    //后序遍历
    public void PostOrder(Node theRoot)
    {
        if (!(theRoot == null)) {
            PostOrder(theRoot.Left);
            PostOrder(theRoot.Right);
            //这里的diplay方法其实就代表了不同遍历方法的顺序, 你可以把显示节点值的代码换成任何其他逻辑代码
            //后序遍历最先显示最左侧叶子节点, 对根节点的左子节点树执行完后序遍历后, 然后对根的右子节点树继续执行后序遍历
            theRoot.DisplayNode();
        }
    }

    //先序遍历
    public void PreOrder(Node theRoot)
    {
        if (!(theRoot == null)) {
            //这里的diplay方法其实就代表了不同遍历方法的顺序, 你可以把显示节点值的代码换成任何其他逻辑代码
            //先序遍历最先显示根节点, 然后对它的左子节点树继续执行先序遍历, 左子节点树完成遍历后再轮到右子节点树
            //theRoot.DisplayNode();
            PreOrder(theRoot.Left);
            PreOrder(theRoot.Right);
        }
    }

    //中序遍历
    public void InOrder(Node theRoot)
    {
        if (theRoot != null) {
            //参数所代表的节点如果不为空, 则先向该节点的左节点深入
            InOrder(theRoot.Left);
            //这里的diplay方法其实就代表了不同遍历方法的顺序, 你可以把显示节点值的代码换成任何其他逻辑代码            
            //中序遍历将最先显示最左侧的叶子节点, 对根节点的左子节点树执行完中序遍历后, 然后对根的右子节点树继续执行中序遍历
            theRoot.DisplayNode();
            //最外层的theRoot的左节点树的所有节点都遍历之后, 代码才会执行到这里
            //又是一轮类似的递归循环.只不过这次轮到了最外层theRoot的右节点树
            InOrder(theRoot.Right);
        }
    }

    public void Insert(int i)
    {
        Node newNode = new Node();
        //为新插入的节点赋值
        newNode.Data = i;
        //如果没有root节点, 新节点将作为root节点
        if (root == null)
            root = newNode;
        else {
            Node current = root;
            while (true) {
                if (i < current.Data) {
                    if (current.Left == null) {
                        current.Left = newNode;
                        break;
                    }
                    //新增else分支, 完成原文代码在上面的current赋值操作, 遍历位置定位到原遍历节点的左节点
                    else {
                        current = current.Left;
                    }
                }
                //如果大于等于, 则向右插
                else {
                    if (current.Right == null) {
                        current.Right = newNode;
                        break;
                    }
                    //同上
                    else {
                        current = current.Right;
                    }
                }
            }
        }
    }
}