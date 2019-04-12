using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeFumaca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Random.Range (1,10) * 0.1f * Time.deltaTime, 0);

        float encolhe = Time.deltaTime;

        transform.localScale -= new Vector3(encolhe, encolhe, encolhe);
    }
}
