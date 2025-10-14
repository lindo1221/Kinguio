using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abelha : MonoBehaviour
{
    [Header("Área de voo (arraste um GameObject com BoxCollider2D ou defina manualmente)")]
    public BoxCollider2D flyArea;

    [Header("Velocidades")]
    public float horizontalSpeed = 2f;
    

    [Header("Opções")]
    public bool useRigidbody = true;
    public bool visualizeArea = true;

    private Rigidbody2D rb;
    private float direction = 1f;

    private float leftBound, rightBound, minY, maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (flyArea != null)
        {
            Bounds b = flyArea.bounds;
            leftBound = b.min.x;
            rightBound = b.max.x;
            minY = b.min.y;
            maxY = b.max.y;
        }
        else
        {
            Debug.LogWarning("⚠️ Nenhuma área de voo atribuída! Defina uma BoxCollider2D em 'flyArea'.");
            // Valores padrão
            leftBound = transform.position.x - 3f;
            rightBound = transform.position.x + 3f;
            minY = transform.position.y - 1f;
            maxY = transform.position.y + 1f;
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal
        float newX = transform.position.x + direction * horizontalSpeed * Time.fixedDeltaTime;
        if (newX > rightBound)
        {
            newX = rightBound;
            direction = -1f;
            Flip();
        }
        else if (newX < leftBound)
        {
            newX = leftBound;
            direction = 1f;
            Flip();
        }

        float verticalSpeed = 1f;
        float t = (Mathf.Sin(Time.time * verticalSpeed) + 1f) * 0.5f;
        float newY = Mathf.Lerp(minY, maxY, t);

        Vector2 target = new Vector2(newX, newY);

        if (useRigidbody)
            rb.MovePosition(target);
        else
            transform.position = target;
    }

    void Flip()
    {
        Vector3 s = transform.localScale;
        s.x = Mathf.Abs(s.x) * (direction > 0 ? 1 : -1);
        transform.localScale = s;
    }

    void OnDrawGizmos()
    {
        if (visualizeArea && flyArea != null)
        {
            Gizmos.color = new Color(0, 1, 1, 0.3f);
            Gizmos.DrawCube(flyArea.bounds.center, flyArea.bounds.size);
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(flyArea.bounds.center, flyArea.bounds.size);
        }
    }
}

