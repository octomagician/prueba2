using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Vector2 velocity;
    int par_impar;
    float next_move_time;
    float next_bullet_spawn;
    public GameObject EnemyBullet;
    public int maxHealth = 4;
    public GameObject explosion;
    int health;
    SoundScript soundScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundScript = GameObject.FindGameObjectWithTag("soundmanager").GetComponent<SoundScript>();
        health = maxHealth;

        velocity.y = -0.01f;
        par_impar = 1;
        next_move_time = Time.time;
        next_bullet_spawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //ciclo de disparo
        if(Time.time > next_bullet_spawn)
        {
            Instantiate(EnemyBullet, transform.position, Quaternion.identity); //spawnear este prefab en la posición de la nave en
            next_bullet_spawn += Random.Range(1,3);    
        }

        //ciclo de cambio de dirección
        if(Time.time > next_move_time)
        {
            if(par_impar % 2 == 0)
            {
                velocity.x = -0.05f;
            }
            else
            {
                velocity.x = 0.05f;
            }
            par_impar += 1;
            next_move_time += 5; //cada 2 seg entre al if
        }
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

        void ShowDamage()
    {
        float t = (float)health / maxHealth; // 2/3, luego 1/3
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, t);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += velocity;
    }
        void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
