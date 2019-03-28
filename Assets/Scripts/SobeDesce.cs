using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobeDesce : MonoBehaviour
{

    private int direcao = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0.4) {
            direcao = -1;

        } else {

            if (transform.position.y < 0.2) {
                direcao = 1;
            }
        }

        transform.Translate(Vector3.up * Time.deltaTime * direcao * 0.1f);
    }
}
