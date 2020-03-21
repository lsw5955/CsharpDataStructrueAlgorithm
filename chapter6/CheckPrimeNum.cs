using System;
using System.Collections;
using System.Windows.Forms;

public partial class CheckPrimeNum : Form {
    public CheckPrimeNum()
    {
        InitializeComponent();
    }

    private void btnPrime_Click(object sender, EventArgs e)
    {
        BitArray bitSet = new BitArray(1024);
        int value = int.Parse(txtValue.Text);
        BuildSieve(bitSet);
        if (bitSet.Get(value))
            lblPrime.Text = (value + " 是素数");
        else
            lblPrime.Text = (value + " 不是素数");
    }

    private void BuildSieve(BitArray bits)
    {
        string primes = "";
        for (int i = 0; i < bits.Count; i++)
            bits.Set(i, true);
        //此处另一种筛选方法, 比不断从头检查到尾效率高很多            
        int bit = Convert.ToInt32(Math.Sqrt(bits.Count));
        //思路是, 外循环从2开始, 检查到全体数字个数的平方根次
        //为什么是平方根, 因为超过平方根的数, 会被内层循环的inner覆盖到, 这里比较抽象, 不理解不用死磕
        for (int outer = 2; outer <= bit; outer++)
            //内层循环, 从2开始, 直接排除inner * outer索引的数字, 因为它们相乘可以得到, 说明必然不是素数
            //由于是从2, 3, 4依次与outer乘, 直到乘到结果超过数字总数, 那么一定是排除了所有以outer为因数的数字, 剩下的就是素数了
            for (int inner = 2; inner * outer < bits.Count; inner++)
                bits.Set(inner * outer, false);
        //输出素数列表
        for (int i = 1; i < bits.Count; i++)
            if (bits.Get(i)) {
                primes += i.ToString("D4") + "  ";
            }
        txtPrimes.Text = primes;
    }
}