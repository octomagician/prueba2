using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public int maxHealth = 3;
    public GameObject explosion;
    int health;
    float escala, velocidadRotacion;
    Vector2 velocidad;
    SoundScript soundScript; //así es para instanciar en unity, con el public, se lo quitamos porque lo haremos con tag
    //en vez de arrastrar mandamos a llamar directo desde código
    //vamos a buscar por el tag, entonces al objeto de soundmanager le ponemos un tag

    void Start()
    {

        //instanciar sin el public
        soundScript = GameObject.FindGameObjectWithTag("soundmanager").GetComponent<SoundScript>();

        escala = Random.Range(.08f,.4f);
        transform.localScale = new Vector3(escala, escala, escala);

        velocidad.x = 0;
        velocidad.y = Random.Range(-0.08f, -0.03f);

        velocidadRotacion = Random.Range(-120f, 120f);

        health = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;

        health -= 1;
        soundScript.PlaySonidoDisparo();
        Destroy(other.gameObject); // la bala se consume al pegar

        if (health <= 0)
            Explode();
        else
            ShowDamage();
    }

    void ShowDamage()
    {
        float t = (float)health / maxHealth; // 2/3, luego 1/3
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, t);
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameManagerScript.score++;
        int max = PlayerPrefs.GetInt("max");
        if (GameManagerScript.score > max )
        {
            PlayerPrefs.SetInt("max", GameManagerScript.score); 
        }
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        //usamos el métogo getcomponent llamamos el componente rigidbody para acceder la posición
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.position += velocidad;
        rb.MoveRotation(rb.rotation + velocidadRotacion * Time.fixedDeltaTime);
    }

    //método para que se ejecute cuando ya nos sea visible
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
