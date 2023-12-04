
namespace GameLife.WinForms
{
    partial class Main
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
            _cancellationTokenSource.Cancel();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartButton = new Button();
            pictureBox = new PictureBox();
            StopButton = new Button();
            IterationsLabel = new Label();
            ScaleComboBox = new ComboBox();
            ScaleGroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ScaleGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(1009, 3);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(120, 30);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1000, 1000);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(1009, 39);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(120, 30);
            StopButton.TabIndex = 2;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // IterationsLabel
            // 
            IterationsLabel.Location = new Point(1009, 72);
            IterationsLabel.Name = "IterationsLabel";
            IterationsLabel.Size = new Size(120, 30);
            IterationsLabel.TabIndex = 3;
            IterationsLabel.Text = "Итераций: 0";
            // 
            // ScaleComboBox
            // 
            ScaleComboBox.FormattingEnabled = true;
            ScaleComboBox.Items.AddRange(new object[] { "1", "2", "4", "5", "10" });
            ScaleComboBox.Location = new Point(6, 22);
            ScaleComboBox.Name = "ScaleComboBox";
            ScaleComboBox.Size = new Size(105, 23);
            ScaleComboBox.TabIndex = 4;
            ScaleComboBox.Text = "5";
            ScaleComboBox.SelectedIndexChanged += ScaleComboBox_SelectedIndexChanged;
            // 
            // ScaleGroupBox
            // 
            ScaleGroupBox.Controls.Add(ScaleComboBox);
            ScaleGroupBox.Location = new Point(1011, 105);
            ScaleGroupBox.Name = "ScaleGroupBox";
            ScaleGroupBox.Size = new Size(118, 59);
            ScaleGroupBox.TabIndex = 6;
            ScaleGroupBox.TabStop = false;
            ScaleGroupBox.Text = "Масштаб";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 1011);
            Controls.Add(ScaleGroupBox);
            Controls.Add(IterationsLabel);
            Controls.Add(StopButton);
            Controls.Add(pictureBox);
            Controls.Add(StartButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.Manual;
            Text = "Main";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ScaleGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button StartButton;
        private PictureBox pictureBox;
        private Button StopButton;
        private Label IterationsLabel;
        private ComboBox ScaleComboBox;
        private GroupBox ScaleGroupBox;
    }
}
