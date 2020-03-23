using System.Collections;

class BitArrayCSet {
    //存储数据的BitArray
    private BitArray data;
    public BitArrayCSet(int size)
    {
        data = new BitArray(size);
    }
    //增加成员的方法
    public void Add(int item)
    {
        //将参数指定的索引设置为true表示存入
        data[item] = true;
    }
    //检查参数指定的成员是否存在
    public bool IsMember(int item)
    {
        //直接返回参数对饮索引的元素值
        return data[item];
    }
    //移除指定成员
    public void Remove(int item)
    {
        //将参数指定的索引元素设置为false
        data[item] = false;
    }
    //并集方法
    public BitArrayCSet Union(BitArrayCSet aSet)
    {
        BitArrayCSet tempSet = new BitArrayCSet(data.Count);
        for (int i = 0; i <= data.Count - 1; i++)    
            tempSet.data[i] = (this.data[i] || aSet.data[i]);
        return tempSet;
    }
    //交集方法
    public BitArrayCSet Intersection(BitArrayCSet aSet)
    {
        BitArrayCSet tempSet = new BitArrayCSet(data.Count);
        for (int i = 0; i <= data.Count - 1; i++)
            tempSet.data[i] = (this.data[i] && aSet.data[i]);
        return tempSet;
    }
    //差集方法
    public BitArrayCSet Difference(BitArrayCSet aSet)
    {
        BitArrayCSet tempSet = new BitArrayCSet(data.Count);
        for (int i = 0; i <= data.Count - 1; i++)
            tempSet.data[i] = (this.data[i] && (!(aSet.data[i])));
        return tempSet;
    }
    //判断子集方法
    public bool IsSubset(BitArrayCSet aSet)
    {
        BitArrayCSet tempSet = new BitArrayCSet(data.Count);
        for (int i = 0; i <= data.Count - 1; i++)
            if (this.data[i] && (!(aSet.data[i])))
                return false;
        return true;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i <= data.Count - 1; i++)
            if (data[i])
                s += i;
        return s;
    }
}