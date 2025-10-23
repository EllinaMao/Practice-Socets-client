namespace ClientForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            sendBtn = new Button();
            textBoxIp = new TextBox();
            textBoxPort = new TextBox();
            Connect = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(14, 56);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(365, 344);
            listBox1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(14, 420);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(365, 80);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(12, 387);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(320, 23);
            sendBtn.TabIndex = 2;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += Send_Click;
            // 
            // textBoxIp
            // 
            textBoxIp.Location = new Point(14, 16);
            textBoxIp.Margin = new Padding(3, 4, 3, 4);
            textBoxIp.Name = "textBoxIp";
            textBoxIp.PlaceholderText = "ip adress";
            textBoxIp.Size = new Size(113, 23);
            textBoxIp.TabIndex = 3;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(131, 12);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.PlaceholderText = "port";
            textBoxPort.Size = new Size(102, 23);
            textBoxPort.TabIndex = 4;
            // 
            // Connect
            // 
            Connect.Location = new Point(239, 13);
            Connect.Name = "Connect";
            Connect.Size = new Size(93, 23);
            Connect.TabIndex = 5;
            Connect.Text = "connectBtn";
            Connect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 422);
            Controls.Add(Connect);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIp);
            Controls.Add(sendBtn);
            Controls.Add(richTextBox1);
            Controls.Add(listBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private Button sendBtn;
        private TextBox textBoxIp;
        private TextBox textBoxPort;
        private Button Connect;
    }
}
