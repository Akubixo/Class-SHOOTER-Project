using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace AJM
{
    public class GameManager : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject cloudPrefab;

        public GameObject enemyOnePrefab;
        public GameObject enemyMichaelPrefab;
        public GameObject enemyJuanPrefab;

        public GameObject gameOverText;
        public GameObject restartText;
        public GameObject powerupPrefab;
        public GameObject coinPrefab;
        public GameObject heartPrefab;
        public GameObject audioPlayer;

        public AudioClip powerupSound;
        public AudioClip powerdownSound;

        public TextMeshProUGUI livesText;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI powerupText;

        public float verticalScreenSize;
        public float horizontalScreenSize;

        public int score;
        public int cloudMove;

        private bool gameOver;

        void Start()
        {
            horizontalScreenSize = 10f;
            verticalScreenSize = 8f;
            score = 0;
            cloudMove = 1;
            gameOver = false;
            AddScore(0);
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            CreateSky();
            InvokeRepeating("CreateEnemyOne", 1, 3);
            InvokeRepeating("CreateEnemyJuan", 5, 7);
            InvokeRepeating("CreateEnemyMichael", 2, 6);
            StartCoroutine(SpawnPowerup());
            StartCoroutine(SpawnCoin());
            StartCoroutine(SpawnHeartPowerup());
            powerupText.text = "No powerups yet!";
        }

        void Update()
        {
            if (gameOver && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void CreateEnemyOne()
        {
            Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
        }

        public void CreateEnemyMichael()
        {
            Instantiate(enemyMichaelPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.6f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
        }

        public void CreateEnemyJuan()
        {
            Instantiate(enemyJuanPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.7f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
        }

        void CreatePowerup()
        {
            Instantiate(powerupPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.7f, verticalScreenSize * 0.1f), 0), Quaternion.identity);
        }

        void CreateCoin()
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.6f, verticalScreenSize * 0.1f), 0), Quaternion.identity);
        }

        void CreateHeartPowerup()
        {
            Instantiate(heartPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.6f, verticalScreenSize * 0.1f), 0), Quaternion.identity);
        }

        void CreateSky()
        {
            for (int i = 0; i < 30; i++)
            {
                Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
            }

        }

        public void ManagePowerupText(int powerupType)
        {
            switch (powerupType)
            {
                case 1:
                    powerupText.text = "Speed!";
                    break;
                case 2:
                    powerupText.text = "Double Weapon!";
                    break;
                case 3:
                    powerupText.text = "Triple Weapon!";
                    break;
                case 4:
                    powerupText.text = "Shield!";
                    break;
                default:
                    powerupText.text = "No powerups yet!";
                    break;
            }
        }

        IEnumerator SpawnPowerup()
        {
            float spawnTime = Random.Range(3, 5);
            yield return new WaitForSeconds(spawnTime);
            CreatePowerup();
            StartCoroutine(SpawnPowerup());
        }

        IEnumerator SpawnCoin()
        {
            float spawnTime = Random.Range(3, 5);
            yield return new WaitForSeconds(spawnTime);
            CreateCoin();
            StartCoroutine(SpawnCoin());
        }

        IEnumerator SpawnHeartPowerup()
        {
            float spawnTime = Random.Range(3, 5);
            yield return new WaitForSeconds(spawnTime);
            CreateHeartPowerup();
            StartCoroutine(SpawnHeartPowerup());
        }

        public void PlaySound(int whichSound)
        {
            switch (whichSound)
            {
                case 1:
                    audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerupSound);
                    break;
                case 2:
                    audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerdownSound);
                    break;
            }
        }

        public void AddScore(int earnedScore)
        {
            score = score + earnedScore;
            scoreText.text = "Score: " + score;
        }

        public void ChangeLivesText(int currentLives)
        {
            livesText.text = "Lives: " + currentLives;
        }

        public void GameOver()
        {
            gameOverText.SetActive(true);
            restartText.SetActive(true);
            gameOver = true;
            CancelInvoke();
            cloudMove = 0;
        }
    }
}