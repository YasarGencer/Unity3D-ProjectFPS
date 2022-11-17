using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _prompText;

    public TextMeshProUGUI GetPrompText(){
        return _prompText;
    }
    public void SetText(TextMeshProUGUI textObject, string text){
        textObject.SetText(text);
    }
}
