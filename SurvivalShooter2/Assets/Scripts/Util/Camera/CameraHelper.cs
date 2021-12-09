using UnityEngine;
using Cinemachine;

public class CameraHelper : MonoBehaviour
{
    #region Variables
    [SerializeField] private CinemachineVirtualCamera _cam;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        PlayerManager.Instance.SetPlayerCam(_cam);
    }
    #endregion
}
