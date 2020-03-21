partial class CheckPrimeNum {
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
            this.txtPrimes = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnPrime = new System.Windows.Forms.Button();
            this.lblPrime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPrimes
            // 
            this.txtPrimes.Font = new System.Drawing.Font("宋体", 16F);
            this.txtPrimes.Location = new System.Drawing.Point(54, 172);
            this.txtPrimes.Multiline = true;
            this.txtPrimes.Name = "txtPrimes";
            this.txtPrimes.ReadOnly = true;
            this.txtPrimes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrimes.Size = new System.Drawing.Size(701, 243);
            this.txtPrimes.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("宋体", 16F);
            this.txtValue.Location = new System.Drawing.Point(54, 34);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 32);
            this.txtValue.TabIndex = 1;
            // 
            // btnPrime
            // 
            this.btnPrime.Font = new System.Drawing.Font("宋体", 16F);
            this.btnPrime.Location = new System.Drawing.Point(198, 27);
            this.btnPrime.Name = "btnPrime";
            this.btnPrime.Size = new System.Drawing.Size(157, 40);
            this.btnPrime.TabIndex = 2;
            this.btnPrime.Text = "是素数吗?";
            this.btnPrime.UseVisualStyleBackColor = true;
            this.btnPrime.Click += new System.EventHandler(this.btnPrime_Click);
            // 
            // lblPrime
            // 
            this.lblPrime.AutoSize = true;
            this.lblPrime.Font = new System.Drawing.Font("宋体", 16F);
            this.lblPrime.Location = new System.Drawing.Point(383, 37);
            this.lblPrime.Name = "lblPrime";
            this.lblPrime.Size = new System.Drawing.Size(0, 22);
            this.lblPrime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F);
            this.label2.Location = new System.Drawing.Point(337, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "素数列表";
            // 
            // CheckPrimeNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrime);
            this.Controls.Add(this.btnPrime);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtPrimes);
            this.Name = "CheckPrimeNum";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtPrimes;
    private System.Windows.Forms.TextBox txtValue;
    private System.Windows.Forms.Button btnPrime;
    private System.Windows.Forms.Label lblPrime;
    private System.Windows.Forms.Label label2;
}