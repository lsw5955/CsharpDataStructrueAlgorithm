using System.Collections;

public class BucketHash {
    private const int SIZE = 101;
    //注意, 这是一个ArrayList数组, 每个元素本身都是一个单独的ArrayList对象
    ArrayList[] data;
    public BucketHash()
    {
        data = new ArrayList[SIZE];
        for (int i = 0; i <= SIZE - 1; i++)
            //原文代码写的new ArrayList(4)
            data[i] = new ArrayList(1);
    }

    //哈希函数
    public int Hash(string s)
    {
        long tot = 0;
        char[] charray;
        charray = s.ToCharArray();
        for (int i = 0; i <= s.Length - 1; i++)
            //对基于37的多项式求和, 跟之前的BetterHash一个思路
            //为啥这么算, 可能就得看下作者推荐的那本书了, 或是继续不断学习早晚也会懂
            tot += 37 * tot + (int)charray[i];
        tot = tot % data.GetUpperBound(0);
        if (tot < 0)
            tot += data.GetUpperBound(0);
        return (int)tot;
    }
    //向哈希表插入数据
    public void Insert(string item)
    {
        int hash_value;
        //计算哈希值
        hash_value = Hash(item);
        //如果已经存在, 则是重复值, 不需要添加
        if (!data[hash_value].Contains(item))
            data[hash_value].Add(item);
    }
    //使用线性寻址处理哈希冲突
    public void Exercise1(string item)
    {
        //没有做哈希表满的时的判断, 实际插入之前应该先检查哈希表是否还有足够空位, 
        //没有的足够空位的话需要扩容或提示用户
        int hash_value;
        //计算哈希值
        hash_value = Hash(item);
        //首先要明确发生了冲突
        //如果哈希值对应索引位置的ArrayList有数据, 才需要进一步判断是否发生冲突
        if (data[hash_value].Count > 0) {
            //如果ArrayList有数据的情况下, 并且数据还不一致, 
            //说明是不同的数据出现了哈希冲突, 那么就需要解决冲突
            if(data[hash_value][0].ToString() != item) {
                //哈希表中的位置数量
                int count = data.Length;
                while (true) {
                    hash_value = (hash_value + 1) % count;
                    if(data[hash_value].Count < 1) {
                        //如果新的哈希索引对应位置的ArrayList为空, 则直接插入
                        data[hash_value].Add(item);
                        break;
                    }
                    else if(data[hash_value][0].ToString() == item) {
                        //如果新的哈希索引对应位置的数据与item一样, 则不需要重复插入了
                        break;
                    }
                }                
            }
        }
        //如果第一次哈希的对应索引位置的ArrayList没数据, 直接插入
        else {
            data[hash_value].Add(item);
        }
    }

    //从哈希表移除数据
    public void Remove(string item)
    {
        int hash_value;
        //计算哈希值
        hash_value = Hash(item);
        //如果指定哈希索引的ArrayList对象中存在该数据,则移除
        if (data[hash_value].Contains(item))
            data[hash_value].Remove(item);
    }
}