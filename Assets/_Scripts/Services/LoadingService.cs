using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingService : Service<LoadingService>
{
    [SerializeField]
    public LoadingCanvas LoadingCanvas;
    
    [SerializeField]
    LoadingSlider LoadingSlider;
    
    [SerializeField]
    Image BackgroundImage;

    [SerializeField]
    Image Logo;

    private AddressableService _addressableService;
    private NetworkService _networkService;
    private int _loadingCounter;
    
    private List<GameObject> _rootGameObjects = new List<GameObject>();
   
    private LoadingFinishedEvent _loadingFinishedEvent;
    
    internal override void Init()
    {
        _addressableService = _serviceProvider.Get<AddressableService>();
        _networkService = _serviceProvider.Get<NetworkService>();
        _dependencies = new List<Service>()
        {
            _addressableService,
            _networkService
        };
        _loadingFinishedEvent = _serviceProvider.Get<LoadingFinishedEvent>();
    }

    internal override void Begin()
    {
        SetReady();
    }

    public bool IsLoading()
    {
        return _loadingCounter > 0;
    }
    
    public void ShowLoading()
    {
        _loadingCounter++;
        LoadingCanvas.Show();
    }
    
    public void HideLoading()
    {
        if (--_loadingCounter < 0)
        {
            _loadingCounter = 0;
        }
            
        if(_loadingCounter == 0)
        {
            bool initialLoading = Logo.gameObject.activeSelf;
            Logo.gameObject.SetActive(false);
            LoadingCanvas.Hide();
            _loadingFinishedEvent.Fire(initialLoading);
        }
    }

    public void SceneReadyToActivate()
    {
        LoadingSlider.SceneReadyToActivate();
    }

    public void HoldInitialLoading()
    {
        LoadingCanvas.Show();
        LoadingSlider.enabled = false;
        LoadingSlider.gameObject.SetActive(true);
    }

    public void ReleaseInitialLoading()
    {
        Logo.gameObject.SetActive(false);
        LoadingCanvas.Hide();
        LoadingSlider.gameObject.SetActive(false);
        LoadingSlider.enabled = true;
    }

    public bool IsInitialLoading()
    {
        return !LoadingSlider.Finished;
    }
}
