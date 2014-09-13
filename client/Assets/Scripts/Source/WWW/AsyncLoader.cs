
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  AsyncLoader.cs
//  Lu Zexi
//  2013-12-16


/// <summary>
/// �첽����
/// </summary>
public class AsyncLoader : MonoBehaviour
{
    private AssetBundleRequest m_cRequest;  //��Դ����

    /// <summary>
    /// ��ʼ����
    /// </summary>
    /// <param name="asset"></param>
    /// <param name="resName"></param>
    /// <param name="callback"></param>
    public static AsyncLoader StartLoad(AssetBundle asset, string resName)
    {
        GameObject obj = new GameObject("AsyncLoader");
        AsyncLoader loader = obj.AddComponent<AsyncLoader>();
        loader.StartCoroutine(loader.GoLoader(asset, resName));
        return loader;
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="asset"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public IEnumerator GoLoader(AssetBundle asset, string resName)
    {
        this.m_cRequest = asset.LoadAsync(resName, typeof(UnityEngine.Object));

        for (; !this.m_cRequest.isDone; )
            yield return this.m_cRequest;

        GameObject.Destroy(this.gameObject);
    }

    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <returns></returns>
    public float Progress()
    {
        if (this.m_cRequest == null)
            return 0;
        if (this.m_cRequest.progress >= 1f && !this.m_cRequest.isDone)
            return 0.99f;
        return this.m_cRequest.progress;
    }

    /// <summary>
    /// ��ȡ��Դ
    /// </summary>
    /// <returns></returns>
    public UnityEngine.Object GetAsset()
    {
        return this.m_cRequest.asset;
    }

}
