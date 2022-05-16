using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; // make an instance of this class that can be accessed by all the scripts in the scene
    public static GameManager Instance
    {
        get
        {
            if (_instance is null) Debug.LogError("Game Manager is Null");

            return _instance; //referenced from https://medium.com/nerd-for-tech/implementing-a-game-manager-using-the-singleton-pattern-unity-eb614b9b1a74
        }
    }

    //references

    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject WinningScreen;
    void Awake()
    {
        _instance = this;
        GameOverText.SetActive(false);
        WinningScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        GameOverText.SetActive(true);
        Time.timeScale = 0;

    }

    public void WinGame()
    {
        WinningScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
