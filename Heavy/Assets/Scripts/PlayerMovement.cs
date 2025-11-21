using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public InputActionAsset InputActions;

    public float WalkSpeed = 2.5f;
    public float SprintSpeed = 8;
    private InputAction m_moveAction;
    private InputAction m_sprintAction;
    private Vector2 m_moveAmt;
    private Vector2 m_sprintAmt;
    private Rigidbody2D m_rigidbody;




    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();

    }

    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Player/Move");
        m_sprintAction = InputSystem.actions.FindAction("Player/Sprint");

        //m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();
        m_sprintAmt = m_sprintAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walking();
        //Sprinting();
    }

    private void Walking()
    {
        //m_animator.SetFloat("Speed", m_moveAmt.y);
        Vector2 newPos = m_rigidbody.position + m_moveAmt * WalkSpeed * Time.deltaTime;
        m_rigidbody.MovePosition(newPos);
    }


    private void Sprinting()
    {
        //m_animator.SetFloat("Speed", m_moveAmt.y);
        Vector2 newPos = m_rigidbody.position + m_moveAmt * SprintSpeed * Time.deltaTime;
        m_rigidbody.MovePosition(newPos);
    }


}
