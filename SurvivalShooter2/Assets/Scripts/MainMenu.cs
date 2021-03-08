using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDD;

    public TMP_Dropdown qualityDD;

    public Toggle fullscreenToggle;

    public Animator transitionAnim;

    float waitForAnimationTime = 7f;

    private void Awake()
    {
        resolutions = Screen.resolutions;

        resolutionDD.ClearOptions();

        List<string> res = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i<resolutions.Length; i++)
        {
            string aux = resolutions[i].width + "x" + resolutions[i].height;
            res.Add(aux);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
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


    public void EnterGame()
    {
        StartCoroutine(TransitionToGame());
    }

    IEnumerator TransitionToGame()
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(waitForAnimationTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    public void ExitGame()
    {
        Debug.Log("Exit Button pressed");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("GeneralVol", volume);
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

}
