namespace WinFormsApp1
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
            btnRunTest = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnRunTest
            // 
            btnRunTest.Location = new Point(0, 0);
            btnRunTest.Name = "btnRunTest";
            btnRunTest.Size = new Size(186, 85);
            btnRunTest.TabIndex = 0;
            btnRunTest.Text = "logout";
            btnRunTest.UseVisualStyleBackColor = true;
            btnRunTest.Click += btnRunTest_Click;
            // 
            // button1
            // 
            button1.Location = new Point(271, 53);
            button1.Name = "button1";
            button1.Size = new Size(232, 131);
            button1.TabIndex = 1;
            button1.Text = "Register exist";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(480, 311);
            button2.Name = "button2";
            button2.Size = new Size(186, 85);
            button2.TabIndex = 2;
            button2.Text = "Contact Us";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnRunTest);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRunTest;
        private Button button1;
        private Button button2;
    }
}
