using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    // this script handles weapon switching

    public GameObject pistol;
    public GameObject machineGun;
    public GameObject Shotgun;

    private void Update()
    {
        // when you press 1 the pistol will be active and all other weapons get disabled
        if (Input.GetKeyDown("1"))
        {
            pistol.SetActive(true);
            machineGun.SetActive(false);
            Shotgun.SetActive(false);
        }

        // when you press 2 the machine gun will be active and all other weapons get disabled
        if(Input.GetKeyDown("2"))
        {
            pistol.SetActive(false);
            machineGun.SetActive(true);
            Shotgun.SetActive(false);
        }

        // when you press 3 the Shotgun will be active and all other weapons get disabled
        if (Input.GetKeyDown("3"))
        {
            pistol.SetActive(false);
            machineGun.SetActive(false);
            Shotgun.SetActive(true);
        }
    }
    // Script Made by Shubh Malhotra
}
