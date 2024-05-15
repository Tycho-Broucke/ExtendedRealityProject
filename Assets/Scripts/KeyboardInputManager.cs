using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use this namespace if you are using TextMeshPro for your input field

public class KeyboardInputManager : MonoBehaviour
{
    public TMP_InputField inputField; // Assign this in the inspector if using TextMeshPro
    public Canvas canvas;  // Assign this in the inspector

    // Call this method from button's OnClick event
    public void AppendToInputField(string characterToAdd)
    {
        if (inputField != null)
        {
            if (characterToAdd == "DEL")
            {
                if (inputField.text.Length > 0)
                    inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
                else
                    inputField.text = "";  // Prevent negative index error
            }
            else if (characterToAdd == "SPACE")
            {
                inputField.text += " ";
            }
            else
                inputField.text += characterToAdd;
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
