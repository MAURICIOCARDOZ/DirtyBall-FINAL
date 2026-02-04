using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento = 10f;
    //private Rigidbody rigid;
    [SerializeField] private Transform camara;
    [SerializeField] private float velocidadRotacion = 10f;
    [SerializeField] public float fuerzaSalto = 5f;
    public float gravedad = -9.81f;


    private CharacterController characterController;
    private Vector3 velocidadVertical;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (camara == null && Camera.main != null) { 
            camara = Camera.main.transform;
        }
        //rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (characterController.isGrounded && velocidadVertical.y < 0) {
            velocidadVertical.y = -2f; //Para que se mantenga en el suelo
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 adelanteCamara = camara.forward;
        Vector3 derechaCamara = camara.right;

        adelanteCamara.y = 0f;
        derechaCamara.y = 0f;

        adelanteCamara.Normalize();
        derechaCamara.Normalize();

        Vector3 direccionPlano = (derechaCamara* moveHorizontal + adelanteCamara * moveVertical);

        if (direccionPlano.sqrMagnitude > 0.001f) { 
            direccionPlano.Normalize();

            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionPlano);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }

        Vector3 movimientoXZ = direccionPlano * (velocidadMovimiento * Time.deltaTime);

        characterController.Move(movimientoXZ);

        
        //logica de salto
        if (Input.GetButtonDown("Jump") && characterController.isGrounded ) {
            velocidadVertical.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
        }
        velocidadVertical.y += gravedad * Time.deltaTime;
        characterController.Move(velocidadVertical * Time.deltaTime);
    }
}
