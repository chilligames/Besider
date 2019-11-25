using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector2 C, N;
    void Update()
    {
        
        var A = Mathf.Pow(N.x - C.x, 2);
        var B = Mathf.Pow(N.y - C.y, 2);
        print(Mathf.Sqrt(A+B));

        print(Vector2.Distance(C, N));
    }
}
