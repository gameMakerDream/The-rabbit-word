using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGeter<T>:IComparer
{
    T GetItem(string ID);
}
