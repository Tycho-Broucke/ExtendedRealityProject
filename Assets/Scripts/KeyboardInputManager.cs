using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use this namespace if you are using TextMeshPro for your input field

public class KeyboardInputManager : MonoBehaviour
{
    public TMP_InputField inputField; // Assign this in the inspector if using TextMeshPro
    public Canvas canvas;  // Assign this in the inspector
    public GameObject[] lettersAndNumbers;
    public GameObject[] symbols;
    public Button symButton;
    private bool isSymbolsActive = false;
    public Button CAPSButton;
    private bool isCAPSActive = false;
    // Call this method from button's OnClick event

    private void Start()
    {
        symButton.onClick.AddListener(() => ToggleSymbols());
        CAPSButton.onClick.AddListener(() => ToggleCAPSLock());
        UpdateKeyVisibility();
        ToggleCAPSLock();
    }

    void ToggleSymbols()
    {
        isSymbolsActive = !isSymbolsActive;
        UpdateKeyVisibility();
    }
    void ToggleCAPSLock()
    {
        isCAPSActive = !isCAPSActive; // Toggle the CAPS LOCK state

        // Change each letter key to uppercase or lowercase based on the isCAPSActive state
        foreach (GameObject key in lettersAndNumbers)
        {
            TMP_Text keyText = key.GetComponentInChildren<TMP_Text>(); // Assuming each key has a TMP_Text child
            if (keyText != null)
            {
                keyText.text = isCAPSActive ? keyText.text.ToUpper() : keyText.text.ToLower();
            }
        }
    }


    void UpdateKeyVisibility()
    {
        foreach (GameObject letterOrNumber in lettersAndNumbers)
        {
            letterOrNumber.SetActive(!isSymbolsActive);
        }
        foreach (GameObject symbol in symbols)
        {
            symbol.SetActive(isSymbolsActive);
        }
    }

    public void AppendToInputField(string characterToAdd)

    {

        if (inputField != null)
        {
            switch (characterToAdd)
            {
                case "DEL":
                    if (inputField.text.Length > 0)
                        inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
                    break;
                case "SPACE":
                    inputField.text += " ";
                    break;
                case "SYM":
                    UpdateKeyVisibility();
                    break;
                default:
                    // Apply the CAPS state to the input if needed
                    inputField.text += isCAPSActive ? characterToAdd.ToUpper() : characterToAdd.ToLower();
                    break;
            }
            checkPlaceholderVisibility();
            inputField.ForceLabelUpdate();  // Make sure the UI updates
            LayoutRebuilder.ForceRebuildLayoutImmediate(canvas.GetComponent<RectTransform>());
            // LayoutRebuilder.ForceRebuildLayoutImmediate(inputField.GetComponent<RectTransform>());
            if (inputField.text.Length > 0 && inputField.placeholder != null)
            {
                Debug.Log("Hiding placeholder");
                inputField.placeholder.gameObject.SetActive(false);  // Hide placeholder if there is text
                Debug.Log("Placeholder hidden");
            }
        }
        else
        {
            Debug.LogError("InputField is not assigned!");
        }
    }

    private void checkPlaceholderVisibility()
    {
        Debug.Log("Checking placeholder visibility");
        if (inputField.text.Length > 0 && inputField.placeholder != null)
        {
            Debug.Log("Hiding placeholder");
            inputField.placeholder.gameObject.SetActive(false);  // Hide placeholder if there is text
            Debug.Log("Placeholder hidden");
        }
        else if (inputField.text.Length == 0 && inputField.placeholder != null)
        {
            Debug.Log("Showing placeholder");
            inputField.placeholder.gameObject.SetActive(true);  // Show placeholder if there is no text
            Debug.Log("Placeholder shown");
        }
    }


}
