using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*
* Author:Rayn Bin Kamaludin
* Date:12/5/2024
* Description: Player interact script
*/


interface PickUp
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    // Interactable object conditions
    public Transform InteractorSource;
    public float InteractRange; // How far interactable range is



    void OnInteract()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out PickUp interactObj))
            {
                interactObj.Interact();
            }
        }
    }


    // Update is called once per frame
    void Update() //Create a ray from the camera to the interactable object
    {
        
    }
}