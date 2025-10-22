using BotAnswers;
using Practice_Socets_client;
using System.Collections.Generic;
namespace ClientForms
{
    public partial class Form1 : Form
    {
        public readonly bool IsBot;
        private readonly SynchronizationContext? _uiContext;
        private Client client;

        public Form1(bool isBot = false)
        {
            InitializeComponent();
            IsBot = isBot;
            _uiContext = SynchronizationContext.Current;
            this.FormClosing += ChatForm_FormClosing; // Для закриття сокетів
            this.FormClosed += ChatForm_FormClosed;
        }

        private void Send_Click(object sender, EventArgs e)
        {

        }

        private void ChatForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            client.CloseSock();
        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //что б менюха закрылась
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsBot)
            {
                this.Text = "This chat is operated by bot!";
                richTextBox1.Enabled = false;
                sendBtn.Enabled = false;
            }
            else
            {
                this.Text = "Let`s chat!";
            }
        }


    }
}
