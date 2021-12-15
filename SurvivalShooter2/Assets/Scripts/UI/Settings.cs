using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    #region Variables
    Resolution[] resolutions;

    public TMP_Dropdown resolutionDD;

    public TMP_Dropdown qualityDD;

    public Toggle fullscreenToggle;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        SetSettings();
    }
    #endregion

    #region Methods

    private void SetSettings()
    {
        resolutions = Screen.resolutions;

        resolutionDD.ClearOptions();

        List<string> res = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string aux = resolutions[i].width + "x" + resolutions[i].height;
            res.Add(aux);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }


        }

        resolutionDD.AddOptions(res);
        resolutionDD.value = currentResolutionIndex;
        resolutionDD.RefreshShownValue();


        qualityDD.value = QualitySettings.GetQualityLevel();

        fullscreenToggle.isOn = Screen.fullScreen;
    }
    public void SetMainVolume(float volume)
    {
        AudioManager.Instance.SetMainVolume(volume );
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
    #endregion
}
