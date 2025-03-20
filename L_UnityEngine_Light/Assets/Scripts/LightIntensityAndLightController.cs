using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightIntensityAndColorController : MonoBehaviour
{
    [SerializeField] private GameObject[] pointLight;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxIntensity = 5f;

    private void Start()
    {
        pointLight = GameObject.FindGameObjectsWithTag("PointLight");  
    }

    private void Update()
    {
        foreach(GameObject LightObj in pointLight)
        {
            Light pointLight = LightObj.GetComponent<Light>();
            //pointLight.intensity = 20;
            float distance = Vector3.Distance(pointLight.transform.position, transform.position);
            float intensity = (1 - distance / maxDistance) * maxIntensity;

            if(distance < maxDistance)
            {
                pointLight.intensity = intensity;
            }
            else
            {
                pointLight.intensity = 0f;
            }
        }
    }
}

