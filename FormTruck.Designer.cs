using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
	partial class FormTruck
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTruck));
			pictureBoxTruck = new PictureBox();
			buttonCreate = new Button();
			buttonUp = new Button();
			buttonDown = new Button();
			buttonLeft = new Button();
			buttonRight = new Button();
			buttonCheckBorders = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBoxTruck).BeginInit();
			SuspendLayout();
			// 
			// pictureBoxTruck
			// 
			pictureBoxTruck.Dock = DockStyle.Fill;
			pictureBoxTruck.Location = new Point(0, 0);
			pictureBoxTruck.Name = "pictureBoxTruck";
			pictureBoxTruck.Size = new Size(900, 500);
			pictureBoxTruck.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBoxTruck.TabIndex = 0;
			pictureBoxTruck.TabStop = false;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(12, 12);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(120, 40);
			buttonCreate.TabIndex = 1;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonUp
			// 
			buttonUp.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonUp.BackgroundImage");
			buttonUp.BackgroundImageLayout = ImageLayout.Zoom;
			buttonUp.Location = new Point(782, 382);
			buttonUp.Name = "buttonUp";
			buttonUp.Size = new Size(50, 50);
			buttonUp.TabIndex = 2;
			buttonUp.UseVisualStyleBackColor = true;
			buttonUp.Click += ButtonMove_Click;
			// 
			// buttonDown
			// 
			buttonDown.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonDown.BackgroundImage");
			buttonDown.BackgroundImageLayout = ImageLayout.Zoom;
			buttonDown.Location = new Point(782, 438);
			buttonDown.Name = "buttonDown";
			buttonDown.Size = new Size(50, 50);
			buttonDown.TabIndex = 3;
			buttonDown.UseVisualStyleBackColor = true;
			buttonDown.Click += ButtonMove_Click;
			// 
			// buttonLeft
			// 
			buttonLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonLeft.BackgroundImage");
			buttonLeft.BackgroundImageLayout = ImageLayout.Zoom;
			buttonLeft.Location = new Point(726, 438);
			buttonLeft.Name = "buttonLeft";
			buttonLeft.Size = new Size(50, 50);
			buttonLeft.TabIndex = 4;
			buttonLeft.UseVisualStyleBackColor = true;
			buttonLeft.Click += ButtonMove_Click;
			// 
			// buttonRight
			// 
			buttonRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonRight.BackgroundImage");
			buttonRight.BackgroundImageLayout = ImageLayout.Zoom;
			buttonRight.Location = new Point(838, 438);
			buttonRight.Name = "buttonRight";
			buttonRight.Size = new Size(50, 50);
			buttonRight.TabIndex = 5;
			buttonRight.UseVisualStyleBackColor = true;
			buttonRight.Click += ButtonMove_Click;
			// 
			// buttonCheckBorders
			// 
			buttonCheckBorders.Location = new Point(12, 448);
			buttonCheckBorders.Name = "buttonCheckBorders";
			buttonCheckBorders.Size = new Size(120, 40);
			buttonCheckBorders.TabIndex = 6;
			buttonCheckBorders.Text = "Проверить границы";
			buttonCheckBorders.UseVisualStyleBackColor = true;
			buttonCheckBorders.Click += ButtonCheckBorders_Click;
			// 
			// FormTruck
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(900, 500);
			Controls.Add(buttonCheckBorders);
			Controls.Add(buttonRight);
			Controls.Add(buttonLeft);
			Controls.Add(buttonDown);
			Controls.Add(buttonUp);
			Controls.Add(buttonCreate);
			Controls.Add(pictureBoxTruck);
			Name = "FormTruck";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Самосвал";
			((System.ComponentModel.ISupportInitialize)pictureBoxTruck).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBoxTruck;
		private Button buttonCreate;
		private Button buttonUp;
		private Button buttonDown;
		private Button buttonLeft;
		private Button buttonRight;
		private Button buttonCheckBorders;
	}
}