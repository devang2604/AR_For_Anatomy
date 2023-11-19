using UnityEngine;
using UnityEngine.UI;

public class ScrollableTextBox : MonoBehaviour
{
    public Text textArea;

    void Start()
    {
        ScrollRect scrollRect = textArea.gameObject.AddComponent<ScrollRect>();

        scrollRect.viewport.sizeDelta = new Vector2(200, 100);

        scrollRect.vertical = true;
    }
}