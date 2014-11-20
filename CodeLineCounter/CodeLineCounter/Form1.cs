using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeLineCounter.Properties;

namespace CodeLineCounter {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e) {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK) {
                openFile(openFileDialog1.FileName);
            }
        }

        private void openFile(string filename) {
            //Result result = new Result();

            //List<ILineCounter> counters = new List<ILineCounter>();
            //AllLineCounter all = new AllLineCounter();
            //FilterCounter empty = new FilterCounter() { Filter = new EmptyLineFilter() };
            //FilterCounter braceCounter = new FilterCounter() { Filter = new BracesFilter() };
            //FilterCounter usingCounter = new FilterCounter { Filter = new UsingImportFilter() };
            CombineCounter result = new CombineCounter();
            //ProcessFile(filename, counters, all, empty, braceCounter, usingCounter);
            //result.AllLines = all.Lines;
            //result.BraceLines = braceCounter.Lines;
            //result.EmptyLines = empty.Lines;
            //result.UsingLines = usingCounter.Lines;
            ProcessFile(filename, result);
            this.propertyGrid1.SelectedObject = result;
            this.propertyGrid1.Refresh();

        }

        private static void ProcessFile(string filename, CombineCounter result) {
            string[] lines = File.ReadAllLines(filename);

            foreach (var line in lines) {
                string trimedLine = line.Trim();
                result.OnCodeLine(trimedLine);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e) {
            //if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
            string fileName = Settings.Default.FolderName;
            if (fileName == string.Empty) {
                MessageBox.Show("folder is empty");
                return;
            }
            var files = Directory.GetFiles(fileName, "*", SearchOption.AllDirectories);
            CombineCounter result = new CombineCounter();
            foreach (var filename in files) {
                FileInfo fileInfo = new FileInfo(filename);
                if (fileInfo.Extension == ".cs" || fileInfo.Extension == ".java") {
                    ProcessFile(filename, result);
                }
            }
            this.propertyGrid1.SelectedObject = result;
            this.propertyGrid1.Refresh();
            //}
        }

        private void btnSelectFolder_Click(object sender, EventArgs e) {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                Settings.Default.FolderName = this.folderBrowserDialog1.SelectedPath;
                Settings.Default.Save();
                ShowFoldName();
            }
        }

        private void ShowFoldName() {
            this.txtFolderName.Text = Settings.Default.FolderName;
        }

        private void Form1_Load(object sender, EventArgs e) {
            ShowFoldName();
        }
    }
}
