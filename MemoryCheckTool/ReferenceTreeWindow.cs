using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryCheckTool
{
	public partial class ReferenceTreeWindow : Form
	{
		//private List<SnapShotInfo> m_DeltaInfos = new List<SnapShotInfo>();
		private Dictionary<string, SnapShotInfo> m_PointerToSnapShotInfo = new Dictionary<string, SnapShotInfo>();
		private Dictionary<string, TreeNode> m_CycleBeginNode = new Dictionary<string, TreeNode>();
		//private const int HAVE_NOT_VISITED = 0;
		//private const int VISIT_ONE_TIME = 1;

		public ReferenceTreeWindow()
		{
			InitializeComponent();
		}

		private void LoadReferenceTree()
		{
			Stopwatch time = new Stopwatch();
			time.Restart();
			foreach (SnapShotInfo info in m_PointerToSnapShotInfo.Values)
			{
				TreeNode rootNode = new TreeNode(string.Format("{0}_{1}({2})", info.Pointer, info.TypeName, info.Size));
				if (info.Reference != "")
				{
					TreeNode childNodeTip = new TreeNode(info.Reference);
					rootNode.Nodes.Add(childNodeTip);
				}
				ReferenceTree.Nodes.Add(rootNode);
			}
			time.Stop();
			MessageBox.Show("节点全部生成成功，耗时" + (time.ElapsedMilliseconds / 1000.00 + 0.005).ToString("f2") + "s");
		}

		private string GetNodePointer(TreeNode node)
		{
			int firstIndex = 0;
			int secondIndex = node.Text.IndexOf("_");
			string result = node.Text.Substring(firstIndex, secondIndex - firstIndex);
			return result;
		}

		private string GetNodeTypeName(TreeNode node)
		{
			int firstIndex = node.Text.IndexOf("_");
			int secondIndex = node.Text.IndexOf("(");
			string result = node.Text.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
			return result;
		}

		private void HasChildNodeTip(TreeNode node, string reference)
		{
			if (reference != "")
			{
				TreeNode childNodeTip = new TreeNode(reference);
				node.Nodes.Add(childNodeTip);
			}
		}

		private bool FindNoCycle(TreeNode node, string nodeReference, List<string> nodeHasVisited, string path, int depth)
		{
			//TODO 有些叶子节点不能显示，弄个遍历看看什么情况
			string pointer = GetNodePointer(node);
			if (m_CycleBeginNode.ContainsKey(pointer))
			{
				HasChildNodeTip(node, nodeReference);
				return false;
				//if (m_NodeVisitTimes[pointer] != null)
				{
					//node = m_NodeVisitTimes[pointer].Clone() as TreeNode;
					//node.Nodes.AddRange(m_NodeVisitTimes[pointer]);
					/*if (m_NodeVisitTimes[pointer].ForeColor == System.Drawing.Color.Red)
						return true;
					else
						return false;*/
					//m_NodeVisitTimes[pointer] = HAVE_NOT_VISITED;
					//node.ForeColor = System.Drawing.Color.Red;
					//HasChildNodeTip(node, nodeReference);
					
					//return false;
				}
				/*if (m_NodeVisitTimes[pointer] == HAVE_NOT_VISITED)
				{
					m_NodeVisitTimes[pointer] = VISIT_ONE_TIME;
					//node.ForeColor = System.Drawing.Color.Red;
				}*/
				
				
				//return m_NodeVisitTimes[pointer];
			}
			if (depth > int.Parse(Depth.Text))
			{
				HasChildNodeTip(node, nodeReference);
				return false;
			}
			else
			{
				if (nodeHasVisited.Contains(pointer))
				{
					HasChildNodeTip(node, nodeReference);
					if(!m_CycleBeginNode.ContainsKey(pointer))
						m_CycleBeginNode.Add(pointer, null);
					return false;
				}
				if (nodeReference == "")	//没有引用了说明没有循环
				{
					node.ForeColor = System.Drawing.Color.Red;
					//Path.AutoScorll();
					//Path.Text += path + GetNodeTypeName(node) + "\n";
					Path.Items.Add(path + "/" + GetNodeTypeName(node));
					//m_NodeVisitTimes.Add(pointer, true);
					return true;
				}
				string[] reference = nodeReference.Split('|');
				bool hasNoCycle = false;
				nodeHasVisited.Add(pointer);
				
				for (int i = 1; i < reference.Length; i++)
				{
					if (!m_PointerToSnapShotInfo.ContainsKey(reference[i]))
					{
						continue;
					}




					/*TreeNode childNode;
					if (m_NodeVisitTimes.ContainsKey(reference[i]))
					{
						if (m_NodeVisitTimes[reference[i]] != null)
						{
							childNode = m_NodeVisitTimes[reference[i]].Clone() as TreeNode;
							node.Nodes.Add(childNode);
							if (m_NodeVisitTimes[reference[i]].ForeColor == System.Drawing.Color.Red)
								hasNoCycle = true;
							continue;
						}
					}*/


					SnapShotInfo info = m_PointerToSnapShotInfo[reference[i]];
					TreeNode childNode = new TreeNode(string.Format("{0}_{1}({2})", info.Pointer, info.TypeName, info.Size));
					bool foreColorToRed = FindNoCycle(childNode, info.Reference, nodeHasVisited, path + "/" + info.TypeName,depth + 1);
					hasNoCycle |= foreColorToRed;
					node.Nodes.Add(childNode);
					if (foreColorToRed)
					{
						//if (!m_NodeHasNoCycle.ContainsKey(pointer))
						{
							//m_NodeHasNoCycle.Add(pointer, hasNoCycle);
						}
						node.ForeColor = System.Drawing.Color.Red;
					}
				}
				nodeHasVisited.Remove(pointer);
				/*if (m_NodeVisitTimes.ContainsKey(pointer) && !nodeHasVisited.Contains(pointer))
				{
					if (m_NodeVisitTimes[pointer] == null)
					{
						m_NodeVisitTimes[pointer] = new TreeNode();
						//m_NodeVisitTimes[pointer].Nodes.Add(node.Clone() as TreeNode);
						//m_NodeVisitTimes[pointer] = new TreeNode();
						m_NodeVisitTimes[pointer] = node.Clone() as TreeNode;
						//ReferenceTree.TopNode = node.Clone() as TreeNode;
						//label1.Text = "1";
						//m_NodeVisitTimes[pointer].Nodes.
					}
				}*/
				//if (m_NodeHasNoCycle.ContainsKey(pointer))
				//{
					//m_NodeHasNoCycle.Add(pointer, hasNoCycle);
				//}
				
				return hasNoCycle;
			}
		}

		private void ReferenceTree_AfterExpand(object sender, TreeViewEventArgs e)
		{
			TreeNode selectedNode = e.Node as TreeNode;
			if (selectedNode.Nodes[0].Text.IndexOf("|") > -1)
			{
				//m_DeltaInfos.Sort(SnapShotInfo.Pointer);
				string[] reference = selectedNode.Nodes[0].Text.Split('|');
				selectedNode.Nodes[0].Remove();
				for (int i = 0; i < reference.Length; i++)
				{
					if (!m_PointerToSnapShotInfo.ContainsKey(reference[i]))
					{
						if (reference[i] != "")
							selectedNode.Nodes.Add("不存在" + reference[i]);
						continue;
					}
					SnapShotInfo info = m_PointerToSnapShotInfo[reference[i]];
					TreeNode childNode = new TreeNode(string.Format("{0}_{1}({2})", info.Pointer, info.TypeName, info.Size));
					if (info.Reference != "")
					{
						TreeNode grandchildNodeTip = new TreeNode(info.Reference);
						childNode.Nodes.Add(grandchildNodeTip);
					}
					/*if (m_NodeHasNoCycle.ContainsKey(info.Pointer.ToString()))
					{
						if (m_NodeHasNoCycle[info.Pointer.ToString()])
						{
							childNode.ForeColor = System.Drawing.Color.Red;
						}
					}*/
					selectedNode.Nodes.Add(childNode);
				}


			}
		}

		
		void SearchPointer_Click(object sender, EventArgs e)
		{
			if (AllBuildeTree.Checked)
			{
				if (MessageBox.Show("全部节点生成时间较长，确定继续?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
					LoadReferenceTree();
			}
			else
			{
				m_CycleBeginNode.Clear();
				ReferenceTree.Nodes.Clear();
				if (!m_PointerToSnapShotInfo.ContainsKey(TargetPointer.Text))
				{
					MessageBox.Show("未能找到 " + TargetPointer.Text);
					return;
				}
				SnapShotInfo info = m_PointerToSnapShotInfo[TargetPointer.Text];
				//Path.Text = string.Format("Pointer:{0}\nTypeName:{1}\nSize:{2}\nStack:{3}", info.Pointer, info.TypeName, info.Size, info.Stack);
				TreeNode rootNode = new TreeNode(string.Format("{0}_{1}({2})", info.Pointer, info.TypeName, info.Size));
				/*if (info.Reference != "")
				{
					TreeNode childNodeTip = new TreeNode(info.Reference);
					rootNode.Nodes.Add(childNodeTip);
				}*/
				List<string> nodeHasVisited = new List<string>();
				//nodeHasVisited.Add(info.Pointer.ToString());
				FindNoCycle(rootNode, info.Reference, nodeHasVisited, info.TypeName, 0);
				ReferenceTree.Nodes.Add(rootNode);
				nodeHasVisited.Clear();
			}
		}

		private SnapShotInfo TxtToShopShotInfo(string oneLineString)
		{
			LitJson.JsonData oneLineJsonData = LitJson.JsonMapper.ToObject(oneLineString);
			SnapShotInfo info = new SnapShotInfo();
			info.Pointer = int.Parse(oneLineJsonData[0].ToString());//"ptr"
			info.TypeName = oneLineJsonData[1].ToString();//"type" 
			info.Size = oneLineJsonData[2].ToString();//"size"
			info.Stack = oneLineJsonData[3].ToString();//"stack"
			info.Reference = oneLineJsonData[4].ToString();//"reference"

			return info;
		}

		private SnapShotInfo CsvToShopShotInfo(string oneLineString)
		{
			SnapShotInfo info = new SnapShotInfo();
			string[] oneLineCsvData = oneLineString.Split(',');
			if (oneLineCsvData[0] == "")
				return null;
			info.Pointer = int.Parse(oneLineCsvData[1]);
			info.TypeName = oneLineCsvData[2].Replace(";", ",");//"type"
			info.Size = oneLineCsvData[3];//"size"
			info.Stack = oneLineCsvData[4];//"stack"
			info.Reference = oneLineCsvData[5];//"reference"
			return info;
		}

		private void SnapShotDirectory_Click(object sender, EventArgs e)
		{
			if (OpenSnapShot.ShowDialog() == DialogResult.OK)
			{
				SnapShotPath.Text = OpenSnapShot.FileName;



				if (!System.IO.File.Exists(SnapShotPath.Text))
				{
					MessageBox.Show(string.Format("快照文件{0}不存在", SnapShotPath.Text));
					return;
				}
				Stopwatch time = new Stopwatch();
				time.Start();
				m_PointerToSnapShotInfo.Clear();
				//m_NodeHasNoCycle.Clear();
				ReferenceTree.Nodes.Clear();
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(SnapShotPath.Text, System.Text.Encoding.Default))
				{
					string oneLineString;
					while ((oneLineString = streamReader.ReadLine()) != null)
					{
						SnapShotInfo info = new SnapShotInfo();
						if (OpenSnapShot.FilterIndex == 1)
						{
							info = TxtToShopShotInfo(oneLineString);
						}
						else
						{
							info = CsvToShopShotInfo(oneLineString);
						}
						if (info == null || m_PointerToSnapShotInfo.ContainsKey(info.Pointer.ToString()))
						{
							continue;
						}
						m_PointerToSnapShotInfo.Add(info.Pointer.ToString(), info);
					}
				}
				time.Stop();
				MessageBox.Show("读取成功，耗时" + (time.ElapsedMilliseconds / 1000.00 + 0.005).ToString("f2") + "s");

			}
		}

		private void AllBuildeTree_CheckedChanged(object sender, EventArgs e)
		{
			TargetPointer.Enabled = !AllBuildeTree.Checked;
		}

		

		private void ReferenceTree_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
		{
			TreeNode selectedNode = e.Node as TreeNode;
			int firstIndex = 0;

			int secondIndex = selectedNode.Text.IndexOf("_");
			string pointer = selectedNode.Text.Substring(firstIndex, secondIndex - firstIndex);
			SnapShotInfo info = m_PointerToSnapShotInfo[pointer];
			ToolTip nodeTip = new ToolTip();
			string tips = string.Format("Pointer:{0}\nTypeName:{1}\nSize:{2}\nStack:{3}", info.Pointer, info.TypeName, info.Size, info.Stack);
			nodeTip.ShowAlways = true;
			//nodeTip.SetToolTip(ReferenceTree, tips);
			//nodeTip.Dispose();
		}

		private void ReferenceTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeNode selectedNode = e.Node as TreeNode;

			/*SnapShotInfo info = m_PointerToSnapShotInfo[GetNodePointer(selectedNode)];
			string tips = string.Format("Pointer:{0}\nTypeName:{1}\nSize:{2}\nStack:{3}", info.Pointer, info.TypeName, info.Size, info.Stack);
			PointerInformation.Text = tips;*/
		}

		
	}

}