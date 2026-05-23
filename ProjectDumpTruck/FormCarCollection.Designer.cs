namespace ProjectDumpTruck
{
    partial class FormCarCollection
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
            groupBox1 = new GroupBox();
            buttonRefresh = new Button();
            buttonGoToCheck = new Button();
            buttonRemoveDumpTruck = new Button();
            maskedTextBoxPosition = new MaskedTextBox();
            buttonAddAdvancedDumpTruck = new Button();
            buttonAddDumpTruck = new Button();
            pictureBox = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonRefresh);
            groupBox1.Controls.Add(buttonGoToCheck);
            groupBox1.Controls.Add(buttonRemoveDumpTruck);
            groupBox1.Controls.Add(maskedTextBoxPosition);
            groupBox1.Controls.Add(buttonAddAdvancedDumpTruck);
            groupBox1.Controls.Add(buttonAddDumpTruck);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(593, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(207, 479);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Инструменты";
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(0, 409);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(207, 29);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // buttonGoToCheck
            // 
            buttonGoToCheck.Location = new Point(0, 374);
            buttonGoToCheck.Name = "buttonGoToCheck";
            buttonGoToCheck.Size = new Size(207, 29);
            buttonGoToCheck.TabIndex = 4;
            buttonGoToCheck.Text = "Передать на тесты";
            buttonGoToCheck.UseVisualStyleBackColor = true;
            buttonGoToCheck.Click += ButtonGoToCheck_Click;
            // 
            // buttonRemoveDumpTruck
            // 
            buttonRemoveDumpTruck.Location = new Point(0, 183);
            buttonRemoveDumpTruck.Name = "buttonRemoveDumpTruck";
            buttonRemoveDumpTruck.Size = new Size(207, 29);
            buttonRemoveDumpTruck.TabIndex = 3;
            buttonRemoveDumpTruck.Text = "Удалить самосвал";
            buttonRemoveDumpTruck.UseVisualStyleBackColor = true;
            buttonRemoveDumpTruck.Click += ButtonRemoveDumpTruck_Click;
            // 
            // maskedTextBoxPosition
            // 
            maskedTextBoxPosition.Location = new Point(0, 150);
            maskedTextBoxPosition.Mask = "00";
            maskedTextBoxPosition.Name = "maskedTextBoxPosition";
            maskedTextBoxPosition.Size = new Size(207, 27);
            maskedTextBoxPosition.TabIndex = 2;
            maskedTextBoxPosition.ValidatingType = typeof(int);
            // 
            // buttonAddAdvancedDumpTruck
            // 
            buttonAddAdvancedDumpTruck.Location = new Point(0, 73);
            buttonAddAdvancedDumpTruck.Name = "buttonAddAdvancedDumpTruck";
            buttonAddAdvancedDumpTruck.Size = new Size(207, 49);
            buttonAddAdvancedDumpTruck.TabIndex = 1;
            buttonAddAdvancedDumpTruck.Text = "Добавление продвинутого самосвала";
            buttonAddAdvancedDumpTruck.UseVisualStyleBackColor = true;
            buttonAddAdvancedDumpTruck.Click += ButtonAddAdvancedDumpTruck_Click;
            // 
            // buttonAddDumpTruck
            // 
            buttonAddDumpTruck.Location = new Point(0, 26);
            buttonAddDumpTruck.Name = "buttonAddDumpTruck";
            buttonAddDumpTruck.Size = new Size(207, 29);
            buttonAddDumpTruck.TabIndex = 0;
            buttonAddDumpTruck.Text = "Добавление самосвала";
            buttonAddDumpTruck.UseVisualStyleBackColor = true;
            buttonAddDumpTruck.Click += ButtonAddDumpTruck_Click;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(593, 479);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // FormCarCollection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(pictureBox);
            Controls.Add(groupBox1);
            Name = "FormCarCollection";
            Text = "Коллекция самосвалов";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox;
        private Button buttonRefresh;
        private Button buttonGoToCheck;
        private Button buttonRemoveDumpTruck;
        private MaskedTextBox maskedTextBoxPosition;
        private Button buttonAddAdvancedDumpTruck;
        private Button buttonAddDumpTruck;
    }
}