using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMusic : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

    }
}
