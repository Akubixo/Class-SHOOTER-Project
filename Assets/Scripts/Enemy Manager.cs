using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AJM
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject explosionPrefab;

        private GameManager gameManager;

        void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        public void Update()
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
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
