using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bigBullet;
    [SerializeField] float timeBigShot;
    [SerializeField] float fireRate;
    SpriteRenderer spriteRenderer;
    private float halfWidth, halfHeight;
    private float minX, maxX, maxY, minY;
    private float timePressStarted, timePressFinished, nextFire;
    private int tipeShoot;

    void Start()
    {

        Vector2 minIzquierda = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = minIzquierda.x;
        minY = minIzquierda.y;
        Vector2 maxDerecha = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = maxDerecha.x;
        maxY = maxDerecha.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.size.x / 2;
        halfHeight = spriteRenderer.size.y / 2;
        nextFire = 0f;
        tipeShoot = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(dirH * speed * Time.deltaTime, dirV * speed * Time.deltaTime));

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX + halfWidth, maxX - halfWidth), Mathf.Clamp(transform.position.y, minY + halfHeight, maxY - halfHeight));

        if (Input.GetKeyUp(KeyCode.Q))
        {
            tipeShoot *= -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timePressStarted = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            timePressFinished = Time.time;
            if (tipeShoot == 1 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bullet, transform.position, transform.rotation);
            }
            if (tipeShoot == -1)
            {
                if (timePressFinished - timePressStarted > timeBigShot)
                {
                    Instantiate(bigBullet, transform.position, transform.rotation);
                }
            }

        }

    }
}
