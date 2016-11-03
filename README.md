Assignment
==========

Brief
----------

`public static int[] MergeAndReorder(int[] a, int[] b) { } `

Arrays a and b are both already sorted in ascending order. Your task is to merge
all elements in a and b, sorted in descending order. You may not use any native
sorting functionality of C#, such as SortedList or .OrderBy().

Your variables may only be primitives (and obviously an integer array for the result).

You will be assessed according to the efficiency, correctness and clarity of your
algorithm.

*Please also explain in a separate paragraph in English how your algorithm works.*


Algorithm
----------------

The two source arrays are already sorted in a ascending order, which means that
the largest values (the ones that we want to at the front of our resulting array)
is at the end of the source arrays.

So working from the back we compare the values and decide which value to transfer
to our resulting array.

<code>
  A: [1, 3, 5, 7, 9]
  B: [2, 4, 6, 8, 10]
</code>

In `JavaScript` we can simply remove(`pop`) the elements from the source arrays
and then add them to the result(`push`).

In `C#` the arrays are defined and resizing arrays is very costly so using position
variables we traverse the array in reverse order(`--`) and the result array in
ascending order(`++`).

Finally at the end the result array is filled up by the remaining items in either
source arrays.

Resulting array:

<code>
  [10,9,8,7,6,5,4,3,2,1]
</code>

Testing
----------------

The testing method takes a title and two source arrays then compares it by running
it against the native concatenation and sort of an array and the MergeAndReorder
function.
