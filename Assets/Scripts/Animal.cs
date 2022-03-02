using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    Rigidbody2D myBody;
    SpriteRenderer spriteRenderer;
    [SerializeField] float velocidad;
    [SerializeField] int health;
    float minX, maxX, maxY, minY;
    float halfWidth;

    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        Vector2 minIzquierda = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = minIzquierda.x;
        Vector2 maxDerecha = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = maxDerecha.x;
        halfWidth = spriteRenderer.size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 1. definir limites
        //2. Cambiar velocidad cuando llegue al borde
        if (myBody.position.x + halfWidth >= maxX || myBody.position.x - halfWidth < minX)
            velocidad *= -1;

        myBody.velocity = new Vector2(velocidad, myBody.velocity.y);

    }
    public void hit(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
   
}
    