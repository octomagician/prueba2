using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static int score;
    public GameObject asteroid;
    public GameObject enemy;
    public GameObject powerup;
    float next_time_spawn;
    float next_time_spawn_powerup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;

        next_time_spawn_powerup = Time.time + Random.Range(10,20); 
        Instantiate(powerup, new Vector2 (Random.Range(-7,7), Random.Range(-4,4)), Quaternion.identity);

        if (!PlayerPrefs.HasKey("max")) //player prefs es la clase de los archivos persistentes
        {
            PlayerPrefs.SetInt("max", 0);
        }

        if (Time.time < next_time_spawn_powerup)
        {
            next_time_spawn_powerup += Random.Range(5, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_time_spawn)
        {
            Instantiate(asteroid, new Vector2(Random.Range(-7,7), 10), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(-7,7), 10), Quaternion.identity);
            next_time_spawn += 2;
        }
    }
}
