using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceText;
    public GameObject ShopManager;
    public GameObject isOwnedWidget;
    public GameObject skinModel;
    public bool isOwned = false;

    private void Start()
    {
        PriceText.text = "Cena: "
            + ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString()
            + " K";

        isOwned = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID] == 1 ? true : false;
        CheckIfIsOwned();
    }

    public void CheckIfIsOwned() {
        if (isOwned)
        {
            isOwnedWidget.SetActive(true);
        }
        else
        {
            isOwnedWidget.SetActive(false);
        }
    }
}
