using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Animal;
    private Rigidbody2D myBulet;
    [SerializeField] int damage;
    private int health;
    private float minY;
    // Start is called before the first frame update
    void Start()
    {
        myBulet = GetComponent<Rigidbody2D>();
        minY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (myBulet.position.y <= minY)
            Destroy(gameObject);
        print("Casa");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animal animal = collision.GetComponent<Animal>();


        if (collision.gameObject)
        {
            if (animal != null)
            {
                animal.hit(damage);
            }
            Destroy(gameObject);
        }

    }

}
