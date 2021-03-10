using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    MyGameManager[] gameManagers;

    private void Start()
    {
        gameManagers = FindObjectsOfType<MyGameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            KeepGameManagers();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoadLevelSelect()
    {
        KeepGameManagers();
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadSceneByInt(int sceneNumber)
    {
        KeepGameManagers();
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadLevelByInt(int levelNumber)
    {
        KeepGameManagers();
        SceneManager.LoadScene("Level"+levelNumber.ToString());
    }

        private void KeepGameManagers()
    {
        foreach (var gameManager in gameManagers)
        {
            DontDestroyOnLoad(gameManager);
        }
    }

}
