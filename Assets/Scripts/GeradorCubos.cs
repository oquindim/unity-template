using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCubos : MonoBehaviour
{

    public GameObject cubo; // objeto a ser clonado
    public GameObject elefante;
    private int gerados; // esse é privado, para ir deslocando a posição a cada vez que gera um novo
    public int zRandom = 0; // colocar 1 se precisar ser randômico, e 0 se não precisar
    public int xRandom = 0; // colocar 1 se precisar ser randômico, e 0 se não precisar
    public int quant = 1; // número de cópias. se não tiver randômico, ele vai colocar sempre no mesmo lugar


    // Update is called once per frame
    void Update()
    {

        if (elefante.transform.position.x > gerados * 10 - 5) // checando se andou um "tile" grande do chão
        {

            List<Vector3> posList = new List<Vector3>() ; // essa lista é pra checar o que já foi gerado e não ter random duplicado no mesmo lugar

            for (int i = 0; i < quant; i++)
            {

                Vector3 pos = new Vector3 ((gerados + 1) * 10 + Random.Range (-5,5) * xRandom, 0 , Random.Range(-5, 6) * zRandom);

                while (posList.Contains(pos)) {
                    pos = new Vector3((gerados + 1) * 10 + Random.Range(-5, 5) * xRandom, 0, Random.Range(-5, 6) * zRandom); // checando se o random deu repetido
                }

                posList.Add(pos); // poe na lista de já gerados

                GameObject objetoGerado = Instantiate(cubo, pos, Quaternion.identity, transform);

                objetoGerado.SetActive(true);

                Destroy(objetoGerado, 20);

            }

            gerados = gerados + 1;
        }

    }
}
