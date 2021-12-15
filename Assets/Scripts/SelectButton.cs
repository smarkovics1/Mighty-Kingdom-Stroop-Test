using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    private GameController gc;
    public int buttonNumber;

    public void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    public void SelectAnswer()
    {
        gc.ChosenAnswer(buttonNumber);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QUITMAINMENU()
    {
        SceneManager.LoadScene(0);
    }
}
