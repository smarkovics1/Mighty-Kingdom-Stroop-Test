using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController: MonoBehaviour
{
    private Dictionary<string, Color> colourInfo = new Dictionary<string, Color>();

    [Header("Answer Buttons")]
    public GameObject[] buttons;
    public SelectButton[] buttonSelect;

    public TextMeshProUGUI mainText;

    public TextMeshProUGUI totalCorrect;
    public TextMeshProUGUI totalIncorrect;
    public TextMeshProUGUI scoreResult;
    int correct = 0;
    int inCorrect = 0;
    int roundNumber = 0;
    int score = 0;

    public enum ColourOptions { Red, Blue, Green, Yellow };
    int numColours = 4;
    public ColourOptions colourChosen;

    int randomColourInt;

    public GameObject mainScreen;
    public GameObject resultScreen;

    //Timer Variables
    float timer = 0f;

    void Start()
    {
        score = 0;
        //add colours and text to dictionary for use later
        colourInfo.Add("Red", Color.red);
        colourInfo.Add("Blue", Color.blue);
        colourInfo.Add("Green", Color.green);
        colourInfo.Add("Yellow", Color.yellow);

        //check data was inputted correctly into dictionary
        //foreach (KeyValuePair<string, Color> pair in colourInfo)
        //{
        //    print(pair.Key + "------" + pair.Value);
        //}

        //sets the button values and text
        for (int i = 0; i < buttonSelect.Length; i++)
        {
            buttonSelect[i].buttonNumber = i;
            buttonSelect[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = SetMainText(i);
        }

        CreateQuestion();
    }

    public void Update()
    {
        //reset main text to test random combinations
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    CreateQuestion();
        //}
        timer += Time.deltaTime;
    }

    public void CreateQuestion()
    {
        timer = 0f;

        int temp = Random.Range(0, numColours);
        int temp2;

        //loop to make sure colour of text and text are different
        do
        {
            temp2 = Random.Range(0, numColours);
            //print(temp + "--" + temp2);
        }
        while (temp2 == temp);

        if (temp == temp2)
        {
            print("Should not get here");
        }
        randomColourInt = temp;
        //print(temp + "-temp 1 value-" + temp2 + "-temp 2 value-");
        print(RandomizeColour(temp));
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
        roundNumber++;
        if (randomColourInt == answer)
        {
            //print("correct");
            correct++;
            AddScore();
            CreateQuestion();


        }
        else
        {
            inCorrect++;
            //print("incorrect");
            CreateQuestion();
        }
        CheckRoundNumber();
    }

    public void CheckRoundNumber()
    {
        //checks round number
        if (roundNumber == 10)
        {
            //switches screen to results and sets values
            resultScreen.SetActive(true);
            mainScreen.SetActive(false);
            totalCorrect.text = correct + " correct answers";
            totalIncorrect.text = inCorrect + " incorrect answers";
            scoreResult.text = score.ToString();
        }
    }

    public void AddScore()
    {
        if (timer < 0.35f)
        {
            print(timer + "here is 100 points0");
            score += 100;
        }
        else if (timer >= 0.35f && timer < 0.45f)
        {
            score += 80;
        }
        else if (timer >= 0.45f && timer < 0.55f)
        {
            score += 60;
        }
        else if (timer >= 0.55f && timer < 0.75f)
        {
            score += 40;
        }
        else
        {
            score += 20;
        }
        print(score);
    }
}