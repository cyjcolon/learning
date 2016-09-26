namespace _08通过存储过程实现转账
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTran = new System.Windows.Forms.Button();
            this.labelFrom = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelTo = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelMoney = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label_OK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTran
            // 
            this.buttonTran.Location = new System.Drawing.Point(118, 160);
            this.buttonTran.Name = "buttonTran";
            this.buttonTran.Size = new System.Drawing.Size(75, 23);
            this.buttonTran.TabIndex = 0;
            this.buttonTran.Text = "Transfer ";
            this.buttonTran.UseVisualStyleBackColor = true;
            this.buttonTran.Click += new System.EventHandler(this.buttonTran_Click);
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(31, 35);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(29, 12);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "From";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(31, 72);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(17, 12);
            this.labelTo.TabIndex = 1;
            this.labelTo.Text = "To";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 2;
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Location = new System.Drawing.Point(31, 110);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(35, 12);
            this.labelMoney.TabIndex = 1;
            this.labelMoney.Text = "Money";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 107);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 2;
            // 
            // label_OK
            // 
            this.label_OK.AutoSize = true;
            this.label_OK.Location = new System.Drawing.Point(25, 171);
            this.label_OK.Name = "label_OK";
            this.label_OK.Size = new System.Drawing.Size(0, 12);
            this.label_OK.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 216);
            this.Controls.Add(this.label_OK);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.buttonTran);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTran;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label_OK;
    }
}

