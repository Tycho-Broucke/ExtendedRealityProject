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
    // add differtent sentences to display
    private string[] sentencesToDisplay =
    {
        "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG",
        "you see what you believe",
        "ThIs iS aN exaMplE sEnTencE, tHat hAs 12345 NumbERS, and ,.';/][ sy$mbols.",
    };

    void Start()
    {
        // randomly select a sentence from the array
        correctSentence = sentencesToDisplay[Random.Range(0, sentencesToDisplay.Length)];
        // correctSentence = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"; // Set the sentence
        exerciseText.text = correctSentence;
        doneButton.onClick.AddListener(CheckInput);
        restartButton.onClick.AddListener(RestartExercise);

        resultsText.text = "";
    }

    void CheckInput()
    {
        int correctCount = 0;
        string userInput = inputField.text;

        // Ensure we compare the shorter length to avoid index out of range issues
        int comparisonLength = Mathf.Min(userInput.Length, correctSentence.Length);

        for (int i = 0; i < comparisonLength; i++)
        {
            if (userInput[i] == correctSentence[i])
            {
                correctCount++;
            }
        }

        // Count missing characters as errors
        int totalCharacters = correctSentence.Length;
        int errorCount = totalCharacters - correctCount; // Mistakes include wrong and missing characters

        // Calculate correctness percentage
        float correctness = (correctCount / (float)totalCharacters) * 100;

        resultsText.text = $"You scored {correctness}% correctness.";

        ShowResultWindow(correctness);

        inputField.gameObject.SetActive(false); // Hide the keyboard/input field
        doneButton.gameObject.SetActive(false); // Optionally hide the done button
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
        inputField.text = ""; // Clear the input field
        resultsText.text = ""; // Clear the results text

        inputField.gameObject.SetActive(true); // Show the input field again
        inputField.ForceLabelUpdate();
        // resultsMessage.gameObject.SetActive(false); // Hide the result window
        resultWindow.SetActive(false); // Hide the result window
        doneButton.gameObject.SetActive(true); // Show the done button again

        // Optionally, reset any other states or variables if needed

    }
}
