using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverMenu;
    public bool isDead = false;
    
    public static GameOverScreen Instance {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        
    }
    
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Time.timeScale = 0f;  
            gameOverMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
        
    }

    public void RestartGame()
    {
        gameOverMenu.SetActive(false);
        isDead = false;
        Time.timeScale = 1f;  
        SceneManager.LoadScene("Game");
        
        
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
