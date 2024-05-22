using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExerciseManager : MonoBehaviour
{
    public TMP_Text exerciseText; // Assign in inspector, remove TMP_ if not using TextMeshPro
    public TMP_InputField inputField; // Assign in inspector
    public Button doneButton; // Assign in inspector
    public TMP_Text resultsText; // Assign in inspector
    public Button restartButton;  // restart button

    private string correctSentence;
    private int currentSentenceIndex = 0;

    // add differtent sentences to display
    private string[] sentencesToDisplay =
    {
        "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG",
        "you see what you believe",
        "ThIs iS aN exaMplE sEnTencE, tHat hAs 12345 NumbERS, and ,.';/][ sy$mbols.",
    };

    void Start()
    {
        LoadNewSentence();
        doneButton.onClick.AddListener(CheckInput);
        restartButton.onClick.AddListener(RestartExercise);
        resultsText.text = "";
    }
    void LoadNewSentence()
    {
        if (currentSentenceIndex < sentencesToDisplay.Length)
        {
            correctSentence = sentencesToDisplay[currentSentenceIndex];
            exerciseText.text = correctSentence;
        }
        else
        {
            // Optionally handle the scenario where all sentences have been used
            exerciseText.text = "Well done! You've completed all exercises.";
            inputField.gameObject.SetActive(false);
            doneButton.gameObject.SetActive(false);
            resultWindow.SetActive(false);
        }
    }


    void CheckInput()
    {
        int correctCount = 0;
        string userInput = inputField.text;

        int comparisonLength = Mathf.Min(userInput.Length, correctSentence.Length);

        for (int i = 0; i < comparisonLength; i++)
        {
            if (userInput[i] == correctSentence[i])
            {
                correctCount++;
            }
        }

        int totalCharacters = correctSentence.Length;
        float correctness = (correctCount / (float)totalCharacters) * 100;
        resultsText.text = $"You scored {correctness}% correctness.";

        ShowResultWindow(correctness);

        inputField.gameObject.SetActive(false);
        doneButton.gameObject.SetActive(false);

        if (correctness == 100)
        {
            currentSentenceIndex++; // Move to the next sentence
            RestartExercise(); // Call RestartExercise to setup for the next sentence
        }
    }

    public GameObject resultWindow; // Assign this in inspector. This should be your UI panel for results.

    void ShowResultWindow(float correctness)
    {
        // You might have a Text element in this window to display the message
        TMP_Text resultMessage = resultWindow.GetComponentInChildren<TMP_Text>();

        if (correctness == 100)
        {
            resultMessage.text = "Congratulations! Perfect score!";
        }
        else
        {
            resultMessage.text = "Try again! You made some mistakes.";
        }

        resultWindow.SetActive(true); // Show the result window
    }



    public void RestartExercise()
    {
        if (currentSentenceIndex < sentencesToDisplay.Length)
        {
            LoadNewSentence();  // Load the next sentence
        }

        inputField.text = "";
        resultsText.text = "";
        resultWindow.SetActive(false);
        inputField.gameObject.SetActive(true);
        doneButton.gameObject.SetActive(true);
        inputField.ForceLabelUpdate();
    }

}
