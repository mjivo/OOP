using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public StackOfStrings()
        {
            // Summary:
            //     Initializes a new instance of the System.Collections.Generic.Stack`1 class that
            //     contains elements copied from the specified collection and has sufficient capacity
            //     to accommodate the number of elements copied.
            //
            // Parameters:
            //   collection:
            //     The collection to copy elements from.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     collection is null.
        }
        public StackOfStrings(IEnumerable<string> collection)
        {
            // Summary:
            //     Initializes a new instance of the System.Collections.Generic.Stack`1 class that
            //     is empty and has the specified initial capacity or the default initial capacity,
            //     whichever is greater.
            //
            // Parameters:
            //   capacity:
            //     The initial number of elements that the System.Collections.Generic.Stack`1 can
            //     contain.
            //
            // Exceptions:
            //   T:System.ArgumentOutOfRangeException:
            //     capacity is less than zero.
        }
        public StackOfStrings(int capacity)
        {
        }

        public bool IsEmpty()
        {
            return base.Count == 0;
        }
        public Stack<string> AddRange()
        {
            return new Stack<string>(base.ToArray());
        }
    }
}
