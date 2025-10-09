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

    private DialogueSystemnew dialogueSystem;
    private SpriteRenderer spriteRenderer;
    public Transform npc;
    public float knock = 50;

    public float tempoRestante = 0.5f;
    public bool acionado = false;

    public bool podeEntrar = false;
    public GameObject icone;


    public bool naAgua = false;
    public Respiracao respirar;
    public GameObject painel;

    public BoxCollider2D ataque;
    public float tim = 0.05f;
    public bool atacou = false;
    public GameObject boxAtaque;
    public float cooldown = 0.5f;
    public bool estaemcool = true;



    public void ataqueTime()
    {
        if (atacou)
        {
            tim -= Time.deltaTime;
        }
        if (estaemcool) 
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0)
        {
            estaemcool = false;
            cooldown = 0.5f;
        }
        if (tim <= 0)
        {
            ataque.size = new Vector2(0, 1);
            atacou = false;
            tim = 0.05f;
            boxAtaque.SetActive(false);
        }
    }
    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && estaemcool == false)
        {
            boxAtaque.SetActive(true);
            ataque.size = new Vector2(2, 1);
            atacou = true;
            estaemcool = true;
        }
    }
    void Start()
    {
        icone.SetActive(false);
        boxAtaque.SetActive(false);
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
        ataqueTime();

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
    public void OnEntrar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && podeEntrar)
        {
            SceneManager.LoadScene("Cabana");
            podeEntrar = false;
        }

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


        }
        if (collision.gameObject.CompareTag("sair"))
        {
            SceneManager.LoadScene("SampleScene");
        }


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("entrar"))
        {
            icone.SetActive(true);
            podeEntrar = true;
        }       
        if (collision.gameObject.CompareTag("agua"))
        {
           
            painel.SetActive(true);
            rg.drag = 0.4f;
            respirar.semAr = true;
            naAgua = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("agua"))
        {
            respirar.ar = respirar.arMaximo;
            painel.SetActive(false);
            respirar.semAr = false;
            naAgua = false;
            respirar.tempoMortal = 3f;
            respirar.temposem = 3f;

        }
        if (collision.gameObject.CompareTag("entrar"))
        {
            icone.SetActive(false);
            podeEntrar = false;
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

        dialogueSystem = FindObjectOfType<DialogueSystemnew>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }


}