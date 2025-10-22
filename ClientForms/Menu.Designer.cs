namespace ClientForms
{
    partial class Foem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            humanBth = new Button();
            botBtn = new Button();
            SuspendLayout();
            // 
            // humanBth
            // 
            humanBth.Location = new Point(22, 55);
            humanBth.Name = "humanBth";
            humanBth.Size = new Size(260, 23);
            humanBth.TabIndex = 0;
            humanBth.Text = "Im a Human";
            humanBth.UseVisualStyleBackColor = true;
            // 
            // botBtn
            // 
            botBtn.Location = new Point(22, 93);
            botBtn.Name = "botBtn";
            botBtn.Size = new Size(260, 23);
            botBtn.TabIndex = 1;
            botBtn.Text = "Im a Bot";
            botBtn.UseVisualStyleBackColor = true;
            // 
            // Foem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 179);
            Controls.Add(botBtn);
            Controls.Add(humanBth);
            Name = "Foem";
            Text = "Foem";
            ResumeLayout(false);
        }

        #endregion

        private Button humanBth;
        private Button botBtn;
    }
}