using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // En la clase que va a invocar el objeto, declaramos el objeto
    // public porque otras clases pueden acceder a esto, pero también para que aparezca en el inspect
    public GameObject bullet;
    Vector2 player_velocity; //es un tipo de objeto que es un array de 2 valores, xy

    //instanciar la clase: un objeto público del tipo soundscript, que es la clase que tiene el audio
    //con esto en la interfaz, player ya pide un soundscript, entonces ahí arrastramos el objeto con el script
    public SoundScript soundScript;

    public GameObject bullet2; //balas triples
    int tipo_balas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tipo_balas = 0; //bala regular
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direccion = (mouse_pos - transform.position);

        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0 , 0, angle);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player_velocity.y = .1f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player_velocity.y = -.1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player_velocity.x = .1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player_velocity.x = -.1f;
        }

        // si se hace el release del botón, se retira la fuerza
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            player_velocity.y = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            player_velocity.x = 0;
        }

        //acción con el objeto bullet
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //el 0 es el botón izquierdo del mouse
        {
            if (tipo_balas == 0)
            {
                //instancias(qué objeto, de dónde lo voy a instanciar, rotación del sprite (quaternion.identity no va a rotar ni modificar nada))
                //Instantiate(bullet, transform.position, Quaternion.identity);
                Instantiate(bullet, transform.position, transform.rotation);
                soundScript.PlaySonidoDisparo(); //después de disparar, sonido
            }
            else if (tipo_balas == 1)
            {
                //instancias(qué objeto, de dónde lo voy a instanciar, rotación del sprite (quaternion.identity no va a rotar ni modificar nada))
                //Instantiate(bullet, transform.position, Quaternion.identity);
                Instantiate(bullet2, transform.position, transform.rotation);
                soundScript.PlaySonidoDisparo(); //después de disparar, sonido
            }

        }


    }

    // Es para controlar la velocidad del objeto
    // Un update que Unity va a intentar arreglar
    // Es para calcular el destino final sin importar los frames
    void FixedUpdate()
    {
        //usamos el métogo getcomponent llamamos el componente rigidboy para acceder a posición
        //no recomendado para juegos que requieren pixeles precisos, como la viborita
        GetComponent<Rigidbody2D>().position += player_velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "powerup")
        {
            tipo_balas = 1;
            Destroy(collision.gameObject);
        }
    }
}
