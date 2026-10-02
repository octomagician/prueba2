using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5); //el metodo de destroy es sobrecargado entonces en 2ndo parámetro puedes poner los segundos, se tarda # tiempo en ejecutarse.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
