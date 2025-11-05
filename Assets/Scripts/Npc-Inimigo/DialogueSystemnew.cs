using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemnew : MonoBehaviour
{
    [Header("Configuração do NPC")]
    [TextArea(2, 5)]
    public string[] dialogueNpc;
    public string[] NameNpc;
    public Sprite npcSprite;              // Sprite do NPC
    [Header("Referências UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    [Header("Configurações")]
    public float typingSpeed = 0.05f;
    private int dialogueIndex = 0;
    private bool readyToSpeak = false;
    private bool isTalking = false;
    private Coroutine typingCoroutine;
    public bool multiFim = false;

    public GameObject simOuNao;

    public GameObject[] sumirDuranteDialogo;

    

    void Start()
    {
        dialoguePanel.SetActive(false); // começa desativado

    }

    void Update()
    {
        if (readyToSpeak && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
            {
                StartDialogue();

            }
            else
            {
                NextDialogue();

            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        dialogueIndex = 0;

        dialoguePanel.SetActive(true);
        nameText.text = NameNpc[dialogueIndex];
        for (int i = 0; i < sumirDuranteDialogo.Length; i++) 
        {
            if (sumirDuranteDialogo != null)
                sumirDuranteDialogo[i].SetActive(false);
        }

        ShowDialogue();
    }

    void NextDialogue()
    {
        if (dialogueIndex < dialogueNpc.Length - 1)
        {
            dialogueIndex++;
            ShowDialogue();
        }
        else
        {
            if (multiFim)
            {
                simOuNao.active = true;
            }
            else 
            {
                EndDialogue();
            }
           
        }
        if (dialogueIndex < NameNpc.Length)
            nameText.text = NameNpc[dialogueIndex];
        else
            nameText.text = "???";
    }

    void ShowDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        typingCoroutine = StartCoroutine(TypeSentence(dialogueNpc[dialogueIndex]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null;
    }

   public void EndDialogue()
    {       
        dialoguePanel.SetActive(false);

        if (simOuNao != null)
            simOuNao.SetActive(false);

        isTalking = false;
        dialogueIndex = 0;
        for (int i = 0; i < sumirDuranteDialogo.Length; i++)
        {
            if(sumirDuranteDialogo != null)
            sumirDuranteDialogo[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            readyToSpeak = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            readyToSpeak = false;
            if (isTalking) EndDialogue();
        }
    }
}
