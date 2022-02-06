using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string pretext;
    [SerializeField] private string postText;

    public void UpdateText(string textToUpdate)
    {
        text.text = $"{pretext}{textToUpdate}{postText}";
    }
}
