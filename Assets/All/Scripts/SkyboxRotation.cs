using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    private Material _skybox;

    void Start()
    {
        _skybox = Instantiate(RenderSettings.skybox);
        RenderSettings.skybox = _skybox;
    }

    void Update()
    {
        RotateSkybox(Time.timeSinceLevelLoad * _rotationSpeed);
    }

    private void RotateSkybox(float angle)
    {
        _skybox.SetFloat("_Rotation", angle);
    }
}