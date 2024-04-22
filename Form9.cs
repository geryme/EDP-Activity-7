using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using buy_and_selldb;
using Excel = Microsoft.Office.Interop.Excel;

namespace RymeInformation_System
{
    public partial class Form9 : Form
    {
        private buyDB dbManage;
        public Form9()
        {
            InitializeComponent();
            dbManage = new buyDB();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                // Create an instance of DatabaseManager
                buyDB dbManage = new buyDB();

                // Call GetAllOrderReports to retrieve data from the "orderreport" table
                List<OrderReport> orderReports = dbManage.GetAllOrderReports();

                // Bind the retrieved data to dataGridView1
                dataGridView1.DataSource = orderReports;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Set the selected file path to the label
                textBox1.Text = openFileDialog1.FileName;
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                // Load the selected file into pictureBox1
                pictureBox1.ImageLocation = ((OpenFileDialog)sender).FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    Excel.Workbook workbook = excelApp.Workbooks.Open(textBox1.Text);
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    Excel.Range range = worksheet.Range["C7", "F17"];

                    object value; // Declare the object outside the loop

                    for (int i = 0; i < Math.Min(dataGridView1.Rows.Count, 10); i++)
                    {
                        for (int j = 0; j < Math.Min(dataGridView1.Columns.Count, 4); j++)
                        {
                            // Assign the cell value to the "value" object
                            value = dataGridView1.Rows[i].Cells[j].Value;

                            // Check if the cell value is not null
                            if (value != null)
                            {
                                // Convert the cell value to string and assign it to Excel cell
                                ((Excel.Range)range.Cells[i + 1, j + 1]).Value = value.ToString();
                            }
                            else
                            {
                                // If the cell value is null, assign an empty string to Excel cell
                                ((Excel.Range)range.Cells[i + 1, j + 1]).Value = "";
                            }
                        }
                    }


                    // Create a new worksheet for the chart
                    Excel.Worksheet chartSheet = (Excel.Worksheet)workbook.Sheets.Add();
                    chartSheet.Name = "Chart Graph";

                    // Add chart to the new worksheet
                    Excel.ChartObjects chartObjects = (Excel.ChartObjects)chartSheet.ChartObjects(Type.Missing);
                    Excel.ChartObject chartObject = chartObjects.Add(50, 50, 300, 300);
                    Excel.Chart chart = chartObject.Chart;

                    // Set data source for the chart
                    Excel.Range chartRange = worksheet.Range["E9", "F18"]; // Assuming Quantity is in column C and Price is in column D
                    chart.SetSourceData(chartRange);

                    // Set chart type
                    chart.ChartType = Excel.XlChartType.xlColumnClustered;

                    // Save the changes and close the workbook
                    workbook.Save();
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Data and chart inserted into Excel successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No data to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

