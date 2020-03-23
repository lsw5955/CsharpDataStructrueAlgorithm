using System;
using System.Collections;

class ArrayListCSet {
    private ArrayList data;
    public ArrayListCSet()
    {
        data = new ArrayList();
    }
    public void Add(Object item)
    {
        if (!data.Contains(item))
            data.Add(item);
    }
    //并集
    public ArrayListCSet Union(ArrayListCSet aSet)
    {
        ArrayListCSet tempSet = new ArrayListCSet();
        foreach (Object item in data)
            tempSet.Add(item);
        foreach (Object item in aSet.data)
            if (!(this.data.Contains(item)))
                tempSet.Add(item);
        return tempSet;
    }
    //交集
    public ArrayListCSet Intersection(ArrayListCSet aSet)
    {
        ArrayListCSet tempSet = new ArrayListCSet();
        foreach (Object item in data)
            if (aSet.data.Contains(item))
                tempSet.Add(item );
        return tempSet;
    }
    //差集
    public ArrayListCSet Difference(ArrayListCSet aSet)
    {
        ArrayListCSet tempSet = new ArrayListCSet();
        foreach (Object item in data)
            if (!(aSet.data.Contains(item)))
                tempSet.Add(data);
        return tempSet;
    }
}