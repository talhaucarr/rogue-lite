using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class AddressableService : Service<AddressableService>
{
    internal override void Init()
    {
    }

    internal override async void Begin()
    {
        await Addressables.InitializeAsync().Task;
        SetReady();
    }

    public T LoadAsset<T>(string label)
    {
        return Addressables.LoadAssetAsync<T>(label).WaitForCompletion();
    }

    public async Task<T> LoadAssetAsync<T>(string label)
    {
        return await Addressables.LoadAssetAsync<T>(label).Task;
    }

    public async Task<GameObject> InstantiateAsync(string label, Transform parent)
    {
        return await Addressables.InstantiateAsync(label, parent).Task;
    }

    public async Task<SceneInstance> LoadScene(string label)
    {
        return await Addressables.LoadSceneAsync(label, LoadSceneMode.Additive, false).Task;
    }
}