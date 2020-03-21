using System.Collections;

class CStack {
    //栈顶索引
    private int p_index;
    //在CStack类内部保存数据的ArrayList字段
    private ArrayList list;
    public CStack()
    {
        list = new ArrayList();
        p_index = -1;
    }
    //只读属性, 返回ArrayList的元素总数
    public int count {
        get {
            return list.Count;
        }
    }
    //入栈
    public void push(object item)
    {
        list.Add(item);
        p_index++;
    }
    //出栈
    public object pop()
    {
        object obj = list[p_index];
        list.RemoveAt(p_index);
        //数据出栈后栈顶改变
        p_index--;
        return obj;
    }
    public void clear()
    {
        list.Clear();
        p_index = -1;
    }
    public object peek()
    {
        return list[p_index];
    }
}