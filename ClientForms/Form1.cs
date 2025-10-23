using BotAnswers;
using Practice_Socets_client;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            string message = richTextBox1.Text;
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            client.Send(message);

            LogMessage($"You: {message}");

            richTextBox1.Clear();
        }

        private void ChatForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            client?.Send(client?.StopWord);
            client?.CloseSock();
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

        private void Connect_Click(object sender, EventArgs e)
        {
            if (textBoxIp.Text.Trim().Length == 0)
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
                int port;
                if (!int.TryParse(textBoxPort.Text.Trim(), out port))
                {
                    MessageBox.Show("Please, enter a valid port number (e.g., 4000)");
                    return;
                }
                string ip = textBoxIp.Text.Trim();
                client = new Client(_uiContext!);
                client.Reseive += ReseveMessage; 
                client.Connect(ip, port);
                Connect.Enabled = false;
                textBoxIp.Enabled = false;
                textBoxPort.Enabled = false;
                if (!IsBot)
                {
                    richTextBox1.Enabled = true;
                    sendBtn.Enabled = true;//we conected
                }
                LogMessage("Connected to server!"); 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting: " + ex.Message);
            }
        }

        private void ReseveMessage(string msg)
        {
            LogMessage($"Server: {msg}");
            if (msg.IndexOf(client?.StopWord) > -1)
            {
                return;
            }

            if (IsBot)
            {
                string reply = ComputerAnswers.GetRandomAnswer();
                client.Send(reply);
                LogMessage($"Bot: {reply}");
            }

        }

        private void LogMessage(string message)
        {
            listBox1.Items.Add(message);
            // Автоматично прокручуємо до останнього повідомлення
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1; // Знімаємо виділення
        }
    }
}
