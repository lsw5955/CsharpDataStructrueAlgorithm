using System;
using System.Collections;

public class Collection : CollectionBase {
    public int Add(object item)
    {
        return InnerList.Add(item);
    }

    public void Remove(object item)
    {
        InnerList.Remove(item);
    }

    public new void Clear()
    {
        InnerList.Clear();
    }

    public new int Count()
    {
        return InnerList.Count;
    }

    //Insert 练习
    public void Insert(int index,object value)
    {
        InnerList.Insert(index, value);
    }
    //Contains 练习
    public bool Contains(object value)
    {
        return InnerList.Contains(value);
    }
    //IndexOf 练习
    public int IndexOf(object value)
    {
        return InnerList.IndexOf(value);
    }
    //RemoveAt 练习
    public new void RemoveAt(int index)
    {
        InnerList.RemoveAt(index);
    }
}