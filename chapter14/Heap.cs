using System;

public class Node {
    public int data;
    public Node(int key)
    {
        data = key;
    }
}
class Heap {
    Node[] heapArray;
    //代表堆的当前数据数量
    int currSize;
    //代表堆最多可容纳的数据数量
    int maxSize;
    public Heap(int size)
    {
        currSize = 0;
        maxSize = size;
        heapArray = new Node[maxSize];
    }
    //显示堆数据
    public void ShowArray()
    {
        foreach (Node item in heapArray) {
            Console.Write($"[{item.data}]");
        }
    }
    //专用于排序的方法
    public void HeapSort()
    {
        Node temp;
        for (int i = 0; i < currSize; i++) {
            temp = heapArray[0];
            heapArray[0] = heapArray[currSize - 1 - i];
            heapArray[currSize - 1 - i] = temp;
            //每次在堆顶将最大值交换到末尾, 然后对其末尾之前的节点进行ShiftDown
            //下一次依然拿堆顶, 但是交换位置比末尾向前一个位置, 同样的, ShiftDown操作也提前一个位置
            //如此往复, 最终最大值一个个的被交换到了数组的后方, 而且从后向前是从大到小的顺序, 排序完成
            ShiftDown(0, currSize - 1 - i);
        }
    }
    //以index为顶点, 到end索引之间形成的子堆, 进行ShiftDown操作
    void ShiftDown(int index,int unSortCount)
    {
        int largerChild;
        Node top = heapArray[index];
        //此处是与ShiftDown(int index)方法的唯一不同之处
        //end变量代替了currSize变量
        while (index < (unSortCount / 2)) {
            int leftChild = 2 * index + 1;
            int rightChild = leftChild + 1;
            if ((rightChild < unSortCount) && heapArray[leftChild].data < heapArray[rightChild].data)
                largerChild = rightChild;
            else
                largerChild = leftChild;
            if (top.data >= heapArray[largerChild].data)
                break;
            heapArray[index] = heapArray[largerChild];
            index = largerChild;
        }
        heapArray[index] = top;
    }

    //用于将指定索引的堆节点进行上浮, 从而保障堆结构的正确性
    public void ShiftUp(int index)
    {
        //获得其父节点索引, 公式如下
        int parent = (index - 1) / 2;
        //通过index获得一个数组元素, 它是parent的子节点
        Node bottom = heapArray[index];
        while ((index > 0) && (heapArray[parent].data < bottom.data)) {
            //在到达索引0之前, 只要父节点值小于其bottom, 就将父节点下移
            heapArray[index] = heapArray[parent];
            index = parent;
            //然后找到这一轮的父节点的父节点继续比较
            parent = (parent - 1) / 2;
        }
        //while循环结束后, 所有比bottom小的父节点或祖先节点都已经在下移, 将最后下移的索引元素设置为bottm
        //至此完成了新增堆数据后的堆重构
        heapArray[index] = bottom;
    }
    public bool Insert(int key)
    {
        //如果堆满了, 数据插入失败
        if (currSize == maxSize)
            return false;        
        Node newNode = new Node(key);
        //在数组的下一个空位插入新数据节点
        heapArray[currSize] = newNode;
        //根据新增的元素, 重构堆的结构, 以维持所有父节点都大于其子节点这一特性
        ShiftUp(currSize);
        //插入完成, 当前数据数量+1
        currSize++;
        return true;
    }
    //在堆结构中移除数据的方法
    public Node Remove()
    {
        Node root = heapArray[0];
        //数据总数-1
        currSize--;
        //使用末尾的Node覆盖根节点Node
        heapArray[0] = heapArray[currSize];
        //重构堆结构, 使得其满足堆的定义
        ShiftDown(0);
        //返回被移除的节点对象
        return root;
    }
    //从指定索引位置开始向下检查, 确保该索引极其子节点均是大值在上小值在下
    public void ShiftDown(int index)
    {
        int largerChild;
        //获得index代表的节点, 作为要重构的堆的顶部节点
        Node top = heapArray[index];
        //只要index小于currsize/2, 说明还没有检查完全部的父节点
        while (index < (currSize / 2)) {
            //计算指定索引index位置节点在堆结构中的左子节点索引
            int leftChild = 2 * index + 1;
            //计算指定索引index位置节点在堆结构中的右子节点索引
            int rightChild = leftChild + 1;
            //父节点不一定有右子节点, 所以要判断下是右子节点索引小于currSize说明是有效索引
            //如果右子节点存在,并且大于左子节点的值, 那么将当前的右子节点标记为大值子节点
            if ((rightChild < currSize) && heapArray[leftChild].data < heapArray[rightChild].data)
                largerChild = rightChild;
            //左子节点不需要判断是否小于currSize, 因为计算出的inddex必定是一个父节点, 而父节点至少有一个左子节点
            //如果左子节点大于等于右子节点, 则将其标记为大值节点
            else
                largerChild = leftChild;
            //如果之前移动到顶部的节点已经大于等于当前index节点的大值子节点, 说明它应该放在index位置, break结束while循环
            if (top.data >= heapArray[largerChild].data)
                break;
            //如果之前移动到顶部的节点小于当前index节点的大值子节点, 
            //则需要将大值子节点向上移动, 然后继续向下寻找小于等于顶部节点的子节点
            heapArray[index] = heapArray[largerChild];
            //设置index, 使得索引向下移动
            index = largerChild;
        }
        //while循环结束标志着两个可能 : 
        //1) 顶部节点最小, 此时的index代表末尾索引 
        //2) 顶部节点并非最小, 而且已经找到了值小于等于它的一个或两个子节点, 此时index是找到的节点的父节点索引
        //无论是哪一种情况, index节点及其所有父节点, 都已经向上移动了一层, 可以将之前顶部的top节点设置在这里了
        //至此, 完成了删除旧堆顶节点后的堆结构重构, 所有父节点都满足了大于等于其子节点这一条件
        heapArray[index] = top;
    }
}