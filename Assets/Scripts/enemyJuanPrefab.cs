using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AJM
{
    public class enemyJuanPrefab : MonoBehaviour
    {
        public GameObject explosionPrefab;

        private GameManager gameManager;

        //variables for direction and speed
        int direction = 1;
        float directionY = -0.5f;
        float speed = 6f;

        void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        public void Update()
        {
            transform.Translate(new Vector3(direction, directionY, 0) * Time.deltaTime * speed);
            if (transform.position.x > 8.5f || transform.position.x < -8.5f)
            {
                direction *= -1;
            }

            if (transform.position.y < -6.5f)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D whatDidIHit)
        {
            if (whatDidIHit.tag == "Player")
            {
                whatDidIHit.GetComponent<PlayerManager>().LoseALife();
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else if (whatDidIHit.tag == "Weapons")
            {
                Destroy(whatDidIHit.gameObject);
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                gameManager.AddScore(5);
                Destroy(this.gameObject);
            }
        }
    }
}
