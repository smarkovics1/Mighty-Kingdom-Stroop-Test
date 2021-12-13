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

    public SelectButton[] buttonSelect;

    public TextMeshProUGUI mainText;

    public enum ColourOptions { Red, Blue, Green, Yellow };
    int numColours = 4;
    public ColourOptions colourChosen;

    int randomColourInt;

    void Start()
    {
        //add colours and text to dictionary for use later
        colourInfo.Add("Red", Color.red);
        colourInfo.Add("Blue", Color.blue);
        colourInfo.Add("Green", Color.green);
        colourInfo.Add("Yellow", Color.yellow);


        //check data was inputted correctly into dictionary
        foreach (KeyValuePair<string, Color> pair in colourInfo)
        {
            print(pair.Key + "-" + pair.Value);
        }

        //sets the button values and text
        for (int i = 0; i < buttonSelect.Length; i++)
        {
            buttonSelect[i].buttonNumber = i;
            buttonSelect[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = SetMainText(i);
        }

        CreateQuestion();
    }

    void Update()
    {
        //reset main text to test random combinations
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreateQuestion();
        }
    }

    public void CreateQuestion()
    {
        
        int temp = Random.Range(0, numColours);
        int temp2;

        //loop to make sure colour of text and text are different
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
        randomColourInt = temp;
        print(temp + "-temp 1 value-" + temp2 + "-temp 2 value-");

        //sets the text and texts colour of the main text
        SetMainText(temp2, temp);

        

    }

    public string RandomizeColour(int temp)
    {
        //sets the enum colour chosen to the inputted value
        colourChosen = (ColourOptions)temp;

        //returns text string to find dictionary key
        return colourChosen.ToString();
    }

    public void SetMainText(int textColour, int text)
    {
        Color chosenColour;
        colourInfo.TryGetValue(RandomizeColour(text), out chosenColour);
        mainText.color = chosenColour;
        mainText.text = RandomizeColour(textColour);
    }

    public string SetMainText(int textColour)
    {
        Color chosenColour;
        colourInfo.TryGetValue(RandomizeColour(textColour), out chosenColour);
        //mainText.color = chosenColour;
        return RandomizeColour(textColour);
    }

    public void ChosenAnswer(int answer)
    {
        if (randomColourInt == answer)
        {
            print("correct");
            CreateQuestion();

        }
        else
        {
            print("incorrect");
        }
    }
}