using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamara : MonoBehaviour
{
    [SerializeField] GameObject jogador;
    Vector3 diferenca;
    // Start is called before the first frame update
    void Start()
    {
        diferenca = transform.position - jogador.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = jogador.transform.position + diferenca;
    }
}
