using System.Collections;
using UnityEngine;

public class Atirador : MonoBehaviour
{
    [SerializeField] private Bala balaPrefab;
    [SerializeField] private Transform pontoDeTiro;
    [SerializeField] private Vector2 direcao = Vector2.right;

    [Header("Rajada")]
    [SerializeField] private int balasPorRajada = 3;
    [SerializeField] private float intervaloEntreBalas = 0.3f;

    [Header("Pausa entre rajadas")]
    [SerializeField] private float pausaMin = 1.5f;
    [SerializeField] private float pausaMax = 3f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(pausaMin, pausaMax));

            for (int i = 0; i < balasPorRajada; i++)
            {
                if (GameManager.Instance.FimDeJogo) yield break;
                Bala bala = Instantiate(balaPrefab, pontoDeTiro.position, Quaternion.identity);
                bala.Iniciar(direcao);
                yield return new WaitForSeconds(intervaloEntreBalas);
            }
        }
    }
}