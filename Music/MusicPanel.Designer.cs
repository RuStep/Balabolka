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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPanel));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.audioListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pauseButton = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarBuffer = new DevExpress.XtraEditors.ProgressBarControl();
            this.previousTrackButton = new DevExpress.XtraEditors.SimpleButton();
            this.nextTrackButton = new DevExpress.XtraEditors.SimpleButton();
            this.stopButton = new DevExpress.XtraEditors.SimpleButton();
            this.playButton = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBuffer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.audioListBox);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(273, 291);
            this.splitContainerControl1.SplitterPosition = 194;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // audioListBox
            // 
            this.audioListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioListBox.FormattingEnabled = true;
            this.audioListBox.Location = new System.Drawing.Point(0, 20);
            this.audioListBox.Name = "audioListBox";
            this.audioListBox.Size = new System.Drawing.Size(273, 174);
            this.audioListBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchButtonEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 20);
            this.panel1.TabIndex = 2;
            // 
            // searchButtonEdit
            // 
            this.searchButtonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButtonEdit.Location = new System.Drawing.Point(0, 0);
            this.searchButtonEdit.Name = "searchButtonEdit";
            this.searchButtonEdit.Properties.Appearance.Options.UseImage = true;
            this.searchButtonEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            serializableAppearanceObject2.Options.UseImage = true;
            this.searchButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, ((System.Drawing.Image)(resources.GetObject("searchButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.searchButtonEdit.Size = new System.Drawing.Size(273, 20);
            this.searchButtonEdit.TabIndex = 1;
            this.searchButtonEdit.TextChanged += new System.EventHandler(this.searchButtonEdit_TextChanged);
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
            this.groupControl1.Size = new System.Drawing.Size(273, 92);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Здесь будет название";
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MusicPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MusicPanel";
            this.Size = new System.Drawing.Size(273, 291);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBuffer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton playButton;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton stopButton;
        private DevExpress.XtraEditors.ButtonEdit searchButtonEdit;
        private System.Windows.Forms.ListBox audioListBox;
        private DevExpress.XtraEditors.SimpleButton previousTrackButton;
        private DevExpress.XtraEditors.SimpleButton nextTrackButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarBuffer;
        private DevExpress.XtraEditors.SimpleButton pauseButton;
    }
}
