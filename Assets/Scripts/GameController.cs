using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController: MonoBehaviour
{
    //dictionary for storing colour and colour name
    private Dictionary<string, Color> colourInfo = new Dictionary<string, Color>();

    [Header("Answer Buttons")]
    public SelectButton[] buttonSelect;

    [Header("Text Variables")]
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI totalCorrect;
    public TextMeshProUGUI totalIncorrect;
    public TextMeshProUGUI scoreResult;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    //scoring variables
    int correct = 0;
    int inCorrect = 0;
    int roundNumber = 0;
    int score = 0;

    public enum ColourOptions { Red, Blue, Green, Yellow };
    private int numColours = 4;
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

        //sets the button values and text
        for (int i = 0; i < buttonSelect.Length; i++)
        {
            buttonSelect[i].buttonNumber = i;
            buttonSelect[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = SetMainText(i);
        }

        //setup first Question for player
        CreateQuestion();
    }

    public void Update()
    {
        //timer run and display time taken to player
        timer += Time.deltaTime;
        timerText.text = "Time: "+ timer.ToString("F1");
    }

    public void CreateQuestion()
    {
        //reset timer for each question
        timer = 0f;

        int temp = Random.Range(0, numColours);
        int temp2;

        //loop to make sure colour of text and text are different
        do
        {
            temp2 = Random.Range(0, numColours);
        }
        while (temp2 == temp);

        //set correct answer value
        randomColourInt = temp;
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
        //finds the colour value from the key input
        colourInfo.TryGetValue(RandomizeColour(text), out Color chosenColour);

        //set the colour to output from string
        mainText.color = chosenColour;

        //set the text to different colour than text colour
        mainText.text = RandomizeColour(textColour);
    }

    public string SetMainText(int textColour)
    {
        //colourInfo.TryGetValue(RandomizeColour(textColour), out Color chosenColour);
        return RandomizeColour(textColour);
    }

    public void ChosenAnswer(int answer)
    {
        //add to round number
        roundNumber++;

        //check input from button
        if (randomColourInt == answer)
        {
            //add to correct;
            correct++;
            
            //add score depending on time
            AddScore();

            //create new question
            CreateQuestion();
        }
        else
        {
            //add to incorrect
            inCorrect++;
            
            //create new question
            CreateQuestion();
        }

        //check that game has completed
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
            scoreResult.text = score.ToString() + " / 100";
        }
    }

    public void AddScore()
    {
        //score value less than 10
        float addScore = 10 - timer;

        //if greater than 10 seconds add 1 score
        if (addScore < 0)
        {
            score += 1;
        }
        //add normal score
        else
        {
            score += (int)addScore + 1;
        }

        //change score text to new score
        scoreText.text = "Score: " + score;
    }
}