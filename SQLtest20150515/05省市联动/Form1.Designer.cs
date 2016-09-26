namespace _05省市联动
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
            this.cb_province = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_city = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.show_Pid = new System.Windows.Forms.Label();
            this.show_Cid = new System.Windows.Forms.Label();
            this.cb_area = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.show_area = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_province
            // 
            this.cb_province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_province.FormattingEnabled = true;
            this.cb_province.Location = new System.Drawing.Point(59, 39);
            this.cb_province.Name = "cb_province";
            this.cb_province.Size = new System.Drawing.Size(92, 20);
            this.cb_province.TabIndex = 0;
            this.cb_province.SelectedIndexChanged += new System.EventHandler(this.cb_province_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "省份";
            // 
            // cb_city
            // 
            this.cb_city.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_city.FormattingEnabled = true;
            this.cb_city.Location = new System.Drawing.Point(59, 84);
            this.cb_city.Name = "cb_city";
            this.cb_city.Size = new System.Drawing.Size(92, 20);
            this.cb_city.TabIndex = 0;
            this.cb_city.SelectedIndexChanged += new System.EventHandler(this.cb_city_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "市";
            // 
            // show_Pid
            // 
            this.show_Pid.AutoSize = true;
            this.show_Pid.Location = new System.Drawing.Point(170, 42);
            this.show_Pid.Name = "show_Pid";
            this.show_Pid.Size = new System.Drawing.Size(0, 12);
            this.show_Pid.TabIndex = 3;
            // 
            // show_Cid
            // 
            this.show_Cid.AutoSize = true;
            this.show_Cid.Location = new System.Drawing.Point(170, 87);
            this.show_Cid.Name = "show_Cid";
            this.show_Cid.Size = new System.Drawing.Size(0, 12);
            this.show_Cid.TabIndex = 3;
            // 
            // cb_area
            // 
            this.cb_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_area.FormattingEnabled = true;
            this.cb_area.Location = new System.Drawing.Point(59, 121);
            this.cb_area.Name = "cb_area";
            this.cb_area.Size = new System.Drawing.Size(92, 20);
            this.cb_area.TabIndex = 0;
            this.cb_area.SelectedIndexChanged += new System.EventHandler(this.cb_area_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "区/县";
            // 
            // show_area
            // 
            this.show_area.AutoSize = true;
            this.show_area.Location = new System.Drawing.Point(170, 124);
            this.show_area.Name = "show_area";
            this.show_area.Size = new System.Drawing.Size(0, 12);
            this.show_area.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 168);
            this.Controls.Add(this.show_area);
            this.Controls.Add(this.show_Cid);
            this.Controls.Add(this.show_Pid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_area);
            this.Controls.Add(this.cb_city);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_province);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_province;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_city;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label show_Pid;
        private System.Windows.Forms.Label show_Cid;
        private System.Windows.Forms.ComboBox cb_area;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label show_area;
    }
}

