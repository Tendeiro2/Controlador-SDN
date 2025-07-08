namespace LTI_Mikrotik
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            username = new TextBox();
            password = new TextBox();
            Login = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            name = new TextBox();
            ipAddress = new TextBox();
            label5 = new Label();
            listBox1 = new ListBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // username
            // 
            username.Location = new Point(939, 452);
            username.Name = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 1;
            // 
            // password
            // 
            password.Location = new Point(939, 506);
            password.Name = "password";
            password.Size = new Size(125, 27);
            password.TabIndex = 3;
            // 
            // Login
            // 
            Login.BackColor = Color.LightSkyBlue;
            Login.FlatAppearance.BorderColor = Color.Black;
            Login.FlatStyle = FlatStyle.Flat;
            Login.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Login.ForeColor = SystemColors.ActiveCaptionText;
            Login.Location = new Point(917, 565);
            Login.Name = "Login";
            Login.Size = new Size(104, 35);
            Login.TabIndex = 4;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = false;
            Login.Click += Login_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BackgroundImage = Properties.Resources.istockphoto_1200064810_170667a;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.ErrorImage = null;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(850, 118);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(219, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(850, 455);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 6;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(850, 508);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(850, 349);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 10;
            label4.Text = "Name";
            // 
            // name
            // 
            name.Location = new Point(939, 346);
            name.Name = "name";
            name.Size = new Size(125, 27);
            name.TabIndex = 11;
            // 
            // ipAddress
            // 
            ipAddress.Location = new Point(939, 398);
            ipAddress.Name = "ipAddress";
            ipAddress.Size = new Size(125, 27);
            ipAddress.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(850, 401);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 13;
            label5.Text = "IP Address";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(168, 118);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(458, 484);
            listBox1.TabIndex = 14;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1144, 707);
            label1.Name = "label1";
            label1.Size = new Size(171, 60);
            label1.TabIndex = 15;
            label1.Text = "Made by: \r\n                João Tendeiro\r\n                Miguel Lopes\r\n";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources._438b4141_d7f6_4e2a_9f56_6233ba93d680;
            ClientSize = new Size(1327, 776);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(label5);
            Controls.Add(ipAddress);
            Controls.Add(name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(Login);
            Controls.Add(password);
            Controls.Add(username);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox username;
        private TextBox password;
        private Button Login;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox name;
        private TextBox ipAddress;
        private Label label5;
        private ListBox listBox1;
        private Label label1;
    }
}