using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AJM
{
    public class PlayerManager : MonoBehaviour
    {
        private float playerSpeed;
        private float horizontalInput;
        private float verticalInput;
        private float horizontalScreenLimit = 9.5f;
        private float verticalScreenLimit = 6.5f;
        public GameObject bulletPrefab;

        public void Start()
        {
            playerSpeed = 6f;
        }

        public void Update()
        {
            Movement();
            Shooting();
        }

        public void Movement()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

            if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
            {
                transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
            }

            float minY = -4f; // stop at the bottom of Anthony's Screen
            float maxY = 0f; // stop at halfway (0 = middle)
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY); // clamping the y transform of the player to the values I set above

            transform.position = new Vector3(transform.position.x, clampedY, 0); // updates the player on what it can do. In the same way we do in the "if" statement above
        }

        public void Shooting()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Pew Pew" + verticalScreenLimit);
                Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
        }
    }
}