using System.Diagnostics;

namespace Lengthy
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start a new file?", "New File",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox1.Text = "";
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "leny(Lengthy) files (*.leny)|*.leny";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        richTextBox1.Text = fileContent;
                    }
                }
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "leny(Lengthy) files (*.leny)|*.leny";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    StreamWriter sw = new StreamWriter(myStream);
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();

                    myStream.Close();
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
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

        private void menuCompile_Click(object sender, EventArgs e)
        {
            Compiler comp = new Compiler();
            string cCode = comp.convertToC(richTextBox1.Text);

            /*
            // THIS IS JUST A TEST TO SEE IF IT IS CONVERTING TO C CORRECTLY
            richTextBox1.Text = cCode;
            //*/

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "C files (*.c)|*.c";
            saveFileDialog1.RestoreDirectory = true;
            string fileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    fileName = saveFileDialog1.FileName;
                    // Code to write the stream goes here.
                    StreamWriter sw = new StreamWriter(myStream);
                    sw.WriteLine(cCode);
                    sw.Close();
                    myStream.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
            //                 K <- to make not dissapear for testing
            string command = "/C gcc \"" + fileName + "\" -o \"" + fileName.Substring(0, fileName.Length - 2) + "\"";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            File.Delete(fileName);
            
        }

        Form2 secondForm = new Form2();
        private void cConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secondForm.IsDisposed)
                secondForm = new Form2();  
            secondForm.Show();
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = richTextBox1.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBox1.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBox1.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBox1.Font.Size;
            }

            return w;
        }
        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);

            // get First Index & First Line from richTextBox1    
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);

            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;

            // get Last Index & Last Line from richTextBox1
            int Last_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox1.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line + 1; i <= Last_Line + 2; i++)
            {
                LineNumberTextBox.Text += i + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            AddLineNumbers();
        }

        public void TestFunction()
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                //AddLineNumbers();
                TestFunction();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            TestFunction();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //AddLineNumbers();
            TestFunction();
        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            //AddLineNumbers();
            TestFunction();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //AddLineNumbers();
            TestFunction();        
        }

        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}