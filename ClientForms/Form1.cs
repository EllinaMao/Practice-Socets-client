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
                richTextBox1.Enabled = false;
                sendBtn.Enabled = false;//we didn`t conected yet
            if (IsBot)
            {
                this.Text = "This chat is operated by bot!";
            }
            else
            {
                this.Text = "Let`s chat!";
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if(textBoxIp.Text.Trim().Length==0)
            {
                MessageBox.Show("Please, enter valid IP adress");
                return;
            }
            if (textBoxPort.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please, enter valid port");
                return;
            }
            try
            {
                int port = int.Parse(textBoxPort.Text.Trim());// TODO: переделать на TryParse
                string ip = textBoxIp.Text.Trim();
                client = new Client(_uiContext!);
                //client.Reseive += (msg) =>
                //{
                //    if (IsBot)
                //    {
                //        string botAnswer = ComputerAnswers.GetRandomAnswer();
                //        richTextBox1.AppendText("Bot: " + botAnswer + "\n");
                //    }
                //    else
                //    {
                //        richTextBox1.AppendText("Server: " + msg + "\n");
                //    }
                //};

                client.Connect(ip, port);
                richTextBox1.Enabled = true;
                sendBtn.Enabled = true;
                connectBtn.Enabled = false;
                textBoxIp.Enabled = false;
                textBoxPort.Enabled = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while connecting: " + ex.Message);
            }
    }
}
