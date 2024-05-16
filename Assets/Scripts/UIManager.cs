using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string questionText = "test";
    public string[] answers = new string[3];
    public int correctAnswerIndex; // Add correct answer index
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

    public TMP_Text scoreText; // Add score text

    [Header("Questions and Answers")]
    public Question[] questions;

    private int currentQuestionIndex = -1;
    private int score = 0;

    private void Start()
    {
        // Ensure option buttons are initially invisible
        SetAllOptionButtonsVisibility(false);

        // Initialize questions
        InitializeQuestions();

        // Initialize score
        UpdateScoreText();
    }

    private void InitializeQuestions()
    {
        questions = new Question[]
        {
            new Question
            {
                questionText = "What is the capital of France?",
                answers = new string[] { "Paris", "London", "Berlin" },
                correctAnswerIndex = 0 // Set correct answer index
            },
            new Question
            {
                questionText = "What is 2 + 2?",
                answers = new string[] { "3", "4", "5" },
                correctAnswerIndex = 1 // Set correct answer index
            },
            new Question
            {
                questionText = "What is the chemical symbol for water?",
                answers = new string[] { "H2O", "O2", "CO2" },
                correctAnswerIndex = 0 // Set correct answer index
            },
            new Question
            {
                questionText = "Which planet is known as the Red Planet?",
                answers = new string[] { "Mars", "Earth", "Jupiter" },
                correctAnswerIndex = 0 // Set correct answer index
            },
            new Question
            {
                questionText = "Who wrote 'Romeo and Juliet'?",
                answers = new string[] { "Mark Twain", "William Shakespeare", "Charles Dickens" },
                correctAnswerIndex = 1 // Set correct answer index
            },
            new Question
            {
                questionText = "What is the speed of light?",
                answers = new string[] { "300,000 km/s", "150,000 km/s", "450,000 km/s" },
                correctAnswerIndex = 0 // Set correct answer index
            },
            new Question
            {
                questionText = "What is the largest mammal in the world?",
                answers = new string[] { "Elephant", "Blue Whale", "Giraffe" },
                correctAnswerIndex = 1 // Set correct answer index
            },
            new Question
            {
                questionText = "What is the smallest prime number?",
                answers = new string[] { "1", "2", "3" },
                correctAnswerIndex = 1 // Set correct answer index
            },
            new Question
            {
                questionText = "What element does 'O' represent on the periodic table?",
                answers = new string[] { "Osmium", "Oxygen", "Oganesson" },
                correctAnswerIndex = 1 // Set correct answer index
            },
            new Question
            {
                questionText = "Which ocean is the largest?",
                answers = new string[] { "Atlantic Ocean", "Indian Ocean", "Pacific Ocean" },
                correctAnswerIndex = 2 // Set correct answer index
            }
        };
    }

    public void StartGame()
    {
        // Hide the progression button and show the option buttons
        Debug.Log("StartGame called");
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
            // Show Try Again button
            SetButtonVisibility(progressionButton, true);
            SetProgressionButtonText("Try Again");
            // Attach the TryAgain function to the button click event
            progressionButton.onClick.RemoveAllListeners();
            progressionButton.onClick.AddListener(TryAgain);
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

        // Make sure all option buttons are visible
        SetAllOptionButtonsVisibility(true);
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
            Debug.Log($"Setting visibility of {button.name} to {isVisible}");
            button.transform.localScale = isVisible ? new Vector3(1, 1, 1) : new Vector3(0, 0, 0);
            Debug.Log($"{button.name} active state: {button.gameObject.activeSelf}, scale: {button.transform.localScale}");
        }
    }

    public void SetAllOptionButtonsVisibility(bool isVisible)
    {
        Debug.Log($"Setting all option buttons visibility to {isVisible}");
        SetButtonVisibility(optionButton1, isVisible);
        SetButtonVisibility(optionButton2, isVisible);
        SetButtonVisibility(optionButton3, isVisible);
    }

    public void OnOptionButtonClick(int optionIndex)
    {
        Debug.Log("Option " + optionIndex + " clicked.");

        if (currentQuestionIndex < questions.Length)
        {
            // Check if the selected option is correct
            if (optionIndex-1 == questions[currentQuestionIndex].correctAnswerIndex)
            {
                score += 10; // Increase score by 10 for a correct answer
                Debug.Log("Correct answer! Score: " + score);
            }
            else
            {
                Debug.Log("Incorrect answer.");
            }

            // Update the score text
            UpdateScoreText();

            // Load next question
            LoadNextQuestion();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void TryAgain()
    {
        // Reset the game state
        score = 0;
        currentQuestionIndex = -1;
        UpdateScoreText();

        // Start the game again
        StartGame();
    }
}
