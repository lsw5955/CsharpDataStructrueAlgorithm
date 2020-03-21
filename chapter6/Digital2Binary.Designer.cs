    partial class Digital2Binary {
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
            this.InputBox = new System.Windows.Forms.TextBox();
            this.ResultLable = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入要转换的整数";
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputBox.Location = new System.Drawing.Point(337, 21);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(218, 38);
            this.InputBox.TabIndex = 1;
            // 
            // ResultLable
            // 
            this.ResultLable.AutoSize = true;
            this.ResultLable.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultLable.Location = new System.Drawing.Point(76, 173);
            this.ResultLable.Name = "ResultLable";
            this.ResultLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultLable.Size = new System.Drawing.Size(120, 27);
            this.ResultLable.TabIndex = 0;
            this.ResultLable.Text = "转换结果";
            this.ResultLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("宋体", 20F);
            this.ConvertButton.Location = new System.Drawing.Point(205, 78);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(259, 56);
            this.ConvertButton.TabIndex = 2;
            this.ConvertButton.Text = "计算二进制补码";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // Digital2Binary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 242);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.ResultLable);
            this.Controls.Add(this.label1);
            this.Name = "Digital2Binary";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Digital2Binary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Label ResultLable;
        private System.Windows.Forms.Button ConvertButton;
    }