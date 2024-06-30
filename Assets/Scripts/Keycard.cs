using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:12/5/2024
* Description: Interactable Keycard
*/

public class Keycard : MonoBehaviour, PickUp
{


    public void Interact()
    {
        GameManager.instance.playerInventory.hasKeycard = true;
        Destroy(gameObject); // Destroy the keycard
    }
}