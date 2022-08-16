using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lengthy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start a new file?", "New File",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBox1.Text = "";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Application",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }

        private void lengthyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // IN HERE IS THE CODE TO CONVERT THE C CODE TO LENGTHY CODE
            Compiler comp = new Compiler();
            textBox1.Text = comp.convertToLengthy(textBox1.Text);
        }
    }
}
