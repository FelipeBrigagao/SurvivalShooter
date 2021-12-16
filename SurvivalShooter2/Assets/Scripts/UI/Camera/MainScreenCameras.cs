using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainScreenCameras : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _cameraHolder;
    private CinemachineVirtualCamera[] _screensCameras;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        _screensCameras = new CinemachineVirtualCamera[_cameraHolder.childCount];

        for(int i = 0; i< _screensCameras.Length; i++)
        {
            _screensCameras[i] = _cameraHolder.GetChild(i).GetComponent<CinemachineVirtualCamera>();
        }


        TurnMainMenuCameraOn();
    }
    #endregion

    #region Methods
    public void TurnMainMenuCameraOn()
    {
        ManageTurnOnCameras(0);
    }

    public void TurnSettingsCameraOn()
    {
        ManageTurnOnCameras(1);
    }

    public void TurnEnterGameCameraOn()
    {
        ManageTurnOnCameras(2);
    }

    private void ManageTurnOnCameras(int index)
    {
        for(int i = 0; i < _screensCameras.Length; i++)
        {
            if(index == i)
            {
                _screensCameras[i].enabled = true;
            }
            else
            {
                _screensCameras[i].enabled = false;
            }
        }
    }



    #endregion
}
