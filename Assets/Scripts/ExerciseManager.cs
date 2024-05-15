using UnityEngine;
using UnityEngine.UI;
using TMPro; // Remove this line if you're not using TextMeshPro

public class ExerciseManager : MonoBehaviour
{
    public TMP_Text exerciseText; // Assign in inspector, remove TMP_ if not using TextMeshPro
    public TMP_InputField inputField; // Assign in inspector
    public Button doneButton; // Assign in inspector
    public TMP_Text resultsText; // Assign in inspector
    public Button restartButton;  // restart button

    private string correctSentence;

    void Start()
    {
        correctSentence = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"; // Set the sentence
        exerciseText.text = correctSentence;
        doneButton.onClick.AddListener(CheckInput);
        restartButton.onClick.AddListener(RestartExercise);

        resultsText.text = "";
    }

    void CheckInput()
    {
        if (inputField.text.Equals(correctSentence))
        {
            resultsText.text = "Correct!";
        }
        else
        {
            resultsText.text = "Incorrect, try again.";
        }

        inputField.gameObject.SetActive(false); // Hide the keyboard/input field
        doneButton.gameObject.SetActive(false); // Optionally hide the done button
    }

    public void RestartExercise()
    {
        inputField.text = ""; // Clear the input field
        resultsText.text = ""; // Clear the results text

        inputField.gameObject.SetActive(true); // Show the input field again
        inputField.ForceLabelUpdate();
        doneButton.gameObject.SetActive(true); // Show the done button again

        // Optionally, reset any other states or variables if needed

    }
}
