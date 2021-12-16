using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHelper : MonoBehaviour
{
    [SerializeField] private Light _ambientLight;

    private void Awake()
    {
        WaveManager.Instance.SetAmbientLight(_ambientLight);
    }
}
