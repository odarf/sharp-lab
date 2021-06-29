using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp8._3
{
    public partial class Form1 : Form
    {
        public OpenFileDialog openFileDialog = new OpenFileDialog
        {
            InitialDirectory = "C:\\Class1.cs",
            Filter = @"cs files (*.cs)|*.cs|All files (*.*)|*.*"
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetFieldsClass(openFileDialog);
        }

        private void GetFieldsClass(OpenFileDialog openFileDialog)
        {
            int Number = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                File.ReadAllText(openFileDialog.FileName);
            StreamReader input = new StreamReader(openFileDialog.FileName);
            List<string> ArrayString = new List<string>();
            while (!input.EndOfStream)
            {
                ArrayString.Add(input.ReadLine());
                richTextBox1.Text += ArrayString.Last<string>() + "\n";
            }
            for (int n = 0; n < ArrayString.Count; n++)
            {
                if (ArrayString[n].Contains("{"))
                    Number++;
                if (ArrayString[n].Contains("}"))
                    Number--;
                if (Number == 2)
                if (((ArrayString[n].Contains(";") & !(ArrayString[n].Contains("(") | ArrayString[n].Contains(")"))) & (!ArrayString[n].Contains("using"))) | (ArrayString[n].Contains(";") & ArrayString[n].Contains("=")))
                    richTextBox2.Text += ArrayString[n] + "\n";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
