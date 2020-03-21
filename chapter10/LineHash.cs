using System;
using System.Collections;

/*
 请创建一个新的Hash类. 针对哈希表, 此类用arraylist来代替数组. 
 通过重新编写计算机术语表的应用程序来测试自行编写的实现.
*/
class LineHash {
    //keys只读
    public ArrayList Keys {
        get {
            return keys;
        }
    }
    private ArrayList keys;
    private ArrayList values;
    //记录哈希表中有多少有意义的数据了
    private int itemCount;

    public LineHash(int size)
    {
        itemCount = 0;
        keys = new ArrayList(size);
        values = new ArrayList(size);
        for (int i = 0; i < size; i++) {
            //如果不Add添加元素, 就不能通过下标访问
            keys.Add(null);
            values.Add(null);
        }
        Console.WriteLine("自定义哈希表大小 : " + keys.Count);
    }
    //Add方法
    //key与value都需要按照hash值索引进行存储
    public void Add(object key, object value)
    {
        if (keys.Contains(key)) {
            Console.WriteLine($"关键字:[{key}]已存在, 插入失败!");
        }
        else if (itemCount == keys.Count) {
            Console.WriteLine($"哈希表已满, 插入失败!");
        }
        else {
            int hashValue = Hash(key.ToString());
            keys[hashValue] = key;
            values[hashValue] = value;
            itemCount++;
            Console.WriteLine($"插入第{itemCount}条记录成功!");
        }
    }
    //哈希函数
    //并且要处理哈希冲突, 此处使用最简单的线性探查法处理冲突    
    public int Hash(string key)
    {
        long tot = 0;
        char[] charray;
        charray = key.ToCharArray();
        for (int i = 0; i <= key.Length - 1; i++)
            //对基于37的多项式求和,照抄书中
            tot += 37 * tot + (int)charray[i];
        tot = tot % values.Capacity;
        if (tot < 0)
            tot += values.Capacity;
        return CheckAndHandleCollision(key, (int)tot);
    }
    //使用线性寻址处理哈希冲突
    public int CheckAndHandleCollision(string key, int hashValue)
    {
        //首先要明确是否发生了冲突
        //如果哈希值对应索引位置有数据, 才需要进一步判断是否发生冲突
        if (keys[hashValue] != null) {
            //如果有数据的情况下, 并且数据还不一致, 
            //说明是不同的数据出现了哈希冲突, 那么就需要解决冲突
            if (keys[hashValue].ToString() != key) {
                //哈希表中的位置总数
                int count = keys.Count;
                for (int i = 1; i < count; i++) {
                    //只要没有找到空位, 就不断向后找, 找到末尾就从头再找
                    //重复值判断和哈希表满了的判断都写在了Hash方法中, 此处没加
                    hashValue = (hashValue + 1) % count;
                    if (keys[hashValue] == null)
                        //找到空位就直接破坏循环
                        break;
                }
            }
        }
        return hashValue;
    }
    //定义哈希表[key]方式取值的规则
    public object this[object key] {
        //围绕练习要求写的, 用不到Set 就不写了
        get {
            return values[Hash(key.ToString())];
        }
    }
}