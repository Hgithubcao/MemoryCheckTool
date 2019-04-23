namespace MemoryCheckTool
{
	partial class ReferenceTreeWindow
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
			this.ReferenceTree = new System.Windows.Forms.TreeView();
			this.SearchPointer = new System.Windows.Forms.Button();
			this.TargetPointer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SnapShotDirectory = new System.Windows.Forms.Button();
			this.AllBuildeTree = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SnapShotPath = new System.Windows.Forms.Label();
			this.OpenSnapShot = new System.Windows.Forms.OpenFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.Depth = new System.Windows.Forms.TextBox();
			this.Path = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// ReferenceTree
			// 
			this.ReferenceTree.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ReferenceTree.Location = new System.Drawing.Point(0, 147);
			this.ReferenceTree.Name = "ReferenceTree";
			this.ReferenceTree.Size = new System.Drawing.Size(754, 424);
			this.ReferenceTree.TabIndex = 15;
			this.ReferenceTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ReferenceTree_AfterExpand);
			this.ReferenceTree.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.ReferenceTree_NodeMouseHover);
			this.ReferenceTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ReferenceTree_NodeMouseClick);
			// 
			// SearchPointer
			// 
			this.SearchPointer.Location = new System.Drawing.Point(234, 96);
			this.SearchPointer.Name = "SearchPointer";
			this.SearchPointer.Size = new System.Drawing.Size(75, 23);
			this.SearchPointer.TabIndex = 18;
			this.SearchPointer.Text = "搜索";
			this.SearchPointer.UseVisualStyleBackColor = true;
			this.SearchPointer.Click += new System.EventHandler(this.SearchPointer_Click);
			// 
			// TargetPointer
			// 
			this.TargetPointer.Location = new System.Drawing.Point(87, 73);
			this.TargetPointer.Name = "TargetPointer";
			this.TargetPointer.Size = new System.Drawing.Size(100, 21);
			this.TargetPointer.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 20;
			this.label3.Text = "Pointer:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SnapShotDirectory
			// 
			this.SnapShotDirectory.Location = new System.Drawing.Point(12, 12);
			this.SnapShotDirectory.Name = "SnapShotDirectory";
			this.SnapShotDirectory.Size = new System.Drawing.Size(75, 23);
			this.SnapShotDirectory.TabIndex = 21;
			this.SnapShotDirectory.Text = "选择快照";
			this.SnapShotDirectory.UseVisualStyleBackColor = true;
			this.SnapShotDirectory.Click += new System.EventHandler(this.SnapShotDirectory_Click);
			// 
			// AllBuildeTree
			// 
			this.AllBuildeTree.AutoSize = true;
			this.AllBuildeTree.Location = new System.Drawing.Point(234, 75);
			this.AllBuildeTree.Name = "AllBuildeTree";
			this.AllBuildeTree.Size = new System.Drawing.Size(96, 16);
			this.AllBuildeTree.TabIndex = 22;
			this.AllBuildeTree.Text = "生成全部节点";
			this.AllBuildeTree.UseVisualStyleBackColor = true;
			this.AllBuildeTree.CheckedChanged += new System.EventHandler(this.AllBuildeTree_CheckedChanged);
			// 
			// label1
			// 
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label1.Location = new System.Drawing.Point(10, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 23;
			this.label1.Text = "快照地址:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SnapShotPath
			// 
			this.SnapShotPath.AutoSize = true;
			this.SnapShotPath.Location = new System.Drawing.Point(85, 51);
			this.SnapShotPath.Name = "SnapShotPath";
			this.SnapShotPath.Size = new System.Drawing.Size(11, 12);
			this.SnapShotPath.TabIndex = 24;
			this.SnapShotPath.Text = " ";
			this.SnapShotPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OpenSnapShot
			// 
			this.OpenSnapShot.FileName = "OpenSnapShot";
			this.OpenSnapShot.Filter = "文本文件|*.txt|Excel文件|*.csv";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 27;
			this.label2.Text = "深度:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Depth
			// 
			this.Depth.Location = new System.Drawing.Point(87, 101);
			this.Depth.Name = "Depth";
			this.Depth.Size = new System.Drawing.Size(100, 21);
			this.Depth.TabIndex = 28;
			this.Depth.Text = "10";
			// 
			// Path
			// 
			this.Path.FormattingEnabled = true;
			this.Path.HorizontalScrollbar = true;
			this.Path.ItemHeight = 12;
			this.Path.Location = new System.Drawing.Point(336, 12);
			this.Path.Name = "Path";
			this.Path.Size = new System.Drawing.Size(406, 124);
			this.Path.Sorted = true;
			this.Path.TabIndex = 31;
			// 
			// ReferenceTreeWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 571);
			this.Controls.Add(this.Path);
			this.Controls.Add(this.Depth);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SnapShotPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AllBuildeTree);
			this.Controls.Add(this.SnapShotDirectory);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TargetPointer);
			this.Controls.Add(this.SearchPointer);
			this.Controls.Add(this.ReferenceTree);
			this.Name = "ReferenceTreeWindow";
			this.Text = "ReferenceTreeWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView ReferenceTree;
		private System.Windows.Forms.Button SearchPointer;
		private System.Windows.Forms.TextBox TargetPointer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button SnapShotDirectory;
		private System.Windows.Forms.CheckBox AllBuildeTree;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label SnapShotPath;
		private System.Windows.Forms.OpenFileDialog OpenSnapShot;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Depth;
		private System.Windows.Forms.ListBox Path;
	}
}