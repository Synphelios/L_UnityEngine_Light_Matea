using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightFlicker : MonoBehaviour
{

    public float minIntensity = .5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 1f;

    void Update()
    {
        float noise = Mathf.PerlinNoise(1, Time.time * flickerSpeed);
        GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        transform.rotation = Quaternion.Euler(0, noise, 0);
    }

}
