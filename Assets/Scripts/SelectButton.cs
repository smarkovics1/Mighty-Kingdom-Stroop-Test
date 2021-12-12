using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        print(buttonNumber + "----" + gameObject.name);
    }
}
