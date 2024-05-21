using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class Simple3DButton : XRBaseInteractable
{
    [SerializeField]
    public TMP_Text textComponent;

    private void OnEnable()
    {
        selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (textComponent != null)
        {
            textComponent.text = "Text changed on button press";
        }
    }
}
