using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 食堂统计系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var stream = File.Open("dataRecord.xlsx", FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                        dt = result.Tables[0];
                    }
                }
                Hide();
                if (new Login().ShowDialog() == DialogResult.Yes)
                {
                    Show();
                }
                else Application.Exit();
                CheckStatisticMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "文件打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void ShowTable_Click(object sender, EventArgs e)
        {
            using (ShowTableForm stf = new ShowTableForm(dt))
            {
                stf.ShowDialog();
            }
        }

        private void CheckStatisticMethod()
        {
            if (month_radioButton.Checked)
            {
                month_pick_label.Visible = true;
                month_dateTimePicker.Visible = true;
                days_from_dateTimePicker.Visible = false;
                days_from_label.Visible = false;
                days_to_dateTimePicker.Visible = false;
                days_to_label.Visible = false;
            }
            else if(days_radioButton.Checked)
            {
                month_pick_label.Visible = false;
                month_dateTimePicker.Visible = false;
                days_from_dateTimePicker.Visible = true;
                days_from_label.Visible = true;
                days_to_dateTimePicker.Visible = true;
                days_to_label.Visible = true;
            }
        }

        private void month_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            CheckStatisticMethod();
        }
        private bool DateCompare(DateTime dt1,DateTime dt2)
        {
            if (dt1.Year != dt2.Year) return dt1.Year < dt2.Year;
            else
            {
                if (dt1.Month != dt2.Month) return dt1.Month < dt2.Month;
                else return dt1.Day < dt2.Day;
            }
        }

        private void execute_button_Click(object sender, EventArgs e)
        {
            intake_total_textBox.Clear();
            waste_total_textBox.Clear();
            waste_most_textBox.Clear();
            waste_least_textBox.Clear();
            order_least_textBox.Clear();
            order_most_textBox.Clear();
            if (month_radioButton.Checked)
            {
                int intake_total = 0, waste_total = 0;
                Dictionary<string, int> order = new Dictionary<string, int>();
                Dictionary<string, double> waste = new Dictionary<string, double>();
                bool empty_flag = true;
                foreach (DataRow row in dt.Rows)
                {
                    Match m = Regex.Matches(row["用餐时间"].ToString(), @"(\d*)/(\d*)/(\d*) (\d*):(\d*):(\d*)")[0];
                    DateTime current_dt = new DateTime(Convert.ToInt32(m.Groups[1].ToString()), Convert.ToInt32(m.Groups[2].ToString()), Convert.ToInt32(m.Groups[3].ToString()));
                    if (current_dt.Month != month_dateTimePicker.Value.Month || current_dt.Year != month_dateTimePicker.Value.Year) continue;
                    empty_flag = false;
                    intake_total += Convert.ToInt32(row["摄入重量(克)"]);
                    waste_total += Convert.ToInt32(row["剩余重量(克)"]);
                    if (!order.Keys.Contains(row["菜品名称"].ToString()))
                        order.Add(row["菜品名称"].ToString(), 1);
                    else
                        order[row["菜品名称"].ToString()] += 1;
                    if (!waste.Keys.Contains(row["菜品名称"].ToString()))
                        waste.Add(row["菜品名称"].ToString(), 1.0 - Convert.ToDouble(row["摄入占比"].ToString()));
                    else
                        waste[row["菜品名称"].ToString()] += 1.0 - Convert.ToDouble(row["摄入占比"].ToString());
                }
                if (empty_flag)
                {
                    intake_total_textBox.Text =
                    waste_total_textBox.Text =
                    waste_most_textBox.Text =
                    waste_least_textBox.Text =
                    order_least_textBox.Text =
                    order_most_textBox.Text = "(所选时间无记录！)";
                    return;
                }
                List<string> name = new List<string>();
                foreach (var item in waste.Keys)
                {
                    name.Add(item);
                }
                Dictionary<string, int> sorted_order = order.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                order_most_textBox.Text = sorted_order.First().Key.ToString() + " (" + sorted_order.First().Value.ToString() + " 次)";
                sorted_order = order.OrderBy(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                order_least_textBox.Text = sorted_order.First().Key.ToString() + " (" + sorted_order.First().Value.ToString() + " 次)";

                foreach (var item in name)
                {
                    waste[item] /= order[item];
                }

                Dictionary<string, double> sorted_waste = waste.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                waste_most_textBox.Text = sorted_waste.First().Key.ToString() + " (浪费率：" + sorted_waste.First().Value.ToString() + ")";
                sorted_waste = waste.OrderBy(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                waste_least_textBox.Text = sorted_waste.First().Key.ToString() + " (浪费率：" + sorted_waste.First().Value.ToString() + ")";
                //Dictionary<string, double> sorted_waste = waste.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                //waste_most_textBox.Text = sorted_waste.First().Key.ToString() +" "+sorted_waste.First().Value.ToString() +" 克";

                intake_total_textBox.Text = intake_total.ToString() + " 克";
                waste_total_textBox.Text = waste_total.ToString() + " 克";
            }
            else if (days_radioButton.Checked)
            {
                if (DateCompare(days_to_dateTimePicker.Value,days_from_dateTimePicker.Value))
                {
                    MessageBox.Show("日期范围有误，请检查后重新输入！", "日期范围错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intake_total = 0, waste_total = 0;
                Dictionary<string, int> order = new Dictionary<string, int>();
                Dictionary<string, double> waste = new Dictionary<string, double>();
                bool empty_flag = true;
                foreach (DataRow row in dt.Rows)
                {
                    Match m = Regex.Matches(row["用餐时间"].ToString(), @"(\d*)/(\d*)/(\d*) (\d*):(\d*):(\d*)")[0];
                    DateTime current_dt = new DateTime(Convert.ToInt32(m.Groups[1].ToString()), Convert.ToInt32(m.Groups[2].ToString()), Convert.ToInt32(m.Groups[3].ToString()));
                    if (DateCompare(current_dt, days_from_dateTimePicker.Value) || DateCompare(days_to_dateTimePicker.Value, current_dt)) continue;
                    empty_flag = false;
                    intake_total += Convert.ToInt32(row["摄入重量(克)"]);
                    waste_total += Convert.ToInt32(row["剩余重量(克)"]);
                    if (!order.Keys.Contains(row["菜品名称"].ToString()))
                        order.Add(row["菜品名称"].ToString(), 1);
                    else
                        order[row["菜品名称"].ToString()] += 1;
                    if (!waste.Keys.Contains(row["菜品名称"].ToString()))
                        waste.Add(row["菜品名称"].ToString(), 1.0 - Convert.ToDouble(row["摄入占比"].ToString()));
                    else
                        waste[row["菜品名称"].ToString()] += 1.0 - Convert.ToDouble(row["摄入占比"].ToString());
                }
                if (empty_flag)
                {
                    intake_total_textBox.Text =
                    waste_total_textBox.Text =
                    waste_most_textBox.Text =
                    waste_least_textBox.Text =
                    order_least_textBox.Text =
                    order_most_textBox.Text = "(所选时间无记录！)";
                    return;
                }
                List<string> name = new List<string>();
                foreach (var item in waste.Keys)
                {
                    name.Add(item);
                }
                Dictionary<string, int> sorted_order = order.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                order_most_textBox.Text = sorted_order.First().Key.ToString() + " (" + sorted_order.First().Value.ToString() + " 次)";
                sorted_order = order.OrderBy(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                order_least_textBox.Text = sorted_order.First().Key.ToString() + " (" + sorted_order.First().Value.ToString() + " 次)";

                foreach (var item in name)
                {
                    waste[item] /= order[item];
                }

                Dictionary<string, double> sorted_waste = waste.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                waste_most_textBox.Text = sorted_waste.First().Key.ToString() + " (浪费率：" + sorted_waste.First().Value.ToString() + ")";
                sorted_waste = waste.OrderBy(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                waste_least_textBox.Text = sorted_waste.First().Key.ToString() + " (浪费率：" + sorted_waste.First().Value.ToString() + ")";
                //Dictionary<string, double> sorted_waste = waste.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
                //waste_most_textBox.Text = sorted_waste.First().Key.ToString() +" "+sorted_waste.First().Value.ToString() +" 克";

                intake_total_textBox.Text = intake_total.ToString() + " 克";
                waste_total_textBox.Text = waste_total.ToString() + " 克";
            }
            
        }
    }
}
