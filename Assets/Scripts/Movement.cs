using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]   //для работы требуется компонент физ.тело

public class Movement : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0.1f, 100f)]
    [SerializeField] float speed = 0.1f;
    [Range(0.1f, 100f)]
    [SerializeField] float jumpForce = 0.1f;

    [Header("Links")]
    [SerializeField] FollowCam cameraControl;

    Rigidbody rb;

    float movementX = 0;
    float movementY = 0;

    bool onFloor = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //получение ссылки на объект Rigidbody
        Debug.Log("Игра началась");
    }

    private void OnMove(InputValue movementValue)               //событие ввода движения от Input System
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  //получение параметров события в виде двумерного вектора

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump()
    {
        if (onFloor)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnLook (InputValue lookValue)                          //событие вводе, отвечающее за перемещение мыши
    {
        float horizontalRotation = lookValue.Get<Vector2>().x;
        cameraControl.rotate(horizontalRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            onFloor = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            onFloor = false;
    }

    // Update is called once per frame
    void FixedUpdate()  //функции основанные на физике
    {
        Vector3 movement = cameraControl.getDirection (new Vector3(movementX, 0.0f, movementY)).normalized;
        rb.AddForce(movement * speed);

        cameraControl.follow();
    }
}
