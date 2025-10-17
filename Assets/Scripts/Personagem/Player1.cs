using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int pulo = 350;
    public float velocidade = 5;
    public Rigidbody2D rg;
    Vector2 mover; // x e y
    bool ehchao = false;
    [Header("Check Chão")]
    public Transform checkChao;
    public float raioChao = 0.2f;
    public LayerMask oQueEChao;
    public bool noChao;
    public bool Djump = true;

    public bool pegado = false;
    public int points = 0;

    private DialogueSystemnew dialogueSystem;
    private SpriteRenderer spriteRenderer;

    public bool naAgua = false;
    public HeartSystem heartSystem;

    public Knock knock;
    public Transform transform1;
    public float KnockForce = 50;

    public BoxCollider2D box;


    [SerializeField] public Animator animator;
   
    void Start()
    {
       
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.OverlapCircle(checkChao.position, raioChao, oQueEChao);

        if (mover.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(mover.x), 1, 1);
        }
        if (mover.x != 0) animator.SetBool("IsRunning", true);

        else animator.SetBool("IsRunning", false);


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        mover = context.ReadValue<Vector2>();
       

    }
    public void OnPular(InputAction.CallbackContext context)
    {
        animator.SetBool("IsJump", true);
        if (context.phase == InputActionPhase.Performed && noChao)
        {
            
            rg.AddForce(Vector2.up * pulo);
            Djump = true;
        }
        else if(context.phase == InputActionPhase.Performed && Djump)
        {
            rg.velocity = Vector2.zero;
            rg.AddForce(Vector2.up * pulo);
            Djump = false;
        }
        if (context.phase == InputActionPhase.Performed && naAgua)
        {
            int nado = 100;
            rg.AddForce(Vector2.up * nado);

        }
    }

    void FixedUpdate()
    {

        rg.velocity = new Vector2(mover.x * velocidade, rg.velocity.y);
    }
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            animator.SetBool("IsJump", false);
            Djump = true;
        }
        if (collision.gameObject.CompareTag("item"))
        {

            points++;
            Destroy(collision.gameObject);
            pegado = true;

        }
     
        if (collision.gameObject.CompareTag("sair"))
        {
            SceneManager.LoadScene("SampleScene");
        }


    }
   
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(checkChao.position, raioChao);
    }
    private void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystemnew>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


}