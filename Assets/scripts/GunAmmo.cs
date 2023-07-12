using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAmmo : MonoBehaviour
{
    public int bullets = 30;
    public int maxBullets = 30;
    public int ammo = 90;
    public int kill = 0;

    public float range = 90;
    public float timeToShoot = 0.1f;
    public float timeToReload = 3f;
    public Text bulletText;
    public Text killText;
    public Text ammoText;

    bool canShoot;
    bool reloading;

    float initialTimeToShoot;
    float initialTimeToReload;

    public float damage = 30f; // Declaração da variável damage

    void Start()
    {
        initialTimeToShoot = timeToShoot;
        initialTimeToReload = timeToReload;
    }

    void Update()
    {
        bulletText.text = bullets.ToString();
        ammoText.text = ammo.ToString();
        killText.text = kill.ToString();

        if (Input.GetKey(KeyCode.Mouse0) && canShoot && !reloading && (bullets > 0 || ammo > 0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    inimigo enemy = hit.transform.GetComponent<inimigo>();
                    if (enemy != null)
                    {
                        enemy.Damage(damage);
                    }
                }
            }
            bullets--;
            canShoot = false;
        }

        if (!canShoot)
        {
            timeToShoot -= Time.deltaTime;

            if (timeToShoot <= 0)
            {
                timeToShoot = initialTimeToShoot;
                canShoot = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && bullets < maxBullets && ammo >= 0)
        {
            reloading = true;
            canShoot = false;
        }

        if (reloading)
        {
            timeToReload -= Time.deltaTime;
            if (timeToReload <= 0)
            {
                int currentNeed = maxBullets - bullets;
                if (currentNeed > ammo)
                {
                    bullets += ammo;
                    ammo = 0;
                }
                else
                {
                    bullets += currentNeed;
                    ammo -= currentNeed;
                }
                timeToReload = initialTimeToReload;
                reloading = false;
                canShoot = true;
            }
        }

        if (bullets <= 0 && !reloading)
        {
            reloading = true;
            canShoot = false;

            int bulletsToAdd = maxBullets - bullets;
            int ammoToAdd = 0;

            if (bulletsToAdd > bullets)
            {
                ammoToAdd = Mathf.Min(ammo, bulletsToAdd);
            }

            bullets += ammoToAdd;
            ammo -= ammoToAdd;

            timeToReload = initialTimeToReload;
            reloading = false;
            canShoot = true;
        }
    }
}
