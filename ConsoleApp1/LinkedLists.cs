using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;

public class LinkedLists
{
    public static void exec()
    {
        U.pst("LinkedLists");

        LinkedList<int> linkedList = [];
        linkedList.AddFirst(1);
        linkedList.Append(4);
        LinkedListNode<int> three = new(3);
        LinkedListNode<int>? positionOf3 = linkedList.FindLast(three.Value);
        // I don't know why, positionOf3 is null so these don't work:
        if (positionOf3 != null)
        {
            linkedList.AddBefore(positionOf3, 2);
            linkedList.AddAfter(positionOf3, 4);
        }
        // linkedList.AddBefore(three, 2); // throws exception that the node doesn't belong to LList
        // linkedList.AddBefore(linkedList.Find(4), 2);

        linkedList.AddLast(5);
        U.pt(linkedList); // prints 1 and 5 only!
    }
}