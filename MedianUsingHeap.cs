using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class MinInteHeap{
	public int capacity = 10;
	private int size = 0;

	float[] items = new float[10];


	private int getLeftChildIndex(int parentIndex){ return ((2 * parentIndex) + 1); }
	private int getRightChildIndex(int parentIndex){ return ((2 * parentIndex) + 2); }
	private int getParentIndex(int childIndex){ return ((childIndex - 1) / 2); }


	private bool hasLeftChild(int index){ return (getLeftChildIndex(index) < size); }
	private bool hasRightChild(int index){ return (getRightChildIndex(index) < size); }
	private bool hasParent(int index){ return (getParentIndex(index) >= 0); }


	private float leftChild(int index){ return items[getLeftChildIndex(index)]; }
	private float rightChild(int index){ return items[getRightChildIndex(index)]; }
	private float parent(int index){ return items[getParentIndex(index)]; }

	private void swap(int indexOne, int indexTwo){
		float temp = items[indexOne];
		items[indexOne] = items[indexTwo];
		items[indexTwo] = temp;
	}

	private void ensureExtraCapacity(){
		if (size == capacity)
		{
			//capacity = (capacity * 2);
			capacity *= 2;
			Array.Resize<float>(ref items, capacity);
		}
	}

	public void add(float item)
	{
		ensureExtraCapacity();
		// Console.WriteLine("Current capacity is {0}", capacity);
		items[size] = item;
		size++;

		//Console.WriteLine("add item {0} and updated size as {1}", item, size);
		HeapifyUp();
	}

	public void HeapifyUp()
	{
		int index = size - 1;
		while (hasParent(index) && (parent(index)  > items[index]))
		{
			swap(getParentIndex(index), index);
			index = getParentIndex(index);
		}
	}

	public float getMedian()
	{
		//Console.WriteLine("About to get median at {0}", Convert.ToInt32((size) ));


		//Console.WriteLine("got {0} as  median at {1}", Convert.ToInt32( items[(size/2) ]), Convert.ToInt32((size/2) ));

		if (((size) % 2) == 0)
		{
			float avg = 2.0f;
			float result = (items[(size / 2) - 1] + items[(size / 2)]) / avg;

			//Console.WriteLine(" get median at {0}", result);
			return result;
		}
		else
			return (items[((size - 1) / 2)]);




	}

}
class Solution {

	static void Main(String[] args) {
		int n = Convert.ToInt32(Console.ReadLine());
		int[] a = new int[n];
		MinInteHeap myHeap = new MinInteHeap();
		for (int a_i = 0; a_i < n; a_i++){
			myHeap.add(Convert.ToInt32(Console.ReadLine()));

			Console.WriteLine("{0:N1}", myHeap.getMedian());

		}
	}
}
