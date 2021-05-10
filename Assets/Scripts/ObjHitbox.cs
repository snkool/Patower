using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjHitbox : MonoBehaviour
{
    // Script responsável por mostrar o hitbox do pato 

    // Deixa a opacidade zerada 
    private void Start()
    {
        this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // Ao passar o mouse em cima aumenta a opacidade
    void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
    }

    // Tirando o mouse zera a opacidade 
    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

}
