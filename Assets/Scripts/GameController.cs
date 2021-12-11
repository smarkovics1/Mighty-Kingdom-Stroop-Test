using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController: MonoBehaviour
{
    public Dictionary<string, Color> colourInfo = new Dictionary<string, Color>();

    [Header("Answer Buttons")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public TextMeshProUGUI mainText;

    public enum ColourOptions { red, blue, green, yellow };//, white, grey };
    int numColours = 4;
    public ColourOptions colourChosen;

    void Start()
    {
        colourInfo.Add("red", Color.red);
        colourInfo.Add("blue", Color.blue);
        colourInfo.Add("green", Color.green);
        colourInfo.Add("yellow", Color.yellow);
        //colourInfo.Add("white", Color.white);
        //colourInfo.Add("grey", Color.grey);

        foreach (KeyValuePair<string, Color> pair in colourInfo)
        {
            print(pair.Key + "-" + pair.Value);
        }

        CreateQuestion();
    }

    void Update()
    {

    }

    public void CreateQuestion()
    {
        Color chosenColour;
        string textValue;
        int temp = Random.Range(0, numColours);

        int temp2;
        do
        {
            temp2 = Random.Range(0, numColours);
            print(temp + "--" + temp2);
        }
        while (temp2 == temp);
        //if (temp2 == temp)
        //{
        //    temp2 = Random.Range(0, numColours);
        //}

        colourInfo.TryGetValue(RandomizeColour(temp), out chosenColour);
        mainText.color = chosenColour;
        colourInfo.TryGetValue(RandomizeColour(temp), out textValue);
        mainText.text = textValue;
    }

    public string RandomizeColour(int temp)
    {
        colourChosen = (ColourOptions)temp;
        return colourChosen.ToString();
    }
}