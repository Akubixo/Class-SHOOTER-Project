using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AJM
{
    public class MainMenuManager : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }

        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}