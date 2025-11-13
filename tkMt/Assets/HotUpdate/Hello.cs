using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    public static void Run()
    {
        //Debug.Log("Hello, HybridCLR");
        Debug.Log("Hello, World");

        GameObject go = new GameObject("hotTest_1");
        go.AddComponent<Print>();
    }
}
