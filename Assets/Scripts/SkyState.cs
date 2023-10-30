using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SkyState : MonoBehaviour
{
    public Light DirectionalLight;

    public float TemperatureBegin;
    public float TemperatureEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currt = GameManager.instance.currentTime;
        float t = (GameManager.instance.levelTime - currt) / GameManager.instance.levelTime;

        UnityEngine.RenderSettings.skybox.SetFloat("_value", t);
        DirectionalLight.colorTemperature = Mathf.Lerp(TemperatureBegin, TemperatureEnd, t);
    }
}
