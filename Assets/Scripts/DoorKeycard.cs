using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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