using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    private void Start()
    {
        playerNameInput.text = GameManager.instance.playerName;
    }
    public void StartNew()
    {
        if(playerNameInput.text != "")
        {
            GameManager.instance.playerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
