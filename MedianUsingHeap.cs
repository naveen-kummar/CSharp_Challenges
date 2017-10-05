using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Globalization.CultureInfo;

public class InteHeap{
    
    
    public InteHeap(bool isMaxHeap)
    {
        m_isMaxHeap = isMaxHeap;
        size = 0;
    }
    
    bool m_isMaxHeap = false;
	public int capacity = 10;
	public int size = 0;

	public float[] items = new float[10];


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
    
    public float peak()
    {
        return items[0];
    }

	public void HeapifyUp()
	{
		int index = size - 1;
		while (hasParent(index) && (NeedToMoveUp( parent(index), items[index] )) )
		{
          //  Console.WriteLine("HU Swaping values {0:N1} to {1:N1} ",items[getParentIndex(index)], items[index]);
			swap(getParentIndex(index), index);
			index = getParentIndex(index);
            

		}
        
    /*                         int szSmallHeap = size;
         
        Console.WriteLine("------------");
         Console.WriteLine("HU-CurrentHeap:");
         while(szSmallHeap > 0)
         {
             Console.WriteLine("{0:N1}", items[szSmallHeap - 1]);
             szSmallHeap--;
         }*/
	}
    
    bool NeedToMoveUp(float Root, float Child )
    {
        if(m_isMaxHeap)
            return (Root < Child);
         else
             return (Root > Child); 
    }
    
     bool IsInOrder(float Root, float Child )
    {
        if(m_isMaxHeap)
            return (Root > Child);
         else
             return (Root < Child); 
    }
    
    
    public float poll()
    {
        float item = items[0];
        items[0] = items[size - 1];
        --size;
        heapifyDown();
        return item;
        
    }
    
    public void heapifyDown()
    {
        int index = 0;
        while(hasLeftChild(index))
        {
            int smallerIndex = getLeftChildIndex(index);
            
            if(hasRightChild(index) && (NeedToMoveUp( leftChild(index), rightChild(index)) ))
            {
                smallerIndex = getRightChildIndex(index);
            }
            
            if(IsInOrder(items[index] , items[smallerIndex]))
            {
                break;
            }
            else
            {
                //Console.WriteLine("HD Swaping values {0:N1} to {1:N1} ",items[index], items[smallerIndex]);
                swap(index, smallerIndex);
            }
            index = smallerIndex;
        }
    }


}
class Solution {

	static void Main(String[] args) {
		double n = Convert.ToInt32(Console.ReadLine());
		//float[] a = new float[n];
		InteHeap largeSet = new InteHeap(false);
        InteHeap smallSet = new InteHeap(true);
        //List<float> median;// = new float[n];
        
		for (double a_i = 0; a_i < n; a_i++){
            float number = (float) Convert.ToDouble(Console.ReadLine());
            addNumber(number, smallSet, largeSet);
			reBalance(smallSet, largeSet);
            

			Console.WriteLine( getMedian(smallSet, largeSet).ToString("N1").Replace(",",""));

		}
	}
    
    
    static void  addNumber(float number, InteHeap smallSet, InteHeap largeSet)
    {
       // InteHeap smallHeap = if(minHeap.size < maxHeap.size) ? minHeap : maxHeap;
        
        if((smallSet.size == 0) || (number < smallSet.peak()))
           {
               //  Console.WriteLine("Adding {0:N1} to Max Heap as {1:N1} ",number, smallSet.peak());
               smallSet.add(number);
           }
           else
           {
              // Console.WriteLine("Adding {0:N1} to Min Heap as {1:N1} ",number, smallSet.peak());
               largeSet.add(number);
           }
    }
    
    static void  reBalance(InteHeap smallSet, InteHeap largeSet)
    {
        InteHeap largeHeap = (smallSet.size > largeSet.size) ? smallSet : largeSet;
        InteHeap smallHeap = (smallSet.size > largeSet.size) ? largeSet : smallSet;
        
        
        if((largeHeap.size - smallHeap.size) >= 2)
        {
            smallHeap.add(largeHeap.poll());
        }
        
    }
    
     static float  getMedian(InteHeap smallSet, InteHeap largeSet)
    {
        InteHeap largeHeap = (smallSet.size > largeSet.size) ? smallSet : largeSet;
        InteHeap smallHeap = (smallSet.size > largeSet.size) ? largeSet : smallSet;
         
        /*int szLargeHeap = largeHeap.size;
         int szSmallHeap = smallHeap.size;
         
        Console.WriteLine("------------");
         Console.WriteLine("LargeHeap:");
         while(szLargeHeap > 0)
         {
             Console.WriteLine("{0:N1}", largeHeap.items[szLargeHeap - 1]);
             szLargeHeap--;
         }
         
                  
         Console.WriteLine("------------");
         Console.WriteLine("SmallHeap:");
         while(szSmallHeap > 0)
         {
             Console.WriteLine("{0:N1}", smallHeap.items[szSmallHeap - 1]);
             szSmallHeap--;
         }
         
        Console.WriteLine("------------");*/
      
         if(smallHeap.size == largeHeap.size)
         {
             return ((largeHeap.peak() + smallHeap.peak())/(float)2.0);
         }
         else
         {
             return largeHeap.peak();
         }
     }
           
           
}
