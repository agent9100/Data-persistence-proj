using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    //public NamePicker NamePicker;
    [SerializeField] TextMeshProUGUI highScoreText;

    public void NameEntered(string name) // Take input from text field !!!!!!
    {
        DataManager.Instance.currentName = name;
        Debug.Log(DataManager.Instance.currentName);
    }
    
    private void Start()
    {
        highScoreText.SetText("High Score : " + DataManager.Instance.playerName + " : " + DataManager.Instance.highScore);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if (UNITY_EDITOR)
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
