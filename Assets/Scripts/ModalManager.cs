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
        modalPanel.SetActive(true);
    }

    public void ShowModal(string title, string description, Sprite image)
    {
        Debug.Log("ShowModal");
        titleText.text = title;
        descriptionText.text = description;
        eventImage.sprite = image;

        modalPanel.SetActive(true);
    }

    public void CloseModal()
    {
        Debug.Log("CloseModal");
        modalPanel.SetActive(false);
    }
}
