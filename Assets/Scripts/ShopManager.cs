using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];


    // Start is called before the first frame update
    void Start()
    {
        // ID's 
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 100;
        shopItems[2, 3] = 100;
        shopItems[2, 4] = 2137;

        // Qantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    private bool IsItemOwned()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event")
            .GetComponent<EventSystem>().currentSelectedGameObject;

        int itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;

        if (shopItems[3, itemID] == 1)
        {
            print("Item with ID: " + itemID + " is owned");
            return true;
        }
        else
        {
            shopItems[3, itemID] = 1;
            print("Item with ID: " + itemID + " is NOT owned");
            return false;
        }
    }

    public void Buy()
    {
        if (!IsItemOwned())
        {
            // nie posiadany skin
            GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event")
             .GetComponent<EventSystem>().currentSelectedGameObject;

            int itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;
            int itemPrice = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            if (ScoreManager.instance.GetKremowkaCollectedTotal() >= itemPrice)
            {
                // User has enough kremowka to purchase
                // Remove Kremowka amount 
                print("Purchasing item, removing " + itemPrice + " kremowka from balance");
                ScoreManager.instance.RemoveKremowka(itemPrice);

                // save that user has bought this skin
                shopItems[3, itemID] = 1; // 1 means it's owned
                print("Item with ID: " + itemID + " is owned");
                ButtonRef.GetComponent<ButtonInfo>().isOwned = true;
                ButtonRef.GetComponent<ButtonInfo>().CheckIfIsOwned();
            }
        }
        else
        { 
        // skin jest posiadany, trzeba tylko zmienić model
        }
    }
}
