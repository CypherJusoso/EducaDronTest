using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover2 : MonoBehaviour
{
    public Camera playerCamera; //Camara del jugador

    //Variables de control de movimiento
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 1f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float goDownPower = -1f;
    public float crouchSpeed = 3f;

    //Dirección actual del movimiento
    private Vector3 moveDirection = Vector3.zero;

    //Acumulador para mirar arriba y abajo
    private float rotationX = 0;

    //Componente que mueve al jugador
    private CharacterController characterController;

    //Bloqueo del movimiento por si hay pausa
    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        //Cambia entre correr y caminar, si no se puede mover su velocidad es 0
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //Si el jugador apreta jump se eleva
        if (Input.GetButton("Jump") && canMove)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = 0;
        }

        //Si apretas la R, vas para abajo
        if (Input.GetKey(KeyCode.LeftControl) && canMove && !characterController.isGrounded)
        {

            moveDirection.y = goDownPower;

        }

        characterController.Move(moveDirection * Time.deltaTime);

        //Movimiento de camara
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}