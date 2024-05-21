using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    public string title;
    public string description;
    public Sprite image;

    private ModalManager modalManager;
    // Start is called before the first frame update
    void Start()
    {
        modalManager = GameObject.Find("ModalManager").GetComponent<ModalManager>();
        
    }

    public void onImageClick()
    {
        modalManager.ShowModal(title, description, image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
