
partial class Glossary {
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
            this.txtDefinition = new System.Windows.Forms.TextBox();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtDefinition
            // 
            this.txtDefinition.Font = new System.Drawing.Font("宋体", 20F);
            this.txtDefinition.Location = new System.Drawing.Point(278, 12);
            this.txtDefinition.Multiline = true;
            this.txtDefinition.Name = "txtDefinition";
            this.txtDefinition.ReadOnly = true;
            this.txtDefinition.Size = new System.Drawing.Size(336, 426);
            this.txtDefinition.TabIndex = 1;
            // 
            // lstWords
            // 
            this.lstWords.Font = new System.Drawing.Font("宋体", 16F);
            this.lstWords.FormattingEnabled = true;
            this.lstWords.ItemHeight = 21;
            this.lstWords.Location = new System.Drawing.Point(12, 12);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(251, 424);
            this.lstWords.TabIndex = 2;
            this.lstWords.SelectedIndexChanged += new System.EventHandler(this.lstWords_SelectedIndexChanged);
            // 
            // Glossary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.txtDefinition);
            this.Name = "Glossary";
            this.Text = "Glossary";
            this.Load += new System.EventHandler(this.Glossary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox txtDefinition;
    private System.Windows.Forms.ListBox lstWords;
}