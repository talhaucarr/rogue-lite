using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;

    private bool _ready;

    public bool Finished { get; private set; }

    private void Update()
    {
        float value = 0.15f 
                      + GetManagerReadyRatio() * 0.7f 
                      + (_ready ? 0.15f : 0f);
        if (value > Slider.value)
            Slider.value += Time.deltaTime * 0.5f;
        CheckFinish();
    }

    public float GetManagerReadyRatio()
    {
        float total = ServiceProvider.Instance.GetServiceCount();
        float ready = total - ServiceProvider.Instance.GetNotReadyServiceCount();
        float ratio = ready / total;
        return ratio;
    }

    private void CheckFinish()
    {
        if(Slider.value >= .99f)
        {
            Finished = true;
            Slider.gameObject.SetActive(false);
            ServiceProvider.Instance.Get<LoadingService>().HideLoading();
        }
    }

    public void SceneReadyToActivate()
    {
        _ready = true;
        CheckFinish();
    }
}
