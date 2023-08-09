using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAndReload : MonoBehaviour
{
    // This Script Handles Ammo And Reloading

    public int MaxAmmo = 10;
    [HideInInspector]public int CurrentAmmo = 1;
    
    public AudioSource ReloadSound;

    public Transform MagezineSpawnpoint;
    
    public float ReloadTime = 1;

    public GameObject Magezine;

    private bool isReloading = false;
    public bool CanShoot;

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }

        // on input a function plays and the gun is reloaded
        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo <= 0)
        {
            StartCoroutine(ReloadTheGun());
        }

        if (CurrentAmmo < 1)
        {
            CanShoot = true;
        }

        if(CurrentAmmo <= 0)
        {
            CanShoot = false;
        }

    }
    IEnumerator ReloadTheGun()
    {
        ReloadSound.Play();
        Instantiate(Magezine, MagezineSpawnpoint.position, MagezineSpawnpoint.rotation);
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = MaxAmmo;
        CanShoot = true;
    }
    // Script Made By Shubh Malhotra
}
