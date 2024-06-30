using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:12/5/2024
* Description: Interactable core
*/

public class PowerCore : MonoBehaviour, PickUp
{


    public void Interact()
    {
        GameManager.instance.playerInventory.hasPower = true;
        Destroy(gameObject); // Destroy the core
    }
}