using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Make sure to include the TextMeshPro namespace if using TMP components

public class VRKeyboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;  // Assign this in the inspector

    public void OnKeyPress(string key)
    {
        switch (key)
        {
            case "DEL":
                if (displayText.text.Length > 0)
                {
                    displayText.text = displayText.text.Substring(0, displayText.text.Length - 1);
                }
                break;
            case "SPACE":
                displayText.text += " ";
                break;
            default:
                displayText.text += key;
                break;
        }
    }
}
