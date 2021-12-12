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
    //public SelectButton button1Select;
    //public SelectButton button2Select;
    //public SelectButton button3Select;
    //public SelectButton button4Select;

    public SelectButton[] buttonSelect;

    public TextMeshProUGUI mainText;

    public enum ColourOptions { Red, Blue, Green, Yellow , White, Grey };
    int numColours = 6;
    public ColourOptions colourChosen;

    void Start()
    {
        colourInfo.Add("Red", Color.red);
        colourInfo.Add("Blue", Color.blue);
        colourInfo.Add("Green", Color.green);
        colourInfo.Add("Yellow", Color.yellow);
        colourInfo.Add("White", Color.white);
        colourInfo.Add("Grey", Color.grey);

        foreach (KeyValuePair<string, Color> pair in colourInfo)
        {
            print(pair.Key + "-" + pair.Value);
        }

        CreateQuestion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreateQuestion();
        }
    }

    public void CreateQuestion()
    {
        Color chosenColour;
        int temp = Random.Range(0, numColours);
        int temp2;

        do
        {
            temp2 = Random.Range(0, numColours);
            print(temp + "--" + temp2);
        }
        while (temp2 == temp);

        if (temp == temp2)
        {
            print("Should not get here");
        }

        print(temp + "-temp 1 value-" + temp2 + "-temp 2 value-");

        colourInfo.TryGetValue(RandomizeColour(temp), out chosenColour);
        mainText.color = chosenColour;
        mainText.text = RandomizeColour(temp2);

    }

    public string RandomizeColour(int temp)
    {
        //sets the enum colour chosen to the inputted value
        colourChosen = (ColourOptions)temp;

        //returns text string to find dictionary key
        return colourChosen.ToString();
    }

    public void ChosenAnswer(int answer)
    {

    }
}