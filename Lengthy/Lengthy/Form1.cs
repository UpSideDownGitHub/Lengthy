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
                mainCodeEditor.Text = "";
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
                        mainCodeEditor.Text = fileContent;
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
                    sw.WriteLine(mainCodeEditor.Text);
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
            string cCode = comp.convertToC(mainCodeEditor.Text);

            /*
            // THIS IS JUST A TEST TO SEE IF IT IS CONVERTING TO C CORRECTLY
            mainCodeEditor.Text = temp;
            */

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
    }
}