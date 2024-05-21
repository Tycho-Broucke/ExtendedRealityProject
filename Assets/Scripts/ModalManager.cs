using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalManager : MonoBehaviour
{
    public GameObject modalPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image eventImage;
    public Button closeButton;
    public Button ExperienceButton;

    // Start is called before the first frame update
    void Start()
    {
        modalPanel.SetActive(false);
    }

    public void ShowModal(string title, string description, Sprite image)
    {
        titleText.text = title;
        descriptionText.text = description;
        eventImage.sprite = image;

        modalPanel.SetActive(true);
    }

    public void CloseModal()
    {
        modalPanel.SetActive(false);
    }
}
