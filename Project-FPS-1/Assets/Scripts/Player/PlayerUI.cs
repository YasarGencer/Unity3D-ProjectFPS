using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI prompText;

    public TextMeshProUGUI GetPrompText(){
        return prompText;
    }
    public void SetText(TextMeshProUGUI textObject, string text){
        textObject.SetText(text);
    }
}
