using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace AJM
{
    public class GameManager : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject cloudPrefab;

        public GameObject enemyOnePrefab;
        public GameObject enemyMichaelPrefab;
        public GameObject enemyJuanPrefab;

        public TextMeshProUGUI livesText;

        public float verticalScreenSize;
        public float horizontalScreenSize;

        public int score;

        void Start()
        {
            horizontalScreenSize = 10f;
            verticalScreenSize = 8f;
            score = 0;
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            CreateSky();
            InvokeRepeating("CreateEnemyOne", 1, 3);
            InvokeRepeating("CreateEnemyJuan", 5, 7);
        }

        public void CreateEnemyOne()
        {
            Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
        }

        public void CreateEnemyMicheal()
        {
            
        }

        public void CreateEnemyJuan()
        {
            Instantiate(enemyJuanPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.7f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
        }

        void CreateSky()
        {
            for (int i = 0; i < 30; i++)
            {
                Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
            }

        }

<<<<<<< Updated upstream
=======
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
                case 5:
                    powerupText.text = "Extra Life!";
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

>>>>>>> Stashed changes
        public void AddScore(int earnedScore)
        {
            score = score + earnedScore;
        }

        public void ChangeLivesText(int currentLives)
        {
            livesText.text = "Lives: " + currentLives;
        }

    }
}