using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
* Author:Rayn Bin Kamaludin
* Date:12/6/2024
* Description: Check player inventory status
*/


public class InventoryUIUpdater : MonoBehaviour
{
    public PlayerInventory playerInventory; // Reference to the PlayerInventory script

    public TextMeshProUGUI keycardText; // Reference to the TextMeshProUGUI component for the keycard
    public TextMeshProUGUI powerText; // Reference to the TextMeshProUGUI component for the powercore
    public TextMeshProUGUI hullText; // Reference to the TextMeshProUGUI component for the hull
    public TextMeshProUGUI engineText; // Reference to the TextMeshProUGUI component for the engine

    private static Singleton instance;



    // Update is called once per frame
    void Update()
    {
        if (playerInventory.hasKeycard)
        {
            keycardText.color = Color.green;
        }
        else
        {
            keycardText.color = Color.red;
        }

        if (playerInventory.hasPower)
        {
            powerText.color = Color.green;
        }
        else
        {
            powerText.color = Color.red;
        }

        if (playerInventory.hasHull)
        {
            hullText.color = Color.green;
        }
        else
        {
            hullText.color = Color.red;
        }

        if (playerInventory.hasEngine)
        {
            engineText.color = Color.green;
        }
        else
        {
            engineText.color = Color.red;
        }
    }
}
