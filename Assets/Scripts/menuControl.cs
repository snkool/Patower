using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuControl : MonoBehaviour
{
    public string nomeCena;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
