namespace MemoryDifferenceTool
{
	partial class DeltaWindow
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
			this.button_SnapShot2 = new System.Windows.Forms.Button();
			this.button_SnapShot1 = new System.Windows.Forms.Button();
			this.button_ExportDirectory = new System.Windows.Forms.Button();
			this.Button_CompareAndWriteCSV = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.WriteStillInfo = new System.Windows.Forms.CheckBox();
			this.label_Snapshot1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label_Path_Snapshot1 = new System.Windows.Forms.Label();
			this.label_Path_Snapshot2 = new System.Windows.Forms.Label();
			this.label_Path_Export = new System.Windows.Forms.Label();
			this.checkBox_Difference = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button_SnapShot2
			// 
			this.button_SnapShot2.Location = new System.Drawing.Point(156, 23);
			this.button_SnapShot2.Name = "button_SnapShot2";
			this.button_SnapShot2.Size = new System.Drawing.Size(75, 23);
			this.button_SnapShot2.TabIndex = 0;
			this.button_SnapShot2.Text = "选择快照2";
			this.button_SnapShot2.UseVisualStyleBackColor = true;
			this.button_SnapShot2.Click += new System.EventHandler(this.button_SnapShot2_Click);
			// 
			// button_SnapShot1
			// 
			this.button_SnapShot1.Location = new System.Drawing.Point(45, 23);
			this.button_SnapShot1.Name = "button_SnapShot1";
			this.button_SnapShot1.Size = new System.Drawing.Size(75, 23);
			this.button_SnapShot1.TabIndex = 1;
			this.button_SnapShot1.Text = "选择快照1";
			this.button_SnapShot1.UseVisualStyleBackColor = true;
			this.button_SnapShot1.Click += new System.EventHandler(this.button2_Click);
			// 
			// button_ExportDirectory
			// 
			this.button_ExportDirectory.Location = new System.Drawing.Point(267, 23);
			this.button_ExportDirectory.Name = "button_ExportDirectory";
			this.button_ExportDirectory.Size = new System.Drawing.Size(97, 23);
			this.button_ExportDirectory.TabIndex = 2;
			this.button_ExportDirectory.Text = "选择导出文件夹";
			this.button_ExportDirectory.UseVisualStyleBackColor = true;
			this.button_ExportDirectory.Click += new System.EventHandler(this.button_ExportDirectory_Click);
			// 
			// Button_CompareAndWriteCSV
			// 
			this.Button_CompareAndWriteCSV.Location = new System.Drawing.Point(56, 161);
			this.Button_CompareAndWriteCSV.Name = "Button_CompareAndWriteCSV";
			this.Button_CompareAndWriteCSV.Size = new System.Drawing.Size(110, 23);
			this.Button_CompareAndWriteCSV.TabIndex = 3;
			this.Button_CompareAndWriteCSV.Text = "生成CSV";
			this.Button_CompareAndWriteCSV.UseVisualStyleBackColor = true;
			this.Button_CompareAndWriteCSV.Click += new System.EventHandler(this.Button_CompareAndWriteCSV_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// WriteStillInfo
			// 
			this.WriteStillInfo.AutoSize = true;
			this.WriteStillInfo.Location = new System.Drawing.Point(221, 202);
			this.WriteStillInfo.Name = "WriteStillInfo";
			this.WriteStillInfo.Size = new System.Drawing.Size(174, 16);
			this.WriteStillInfo.TabIndex = 5;
			this.WriteStillInfo.Text = "生成没变化的内存的CSV文件";
			this.WriteStillInfo.UseVisualStyleBackColor = true;
			// 
			// label_Snapshot1
			// 
			this.label_Snapshot1.AutoSize = true;
			this.label_Snapshot1.Location = new System.Drawing.Point(54, 66);
			this.label_Snapshot1.Name = "label_Snapshot1";
			this.label_Snapshot1.Size = new System.Drawing.Size(41, 12);
			this.label_Snapshot1.TabIndex = 6;
			this.label_Snapshot1.Text = "快照1:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 7;
			this.label1.Text = "快照2:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "导出路径:";
			// 
			// label_Path_Snapshot1
			// 
			this.label_Path_Snapshot1.AutoSize = true;
			this.label_Path_Snapshot1.Location = new System.Drawing.Point(101, 66);
			this.label_Path_Snapshot1.Name = "label_Path_Snapshot1";
			this.label_Path_Snapshot1.Size = new System.Drawing.Size(0, 12);
			this.label_Path_Snapshot1.TabIndex = 10;
			// 
			// label_Path_Snapshot2
			// 
			this.label_Path_Snapshot2.AutoSize = true;
			this.label_Path_Snapshot2.Location = new System.Drawing.Point(101, 89);
			this.label_Path_Snapshot2.Name = "label_Path_Snapshot2";
			this.label_Path_Snapshot2.Size = new System.Drawing.Size(0, 12);
			this.label_Path_Snapshot2.TabIndex = 11;
			// 
			// label_Path_Export
			// 
			this.label_Path_Export.AutoSize = true;
			this.label_Path_Export.Location = new System.Drawing.Point(101, 110);
			this.label_Path_Export.Name = "label_Path_Export";
			this.label_Path_Export.Size = new System.Drawing.Size(0, 12);
			this.label_Path_Export.TabIndex = 12;
			// 
			// checkBox_Difference
			// 
			this.checkBox_Difference.AutoSize = true;
			this.checkBox_Difference.Checked = true;
			this.checkBox_Difference.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_Difference.Location = new System.Drawing.Point(221, 161);
			this.checkBox_Difference.Name = "checkBox_Difference";
			this.checkBox_Difference.Size = new System.Drawing.Size(48, 16);
			this.checkBox_Difference.TabIndex = 13;
			this.checkBox_Difference.Text = "差分";
			this.checkBox_Difference.UseVisualStyleBackColor = true;
			// 
			// DeltaWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 289);
			this.Controls.Add(this.checkBox_Difference);
			this.Controls.Add(this.label_Path_Export);
			this.Controls.Add(this.label_Path_Snapshot2);
			this.Controls.Add(this.label_Path_Snapshot1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_Snapshot1);
			this.Controls.Add(this.WriteStillInfo);
			this.Controls.Add(this.Button_CompareAndWriteCSV);
			this.Controls.Add(this.button_ExportDirectory);
			this.Controls.Add(this.button_SnapShot1);
			this.Controls.Add(this.button_SnapShot2);
			this.Name = "DeltaWindow";
			this.Text = "MemoryDifferenceTool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_SnapShot2;
		private System.Windows.Forms.Button button_SnapShot1;
		private System.Windows.Forms.Button button_ExportDirectory;
		private System.Windows.Forms.Button Button_CompareAndWriteCSV;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.CheckBox WriteStillInfo;
		private System.Windows.Forms.Label label_Snapshot1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_Path_Snapshot1;
		private System.Windows.Forms.Label label_Path_Snapshot2;
		private System.Windows.Forms.Label label_Path_Export;
		private System.Windows.Forms.CheckBox checkBox_Difference;
	}
}

