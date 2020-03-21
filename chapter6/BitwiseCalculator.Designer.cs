partial class BitwiseCalculator {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_bit1 = new System.Windows.Forms.Label();
            this.lab_bit2 = new System.Windows.Forms.Label();
            this.tbox_num1 = new System.Windows.Forms.TextBox();
            this.tbox_num2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_or = new System.Windows.Forms.Button();
            this.lab_resultNum = new System.Windows.Forms.Label();
            this.lab_resultBit = new System.Windows.Forms.Label();
            this.bt_and = new System.Windows.Forms.Button();
            this.bt_Xor = new System.Windows.Forms.Button();
            this.lab_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.Location = new System.Drawing.Point(27, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "数字2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20F);
            this.label3.Location = new System.Drawing.Point(362, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "数字位值";
            // 
            // lab_bit1
            // 
            this.lab_bit1.AutoSize = true;
            this.lab_bit1.Font = new System.Drawing.Font("宋体", 20F);
            this.lab_bit1.Location = new System.Drawing.Point(267, 62);
            this.lab_bit1.Name = "lab_bit1";
            this.lab_bit1.Size = new System.Drawing.Size(0, 27);
            this.lab_bit1.TabIndex = 3;
            // 
            // lab_bit2
            // 
            this.lab_bit2.AutoSize = true;
            this.lab_bit2.Font = new System.Drawing.Font("宋体", 20F);
            this.lab_bit2.Location = new System.Drawing.Point(267, 121);
            this.lab_bit2.Name = "lab_bit2";
            this.lab_bit2.Size = new System.Drawing.Size(0, 27);
            this.lab_bit2.TabIndex = 4;
            // 
            // tbox_num1
            // 
            this.tbox_num1.Font = new System.Drawing.Font("宋体", 20F);
            this.tbox_num1.Location = new System.Drawing.Point(116, 51);
            this.tbox_num1.Name = "tbox_num1";
            this.tbox_num1.Size = new System.Drawing.Size(119, 38);
            this.tbox_num1.TabIndex = 5;
            // 
            // tbox_num2
            // 
            this.tbox_num2.Font = new System.Drawing.Font("宋体", 20F);
            this.tbox_num2.Location = new System.Drawing.Point(116, 110);
            this.tbox_num2.Name = "tbox_num2";
            this.tbox_num2.Size = new System.Drawing.Size(119, 38);
            this.tbox_num2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "数字1";
            // 
            // bt_or
            // 
            this.bt_or.Font = new System.Drawing.Font("宋体", 20F);
            this.bt_or.Location = new System.Drawing.Point(42, 306);
            this.bt_or.Name = "bt_or";
            this.bt_or.Size = new System.Drawing.Size(125, 38);
            this.bt_or.TabIndex = 7;
            this.bt_or.Text = "按位或";
            this.bt_or.UseVisualStyleBackColor = true;
            this.bt_or.Click += new System.EventHandler(this.bt_or_Click);
            // 
            // lab_resultNum
            // 
            this.lab_resultNum.AutoSize = true;
            this.lab_resultNum.Font = new System.Drawing.Font("宋体", 20F);
            this.lab_resultNum.Location = new System.Drawing.Point(128, 231);
            this.lab_resultNum.Name = "lab_resultNum";
            this.lab_resultNum.Size = new System.Drawing.Size(0, 27);
            this.lab_resultNum.TabIndex = 1;
            // 
            // lab_resultBit
            // 
            this.lab_resultBit.AutoSize = true;
            this.lab_resultBit.Font = new System.Drawing.Font("宋体", 20F);
            this.lab_resultBit.Location = new System.Drawing.Point(274, 231);
            this.lab_resultBit.Name = "lab_resultBit";
            this.lab_resultBit.Size = new System.Drawing.Size(0, 27);
            this.lab_resultBit.TabIndex = 1;
            // 
            // bt_and
            // 
            this.bt_and.Font = new System.Drawing.Font("宋体", 20F);
            this.bt_and.Location = new System.Drawing.Point(173, 306);
            this.bt_and.Name = "bt_and";
            this.bt_and.Size = new System.Drawing.Size(125, 38);
            this.bt_and.TabIndex = 7;
            this.bt_and.Text = "按位与";
            this.bt_and.UseVisualStyleBackColor = true;
            this.bt_and.Click += new System.EventHandler(this.bt_and_Click);
            // 
            // bt_Xor
            // 
            this.bt_Xor.Font = new System.Drawing.Font("宋体", 20F);
            this.bt_Xor.Location = new System.Drawing.Point(304, 306);
            this.bt_Xor.Name = "bt_Xor";
            this.bt_Xor.Size = new System.Drawing.Size(178, 38);
            this.bt_Xor.TabIndex = 7;
            this.bt_Xor.Text = "按位异或";
            this.bt_Xor.UseVisualStyleBackColor = true;
            this.bt_Xor.Click += new System.EventHandler(this.bt_Xor_Click);
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Font = new System.Drawing.Font("宋体", 20F);
            this.lab_result.Location = new System.Drawing.Point(111, 176);
            this.lab_result.Name = "lab_result";
            this.lab_result.Size = new System.Drawing.Size(66, 27);
            this.lab_result.TabIndex = 1;
            this.lab_result.Text = "结果";
            // 
            // BitwiseCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_Xor);
            this.Controls.Add(this.bt_and);
            this.Controls.Add(this.bt_or);
            this.Controls.Add(this.tbox_num2);
            this.Controls.Add(this.tbox_num1);
            this.Controls.Add(this.lab_bit2);
            this.Controls.Add(this.lab_bit1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_resultBit);
            this.Controls.Add(this.lab_result);
            this.Controls.Add(this.lab_resultNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BitwiseCalculator";
            this.Text = "123";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lab_bit1;
    private System.Windows.Forms.Label lab_bit2;
    private System.Windows.Forms.TextBox tbox_num1;
    private System.Windows.Forms.TextBox tbox_num2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button bt_or;
    private System.Windows.Forms.Label lab_resultNum;
    private System.Windows.Forms.Label lab_resultBit;
    private System.Windows.Forms.Button bt_and;
    private System.Windows.Forms.Button bt_Xor;
    private System.Windows.Forms.Label lab_result;
}