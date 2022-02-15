using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifetime = 2f;
    private GameManager gameManagerScript;

    void Start()
    {
        // Autodestrucción tras 2 segundos
        Destroy(gameObject, lifetime);
        gameManagerScript = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);

        if(gameObject.CompareTag("Bad"))
        {
            gameManagerScript.isGameover = true;
        }
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }
}
