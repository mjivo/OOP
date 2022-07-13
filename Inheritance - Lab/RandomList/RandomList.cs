namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class RandomList
    : List<string>
    {
        public RandomList()
        {
        }
        public RandomList(IEnumerable<string> strings) : base(strings)
        {
        }
        public RandomList(int capacity) : base(capacity)
        {
        }
        public string RandomString()// remove random element and returns it
        {
            Random random = new Random();
            string element = base[random.Next(0, base.Count)];
            Remove(element);
            return element;
        }
        //{
        //    private int[] list = new int[5];
        //    public int this[int index]
        //    {
        //        get => list[index];
        //        set => list[index] = value;
        //        // get and set accessors
        //    }
        //}
    }
}
