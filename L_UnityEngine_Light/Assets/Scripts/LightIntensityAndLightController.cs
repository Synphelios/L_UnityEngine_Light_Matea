using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightIntensityAndColorController : MonoBehaviour
{
    [SerializeField] private GameObject[] pointLight;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxIntensity = 5f;

    public Color startColor = Color.red;
    public Color endColor = Color.green;


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
                //Itensität des Lichts
                pointLight.intensity = intensity;

                float colorRatio = 1 - (distance / maxDistance);
                //Color des Lichts
                pointLight.color = Color.Lerp(startColor, endColor, colorRatio);
            }
            else
            {
                pointLight.intensity = 0f;
                pointLight.color = startColor;
            }
        }

        
        
        //valuetolerp (startColor, endColor)
    }
}

