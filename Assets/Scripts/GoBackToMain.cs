﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }
}