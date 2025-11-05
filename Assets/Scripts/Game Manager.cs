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
            verticalScreenSize = 6.5f;
            score = 0;
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            CreateSky();
            InvokeRepeating("CreateEnemyOne", 1, 3);
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
            
        }

        void CreateSky()
        {
            for (int i = 0; i < 30; i++)
            {
                Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
            }

        }

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