using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCubos : MonoBehaviour
{

    public GameObject cubo;
    public GameObject elefante;
    private int gerados;
    public int zRandom = 0;
    public int xRandom = 0;
    public int quant = 1;


    // Update is called once per frame
    void Update()
    {

        if (elefante.transform.position.x > gerados * 10 - 5)
        {

            List<Vector3> posList = new List<Vector3>() ;

            for (int i = 0; i < quant; i++)
            {

                Vector3 pos = new Vector3 ((gerados + 1) * 10 + Random.Range (-5,5) * xRandom, 0 , Random.Range(-5, 6) * zRandom);
                //Vector3 pos = new Vector3();

                while (posList.Contains(pos)) {
                    pos = new Vector3((gerados + 1) * 10 + Random.Range(-5, 5) * xRandom, 0, Random.Range(-5, 6) * zRandom);
                }

                posList.Add(pos);

                GameObject objetoGerado = Instantiate(cubo, pos, Quaternion.identity, transform);
                objetoGerado.SetActive(true);
                Destroy(objetoGerado, 20);

            }

            gerados = gerados + 1;
        }

    }
}
