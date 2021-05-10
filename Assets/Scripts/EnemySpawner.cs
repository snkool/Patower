using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPoint;
    private int contadorTotal;
    [SerializeField] private int contador;
    [SerializeField] private int contador_1wave;
    [SerializeField] private int contador_2wave;
    [SerializeField] private int contador_3wave;
    [SerializeField] private float timer;
    public bool Start_game = false;
    public bool passWave2 = false;
    public bool passWave3 = false;
    public int wave = 1;
    public TextMeshProUGUI text_wave;

    private Inicio_jogo access_inicioJogo;

    public Button botaoAdd;
    public GameObject vitoria_aviso;

    // Chama a função para iniciar o spawn dos inimigos mas apenas se o valor de Start_game = True
    public void Start()
    {
        // Aviso de 'Vitória!'
        vitoria_aviso.gameObject.SetActive(false);

        if (Start_game)
        {
            StartCoroutine(TimeSpawner()); // Função que spawna os inimigos

            TextMeshPro text_wave = GetComponent<TextMeshPro>(); // Define a váriavel da Wave atual que aparece no placar 
        }
        else
        {
            Debug.Log("Start Spawner = false");
        }

    }

    // Função responsável por spawnar os inimigos em cada Wave, 3 waves no total
    public IEnumerator TimeSpawner()
    {
        // Primeira onda
        if (wave == 1)
        {
            text_wave.SetText("" + wave); // Seta o valor da wave no placar
            yield return new WaitForSeconds(3); 
            while (contador < contador_1wave) // Loop para instanciar os objetos dos inimigos
            {
                SpawnEnemy();
                contador++;
                Debug.Log(contador);
                yield return new WaitForSeconds(timer);

            }
            wave++; // Após terminar o loop adicionar +1 na váriavel wave
            contador = 0; 
            Start_game = false; // Deixa o Start_game como false, para não iniciar a próxima wave automaticamente
            //Debug.Log("wave " + wave);
            //Debug.Log("contador" + contador);
            botaoAdd.interactable = true; // O botão 'add_pato' fica ativo novamente
            Start(); // Inicia o código novamente
        }

        // Segunda onda
        if (wave == 2)
        {
            text_wave.SetText("" + wave);
            if (passWave2 == true)
            {
                yield return new WaitForSeconds(3);
                while (contador < contador_2wave)
                {
                    SpawnEnemy();
                    contador++;
                    Debug.Log(contador);
                    yield return new WaitForSeconds(timer);
                }
                wave++;
                contador = 0;
                Start_game = false;
                //Debug.Log("wave " + wave);
                //Debug.Log("contador" + contador);
                yield return new WaitForSeconds(10);
                botaoAdd.interactable = true;
                Start();
            }
        }

        // Terceira onda
        if (wave == 3)
        {
            text_wave.SetText("" + wave);
            if(passWave3 == true)
            {
                yield return new WaitForSeconds(3);
                while (contador < contador_3wave)
                {
                    SpawnEnemy();
                    contador++;
                    Debug.Log(contador);
                    yield return new WaitForSeconds(timer);
                }
                wave = 0;
                contador = 0;
                //Debug.Log("wave " + wave);
                //Debug.Log("contador" + contador);
                yield return new WaitForSeconds(14);
                vitoria_aviso.gameObject.SetActive(true);
                yield return new WaitForSeconds(4);
                // Após a vitória, a cena é resetada, começando o jogo novamente
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Função responsável por spawnar o inimigo na posição correta definida pelo objeto 'SpawnPoint'
    void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        newEnemy.transform.parent = transform;
    }
}
