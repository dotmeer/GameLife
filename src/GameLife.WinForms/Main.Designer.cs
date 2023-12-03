
namespace GameLife
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
            StepButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(2, 3);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(75, 23);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButtonClick;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(2, 32);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1000, 1000);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(83, 3);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(75, 23);
            StopButton.TabIndex = 2;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButtonClick;
            // 
            // StepButton
            // 
            StepButton.Location = new Point(164, 3);
            StepButton.Name = "StepButton";
            StepButton.Size = new Size(75, 23);
            StepButton.TabIndex = 3;
            StepButton.Text = "Step";
            StepButton.UseVisualStyleBackColor = true;
            StepButton.Click += StepButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 1036);
            Controls.Add(StepButton);
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
            ResumeLayout(false);
        }

        #endregion

        private Button StartButton;
        private PictureBox pictureBox;
        private Button StopButton;
        private Button StepButton;
    }
}
