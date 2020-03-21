partial class Form1 {
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
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.lab_before = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.lab_after = new System.Windows.Forms.Label();
        this.bt_moveL = new System.Windows.Forms.Button();
        this.bt_moveR = new System.Windows.Forms.Button();
        this.bt_clear = new System.Windows.Forms.Button();
        this.tbox_num = new System.Windows.Forms.TextBox();
        this.tbox_bitCount = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("宋体", 20F);
        this.label1.Location = new System.Drawing.Point(39, 38);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(174, 27);
        this.label1.TabIndex = 0;
        this.label1.Text = "输入目标数字";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("宋体", 20F);
        this.label2.Location = new System.Drawing.Point(364, 38);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(174, 27);
        this.label2.TabIndex = 1;
        this.label2.Text = "输入移动位数";
        // 
        // lab_before
        // 
        this.lab_before.AutoSize = true;
        this.lab_before.Font = new System.Drawing.Font("宋体", 20F);
        this.lab_before.Location = new System.Drawing.Point(138, 98);
        this.lab_before.Name = "lab_before";
        this.lab_before.Size = new System.Drawing.Size(0, 27);
        this.lab_before.TabIndex = 2;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("宋体", 20F);
        this.label4.Location = new System.Drawing.Point(39, 98);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(93, 27);
        this.label4.TabIndex = 3;
        this.label4.Text = "移位前";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("宋体", 20F);
        this.label5.Location = new System.Drawing.Point(39, 246);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(93, 27);
        this.label5.TabIndex = 4;
        this.label5.Text = "移位后";
        // 
        // lab_after
        // 
        this.lab_after.AutoSize = true;
        this.lab_after.Font = new System.Drawing.Font("宋体", 20F);
        this.lab_after.Location = new System.Drawing.Point(138, 246);
        this.lab_after.Name = "lab_after";
        this.lab_after.Size = new System.Drawing.Size(0, 27);
        this.lab_after.TabIndex = 5;
        // 
        // bt_moveL
        // 
        this.bt_moveL.Font = new System.Drawing.Font("宋体", 20F);
        this.bt_moveL.Location = new System.Drawing.Point(44, 155);
        this.bt_moveL.Name = "bt_moveL";
        this.bt_moveL.Size = new System.Drawing.Size(75, 51);
        this.bt_moveL.TabIndex = 6;
        this.bt_moveL.Text = "左移";
        this.bt_moveL.UseVisualStyleBackColor = true;
        this.bt_moveL.Click += new System.EventHandler(this.bt_moveL_Click);
        // 
        // bt_moveR
        // 
        this.bt_moveR.Font = new System.Drawing.Font("宋体", 20F);
        this.bt_moveR.Location = new System.Drawing.Point(226, 155);
        this.bt_moveR.Name = "bt_moveR";
        this.bt_moveR.Size = new System.Drawing.Size(75, 51);
        this.bt_moveR.TabIndex = 7;
        this.bt_moveR.Text = "右移";
        this.bt_moveR.UseVisualStyleBackColor = true;
        this.bt_moveR.Click += new System.EventHandler(this.bt_moveR_Click);
        // 
        // bt_clear
        // 
        this.bt_clear.Font = new System.Drawing.Font("宋体", 20F);
        this.bt_clear.Location = new System.Drawing.Point(592, 155);
        this.bt_clear.Name = "bt_clear";
        this.bt_clear.Size = new System.Drawing.Size(75, 51);
        this.bt_clear.TabIndex = 8;
        this.bt_clear.Text = "清除";
        this.bt_clear.UseVisualStyleBackColor = true;
        this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
        // 
        // tbox_num
        // 
        this.tbox_num.Font = new System.Drawing.Font("宋体", 20F);
        this.tbox_num.Location = new System.Drawing.Point(237, 35);
        this.tbox_num.Name = "tbox_num";
        this.tbox_num.Size = new System.Drawing.Size(105, 38);
        this.tbox_num.TabIndex = 10;
        this.tbox_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // tbox_bitCount
        // 
        this.tbox_bitCount.Font = new System.Drawing.Font("宋体", 20F);
        this.tbox_bitCount.Location = new System.Drawing.Point(562, 35);
        this.tbox_bitCount.Name = "tbox_bitCount";
        this.tbox_bitCount.Size = new System.Drawing.Size(105, 38);
        this.tbox_bitCount.TabIndex = 11;
        this.tbox_bitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.tbox_bitCount);
        this.Controls.Add(this.tbox_num);
        this.Controls.Add(this.bt_clear);
        this.Controls.Add(this.bt_moveR);
        this.Controls.Add(this.bt_moveL);
        this.Controls.Add(this.lab_after);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.lab_before);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lab_before;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lab_after;
    private System.Windows.Forms.Button bt_moveL;
    private System.Windows.Forms.Button bt_moveR;
    private System.Windows.Forms.Button bt_clear;
    private System.Windows.Forms.TextBox tbox_num;
    private System.Windows.Forms.TextBox tbox_bitCount;
}