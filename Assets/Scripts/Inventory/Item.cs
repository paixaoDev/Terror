using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Charada", menuName = "Charadas/CharadaItem", order = 1)]
public class Item : ScriptableObject
{
    public string texto;   
    public Sprite charada;
}
