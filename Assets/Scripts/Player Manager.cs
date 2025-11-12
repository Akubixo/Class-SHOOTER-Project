using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AJM
{
    public class PlayerManager : MonoBehaviour
    {
        private GameManager gameManager;

        public int lives;
        private float playerSpeed;
        private int weaponType;

        private float horizontalInput;
        private float verticalInput;

        private float horizontalScreenLimit = 9.5f;

        public GameObject bulletPrefab;
        public GameObject explosionPrefab;
        public GameObject thrusterPrefab;
        public GameObject shieldPrefab;

        public void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            lives = 3;
            playerSpeed = 6.0f;
            weaponType = 1;
            gameManager.ChangeLivesText(lives);
        }

        public void Update()
        {
            Movement();
            Shooting();
        }

        public void LoseALife()
        {
            //lives = lives - 1;
            //lives -= 1;
            lives--;
            gameManager.ChangeLivesText(lives);
            if (lives == 0)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                gameManager.GameOver();
                Destroy(this.gameObject);
            }
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
                switch (weaponType)
                {
                    case 1:
                        Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
                        Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 45));
                        Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.Euler(0, 0, -45));
                        break;
                }
            }
        }

        IEnumerator SpeedPowerDown()
        {
            yield return new WaitForSeconds(3f);
            playerSpeed = 5f;
            thrusterPrefab.SetActive(false);
            gameManager.ManagePowerupText(0);
            gameManager.PlaySound(2);
        }

        IEnumerator WeaponPowerDown()
        {
            yield return new WaitForSeconds(3f);
            weaponType = 1;
            gameManager.ManagePowerupText(0);
            gameManager.PlaySound(2);
        }

        private void OnTriggerEnter2D(Collider2D whatDidIHit)
        {
            if (whatDidIHit.tag == "Powerup")
            {
                Destroy(whatDidIHit.gameObject);
                int whichPowerup = Random.Range(1, 5);
                gameManager.PlaySound(1);
                switch (whichPowerup)
                {
                    case 1:
                        //Picked up speed
                        playerSpeed = 10f;
                        StartCoroutine(SpeedPowerDown());
                        thrusterPrefab.SetActive(true);
                        gameManager.ManagePowerupText(1);
                        break;
                    case 2:
                        weaponType = 2; //Picked up double weapon
                        StartCoroutine(WeaponPowerDown());
                        gameManager.ManagePowerupText(2);
                        break;
                    case 3:
                        weaponType = 3; //Picked up triple weapon
                        StartCoroutine(WeaponPowerDown());
                        gameManager.ManagePowerupText(3);
                        break;
                    case 4:
                        //Picked up shield
                        //Do I already have a shield?
                        //If yes: do nothing
                        //If not: activate the shield's visibility
                        gameManager.ManagePowerupText(4);
                        break;
                }
            }
        }
    }
}