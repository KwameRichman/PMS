namespace Pharmacy2
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label14 = new Label();
            label1 = new Label();
            UNameTb = new TextBox();
            PassTb = new TextBox();
            LoginBtn = new Button();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-113, -16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 337);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.PaleTurquoise;
            label14.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.DarkSlateGray;
            label14.Location = new Point(-1, 90);
            label14.Name = "label14";
            label14.Size = new Size(113, 28);
            label14.TabIndex = 26;
            label14.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PaleTurquoise;
            label1.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkSlateGray;
            label1.Location = new Point(8, 149);
            label1.Name = "label1";
            label1.Size = new Size(104, 28);
            label1.TabIndex = 27;
            label1.Text = "Password";
            // 
            // UNameTb
            // 
            UNameTb.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point);
            UNameTb.Location = new Point(329, 88);
            UNameTb.Name = "UNameTb";
            UNameTb.PlaceholderText = "First Name";
            UNameTb.Size = new Size(260, 30);
            UNameTb.TabIndex = 50;
            // 
            // PassTb
            // 
            PassTb.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PassTb.Location = new Point(329, 147);
            PassTb.Name = "PassTb";
            PassTb.PasswordChar = '*';
            PassTb.PlaceholderText = "Password";
            PassTb.Size = new Size(260, 30);
            PassTb.TabIndex = 51;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.Gainsboro;
            LoginBtn.ForeColor = Color.Teal;
            LoginBtn.Location = new Point(405, 192);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(101, 44);
            LoginBtn.TabIndex = 54;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(190, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(112, 321);
            panel1.TabIndex = 56;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PaleTurquoise;
            label2.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkSlateGray;
            label2.Location = new Point(405, 38);
            label2.Name = "label2";
            label2.Size = new Size(110, 28);
            label2.TabIndex = 28;
            label2.Text = "Welcome!";
            // 
            // button1
            // 
            button1.BackColor = Color.Gainsboro;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(577, 0);
            button1.Name = "button1";
            button1.Size = new Size(41, 33);
            button1.TabIndex = 57;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(617, 311);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(LoginBtn);
            Controls.Add(PassTb);
            Controls.Add(UNameTb);
            Controls.Add(pictureBox1);
            Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label14;
        private Label label1;
        private TextBox UNameTb;
        private TextBox PassTb;
        private Button LoginBtn;
        private Panel panel1;
        private Label label2;
        private Button button1;
    }
}