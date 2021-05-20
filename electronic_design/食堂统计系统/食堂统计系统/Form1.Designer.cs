namespace 食堂统计系统
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
            this.ShowTable = new System.Windows.Forms.Button();
            this.month_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.month_radioButton = new System.Windows.Forms.RadioButton();
            this.days_radioButton = new System.Windows.Forms.RadioButton();
            this.month_pick_label = new System.Windows.Forms.Label();
            this.days_from_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.days_to_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.days_to_label = new System.Windows.Forms.Label();
            this.days_from_label = new System.Windows.Forms.Label();
            this.execute_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.intake_total_textBox = new System.Windows.Forms.TextBox();
            this.waste_total_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.order_least_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.order_most_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.waste_least_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.waste_most_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowTable
            // 
            this.ShowTable.Location = new System.Drawing.Point(628, 35);
            this.ShowTable.Name = "ShowTable";
            this.ShowTable.Size = new System.Drawing.Size(334, 42);
            this.ShowTable.TabIndex = 0;
            this.ShowTable.Text = "原表查看";
            this.ShowTable.UseVisualStyleBackColor = true;
            this.ShowTable.Click += new System.EventHandler(this.ShowTable_Click);
            // 
            // month_dateTimePicker
            // 
            this.month_dateTimePicker.CustomFormat = "yyyy-MM";
            this.month_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.month_dateTimePicker.Location = new System.Drawing.Point(29, 215);
            this.month_dateTimePicker.Name = "month_dateTimePicker";
            this.month_dateTimePicker.ShowUpDown = true;
            this.month_dateTimePicker.Size = new System.Drawing.Size(200, 34);
            this.month_dateTimePicker.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.days_from_label);
            this.groupBox1.Controls.Add(this.days_to_label);
            this.groupBox1.Controls.Add(this.days_to_dateTimePicker);
            this.groupBox1.Controls.Add(this.days_from_dateTimePicker);
            this.groupBox1.Controls.Add(this.month_pick_label);
            this.groupBox1.Controls.Add(this.days_radioButton);
            this.groupBox1.Controls.Add(this.month_radioButton);
            this.groupBox1.Controls.Add(this.month_dateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(628, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 320);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计方式选择";
            // 
            // month_radioButton
            // 
            this.month_radioButton.AutoSize = true;
            this.month_radioButton.Checked = true;
            this.month_radioButton.Location = new System.Drawing.Point(29, 47);
            this.month_radioButton.Name = "month_radioButton";
            this.month_radioButton.Size = new System.Drawing.Size(113, 31);
            this.month_radioButton.TabIndex = 2;
            this.month_radioButton.TabStop = true;
            this.month_radioButton.Text = "月份统计";
            this.month_radioButton.UseVisualStyleBackColor = true;
            this.month_radioButton.CheckedChanged += new System.EventHandler(this.month_radioButton_CheckedChanged);
            // 
            // days_radioButton
            // 
            this.days_radioButton.AutoSize = true;
            this.days_radioButton.Location = new System.Drawing.Point(29, 97);
            this.days_radioButton.Name = "days_radioButton";
            this.days_radioButton.Size = new System.Drawing.Size(133, 31);
            this.days_radioButton.TabIndex = 3;
            this.days_radioButton.Text = "时间段统计";
            this.days_radioButton.UseVisualStyleBackColor = true;
            // 
            // month_pick_label
            // 
            this.month_pick_label.AutoSize = true;
            this.month_pick_label.Location = new System.Drawing.Point(24, 166);
            this.month_pick_label.Name = "month_pick_label";
            this.month_pick_label.Size = new System.Drawing.Size(112, 27);
            this.month_pick_label.TabIndex = 4;
            this.month_pick_label.Text = "选择月份：";
            // 
            // days_from_dateTimePicker
            // 
            this.days_from_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.days_from_dateTimePicker.Location = new System.Drawing.Point(29, 184);
            this.days_from_dateTimePicker.Name = "days_from_dateTimePicker";
            this.days_from_dateTimePicker.Size = new System.Drawing.Size(200, 34);
            this.days_from_dateTimePicker.TabIndex = 5;
            // 
            // days_to_dateTimePicker
            // 
            this.days_to_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.days_to_dateTimePicker.Location = new System.Drawing.Point(29, 266);
            this.days_to_dateTimePicker.Name = "days_to_dateTimePicker";
            this.days_to_dateTimePicker.Size = new System.Drawing.Size(200, 34);
            this.days_to_dateTimePicker.TabIndex = 6;
            // 
            // days_to_label
            // 
            this.days_to_label.AutoSize = true;
            this.days_to_label.Location = new System.Drawing.Point(30, 227);
            this.days_to_label.Name = "days_to_label";
            this.days_to_label.Size = new System.Drawing.Size(32, 27);
            this.days_to_label.TabIndex = 7;
            this.days_to_label.Text = "到";
            // 
            // days_from_label
            // 
            this.days_from_label.AutoSize = true;
            this.days_from_label.Location = new System.Drawing.Point(30, 150);
            this.days_from_label.Name = "days_from_label";
            this.days_from_label.Size = new System.Drawing.Size(32, 27);
            this.days_from_label.TabIndex = 8;
            this.days_from_label.Text = "从";
            // 
            // execute_button
            // 
            this.execute_button.Location = new System.Drawing.Point(628, 430);
            this.execute_button.Name = "execute_button";
            this.execute_button.Size = new System.Drawing.Size(334, 74);
            this.execute_button.TabIndex = 3;
            this.execute_button.Text = "刷新";
            this.execute_button.UseVisualStyleBackColor = true;
            this.execute_button.Click += new System.EventHandler(this.execute_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "摄入总量：";
            // 
            // intake_total_textBox
            // 
            this.intake_total_textBox.Location = new System.Drawing.Point(130, 99);
            this.intake_total_textBox.Name = "intake_total_textBox";
            this.intake_total_textBox.ReadOnly = true;
            this.intake_total_textBox.Size = new System.Drawing.Size(421, 34);
            this.intake_total_textBox.TabIndex = 5;
            // 
            // waste_total_textBox
            // 
            this.waste_total_textBox.Location = new System.Drawing.Point(130, 156);
            this.waste_total_textBox.Name = "waste_total_textBox";
            this.waste_total_textBox.ReadOnly = true;
            this.waste_total_textBox.Size = new System.Drawing.Size(421, 34);
            this.waste_total_textBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "浪费总量：";
            // 
            // order_least_textBox
            // 
            this.order_least_textBox.Location = new System.Drawing.Point(150, 277);
            this.order_least_textBox.Name = "order_least_textBox";
            this.order_least_textBox.ReadOnly = true;
            this.order_least_textBox.Size = new System.Drawing.Size(401, 34);
            this.order_least_textBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "点最少的菜：";
            // 
            // order_most_textBox
            // 
            this.order_most_textBox.Location = new System.Drawing.Point(150, 220);
            this.order_most_textBox.Name = "order_most_textBox";
            this.order_most_textBox.ReadOnly = true;
            this.order_most_textBox.Size = new System.Drawing.Size(401, 34);
            this.order_most_textBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "点最多的菜：";
            // 
            // waste_least_textBox
            // 
            this.waste_least_textBox.Location = new System.Drawing.Point(170, 395);
            this.waste_least_textBox.Name = "waste_least_textBox";
            this.waste_least_textBox.ReadOnly = true;
            this.waste_least_textBox.Size = new System.Drawing.Size(381, 34);
            this.waste_least_textBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 27);
            this.label5.TabIndex = 14;
            this.label5.Text = "浪费最少的菜：";
            // 
            // waste_most_textBox
            // 
            this.waste_most_textBox.Location = new System.Drawing.Point(170, 338);
            this.waste_most_textBox.Name = "waste_most_textBox";
            this.waste_most_textBox.ReadOnly = true;
            this.waste_most_textBox.Size = new System.Drawing.Size(381, 34);
            this.waste_most_textBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "浪费最多的菜：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 541);
            this.Controls.Add(this.waste_least_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.waste_most_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.order_least_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.order_most_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.waste_total_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.intake_total_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.execute_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ShowTable);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "食堂统计系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowTable;
        private System.Windows.Forms.DateTimePicker month_dateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton month_radioButton;
        private System.Windows.Forms.RadioButton days_radioButton;
        private System.Windows.Forms.Label month_pick_label;
        private System.Windows.Forms.Label days_from_label;
        private System.Windows.Forms.Label days_to_label;
        private System.Windows.Forms.DateTimePicker days_to_dateTimePicker;
        private System.Windows.Forms.DateTimePicker days_from_dateTimePicker;
        private System.Windows.Forms.Button execute_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox intake_total_textBox;
        private System.Windows.Forms.TextBox waste_total_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox order_least_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox order_most_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox waste_least_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox waste_most_textBox;
        private System.Windows.Forms.Label label6;
    }
}

