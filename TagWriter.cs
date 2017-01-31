using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _45PPC_RFID
{
    public partial class TagWriter : Form
    {
        public static Writer writer;
        public TagWriter()
        {
            InitializeComponent();
            writer = new Writer();
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            EventHandlers.writingTag = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
