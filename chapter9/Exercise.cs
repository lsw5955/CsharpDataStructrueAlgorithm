using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Exercise6<TKey, TValue> {
    public TKey[] Keys;
    public TValue[] Values;
    int currentIndex;
    //构造函数
    public Exercise6()
    {
        //没考虑扩容
        Keys = new TKey[10];
        Values = new TValue[10];
        //标记下一个数据要存到哪里了
        currentIndex = 0;
    }
    //Add方法
    public void Add(TKey key, TValue value)
    {
        //没有实现查重, 应该要避免key重复
        //没有实现排序, 推测SortedList每次Add时就进行了排序
        Keys[currentIndex] = key;
        Values[currentIndex] = value;
        currentIndex++;
    }
    //IndexOfValue方法
    public int IndexOfValue(TValue value)
    {        
        for (int i = 0; i < currentIndex; i++) {
            if (Values[i].Equals(value))
                return i;
        }
        return -1;
    }
}