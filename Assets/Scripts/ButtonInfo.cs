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
    public bool isOwned = false;

    private void Start()
    {
        PriceText.text = "Cena: "
            + ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString()
            + " K";

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
