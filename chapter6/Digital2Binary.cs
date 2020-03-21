using System;
using System.Text;
using System.Windows.Forms;

public partial class Digital2Binary : Form {
    public Digital2Binary()
    {
        InitializeComponent();
    }

    //按钮的点击函数
    private void ConvertButton_Click(object sender, EventArgs e)
    {
        int result;
        result = int.Parse(InputBox.Text);
        ResultLable.Text = ConvertBits(result).ToString();
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

    private void Digital2Binary_Load(object sender, EventArgs e)
    {

    }
}
