using System;
using System.Windows.Forms;
using System.Drawing;

namespace Kontalka.Captcha
{
    internal sealed class CaptchaForm : Form
    {
        public CaptchaForm(Image img)
        {
            InitializeComponent();
            pictureBoxCaptcha.Image = img;
        }

        //	private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.TextBox textBoxCode;
        public string enteredText { get; private set; }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.labelHelp = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.labelHelp);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxCaptcha);
            this.flowLayoutPanel1.Controls.Add(this.textBoxCode);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 110);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxCaptcha
            // 
            //this.pictureBoxCaptcha.Image = global::WindowsFormsApplication1.Properties.Resources.captcha;
            this.pictureBoxCaptcha.InitialImage = null;
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(3, 16);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(206, 60);
            this.pictureBoxCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxCaptcha.TabIndex = 0;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(161, 82);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(47, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(3, 82);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(152, 20);
            this.textBoxCode.TabIndex = 1;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(3, 0);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(206, 13);
            this.labelHelp.TabIndex = 4;
            this.labelHelp.Text = "Пожалуйста, введите текст с картинки";
            // 
            // FormCaptchaEnter
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 136);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCaptchaEnter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Captcha";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxCaptcha)).EndInit();
            this.ResumeLayout(false);

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCaptchaEnter_FormClosed);
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
        }

        #endregion

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //resume thread and return value;
            enteredText = this.textBoxCode.Text;

            this.Hide();
        }

        private void FormCaptchaEnter_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.buttonOK_Click(null, null);
        }
    }
}