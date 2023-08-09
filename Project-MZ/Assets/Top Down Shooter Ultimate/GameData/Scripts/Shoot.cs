using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // this script handles shooting and playing sounds of the gun

    public bool AutomaticWeapon;
    public bool SemiAutomaticWeapon;

    private AudioSource weaponSound;
    private Rigidbody RB;
    
    public float BulletSpeed;
    public float FireRate = 15f;
    public float NextTimeToShoot = 0.5f;

    public GameObject Bullet;
    public Transform shootPoint;

    private AmmoAndReload AmmoScript;
    
    private void Update()
    {
        AmmoScript = GetComponent<AmmoAndReload>();
        weaponSound = GetComponent<AudioSource>();

        // if the weapon can fire 1 bullet at a time then on input bullet will spawn on the shootpoint
        if (Input.GetButtonDown("Fire1") && AmmoScript.CanShoot == true && AutomaticWeapon == false && SemiAutomaticWeapon == true && Time.time >= NextTimeToShoot)
        {
            // One Bullet will be subtracted on input
            AmmoScript.CurrentAmmo--;

            // adds a gap between a bullet fired
            NextTimeToShoot = 0.69f;
            NextTimeToShoot = 1 / FireRate + Time.time;

            GameObject bullet = Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
            RB = bullet.GetComponent<Rigidbody>();
            RB.AddForce(shootPoint.forward * BulletSpeed, ForceMode.Impulse);
            // Play weapon sound from the audio source on the gun
            weaponSound.Play();
        }

        // if the weapon can fire many bullets at smae time then on input bullet will spawn on the shootpoint
        if (Input.GetButton("Fire1") && AmmoScript.CanShoot == true && AutomaticWeapon == true && SemiAutomaticWeapon == false && Time.time >= NextTimeToShoot)
        {
            // One Bullet will be subtracted on input
            AmmoScript.CurrentAmmo--;

            // adds a gap between a bullet fired
            NextTimeToShoot = 3f;
            NextTimeToShoot = 1 / FireRate + Time.time;
            
            GameObject bullet = Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
            RB = bullet.GetComponent<Rigidbody>();
            RB.AddForce(shootPoint.forward * BulletSpeed, ForceMode.Impulse);
            // Play weapon sound from the audio source on the gun
            weaponSound.Play();
        }
    }
    
    // Script Made by Shubh Malhotra
}