﻿namespace Kontalka
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.listId = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listF = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listH = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.myNameLabel = new System.Windows.Forms.Label();
            this.myStatusTextBox = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.status_send = new System.Windows.Forms.Button();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.friendsTab = new DevExpress.XtraTab.XtraTabPage();
            this.newsTab = new DevExpress.XtraTab.XtraTabPage();
            this.musicTab = new DevExpress.XtraTab.XtraTabPage();
            this.settingsTab = new DevExpress.XtraTab.XtraTabPage();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.friendsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // listId
            // 
            this.listId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listId.FormattingEnabled = true;
            this.listId.Location = new System.Drawing.Point(0, 0);
            this.listId.Name = "listId";
            this.listId.Size = new System.Drawing.Size(273, 291);
            this.listId.TabIndex = 0;
            this.listId.SelectedIndexChanged += new System.EventHandler(this.listF_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(297, 400);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 50);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStrip1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(691, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tStrip1
            // 
            this.tStrip1.Name = "tStrip1";
            this.tStrip1.Size = new System.Drawing.Size(0, 17);
            // 
            // listF
            // 
            this.listF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listF.FormattingEnabled = true;
            this.listF.Location = new System.Drawing.Point(0, 0);
            this.listF.Name = "listF";
            this.listF.Size = new System.Drawing.Size(273, 291);
            this.listF.TabIndex = 4;
            this.listF.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(91, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listH
            // 
            this.listH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2});
            this.listH.GridLines = true;
            this.listH.Location = new System.Drawing.Point(297, 159);
            this.listH.Name = "listH";
            this.listH.Size = new System.Drawing.Size(380, 241);
            this.listH.TabIndex = 7;
            this.listH.UseCompatibleStateImageBehavior = false;
            this.listH.View = System.Windows.Forms.View.Tile;
            // 
            // col1
            // 
            this.col1.Width = 10;
            // 
            // col2
            // 
            this.col2.Width = 100;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(91, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(91, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // myNameLabel
            // 
            this.myNameLabel.AutoSize = true;
            this.myNameLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myNameLabel.Location = new System.Drawing.Point(91, 5);
            this.myNameLabel.Name = "myNameLabel";
            this.myNameLabel.Size = new System.Drawing.Size(80, 19);
            this.myNameLabel.TabIndex = 13;
            this.myNameLabel.Text = "myName";
            // 
            // myStatusTextBox
            // 
            this.myStatusTextBox.Location = new System.Drawing.Point(91, 28);
            this.myStatusTextBox.Multiline = true;
            this.myStatusTextBox.Name = "myStatusTextBox";
            this.myStatusTextBox.ReadOnly = true;
            this.myStatusTextBox.Size = new System.Drawing.Size(179, 57);
            this.myStatusTextBox.TabIndex = 2;
            this.myStatusTextBox.Click += new System.EventHandler(this.StatusChange);
            this.myStatusTextBox.TextChanged += new System.EventHandler(this.myStatusTextBox_TextChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Webdings", 27.75F);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.SystemColors.Highlight;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Location = new System.Drawing.Point(627, 400);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(50, 50);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "]";
            this.simpleButton1.Click += new System.EventHandler(this.button1_Click);
            this.simpleButton1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleButton1_KeyDown);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.status_send);
            this.panelControl1.Controls.Add(this.myStatusTextBox);
            this.panelControl1.Controls.Add(this.myNameLabel);
            this.panelControl1.Controls.Add(this.pictureBox2);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(279, 117);
            this.panelControl1.TabIndex = 16;
            // 
            // status_send
            // 
            this.status_send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.status_send.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.status_send.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.status_send.Location = new System.Drawing.Point(237, 52);
            this.status_send.Name = "status_send";
            this.status_send.Size = new System.Drawing.Size(33, 33);
            this.status_send.TabIndex = 18;
            this.status_send.Text = "V";
            this.status_send.UseVisualStyleBackColor = true;
            this.status_send.Click += new System.EventHandler(this.status_send_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Location = new System.Drawing.Point(297, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(380, 117);
            this.panelControl2.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(91, 28);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(179, 57);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(91, 28);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(179, 57);
            this.textBox3.TabIndex = 14;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 135);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            this.xtraTabControl1.PaintStyleName = "Skin";
            this.xtraTabControl1.SelectedTabPage = this.friendsTab;
            this.xtraTabControl1.Size = new System.Drawing.Size(279, 320);
            this.xtraTabControl1.TabIndex = 18;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.friendsTab,
            this.newsTab,
            this.musicTab,
            this.settingsTab});
            // 
            // friendsTab
            // 
            this.friendsTab.Controls.Add(this.listF);
            this.friendsTab.Controls.Add(this.listId);
            this.friendsTab.Image = global::Kontalka.Properties.Resources.friends;
            this.friendsTab.Name = "friendsTab";
            this.friendsTab.Size = new System.Drawing.Size(273, 291);
            this.friendsTab.Text = "Друзья";
            // 
            // newsTab
            // 
            this.newsTab.Image = global::Kontalka.Properties.Resources.news;
            this.newsTab.Name = "newsTab";
            this.newsTab.Size = new System.Drawing.Size(273, 291);
            // 
            // musicTab
            // 
            this.musicTab.Image = global::Kontalka.Properties.Resources.music;
            this.musicTab.Name = "musicTab";
            this.musicTab.Size = new System.Drawing.Size(273, 291);
            // 
            // settingsTab
            // 
            this.settingsTab.Image = global::Kontalka.Properties.Resources.settings;
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(273, 291);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 480);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listH);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Конталка";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.friendsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listId;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tStrip1;
        private System.Windows.Forms.ListBox listF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listH;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label myNameLabel;
        private System.Windows.Forms.TextBox myStatusTextBox;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button status_send;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage friendsTab;
        private DevExpress.XtraTab.XtraTabPage newsTab;
        private DevExpress.XtraTab.XtraTabPage musicTab;
        private DevExpress.XtraTab.XtraTabPage settingsTab;
    }
}