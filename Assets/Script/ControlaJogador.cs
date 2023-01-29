using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaJogador : MonoBehaviour
{
    Rigidbody corpoRigido;

    [SerializeField] float velocidade = 10f;
    [SerializeField] Text caixaTexto;
    [SerializeField] GameObject vitoriaText;
    [SerializeField] GameObject fecharText;

    private int contaCaixa = 0;

    // Start is called before the first frame update
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape)){  //sair da aplicação com a tecla ESC
            Application.Quit();
        }
        // transform.position = transform.position + new Vector3(moveHorizontal, moveVertical, 0);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        corpoRigido.AddForce(movimento * velocidade);
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Colectavel")){
            other.gameObject.SetActive(false);
            AtualizarCaixas();
        }
    }

    private void AtualizarCaixas(){
        contaCaixa++;
        caixaTexto.text = "CAIXAS: "+contaCaixa.ToString();
        if(GameObject.FindGameObjectsWithTag("Colectavel").Length <= 0){
            vitoriaText.SetActive(true);
            fecharText.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
