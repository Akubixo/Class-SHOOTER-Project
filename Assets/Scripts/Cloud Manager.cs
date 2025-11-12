using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AJM
{
    public class CloudManager : MonoBehaviour
    {
        private float cloudSpeed;

        private GameManager gameManager;

        void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            transform.localScale = transform.localScale * Random.Range(0.1f, 0.6f);
            transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Random.Range(0.1f, 0.7f));
            cloudSpeed = Random.Range(3f, 7f) * gameManager.cloudMove;
        }

        void Update()
        {
            cloudSpeed = cloudSpeed * gameManager.cloudMove;

            transform.Translate(Vector3.down * cloudSpeed * Time.deltaTime);

            if (transform.position.y < -gameManager.verticalScreenSize)
            {
                transform.position = new Vector3(Random.Range(-gameManager.horizontalScreenSize, gameManager.horizontalScreenSize), gameManager.verticalScreenSize * 1.2f, 0);
            }
        }
    }
}