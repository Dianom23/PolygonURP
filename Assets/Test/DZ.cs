using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZ : MonoBehaviour
{
    private int[] _array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    void Start()
    {
        int sum = 0;

        foreach (int i in _array)
        {
            sum += i;
        }

        print(sum);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
