using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;
    bool gameOver = false;
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] int numEnemies;
    [SerializeField] int nivel;
    public bool lento = false;


    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();

        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1;
  
    }
    public void nivel2()
    {
        SceneManager.LoadScene("game 2");
    }
    public void nivel3()
    {
        SceneManager.LoadScene("game 3");
    }
    public void menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void cambio1()
    {
        SceneManager.LoadScene("cambio1");
    }
    public void cambio2()
    {
        SceneManager.LoadScene("cambio2");
    }


    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;

        player.gamePaused = gamePaused;
        
        pauseUI.SetActive(gamePaused);

        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if (numEnemies < 1 && nivel == 1)
        {
         
            level2();
        }
        else if (numEnemies < 1 && nivel == 2)
        {
            level3();
        }
        else if(numEnemies < 1 && nivel == 3)
        {
            Ganar();
        }
    }
    void level2()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("cambio1");
    }
    void level3()
    {
        Time.timeScale = 0;
      SceneManager.LoadScene("cambio2");
    }
    void Ganar()
    {
        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        SceneManager.LoadScene("final");
    }
}
