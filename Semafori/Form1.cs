using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semafori
{
    public partial class Form1 : Form
    {
        public Form1()
        {
         //   CheckForIllegalCrossThreadCalls = false;    
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void AggiornaListBox(string numero)
        {
            listBox1.Items.Add($"{numero}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EvenOddNumbers EON = new EvenOddNumbers(this);
            EON.Pari();
            EON.Dispari();
        }
    }
}
