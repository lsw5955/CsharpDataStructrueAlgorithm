using System;
using System.Text;
using System.Windows.Forms;

public partial class BitwiseCalculator : Form {
    public BitwiseCalculator()
    {
        InitializeComponent();
    }

    private StringBuilder ConvertBits(int val)
    {
        //掩码, 10000000 00000000 00000000 00000000
        int dispMask = 1 << 31;
        //4个8位加三个空格, 长度一共是35
        StringBuilder bitBuffer = new StringBuilder(35);
        for (int i = 1; i <= 32; i++) {
            if ((val & dispMask) == 0)
                bitBuffer.Append("0");
            else
                bitBuffer.Append("1");
            //假设输入的是-1, -1<<1后得到-2,可推出, 按位操作符, 操作的也是补码
            val <<= 1;
            if ((i % 8) == 0)
                bitBuffer.Append(" ");
        }
        return bitBuffer;
    }

    //公共计算方法
    void Calculator(string opt)
    {
        int val1 = int.Parse(tbox_num1.Text);
        int val2 = int.Parse(tbox_num2.Text);
        lab_bit1.Text = ConvertBits(val1).ToString();
        lab_bit2.Text = ConvertBits(val2).ToString();
        int result = 0;
        switch (opt) {
            case "and":
                result = val1 & val2;
                break;
            case "or":
                result = val1 | val2;
                break;
            case "xor":
                result = val1 ^ val2;
                break;
        }
        lab_result.Text = "按位" + opt + "结果:";
        lab_resultNum.Text = result.ToString();
        lab_resultBit.Text = ConvertBits(result).ToString();
    }

    //点击按位或按钮
    private void bt_or_Click(object sender, EventArgs e)
    {
        Calculator("or");
    }
    //点击按位与按钮
    private void bt_and_Click(object sender, EventArgs e)
    {
        Calculator("and");
    }
    //点击按位异或按钮
    private void bt_Xor_Click(object sender, EventArgs e)
    {
        Calculator("xor");
    }
}