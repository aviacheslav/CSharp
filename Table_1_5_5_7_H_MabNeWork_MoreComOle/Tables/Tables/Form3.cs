using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tables
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.Multiline = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Multiline=!textBox1.Multiline;
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] items;
            string txt = textBox1.Text;
            items = txt.Split('\n');
            comboBox1.Items.Clear();
            foreach (string item in items) comboBox1.Items.Add(item);
        }

        private void textBox1_MultilineChanged(object sender, EventArgs e)
        {
            string[] items;
            string txt = textBox1.Text;
            items = txt.Split('\n');
            comboBox1.Items.Clear();
            foreach (string item in items) comboBox1.Items.Add(item);
        }
        int fActiveN()
        {
            string []items=null;
            int N = 0;
            string text, result = null;
            if (comboBox1.SelectedItem != null)
            {
                N = comboBox1.SelectedIndex + 1;
                
            }
            return N;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int N=fActiveN();
            string text = comboBox1.Text;
            if (comboBox1.SelectedItem != null)
            {
                if (text.Equals(comboBox1.SelectedItem.ToString()))
                {
                    textBox2.Text = comboBox1.SelectedItem.ToString() + " N " + N.ToString();
                }
            }
        }
    }//cl
}//ns
