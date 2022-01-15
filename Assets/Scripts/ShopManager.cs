using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    static private int itemsCount = 4;
    public int[,] shopItems = new int[5, itemsCount + 1];


    // Start is called before the first frame update
    void Awake()
    {
        SetUpShop();

        // Update Button UI
        //ButtonRef.GetComponent<ButtonInfo>().isOwned = true;
    }

    private bool IsItemOwned(int itemID)
    {
        if (shopItems[3, itemID] == 1)
        {
            print("Item with ID: " + itemID + " is owned");
            return true;
        }
        else
        {
            print("Item with ID: " + itemID + " is NOT owned");
            return false;
        }
    }

    public void Buy()
    {
        // Find the active button
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event")
            .GetComponent<EventSystem>().currentSelectedGameObject;

        int itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;

        if (!IsItemOwned(itemID))
        {
            // nie posiadany skin
            int itemPrice = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            if (ScoreManager.instance.GetKremowkaCollectedTotal() >= itemPrice)
            {
                // User has enough kremowka to purchase
                // Remove Kremowka amount 
                print("Purchasing item, removing " + itemPrice + " kremowka from balance");
                ScoreManager.instance.RemoveKremowka(itemPrice);

                // save that user has bought this skin
                shopItems[3, itemID] = 1; // 1 means it's owned
                string SaveId = $"id{itemID}quantity";
                PlayerPrefs.SetInt(SaveId, shopItems[3, itemID]);

                print("Item with ID: " + itemID + " was just bought");
                ButtonRef.GetComponent<ButtonInfo>().isOwned = true;
                ButtonRef.GetComponent<ButtonInfo>().CheckIfIsOwned();

                // change skin model after buying it
                ChangeSkin(ButtonRef);
            }
        }
        else
        {
            // skin jest posiadany, trzeba tylko zmienić model
            ChangeSkin(ButtonRef);
        }
    }

    private void ChangeSkin(GameObject ButtonRef)
    {
        GameObject skinModel = ButtonRef.GetComponent<ButtonInfo>().skinModel;
        PopeController.instance.ChangeSkin(skinModel);
    }


    private void LoadSkinsCollection()
    {
        print("loading skins");
        for (int i = 1; i <= itemsCount; i++)
        {
            string SaveId = $"id{i}quantity";

            if (PlayerPrefs.HasKey(SaveId))
            {
                // save with this id exists
                shopItems[3, i] = PlayerPrefs.GetInt(SaveId, shopItems[3, i]);
            }
            else
            {
                shopItems[3, i] = 0; // item not owned, because it does not exist in saves
            }

        }
    }

    private void SetUpShop()
    {
        // ID's 
        shopItems[1, 1] = 1; // default skin with id 1
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Price
        shopItems[2, 1] = 0; // default skin with id 1
        shopItems[2, 2] = 100;
        shopItems[2, 3] = 2137;
        shopItems[2, 4] = 5;

        // Quantity
        shopItems[3, 1] = 1; // default skin with id 1 is owned at the start of the game
        PlayerPrefs.SetInt("id1quantity", 1);
        LoadSkinsCollection();
    }

}
