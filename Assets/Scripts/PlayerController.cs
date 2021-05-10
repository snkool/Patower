using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject projetil;
    public List<Collider2D> listaContador = new List<Collider2D>();
    public TextMeshProUGUI text_pontos;
    protected static int count = 0;

    private void Start()
    {
        TextMeshPro text_pontos = GetComponent<TextMeshPro>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Cada vez que a bomba colidir com o inimigo o placar aumenta
        if (other.gameObject.tag == "Enemy")
        {
            count++;
            
            text_pontos.SetText("" + count * 350); // Atualiza o valor dos pontos no placar
            //Debug.Log("teste " + count);
        }
        

        if (other.gameObject.CompareTag("Enemy"))
        {
            var newProjectile = Instantiate(projetil, transform.position, Quaternion.identity);
            newProjectile.GetComponent<ProjectileController>().target = other.gameObject;
        }
    }

    public static int getInstanceCount()
    {
        Debug.Log("teste " + count);
        return count;
    }
}
