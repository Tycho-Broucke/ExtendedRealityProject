using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string questionText = "test";
    public string[] answers = new string[3];
}

public class UIManager : MonoBehaviour
{
    [Header("UI Components")]
    public TMP_Text headerText;
    public TMP_Text mainText;
    public Button progressionButton;
    public TMP_Text progressionButtonText;

    public Button optionButton1;
    public TMP_Text optionButton1Text;

    public Button optionButton2;
    public TMP_Text optionButton2Text;

    public Button optionButton3;
    public TMP_Text optionButton3Text;

    [Header("Questions and Answers")]
    public Question[] questions;

    private int currentQuestionIndex = -1;

    private void Start()
    {
        // Ensure option buttons are initially invisible
        SetAllOptionButtonsVisibility(false);

        // Initialize questions
        InitializeQuestions();
    }

    private void InitializeQuestions()
    {
        questions = new Question[]
        {
            new Question
            {
                questionText = "What is the capital of France?",
                answers = new string[] { "Paris", "London", "Berlin" }
            },
            new Question
            {
                questionText = "What is 2 + 2?",
                answers = new string[] { "3", "4", "5" }
            },
            new Question
            {
                questionText = "What is the chemical symbol for water?",
                answers = new string[] { "H2O", "O2", "CO2" }
            }
        };
    }

    public void StartGame()
    {
        // Hide the progression button and show the option buttons
        SetButtonVisibility(progressionButton, false);
        LoadNextQuestion();
    }

    public void LoadNextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        else
        {
            // No more questions, handle accordingly
            Debug.Log("All questions answered!");
            // Optionally, hide the option buttons
            SetAllOptionButtonsVisibility(false);
        }
    }

    private void DisplayQuestion(Question question)
    {
        if (mainText != null)
        {
            mainText.text = question.questionText;
        }

        if (question.answers.Length >= 3)
        {
            if (optionButton1Text != null) optionButton1Text.text = question.answers[0];
            if (optionButton2Text != null) optionButton2Text.text = question.answers[1];
            if (optionButton3Text != null) optionButton3Text.text = question.answers[2];
        }

        // Make sure all option buttons are visible and positioned correctly
        SetAllOptionButtonsVisibility(true);
        SetOptionButtonsPosition();
    }

    private void SetOptionButtonsPosition()
    {
        if (progressionButton != null)
        {
            RectTransform progressionButtonRT = progressionButton.GetComponent<RectTransform>();

            if (optionButton1 != null)
            {
                RectTransform rt1 = optionButton1.GetComponent<RectTransform>();
                rt1.anchoredPosition = new Vector2(progressionButtonRT.anchoredPosition.x - 200, progressionButtonRT.anchoredPosition.y);
            }

            if (optionButton2 != null)
            {
                RectTransform rt2 = optionButton2.GetComponent<RectTransform>();
                rt2.anchoredPosition = new Vector2(progressionButtonRT.anchoredPosition.x, progressionButtonRT.anchoredPosition.y);
            }

            if (optionButton3 != null)
            {
                RectTransform rt3 = optionButton3.GetComponent<RectTransform>();
                rt3.anchoredPosition = new Vector2(progressionButtonRT.anchoredPosition.x + 200, progressionButtonRT.anchoredPosition.y);
            }
        }
    }

    public void SetHeaderText(string text)
    {
        if (headerText != null)
        {
            headerText.text = text;
        }
    }

    public void SetMainText(string text)
    {
        if (mainText != null)
        {
            mainText.text = text;
        }
    }

    public void SetProgressionButtonText(string text)
    {
        if (progressionButtonText != null)
        {
            progressionButtonText.text = text;
        }
    }

    public void SetButtonVisibility(Button button, bool isVisible)
    {
        if (button != null)
        {
            button.gameObject.SetActive(isVisible);
        }
    }

    public void SetAllOptionButtonsVisibility(bool isVisible)
    {
        SetButtonVisibility(optionButton1, isVisible);
        SetButtonVisibility(optionButton2, isVisible);
        SetButtonVisibility(optionButton3, isVisible);
    }

    public void OnOptionButtonClick(int optionIndex)
    {
        Debug.Log("Option " + optionIndex + " clicked.");
        LoadNextQuestion();
    }
}