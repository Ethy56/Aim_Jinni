using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button play, quit;
    void Awake()
    {
        play.onClick.AddListener(playClick);
        quit.onClick.AddListener(quitClick);
    }
    private void playClick()
    {
        SceneManager.LoadScene("Game");
    }
    private void quitClick()
    {
        Application.Quit();
    }
}