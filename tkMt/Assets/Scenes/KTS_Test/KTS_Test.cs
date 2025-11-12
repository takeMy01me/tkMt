using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KTS_Test : MonoBehaviour
{

    void Start()
    {
        KTS_Singleton.Instance.PrintKTS();
    }
}



public class KTS_Singleton : KTS.Singleton<KTS_Singleton>
{
    public void PrintKTS()
    {
        Debug.Log("KTS");
    }
}