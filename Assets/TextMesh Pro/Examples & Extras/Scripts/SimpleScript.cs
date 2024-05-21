using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class SimpleScript : MonoBehaviour
    {
        public TMP_Text textComponent; 
        private TextMeshPro m_textMeshPro;
        //private TMP_FontAsset m_FontAsset;

        private const string label = "The <#0050FF>count is: </color>{0:2}";
        private float m_frame;


        void Start()
        {
            // Add new TextMesh Pro Component
            textComponent.text = "New Text";

       }

        void Update()
        {
            m_textMeshPro.SetText(label, m_frame % 1000);
            m_frame += 1 * Time.deltaTime;
        }
        public void ChangeText()
        {
            textComponent.text = "New Text";  // Change the text here
        }
    }
}
