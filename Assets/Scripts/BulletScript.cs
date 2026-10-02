using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector2 bullet_velocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bullet_velocity.y = .1f;
        //bullet_velocity.x = .5f;

        //para que la bala rote
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * 8f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //usamos el métogo getcomponent llamamos el componente rigidbody para acceder la posición
        //no recomendado para juegos que requieren pixeles precisos, como la viborita
        //GetComponent<Rigidbody2D>().position += bullet_velocity;
    }

    // bala colisiona con bala enemiga
    void OnTriggerEnter2D(Collider2D other) //Cuando otro collider entra en el trigger de este objeto, Unity llama sola a esta función.
    {
        if (!other.CompareTag("enemybullet")) return;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    //método para que se ejecute cuando ya nos sea visible
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
