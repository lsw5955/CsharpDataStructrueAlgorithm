using System;
using System.Collections;

public class CSet {
    private Hashtable data;
    public CSet()
    {
        data = new Hashtable();
    }

    public void Add(Object item)
    {
        if (!data.ContainsValue(item))
            //data.Add(Hash(item), item);
            data.Add(item, item);
    }

    private string Hash(Object item)
    {        
        char[] chars;
        string s = item.ToString();
        int hashValue = 0;
        chars = s.ToCharArray();
        for (int i = 0; i <= chars.GetUpperBound(0); i++)
            hashValue += (int)chars[i];
        return hashValue.ToString();
    }

    public void Remove(Object item)
    {
        data.Remove(Hash(item));
    }

    public int Size()
    {
        return data.Count;
    }
    //并集
    public CSet Union(CSet aSet)
    {
        CSet tempSet = new CSet();
        foreach (Object hashObject in data.Keys)
            tempSet.Add(this.data[hashObject]);
        foreach (Object hashObject in aSet.data.Keys)
            if (!(this.data.ContainsKey(hashObject)))
                tempSet.Add(aSet.data[hashObject]);
        return tempSet;
    }
    //交集
    public CSet Intersection(CSet aSet)
    {
        CSet tempSet = new CSet();
        foreach (Object hashObject in data.Keys)
            if (aSet.data.Contains(hashObject))
                tempSet.Add(aSet.data[hashObject]);
        return tempSet;
    }
    //差集
    public CSet Difference(CSet aSet)
    {
        CSet tempSet = new CSet();
        foreach (Object hashObject in data.Keys)
            if (!(aSet.data.Contains(hashObject)))
                tempSet.Add(data[hashObject]);
        return tempSet;
    }
    public bool Subset(CSet aSet)
    {
        if (this.Size() > aSet.Size())
            return false;
        else
            foreach (Object key in this.data.Keys)
                if (!(aSet.data.Contains(key)))
                    return false;
        return true;
    }

    public override string ToString()
    {
        string s = "";
        foreach (Object key in data.Keys)
            s += data[key] + " ";
        return s;
    }
}