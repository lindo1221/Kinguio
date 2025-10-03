using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int pulo = 300;
    public float velocidade = 5;
    Rigidbody2D rg;
    Vector2 mover; // x e y
    bool ehchao = false;
    [Header("Check Chão")]
    public Transform checkChao;
    public float raioChao = 0.2f;
    public LayerMask oQueEChao;
    public bool noChao;
    public int Djump = 2;
    public bool pegado = false;
    public int points = 0;
    private DialogueSystem dialogueSystem;
    private SpriteRenderer spriteRenderer;
    public Transform npc;
    public float knock = 50;
   
    public float tempoRestante = 0.5f;
    public bool acionado = false;

   
    

    
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.OverlapCircle(checkChao.position, raioChao, oQueEChao);

        if (mover.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(mover.x), 1, 1);
        }
        timerzin();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        mover = context.ReadValue<Vector2>();
    }
    public void OnPular(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Performed && noChao || context.phase == InputActionPhase.Performed && Djump <= 1)
        {
            rg.AddForce(Vector2.up * pulo);
            Djump++;
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

            Djump = 2;
        }  
        if (collision.gameObject.CompareTag("item"))
        {
           
            points++;
            Destroy(collision.gameObject);
            pegado = true;
        
        }
        if (collision.gameObject.CompareTag("inimigo"))
        {
            velocidade = 0;
            rg.AddForce(Vector2.left * knock);
            acionado = true;
            timerzin();
         
        }
        

    }

    public void timerzin() 
    {
        if (acionado) 
        {
            if (tempoRestante > 0)
            {
                tempoRestante -= Time.deltaTime;
            }
            else
            {
                tempoRestante = 0.5f;
                GetComponent<Player>().enabled = true;
                acionado = false;
            }
        }
      
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(checkChao.position, raioChao);

    }
    private void Awake()
    {

        dialogueSystem = FindObjectOfType<DialogueSystem>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }


}