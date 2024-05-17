using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string questionText = "test";
    public string[] answers = new string[3];
    public int correctAnswerIndex;
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

    public TMP_Text scoreText;

    [Header("Questions and Answers")]
    public Question[] questions;

    private int currentQuestionIndex = -1;
    private int score = 0;

    [Header("Table Reference")]
    public Transform tableTransform; // Reference to the table transform

    private GameObject currentFigure; // To keep track of the current 3D figure

    [Header("3D Models")]
    public GameObject flagOfSpainModel; // Reference to the 3D model of the flag of Spain
    public GameObject TRexModel; // Reference to the 3D model for the third question
    public GameObject VaderModel;
    public GameObject SaturnusModel;
    public GameObject BikeModel;
    public GameObject ElephantModel;
    public GameObject CalculatorModel;
    public GameObject GoldModel;
    public GameObject PlaneModel;
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
                questionText = "What is the formula to calculate the volume of a sphere?",
                answers = new string[] { "4/3 π r³", "π r²", "2πr" },
                correctAnswerIndex = 0,
            },
            new Question
            {
                questionText = "From which country is the flag you see below?",
                answers = new string[] { "Portugal", "Spain", "Italy" },
                correctAnswerIndex = 1,
            },
            new Question
            {
                questionText = "What kind of dinosaur is displayed below?",
                answers = new string[] { "Spinosaurus", "Carnotaurus", "T-rex" },
                correctAnswerIndex = 2,
            },
            new Question
            {
                questionText = "From which movie series is this character?",
                answers = new string[] { "Star wars", "Pokemon", "Harry Potter" },
                correctAnswerIndex = 0,
            },
            new Question
            {
                questionText = "What is the name of the planet below?",
                answers = new string[] { "Venus", "Saturn", "Jupiter" },
                correctAnswerIndex = 1,
            },
            new Question
            {
                questionText = "Who won last the Tour de France in 2023?",
                answers = new string[] { "Pogacar", "Wout van Aert", "Vingegaard" },
                correctAnswerIndex = 2,
            },
            new Question
            {
                questionText = "What is the largest mammal in the world?",
                answers = new string[] { "Elephant", "Blue Whale", "Giraffe" },
                correctAnswerIndex = 1,
            },
            new Question
            {
                questionText = "What is the smallest prime number?",
                answers = new string[] { "1", "2", "3" },
                correctAnswerIndex = 1,
            },
            new Question
            {
                questionText = "What is the symbol of gold in the periodic table?",
                answers = new string[] { "Au", "Gd", "Go" },
                correctAnswerIndex = 0,
            },
            new Question
            {
                questionText = " When a jet breaks the sound barrier, it is traveling at speeds around ... km/h ?",
                answers = new string[] { "1495", "300", "1,235 " },
                correctAnswerIndex = 2,
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
            mainText.text = "All questions answered!";
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

        // Handle 3D figure creation for specific questions
        if (currentFigure != null)
        {
            Destroy(currentFigure);
            currentFigure = null;
        }

        if (tableTransform != null)
        {
            if (currentQuestionIndex == 0)
            {
                currentFigure = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                currentFigure.transform.position = tableTransform.position + new Vector3(0, 0.6f, 0); // Adjust position to be a bit above the table
                currentFigure.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Make the sphere smaller
            }
            else if (currentQuestionIndex == 1 && flagOfSpainModel != null)
            {
                flagOfSpainModel.transform.localScale = new Vector3(50f, 50f, 50f); // Adjust scale as needed
            }
            else if (currentQuestionIndex == 2 && TRexModel != null)
            {
                TRexModel.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                flagOfSpainModel.transform.localScale = Vector3.zero; // Adjust scale as needed
            }
            else if (currentQuestionIndex == 3 && VaderModel != null)
            {
                VaderModel.transform.localScale = new Vector3(5f, 5f, 5f);
                TRexModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions
            }
            else if (currentQuestionIndex == 4 && SaturnusModel != null)
            {
                SaturnusModel.transform.localScale = new Vector3(0.001f, 0.001f,0.001f);
                VaderModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions

            }
            else if (currentQuestionIndex == 5 && BikeModel != null)
            {
                BikeModel.transform.localScale = new Vector3(10f, 10f,10f);
                SaturnusModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions

            }
            else if (currentQuestionIndex == 6 && ElephantModel != null)
            {
                ElephantModel.transform.localScale = new Vector3(0.06f,0.06f,0.06f);
                BikeModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions

            }
            else if (currentQuestionIndex == 7 && CalculatorModel!= null)
            {
                CalculatorModel.transform.localScale = new Vector3(200f,200f,200f);
                ElephantModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions

            }
            else if (currentQuestionIndex == 8 && GoldModel!= null)
            {
                GoldModel.transform.localScale = new Vector3(10f,10f,10f);
                CalculatorModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions

            }
            else if (currentQuestionIndex == 9 && PlaneModel!= null)
            {
                PlaneModel.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
                GoldModel.transform.localScale = Vector3.zero; // Make the chemical symbol model invisible for other questions

            }
            else
            {

                    flagOfSpainModel.transform.localScale = Vector3.zero; // Make the flag invisible for other questions
                    TRexModel.transform.localScale = Vector3.zero; // Adjust scale as needed
                    SaturnusModel.transform.localScale = Vector3.zero; // Adjust scale as needed
                    VaderModel.transform.localScale = Vector3.zero; // Adjust scale as needed
                    BikeModel.transform.localScale = Vector3.zero; 
                    ElephantModel.transform.localScale=Vector3.zero;
                    CalculatorModel.transform.localScale=Vector3.zero;
                    GoldModel.transform.localScale=Vector3.zero;
                    PlaneModel.transform.localScale=Vector3.zero;
                
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
            if (optionIndex - 1 == questions[currentQuestionIndex].correctAnswerIndex)
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
        PlaneModel.transform.localScale=Vector3.zero;   
        // Start the game again
        StartGame();
    }
}
