using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Collections;

public class Persistence : MonoBehaviour
{

    private const string tempFileName = "tempFIle.bin";

    [SerializeField]
    private int m_MaxNumberOfLevels = 1;

    private PlayerProgress m_PlayerProgress;
    public PlayerProgress PlayerProgress
    {
        get { return m_PlayerProgress; }
    }


    void Awake()
    {
        if (IsTempFileExists())
        {
            m_PlayerProgress = LoadPreviousPlayerProgressData();
        }
        else
        {
            m_PlayerProgress = new PlayerProgress(1);
        }

    }

    void Start()
    {
        LoadMainMenu();
    }


    bool IsTempFileExists()
    {
        return File.Exists(tempFileName);
    }

    private PlayerProgress LoadPreviousPlayerProgressData()
    {
        FileStream fs = new FileStream(tempFileName, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();

        return (PlayerProgress)bf.Deserialize(fs);
    }


    public void PlayerProgressed()
    {
        // Player finished the level, increase the current level index to the next scene index
        m_PlayerProgress.Level++;
        SavePlayerProgress();

        // Unload the current level 
        CloseCurrentLevel();

        // If the player has finished the game (sceneIndex > m_MaxNumberOfLevels) the load the credits scene
        if (m_PlayerProgress.Level > m_MaxNumberOfLevels)
        {
            LoadCredits();
        }
        else
        {
            // Load the next level 
            LoadNextLevel();
        }
    }

    private void SavePlayerProgress()
    {
        FileStream fs = new FileStream(tempFileName, FileMode.Truncate);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, m_PlayerProgress);
    }

    public void PlayerFailedLevel()
    {
        // Restart the level from a certain point (or from the beginning)
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(m_PlayerProgress.Level);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
    }

    private void CloseCurrentLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.UnloadScene(activeScene);
    }

    private void CloseMainMenu()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "MainMenu")
        {
            SceneManager.UnloadScene(activeScene);
        }
    }

    public void CloseCredits()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "Credits")
        {
            SceneManager.UnloadScene(activeScene);
        }
    }





}
