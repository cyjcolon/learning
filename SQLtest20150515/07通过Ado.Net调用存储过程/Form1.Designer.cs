namespace _07通过Ado.Net调用存储过程
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pageup = new System.Windows.Forms.Button();
            this.Pagedown = new System.Windows.Forms.Button();
            this.label_recordCount = new System.Windows.Forms.Label();
            this.label_pageCount = new System.Windows.Forms.Label();
            this.label_currentPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(631, 304);
            this.dataGridView1.TabIndex = 0;
            // 
            // Pageup
            // 
            this.Pageup.Location = new System.Drawing.Point(13, 341);
            this.Pageup.Name = "Pageup";
            this.Pageup.Size = new System.Drawing.Size(75, 23);
            this.Pageup.TabIndex = 1;
            this.Pageup.Text = "上一页";
            this.Pageup.UseVisualStyleBackColor = true;
            this.Pageup.Click += new System.EventHandler(this.Pageup_Click);
            // 
            // Pagedown
            // 
            this.Pagedown.Location = new System.Drawing.Point(134, 341);
            this.Pagedown.Name = "Pagedown";
            this.Pagedown.Size = new System.Drawing.Size(75, 23);
            this.Pagedown.TabIndex = 1;
            this.Pagedown.Text = "下一页";
            this.Pagedown.UseVisualStyleBackColor = true;
            this.Pagedown.Click += new System.EventHandler(this.Pagedown_Click);
            // 
            // label_recordCount
            // 
            this.label_recordCount.AutoSize = true;
            this.label_recordCount.Location = new System.Drawing.Point(12, 391);
            this.label_recordCount.Name = "label_recordCount";
            this.label_recordCount.Size = new System.Drawing.Size(41, 12);
            this.label_recordCount.TabIndex = 2;
            this.label_recordCount.Text = "label1";
            // 
            // label_pageCount
            // 
            this.label_pageCount.AutoSize = true;
            this.label_pageCount.Location = new System.Drawing.Point(12, 423);
            this.label_pageCount.Name = "label_pageCount";
            this.label_pageCount.Size = new System.Drawing.Size(41, 12);
            this.label_pageCount.TabIndex = 2;
            this.label_pageCount.Text = "label1";
            // 
            // label_currentPage
            // 
            this.label_currentPage.AutoSize = true;
            this.label_currentPage.Location = new System.Drawing.Point(132, 391);
            this.label_currentPage.Name = "label_currentPage";
            this.label_currentPage.Size = new System.Drawing.Size(41, 12);
            this.label_currentPage.TabIndex = 2;
            this.label_currentPage.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 444);
            this.Controls.Add(this.label_pageCount);
            this.Controls.Add(this.label_currentPage);
            this.Controls.Add(this.label_recordCount);
            this.Controls.Add(this.Pagedown);
            this.Controls.Add(this.Pageup);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Pageup;
        private System.Windows.Forms.Button Pagedown;
        private System.Windows.Forms.Label label_recordCount;
        private System.Windows.Forms.Label label_pageCount;
        private System.Windows.Forms.Label label_currentPage;
    }
}

