using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSmoke : MonoBehaviour
{
        
    public CharacterController player;
    public Vector3 posOriginal;
    public GameObject fumaca;
    private GameObject instantiatedFumaca;
    public Transform pointFumaca;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        posOriginal = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(posOriginal,player.transform.position) > 0.2f && player.isGrounded && player.velocity.magnitude > 2) {

            instantiatedFumaca = Instantiate(fumaca, new Vector3 (pointFumaca.transform.position.x, player.transform.position.y - 0.7f, pointFumaca.transform.position.z - 0.25f + 0.5f * Random.value),Quaternion.identity);

            instantiatedFumaca.SetActive(true);
            instantiatedFumaca.transform.Rotate(0,Random.Range(0, 360),0);

            Destroy(instantiatedFumaca, 0.8f);

            posOriginal = player.transform.position;


        }
    }
}
