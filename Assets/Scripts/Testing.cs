using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public float speed;
    public float xRange;
    public float yRange;
    public GameObject Puck;
    public GameObject Pickup;
    public GameObject scoreText;
    public GameObject gameOverText;
    public GameObject highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Pickup, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

     

        //Keep Player within xRange(Left and Right sides)
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }

        //Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);



        float moveHorizontal = Input.GetAxisRaw("Horizontal");
      

        float moveVertical = Input.GetAxisRaw("Vertical");
       

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log(Input.GetAxis("Horizontal"));
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            
            Instantiate(Pickup, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            scoreText.GetComponent<Score>().scoreValue += 5;
            scoreText.GetComponent<Score>().UpdateScore();
        }     

        if (other.gameObject.CompareTag("Puck"))
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
         
        }
    }

    public void NewGame()
    {
        
        GameObject[] allPucks = GameObject.FindGameObjectsWithTag("Puck");
        foreach (GameObject dude in allPucks)
            GameObject.Destroy(dude);

        GameObject[] allPickups = GameObject.FindGameObjectsWithTag("Pickup");
        foreach (GameObject dude in allPickups)
            GameObject.Destroy(dude);

        transform.position = new Vector2(0, 0);
        Instantiate(Pickup, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        gameOverText.SetActive(false);
        Time.timeScale = 1;

        scoreText.GetComponent<Score>().scoreValue = 0;
        scoreText.GetComponent<Score>().UpdateScore();
       
    }
}
