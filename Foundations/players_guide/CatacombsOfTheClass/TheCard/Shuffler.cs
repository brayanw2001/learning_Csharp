using System;
using System.Collections.Generic;

namespace TheCard;

public class Shuffler<T>
{
    private int n;

    public Shuffler (List<T> list)
    {
        Random random = new Random();
        int n = list.Count;

        for (int i = n-1; i>0; i--)
        {
            int j = random.Next(i + 1)
            (list[i], list[j]) = (list[j], list[i]);
        }
    }


}
