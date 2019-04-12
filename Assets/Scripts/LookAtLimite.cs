using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LookAtLimite : MonoBehaviour
{
    public GameObject constraint;
    public float limHorizontal = 90f;
    public int limVert = 30;
    // Start is called before the first frame update

    private float timeCount = 0.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(constraint.transform.localEulerAngles.y));

        if (constraint.transform.localEulerAngles.x < limVert)
        {
            if (constraint.transform.localEulerAngles.y < limHorizontal || constraint.transform.localEulerAngles.y > (360 - limHorizontal))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, constraint.transform.rotation, timeCount);

                timeCount = timeCount + Time.deltaTime;
            }
        }
        else
        {

                timeCount = 0;

        }  

    }   
        
}
