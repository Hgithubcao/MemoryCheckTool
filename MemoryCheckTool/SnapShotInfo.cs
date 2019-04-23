using System;
using System.Collections.Generic;

public class SnapShotInfo
{
	public int Pointer;
	public string TypeName;
	public string Size;
	public string Stack;
	public string Reference;

	public static bool BinarySearch_FindInsertIndex(List<SnapShotInfo> list, int low, int high, SnapShotInfo searchInfo, ref int insertIndex)
	{
		int mid;
		if (high <= low)
		{
			insertIndex = high;
			return false;
		}
		mid = low + ((high - low) / 2);

		if (list[mid].Pointer > searchInfo.Pointer)
		{
			return BinarySearch_FindInsertIndex(list, low, mid, searchInfo, ref insertIndex);
		}
		else if (list[mid].Pointer < searchInfo.Pointer)
		{
			return BinarySearch_FindInsertIndex(list, mid + 1, high, searchInfo, ref insertIndex);
		}
		else //when a[mid] is the search value..
		{
			insertIndex = mid;
			return true;
		}
	}
}
