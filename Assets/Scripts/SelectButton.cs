using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameController gc;

    public void Start()
    {
        gc = FindObjectOfType<GameController>();
    }
}
