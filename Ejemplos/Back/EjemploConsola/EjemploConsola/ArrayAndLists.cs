using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploConsola
{
    internal class DataStructures
    {
        // Index are always from 0 to len-1;
        // Array - Fixed lenght data structure

        public int[] numArray = new int[3]; // Array creation `dataType[] varName = new dataType[lenght]`

        public void FillArray()
        {
            numArray[0] = 5;
            numArray[1] = 15;
            numArray[2] = 25;

            // numArray[99] -> Exception when the index does not exists
        }

        public void PrintArray()
        {

            Console.WriteLine($"Printing position number 1: {numArray[1]} ");
            Console.WriteLine("");
            Console.WriteLine("Printing the array complete");
            for (int i = 0; i < numArray.Length; i++) // how to iterate arrays
            {
                Console.WriteLine($"{i}:{numArray[i]}");

            }
        }
        // List - Dynamic lenght data structure
        // list.Add(ElementToAdd) -> Create a new element into the list. SHOULD be the same type as the list.
        // list.Remove(ElementToRemove) -> Delete a element into the list. SHOULD be the same type as the list.
        // list.Count -> Returns the list lenght.
        public List<int> numList = new List<int>(); // List creation `List<dataType> varName = new List<dataType>()`
        public void FillList()
        {
            numList.Add(8);
            numList.Add(10);
            numList.Add(12);


            // Modify
            numList[0] = 5;
            numList[1] = 15;
            numList[2] = 25;

            numList.Remove(10);

            numList[2] = 25;

            // numList[99] -> Exception when the index does not exists. "Index is out of range"

        }

        public void PrintList()
        {

            Console.WriteLine("Printing the list");
            for (int i = 0; i < numList.Count; i++) // Iterate lists
            {
                Console.WriteLine($"{i}:{numList[i]}");
            }
            // Same as above
            foreach (var item in numList)
            {
                Console.WriteLine($"Value:{item}");
            }
        }
    }
}
