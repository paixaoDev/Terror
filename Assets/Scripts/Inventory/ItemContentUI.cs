using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class ItemContentUI : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Button button;

    public void SetText (string _text){
        text.text = _text;
    }

    public void SetClick (UnityAction call){
        button.onClick.AddListener(call);
    }
}
