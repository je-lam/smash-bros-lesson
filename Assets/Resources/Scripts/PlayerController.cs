using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    public ParticleSystem dust;



    [Header("Player Settings")]
    public int Speed = 5;
    public int JumpForce = 240; //original was 3

    [Header("Ground Checking")]
    public LayerMask GroundLayer = 0;

    private Rigidbody2D m_rigidbody;
    [HideInInspector] public Vector2 m_horizontalMovement;
    [HideInInspector] public bool m_grounded;
    //////////////////////////////////////////////////////////////////////////////////////Mario's code
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        m_horizontalMovement.x = Input.GetAxis("Horizontal");
        m_rigidbody.velocity = new Vector2(m_horizontalMovement.x * Speed, m_rigidbody.velocity.y); //gravity

        m_grounded = Physics2D.OverlapCircle(transform.position + new Vector3(0, -0.5f, 0), .1f, GroundLayer);

        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && m_grounded)
        {
            CreateDust();
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, JumpForce*3);
            
        }
    }

    void CreateDust()
    {
        dust.Play();
    }

    public void DieBottom()
    {
        print("Mario fell to his death! Skill issue!");
    }

    public void Die()
    {

    }
}
