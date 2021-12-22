using UnityEngine;
using Cinemachine;

public class CameraHelper : MonoBehaviour
{
    #region Variables
    [SerializeField] private CinemachineVirtualCamera _cam;
    [SerializeField] private Vector3 _camOffset;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        PlayerManager.Instance.SetPlayerCam(_cam);

        var transposer = _cam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = _camOffset;

    }
    #endregion
}
