namespace Kontalka.Music
{
    partial class MusicPanel
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.playButton = new DevExpress.XtraEditors.SimpleButton();
            this.pauseButton = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarBuffer = new DevExpress.XtraEditors.ProgressBarControl();
            this.previousTrackButton = new DevExpress.XtraEditors.SimpleButton();
            this.nextTrackButton = new DevExpress.XtraEditors.SimpleButton();
            this.stopButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBuffer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.playButton);
            this.groupControl1.Controls.Add(this.pauseButton);
            this.groupControl1.Controls.Add(this.progressBarBuffer);
            this.groupControl1.Controls.Add(this.previousTrackButton);
            this.groupControl1.Controls.Add(this.nextTrackButton);
            this.groupControl1.Controls.Add(this.stopButton);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(273, 93);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Здесь будет название";
            // 
            // playButton
            // 
            this.playButton.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.playButton.Appearance.Options.UseBackColor = true;
            this.playButton.Enabled = false;
            this.playButton.Image = global::Kontalka.Properties.Resources.control_play;
            this.playButton.Location = new System.Drawing.Point(140, 44);
            this.playButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.playButton.LookAndFeel.UseDefaultLookAndFeel = false;
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(42, 42);
            this.playButton.TabIndex = 0;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.Appearance.Options.UseBackColor = true;
            this.pauseButton.Image = global::Kontalka.Properties.Resources.control_pause;
            this.pauseButton.Location = new System.Drawing.Point(140, 44);
            this.pauseButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pauseButton.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(42, 42);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Visible = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // progressBarBuffer
            // 
            this.progressBarBuffer.EditValue = "0";
            this.progressBarBuffer.Location = new System.Drawing.Point(87, 25);
            this.progressBarBuffer.Name = "progressBarBuffer";
            this.progressBarBuffer.Size = new System.Drawing.Size(100, 14);
            this.progressBarBuffer.TabIndex = 9;
            // 
            // previousTrackButton
            // 
            this.previousTrackButton.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.previousTrackButton.Appearance.Options.UseBackColor = true;
            this.previousTrackButton.Enabled = false;
            this.previousTrackButton.Image = global::Kontalka.Properties.Resources.control_rewind;
            this.previousTrackButton.Location = new System.Drawing.Point(44, 44);
            this.previousTrackButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.previousTrackButton.LookAndFeel.UseDefaultLookAndFeel = false;
            this.previousTrackButton.Name = "previousTrackButton";
            this.previousTrackButton.Size = new System.Drawing.Size(42, 42);
            this.previousTrackButton.TabIndex = 3;
            // 
            // nextTrackButton
            // 
            this.nextTrackButton.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.nextTrackButton.Appearance.Options.UseBackColor = true;
            this.nextTrackButton.Enabled = false;
            this.nextTrackButton.Image = global::Kontalka.Properties.Resources.control_fastforward;
            this.nextTrackButton.Location = new System.Drawing.Point(188, 44);
            this.nextTrackButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.nextTrackButton.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nextTrackButton.Name = "nextTrackButton";
            this.nextTrackButton.Size = new System.Drawing.Size(42, 42);
            this.nextTrackButton.TabIndex = 2;
            // 
            // stopButton
            // 
            this.stopButton.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.stopButton.Appearance.Options.UseBackColor = true;
            this.stopButton.Enabled = false;
            this.stopButton.Image = global::Kontalka.Properties.Resources.control_stop;
            this.stopButton.Location = new System.Drawing.Point(92, 44);
            this.stopButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.stopButton.LookAndFeel.UseDefaultLookAndFeel = false;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(42, 42);
            this.stopButton.TabIndex = 1;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // MusicPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "MusicPanel";
            this.Size = new System.Drawing.Size(273, 93);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBuffer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton playButton;
        private DevExpress.XtraEditors.SimpleButton pauseButton;
        private DevExpress.XtraEditors.ProgressBarControl progressBarBuffer;
        private DevExpress.XtraEditors.SimpleButton previousTrackButton;
        private DevExpress.XtraEditors.SimpleButton nextTrackButton;
        private DevExpress.XtraEditors.SimpleButton stopButton;
    }
}
