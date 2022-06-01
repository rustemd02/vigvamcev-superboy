using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;

    public Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.hp < 1)
        {
            Time.timeScale = 0f;
            winScreen.SetActive(true);
        }   
    }
    public void RestartGame()
    {
        winScreen.SetActive(false);
        Time.timeScale = 1f;  
        SceneManager.LoadScene("Game");
        
        
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
