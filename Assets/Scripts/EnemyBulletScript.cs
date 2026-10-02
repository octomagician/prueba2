using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    Vector2 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity.y = -0.08f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += velocity;
    }

    // bala colisiona con bala
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
