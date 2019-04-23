﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryDifferenceTool
{
	public partial class DeltaWindow : Form
	{
		//private string m_FilePath_SnapShot1;
		//private string m_FilePath_SnapShot2;
		//private string m_DirectoryPath_Export;
		private DateTime m_StartCompareAndWriteTime;
		
		
		//private DateTime m_EndCompareAndWriteTime;

		public DeltaWindow()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				label_Path_Snapshot1.Text = openFileDialog1.FileName;
			}
		}

		private void button_SnapShot2_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				label_Path_Snapshot2.Text = openFileDialog1.FileName;
			}
		}

		private void button_ExportDirectory_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				label_Path_Export.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void Button_CompareAndWriteCSV_Click(object sender, EventArgs e)
		{
			if (checkBox_Difference.Checked)
			{
				WriteDifferenceCSV();
			}
			else
			{
				if (System.IO.File.Exists(label_Path_Snapshot1.Text))
				{
					ConvertToCSVDirectly(label_Path_Snapshot1.Text);
				}
				if (System.IO.File.Exists(label_Path_Snapshot2.Text))
				{
					ConvertToCSVDirectly(label_Path_Snapshot2.Text);
				}
			}
		}

		private void ConvertToCSVDirectly(string filePath)
		{
			m_StartCompareAndWriteTime = DateTime.Now;
			string exportFilePath = filePath.Remove(filePath.LastIndexOf('.')+1) + "csv";

			using (System.IO.StreamReader streamReader = new System.IO.StreamReader(label_Path_Snapshot1.Text, System.Text.Encoding.Default))
			{
				using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(exportFilePath, false, System.Text.Encoding.Default))
				{
					//第一行
					streamWriter.WriteLine(",Pointer,TypeName,Size,Stack,Reference");
					string oneLineString;
					int lineIndex = 0;
					while ((oneLineString = streamReader.ReadLine()) != null)
					{
						SnapShotInfo info = StringToShopShotInfo(oneLineString);
						streamWriter.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", lineIndex, info.Pointer, info.TypeName, info.Size, info.Stack, info.Reference));
						++lineIndex;
					}
				}	
			}
			MessageBox.Show(string.Format("生成文件{0}完毕", filePath));

			
		}

		private void WriteDifferenceCSV()
		{
			if (!System.IO.File.Exists(label_Path_Snapshot1.Text))
			{
				MessageBox.Show(string.Format("快照1文件{0}不存在", label_Path_Snapshot1.Text));
				return;
			}
			if (!System.IO.File.Exists(label_Path_Snapshot2.Text))
			{
				MessageBox.Show(string.Format("快照2文件{0}不存在", label_Path_Snapshot2.Text));
				return;
			}
			string directoryPath = CheckExportPathOrUseFilePath(label_Path_Snapshot1.Text);


			m_StartCompareAndWriteTime = DateTime.Now;
			
			List<SnapShotInfo> snapShot1Infos = new List<SnapShotInfo>();
			using (System.IO.StreamReader streamReader = new System.IO.StreamReader(label_Path_Snapshot1.Text, System.Text.Encoding.Default))
			{
				string oneLineString;
				while ((oneLineString = streamReader.ReadLine()) != null)
				{
					SnapShotInfo info = StringToShopShotInfo(oneLineString);
					int index = -1;
					SnapShotInfo.BinarySearch_FindInsertIndex(snapShot1Infos, 0, snapShot1Infos.Count, info, ref index);
					snapShot1Infos.Insert(index, info);
				}
			}

			List<SnapShotInfo> deltaInfos = new List<SnapShotInfo>();
			List<SnapShotInfo> stillInfos = new List<SnapShotInfo>();
			using (System.IO.StreamReader streamReader = new System.IO.StreamReader(label_Path_Snapshot2.Text, System.Text.Encoding.Default))
			{
				string oneLineString;
				while ((oneLineString = streamReader.ReadLine()) != null)
				{
					SnapShotInfo info = StringToShopShotInfo(oneLineString);

					int index = -1;
					bool findOut = SnapShotInfo.BinarySearch_FindInsertIndex(snapShot1Infos, 0, snapShot1Infos.Count, info, ref index);
					if (findOut)
					{
						if (WriteStillInfo.Checked)
							stillInfos.Add(info);
					}
					else
					{
						deltaInfos.Add(info);
					}
				}
			}

			WriteCSV(deltaInfos, directoryPath, "SnapshotDelta");
			if (WriteStillInfo.Checked)
				WriteCSV(stillInfos, directoryPath, "SnapshotStill");

			int spendSecond = (int)(SecondDifference(m_StartCompareAndWriteTime, DateTime.Now));
			MessageBox.Show(string.Format("本次操作共用了{0}秒", spendSecond.ToString()));
		}

		private string CheckExportPathOrUseFilePath(string filePath)
		{
			string directoryPath;
			if (System.IO.Directory.Exists(label_Path_Export.Text))
			{
				directoryPath = label_Path_Export.Text;
			}
			else
			{
				int indexOfLine = label_Path_Snapshot1.Text.LastIndexOf("\\");
				directoryPath = label_Path_Snapshot1.Text.Remove(indexOfLine);
				MessageBox.Show(string.Format("没找到生成CSV的文件夹{0}，将使用文件所在路径{1}", filePath, directoryPath));
			} 
			return directoryPath;
		}


		private SnapShotInfo StringToShopShotInfo(string oneLineString)
		{
			//{"ptr":576627008,"type":"PvPFiringTendency[,]","size":76,"stack":"|osPlaneAISetting.GetFiringTendency|osBTFiringControl_PvP.OnUpdate|BehaviorManager.RunTask|BehaviorManager.Tick|BehaviorManager.Tick|osPlaneController_AI.UpdateInput|osPlaneController.LateUpdate","reference":"|532303136"}
			//
			LitJson.JsonData oneLineJsonData = LitJson.JsonMapper.ToObject(oneLineString);
			SnapShotInfo info = new SnapShotInfo();
			info.Pointer = int.Parse(oneLineJsonData[0].ToString());//"ptr"
			info.TypeName = oneLineJsonData[1].ToString().Replace(",", ";");//"type" [,]会影响CSV文件，暂时把,使用;替代
			info.Size = oneLineJsonData[2].ToString();//"size"
			info.Stack = oneLineJsonData[3].ToString();//"stack"
			info.Reference = oneLineJsonData[4].ToString();//"reference"

			return info;
		}

		private void WriteCSV(List<SnapShotInfo> list, string path, string fileName)
		{
			string filePath = string.Format(@"{0}\{1}.csv", path, fileName);
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.Default))
			{
				//第一行
				streamWriter.WriteLine(",Pointer,TypeName,Size,Stack,Reference");
				for (int i = 0; i < list.Count; i++)
				{
					SnapShotInfo info = list[i];
					streamWriter.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", i, info.Pointer, info.TypeName, info.Size, info.Stack, info.Reference));
				}
			}
			MessageBox.Show(string.Format("生成文件{0}完毕", filePath));
		}

		private double SecondDifference(DateTime dateBegin, DateTime dateEnd)
		{
			TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
			TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
			TimeSpan ts3 = ts1.Subtract(ts2).Duration();
			//你想转的格式
			return ts3.TotalMilliseconds / 1000;
		}
		

	}

}
