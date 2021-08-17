using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;

    private PlayerController playerController;
    private GameManager gameManager;
    private int leftBound = -15;

    private bool scored = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
         
        
        if (playerController.gameOver)
        {
            
        }
        else
        {
            var boost = 1.0f;
            if (playerController.booster)
                boost = 1.5f;
            
            transform.Translate(Vector3.left * Time.deltaTime * (speed * boost));
        }

        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Obstacle")  && transform.position.x < 0 && !scored)
        {
            Debug.Log($"Score: {++gameManager.score}");
            scored = true;
        }

    }
}
