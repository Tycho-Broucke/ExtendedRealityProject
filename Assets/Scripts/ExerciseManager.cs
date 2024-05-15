using UnityEngine;
using UnityEngine.UI;
using TMPro; // Remove this line if you're not using TextMeshPro

public class ExerciseManager : MonoBehaviour
{
    public TMP_Text exerciseText; // Assign in inspector, remove TMP_ if not using TextMeshPro
    public TMP_InputField inputField; // Assign in inspector
    public Button doneButton; // Assign in inspector
    public TMP_Text resultsText; // Assign in inspector

    private string correctSentence;

    void Start()
    {
        correctSentence = "The quick brown fox jumps over the lazy dog."; // Set the sentence
        exerciseText.text = correctSentence;
        doneButton.onClick.AddListener(CheckInput);

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
}
