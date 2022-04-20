using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_cafe_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double Cost_of_Items()
        {
            double sum = 0;
            int i = 0;

                for (i = 0; i < (dataGridView1.RowCount);
                i++)
                {
                    sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                }
                return sum;
        }
        private void AddCost()
        {
            double tax, g;
            tax = 7;
            if (dataGridView1.Rows.Count > 0)
            {
                tbTax.Text = String.Format("{0:c2}", (((Cost_of_Items() * tax) / 100)));
                g = ((Cost_of_Items() * tax) / 100);
                tbTotal.Text = String.Format("{0:c2}", (Cost_of_Items() + g));

            }
        }

        private void Change()
        {
            Double tax, g, c;
            tax = 7;
            if (dataGridView1.Rows.Count > 0)
            {
                g = ((Cost_of_Items() * tax) / 100)+ Cost_of_Items();
                c = Convert.ToInt32(tbCost.Text);
                tbChange.Text = String.Format("{0:c2}", c - g);

            }

        }

        Bitmap bitmap;
        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.Rows.Count * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btClear_Click(object sender, EventArgs e)
        {
            try
            {
                tbCost.Text = "0";
                tbChange.Text = "";
                tbTax.Text = "";
                tbTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cboPayment.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("True wallet");
            cboPayment.Items.Add("Master Card");
        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b= (Button)sender;

            if (tbCost.Text == "0")
            {
                tbCost.Text = "";
                    tbCost.Text = b.Text;
            }
            else if (b.Text == ".")
            {
                if (! tbCost.Text.Contains("."))
                {
                   tbCost.Text = tbCost.Text + b.Text;
                }
                    
          
       
            }
            else
                tbCost.Text = tbCost.Text + b.Text;

        }

        private void btC_Click(object sender, EventArgs e)
        {
            tbCost.Text = "0";
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                tbChange.Text = "";
                tbCost.Text = "0";
            }
        }

        private void btRemoveItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                tbChange.Text = "";
                tbCost.Text = "0";
            }
        }

        private void btCakechocolate_Click(object sender, EventArgs e)
        {
            Double CostofItem = 60;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if((bool)(row.Cells[0].Value = "Cakechocolate"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }   
                

                        
            }
            dataGridView1.Rows.Add("Cakechocolate", "1", CostofItem);
            AddCost();
        }

        private void btEspresso_Click(object sender, EventArgs e)
        {
            Double CostofItem = 55;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Espresso"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Espresso", "1", CostofItem);
            AddCost();
        }

        private void btAmericano_Click(object sender, EventArgs e)
        {
            Double CostofItem = 60;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Americano"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Americano", "1", CostofItem);
            AddCost();
        }

        private void btGreentea_Click(object sender, EventArgs e)
        {
            Double CostofItem = 45;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Greentea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Greentea", "1", CostofItem);
            AddCost();
        }

        private void btMilktea_Click(object sender, EventArgs e)
        {
            Double CostofItem = 45;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Milktea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Milktea", "1", CostofItem);
            AddCost();
        }

        private void btBubblemilktea_Click(object sender, EventArgs e)
        {
            Double CostofItem = 49;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Bubblemilktea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Bubblemilktea", "1", CostofItem);
            AddCost();
        }

        private void btLimesoda_Click(object sender, EventArgs e)
        {
            Double CostofItem = 40;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Limesoda"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Limesoda", "1", CostofItem);
            AddCost();
        }

        private void btSalalemonsoda_Click(object sender, EventArgs e)
        {
            Double CostofItem = 40;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Salalemonsoda"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Salalemonsoda", "1", CostofItem);
            AddCost();
        }

        private void btBlueHawaiisoda_Click(object sender, EventArgs e)
        {
            Double CostofItem = 40;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "BlueHawaiisoda"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("BlueHawaiisoda", "1", CostofItem);
            AddCost();
        }

        private void btBingsu_Click(object sender, EventArgs e)
        {
            Double CostofItem = 139;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Bingsu"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("Bingsu", "1", CostofItem);
            AddCost();
        }

        private void btMixedFruitCake_Click(object sender, EventArgs e)
        {
            Double CostofItem = 79;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "MixedFruitCake"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("MixedFruitCake", "1", CostofItem);
            AddCost();
        }

        private void btStrawberryCake_Click(object sender, EventArgs e)
        {
            Double CostofItem = 69;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "StrawberryCake"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }



            }
            dataGridView1.Rows.Add("StrawberryCake", "1", CostofItem);
            AddCost();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

