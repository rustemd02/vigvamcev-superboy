using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
  {
      resolutions = Screen.resolutions;

      resolutionDropdown.ClearOptions();

      List<string> options = new List<string>();

      int  currentResolutionIndex = 0;
      for (int i = 0; i< resolutions.Length; i++)
      {
        string option = resolutions[i].width + " x " + resolutions[i].height;
        options.Add(option);

        if(resolutions[i].width==Screen.currentResolution.width
         && resolutions[i].height==Screen.currentResolution.height)
        {
            currentResolutionIndex =i;
        }
      }

      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = currentResolutionIndex;
      resolutionDropdown.RefreshShownValue();
  }

    public void SetResolution (int resolutionIndex)
  {
    Resolution resolution = resolutions[resolutionIndex];
   Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
  }

    public void PlayGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    Time.timeScale = 1f;
  }

    public void QuitGame()
  {
    Debug.Log("QUIT!!");
    Application.Quit();
  }


    public void SetVolume(float volume)
  {
   audioMixer.SetFloat("volume", volume);
  }

    public void SetFullscreen(bool isFullscreen)
  {
   Screen.fullScreen = isFullscreen;
  }
}
