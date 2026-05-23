namespace ProjectDumpTruck
{
    partial class FormDumpTruck
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
            pictureBoxDumpTruck = new PictureBox();
            buttonCreate = new Button();
            buttonRight = new Button();
            buttonUp = new Button();
            buttonDown = new Button();
            buttonLeft = new Button();
            buttonCheck = new Button();
            buttonCreateAdvancedDumpTruck = new Button();
            comboBoxPointOfDestination = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDumpTruck).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxDumpTruck
            // 
            pictureBoxDumpTruck.Dock = DockStyle.Fill;
            pictureBoxDumpTruck.Location = new Point(0, 0);
            pictureBoxDumpTruck.Name = "pictureBoxDumpTruck";
            pictureBoxDumpTruck.Size = new Size(882, 453);
            pictureBoxDumpTruck.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxDumpTruck.TabIndex = 0;
            pictureBoxDumpTruck.TabStop = false;
            // 
            // buttonCreate
            // 
            buttonCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCreate.Location = new Point(13, 413);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(157, 29);
            buttonCreate.TabIndex = 1;
            buttonCreate.Text = "Создать самосвал";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += ButtonCreate_Click;
            // 
            // buttonRight
            // 
            buttonRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRight.BackgroundImage = Properties.Resources.right;
            buttonRight.BackgroundImageLayout = ImageLayout.Stretch;
            buttonRight.Location = new Point(829, 364);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(30, 30);
            buttonRight.TabIndex = 2;
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += ButtonMove_Click;
            // 
            // buttonUp
            // 
            buttonUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUp.BackgroundImage = Properties.Resources.up;
            buttonUp.BackgroundImageLayout = ImageLayout.Stretch;
            buttonUp.Location = new Point(777, 327);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(30, 30);
            buttonUp.TabIndex = 3;
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += ButtonMove_Click;
            // 
            // buttonDown
            // 
            buttonDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDown.BackgroundImage = Properties.Resources.down;
            buttonDown.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDown.Location = new Point(777, 400);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(30, 30);
            buttonDown.TabIndex = 4;
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += ButtonMove_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLeft.BackgroundImage = Properties.Resources.left;
            buttonLeft.BackgroundImageLayout = ImageLayout.Stretch;
            buttonLeft.Location = new Point(726, 364);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(30, 30);
            buttonLeft.TabIndex = 5;
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += ButtonMove_Click;
            // 
            // buttonCheck
            // 
            buttonCheck.Location = new Point(13, 12);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(157, 29);
            buttonCheck.TabIndex = 6;
            buttonCheck.Text = " Проверка границ";
            buttonCheck.UseVisualStyleBackColor = true;
            buttonCheck.Click += ButtonCheckBorders_Click;
            // 
            // buttonCreateAdvancedDumpTruck
            // 
            buttonCreateAdvancedDumpTruck.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCreateAdvancedDumpTruck.Location = new Point(176, 413);
            buttonCreateAdvancedDumpTruck.Name = "buttonCreateAdvancedDumpTruck";
            buttonCreateAdvancedDumpTruck.Size = new Size(285, 29);
            buttonCreateAdvancedDumpTruck.TabIndex = 7;
            buttonCreateAdvancedDumpTruck.Text = "Создать продвинутый самосвал";
            buttonCreateAdvancedDumpTruck.UseVisualStyleBackColor = true;
            buttonCreateAdvancedDumpTruck.Click += buttonCreateSportDumpTruck_Click;
            // 
            // comboBoxPointOfDestination
            // 
            comboBoxPointOfDestination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxPointOfDestination.FormattingEnabled = true;
            comboBoxPointOfDestination.Location = new Point(719, 12);
            comboBoxPointOfDestination.Name = "comboBoxPointOfDestination";
            comboBoxPointOfDestination.Size = new Size(151, 28);
            comboBoxPointOfDestination.TabIndex = 8;
            comboBoxPointOfDestination.SelectedIndexChanged += ComboBoxPointOfDestination_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(776, 46);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "Шаг";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonMovementStep_Click;
            // 
            // FormDumpTruck
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 453);
            Controls.Add(button2);
            Controls.Add(comboBoxPointOfDestination);
            Controls.Add(buttonCreateAdvancedDumpTruck);
            Controls.Add(buttonCheck);
            Controls.Add(buttonLeft);
            Controls.Add(buttonDown);
            Controls.Add(buttonUp);
            Controls.Add(buttonRight);
            Controls.Add(buttonCreate);
            Controls.Add(pictureBoxDumpTruck);
            Location = new Point(272, 126);
            Name = "FormDumpTruck";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DumpTruck";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)pictureBoxDumpTruck).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxDumpTruck;
        private Button buttonCreate;
        private Button buttonRight;
        private Button buttonUp;
        private Button buttonDown;
        private Button buttonLeft;
        private Button buttonCheck;
        private Button buttonCreateAdvancedDumpTruck;
        private ComboBox comboBoxPointOfDestination;
        private Button button2;
    }
}
