using MemoryDifferenceTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryCheckTool
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ToDeltaWindow_Click(object sender, EventArgs e)
		{
			Form deltaWindow = new DeltaWindow();
			deltaWindow.Show();
		}

		private void ToReferenceTreeWindow_Click_1(object sender, EventArgs e)
		{
			Form referenceWindow = new ReferenceTreeWindow();
			referenceWindow.Show();
		}
	}
}
