using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Cave laser movement
*/
public class CaveLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Make laser spin
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0);
    }
}
