using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidade = 8f;
    [SerializeField] private float tempoDeVida = 4f;

    private Vector2 direcao = Vector2.right;

    public void Iniciar(Vector2 dir)
    {
        direcao = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Acertou o player!");
            Destroy(gameObject);
        }
    }
}
