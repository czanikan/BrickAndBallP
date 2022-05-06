using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public int ammoAmount = 50;
    public int currentAmmo = 0;
    public float speed = 10f;

    Vector3 shootDirection;
    bool round = false;

    void Start()
    {
        currentAmmo = ammoAmount;
        round = true;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && round)
        {
            round = false;
            StartCoroutine(Shoot());
        }
        if (round)
        {
            Debug.DrawLine(shootDirection + transform.position, transform.position);

            shootDirection = Input.mousePosition;
            shootDirection.z = 0;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);

            shootDirection = shootDirection - transform.position;
        }

        if(transform.childCount <= 0 && !round)
        {
            round = true;
            currentAmmo = ammoAmount;
        }
    }

    IEnumerator Shoot()
    {
        for(int i = 0; i < ammoAmount; i++)
        {
            GameObject Bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            Vector2 force = new Vector2(shootDirection.x, shootDirection.y).normalized * 3 * speed;
            Bullet.GetComponent<Rigidbody2D>().velocity = force;
            currentAmmo--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
