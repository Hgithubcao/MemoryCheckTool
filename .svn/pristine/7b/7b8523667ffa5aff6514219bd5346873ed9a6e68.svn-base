using System;
using System.Collections.Generic;
using System.IO;

public static class mfUtility
{
	#region 快速排序

	/// <summary>
	/// 快速排序
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <param name="left">起始index,完全排序填0</param>
	/// <param name="right">结束index，完全排序填array.Length-1</param>
	public static void QuickSort<T>(T[] array, int left, int right) where T : IComparable
	{

		if (left < right)
		{

			int middle = GetMiddleFroQuickSort<T>(array, left, right);

			QuickSort<T>(array, left, middle - 1);

			QuickSort<T>(array, middle + 1, right);
		}

	}
	/// <summary>
	/// get the index of the middle value for qucik sort
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	private static int GetMiddleFroQuickSort<T>(T[] array, int left, int right) where T : IComparable
	{
		T key = array[left];
		while (left < right)
		{
			while (left < right && key.CompareTo(array[right]) < 0)
			{
				right--;
			}
			if (left < right)
			{
				//T temp = array[left];
				array[left] = array[right];
				//Console.WriteLine("array[{0}]:{1} ---->  arry[{2}]:{3}", left, temp, right, array[right]);
				left++;
			}

			while (left < right && key.CompareTo(array[left]) > 0)
			{
				left++;
			}
			if (left < right)
			{
				//T temp = array[right];
				array[right] = array[left];
				//Console.WriteLine("array[{0}]:{1} ----> arry[{2}]:{3}", right, temp, left, array[left]);
				right--;
			}
			array[left] = key;
		}
		//Console.WriteLine("find the middle value {0} and the index {1}", array[left], left);
		return left;
	}
	#endregion

	/// <summary>
	/// 二分查找
	/// </summary>
	/// <param name="arr"></param>
	/// <param name="low">开始索引 0</param>
	/// <param name="high">结束索引 </param>
	/// <param name="key">要查找的对象</param>
	/// <returns></returns>
	//public static int BinarySearch<T>(mfBetterList<T> arr, int low, int high, int key) where T : IComparable
	//{
	//	int mid = (low + high) / 2;
	//	if (low > high)
	//		return -1;
	//	else
	//	{
	//		if (arr[mid].CompareTo(key) == 0)
	//			return mid;
	//		else if (arr[mid].CompareTo(key) > 0)
	//			return BinarySearch(arr, low, mid - 1, key);
	//		else
	//			return BinarySearch(arr, mid + 1, high, key);
	//	}
	//}

	public static int BinarySearch<T>(mfBetterList<T> a, int low, int high, int searchValue) where T : IComparable
	{
		// recursive version
		int mid;
		if (high <= low)
			return -1;
		mid = low + ((high - low) / 2);
		if (a[mid].CompareTo(searchValue) > 0)
		{
			return BinarySearch(a, low, mid, searchValue);
		}
		else if (a[mid].CompareTo(searchValue) < 0)
		{
			return BinarySearch(a, mid + 1, high, searchValue);
		}
		else //when a[mid] is the search value..
		{
			return mid;
		}
	} //end function
}
