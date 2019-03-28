using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{

    public float horizontalMove;
    public float verticalMove;

    private Vector3 playerInput; // captura os inputs e coloca dentro de uma variável só

    public CharacterController player;

    public float velocidade;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    private float fallVelocity;
    public float jumpForce;
    public float alegria;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //captura os controles básicos;
        GetInput();

        //detecta para onde a camera esta apontando
        camDirection();

        //recebe o input do controle e aplica na direcao da camera
        movePlayer = (playerInput.x * camRight + playerInput.z * camForward) * velocidade;

        //faz o player olhar para a direcao em que está se movendo
        player.transform.LookAt(player.transform.position + movePlayer);

        //aplica um vetor vertical de gravidade
        SetGravity();

        //aplica o pulo
        PlayerSkills();

        //aplica o movimento o movimento ao player
        player.Move(movePlayer * Time.deltaTime);


    }

    void GetInput() 
    {   

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (player.isGrounded)
        {
            playerInput = new Vector3(horizontalMove, 0, verticalMove);
        }
        else
        {
            playerInput = new Vector3(horizontalMove, 0, verticalMove * 0.2f);
        }

        // limita a velocidade na diagonal
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
    }

    void camDirection() {  //detecta para onde a camera esta apontando
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }


    void PlayerSkills() {  //captura e inputa o pulo
        if(player.isGrounded && Input.GetButtonDown("Jump")) 
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    void SetGravity() { //aplica um vetor vertical de gravidade
        
        if (player.isGrounded) {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        } else {
            fallVelocity -= gravity * Time.deltaTime; // aceleração
            movePlayer.y = fallVelocity;
        }


    }

}




