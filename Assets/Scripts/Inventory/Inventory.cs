using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] Transform populateContentUI;
    [SerializeField] GameObject itemContentUIPrefab;

    [SerializeField] Image itemImage;
    bool open = false;

    void Awake (){
        instance = this;
    }

    void Start (){
        if(!open){
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update (){
        if(Input.GetButtonDown("Jump")){
            if(open){
                Cursor.lockState = CursorLockMode.Locked;
                inventoryUI.SetActive(false);
                open = false;
            }else{
                Cursor.lockState = CursorLockMode.None;
                inventoryUI.SetActive(true);
                open = true;
            }
            
        }
    }

    public void PopulateIventory (string text, Sprite image){
        GameObject instance = Instantiate(itemContentUIPrefab, populateContentUI);
        ItemContentUI contentUi = instance.GetComponent<ItemContentUI>();
        contentUi.SetText(text);

        UnityAction unityAction = null;
        unityAction += () =>
        {
            this.ShowItem(image);
        };
        contentUi.SetClick(unityAction);
    }

    void ShowItem (Sprite image) {
        itemImage.sprite = image;
    }
}
