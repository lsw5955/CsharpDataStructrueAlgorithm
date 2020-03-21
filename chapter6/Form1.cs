using System;
using System.Text;
using System.Windows.Forms;

public partial class Form1 : Form {
    public Form1()
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
    //左移
    private void bt_moveL_Click(object sender, EventArgs e)
    {
        int val = int.Parse(tbox_num.Text);
        lab_before.Text = ConvertBits(val).ToString();
        val <<= int.Parse(tbox_bitCount.Text);
        lab_after.Text = ConvertBits(val).ToString();
    }
    //右移
    private void bt_moveR_Click(object sender, EventArgs e)
    {
        int val = int.Parse(tbox_num.Text);
        lab_before.Text = ConvertBits(val).ToString();
        val >>= int.Parse(tbox_bitCount.Text);
        lab_after.Text = ConvertBits(val).ToString();
    }
    //清除文本
    private void bt_clear_Click(object sender, EventArgs e)
    {
        tbox_bitCount.Text = "";
        tbox_num.Text = "";
        lab_after.Text = "";
        lab_before.Text = "";
        tbox_num.Focus();
    }
}
