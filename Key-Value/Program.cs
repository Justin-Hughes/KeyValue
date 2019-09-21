using System;
using System.Collections.Generic;

namespace Key_Value
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");

        }
    }
    public struct KeyValue
    {
        public readonly string Key;
        public readonly object Value;

        public KeyValue(string x, object y)
        {
            Key = x;
            Value = y;
        }
    }


    public class MyDictionary // this class is the indexer
    {
        public int count = 0;// used as the iterator for the set so you don't iterate over null values om keyArray, counts all valid inputs
        public KeyValue[] keyArray = new KeyValue[10];
        bool match = false; // used as bool for if the key already exists
        public object this[string key]   // key is the indexer
                                         //indexers are taking the struct and assigning index values to them
                                         // lookup index notation
        {
            set
            {
                for (int i = 0; i < count; i++)
                {
                    if (keyArray[i].Key == key)
                    {
                        match = true;
                    }
                }
                if (!match)
                {
                    keyArray[count] = new KeyValue(key, value);
                    count++;
                }
            }
            get
            {
                for (int i = 0; i <= count; i++)
                {
                    if (keyArray[i].Key == key)
                    {
                        return keyArray[i].Value;
                    }
                }

                throw new KeyNotFoundException();
            }
        }
    }
}



//index notation
/*
    public returnType this [key name and type]
    {
        get{return returnType}
        set{------ = value}
    }



    made a class mydictionary that holds indexer

     */
