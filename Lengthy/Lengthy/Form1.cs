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

        }

    }
}