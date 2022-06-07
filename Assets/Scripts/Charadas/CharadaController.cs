using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharadaController : MonoBehaviour
{
    public static CharadaController instance;
    public List<Charada> charadas;

    void Awake (){
        instance = this;
    }

    void Start (){
        ActivateCharada();
    }

    public void ActivateCharada (){
        int random = Random.Range (0, charadas.Count);
        charadas[random].nextInteraction.GetCharada(charadas[random].charada);
        Inventory.instance.PopulateIventory(charadas[random].charada.texto, charadas[random].charada.charada);  
        charadas.RemoveAt(random);
    }

    public void ActivateNextCharada () {
        int random = Random.Range (0, charadas.Count);
        charadas[random].nextInteraction.GetCharada(charadas[random].charada);
        charadas.RemoveAt(random);
    }
    
}

[System.Serializable]
public class Charada {

    [SerializeField] public Item charada;
    [SerializeField] public InteractionFeedback nextInteraction;
}
