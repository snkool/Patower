using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio_jogo : MonoBehaviour
{
    public GameObject pato1;
    public GameObject pato2;
    public GameObject pato3;

    public GameObject enemySpawn;
    public GameObject enemyHealth;

    public GameObject Pwave_aviso;
    public GameObject Swave_aviso;
    public GameObject Twave_aviso;

    public Button botaoAdd;

    private EnemySpawner access_enemySpawn;
    private EnemyHealthController access_enemyHealth;



    public void Start()
    {
        // Desabilita os 3 patos (objetos diferentes).
        pato1.gameObject.SetActive(false);
        pato2.gameObject.SetActive(false);
        pato3.gameObject.SetActive(false);

        // Desabilita os 3 avisos de 'Primeira Wave' e etc 
        Pwave_aviso.gameObject.SetActive(false);
        Swave_aviso.gameObject.SetActive(false);
        Twave_aviso.gameObject.SetActive(false);

        // Recebe acesso as variaveis da classe EnemySpawner.
        access_enemySpawn = enemySpawn.GetComponent<EnemySpawner>();
        // Recebe acesso as variaveis da classe EnemyHealthController.
        access_enemyHealth = enemyHealth.GetComponent<EnemyHealthController>();
    }

   
    // Função responsável por verificar em qual wave o jogo está, para setar as configurações especificas de cada uma
    public void VerificaWave()
    {
        // Primeira onda
        if(access_enemySpawn.wave == 1)
        {
            Pwave_aviso.gameObject.SetActive(true); // Mostra a mensagem de 'Primeira Wave' na tela
            botaoAdd.interactable = false; // Desabilita o botão 'add_pato' 
            pato1.gameObject.SetActive(true); // Spawna o primeiro pato
            access_enemyHealth.maxHealth = 10; // Seta o HP dos inimigos com um valor especifico

            //Debug.Log("HP inimigo " + access_enemyHealth.maxHealth);
            //Debug.Log("Teste e wave " + access_enemySpawn.wave);
        }

        // Segunda onda
        if (access_enemySpawn.wave == 2)
        {
            Swave_aviso.gameObject.SetActive(true);
            botaoAdd.interactable = false;
            access_enemySpawn.passWave2 = true;
            pato2.gameObject.SetActive(true);
            access_enemyHealth.maxHealth = 20;

            //Debug.Log("HP inimigo " + access_enemyHealth.maxHealth);
            //Debug.Log("Teste e wave " + access_enemySpawn.wave);
        }

        // Terceira onda
        if (access_enemySpawn.wave == 3)
        {
            Twave_aviso.gameObject.SetActive(true);
            botaoAdd.interactable = false;
            access_enemySpawn.passWave3 = true;
            pato3.gameObject.SetActive(true);
            access_enemyHealth.maxHealth = 30;

            //Debug.Log("HP inimigo " + access_enemyHealth.maxHealth);
            //Debug.Log("Teste e wave " + access_enemySpawn.wave);
        }
    }

    public void Iniciar_Wave()
    {
        access_enemySpawn = enemySpawn.GetComponent<EnemySpawner>();
        access_enemyHealth = enemyHealth.GetComponent<EnemyHealthController>();

        access_enemySpawn.Start_game = true;

        Debug.Log("Start :" + access_enemySpawn.Start_game);
    }
}
