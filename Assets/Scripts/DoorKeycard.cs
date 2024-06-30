using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Door that opens only when player has keycard
*/
public class DoorKeycard : MonoBehaviour, PickUp
{
    public Animator DoorAnim;

    void Start()
    {
        DoorAnim.SetBool("Open", false); // Start closed
    }

    public void Interact()
    {
        if (GameManager.instance.playerInventory.hasKeycard)
        {
            DoorAnim.SetBool("Open", true); // Open the door
        }
    }
}