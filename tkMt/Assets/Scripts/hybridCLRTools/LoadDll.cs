using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 加载热更程序集并调用热更新代码 （测试代码）
/// </summary>
public class LoadDll : MonoBehaviour
{
    void Start()
    {
        // 加载 HotUpdate 程序集
#if !UNITY_EDITOR
        Assembly hotUpdateAss = Assembly.Load(File.ReadAllBytes($"{Application.streamingAssetsPath}/HotUpdate.dll.bytes"));
#else
        // Editor下无需加载，直接查找获得 HotUpdate 程序集 => 在Editor环境下，HotUpdate.dll.bytes 已经被自动加载，不需要加载，重复加载反而会出问题。
        Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate");
#endif

        // 调用热更新代码
        Type type = hotUpdateAss.GetType("Hello");
        type.GetMethod("Run").Invoke(null, null);
    }
}
