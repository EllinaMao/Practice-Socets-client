using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForms
{
    public partial class Foem : Form
    {
        public Foem()
        {
            InitializeComponent();
        }

        private void humanBth_Click(object sender, EventArgs e)
        {
            OpenChatForm(false);
        }

        private void botBtn_Click(object sender, EventArgs e)
        {
            OpenChatForm(true);
        }

        private void OpenChatForm(bool isBot)
        {
            Form1 chatWindow = new Form1(isBot);
            chatWindow.Show();
            this.Hide();
        }
    }
}
