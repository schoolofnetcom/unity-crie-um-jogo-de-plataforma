using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Personagem : MonoBehaviour {


	Rigidbody2D rb;
	SpriteRenderer sprite;
	Animator anim;
    public AudioSource moedaSom;
	public float velocidade;
	public float pulo;
    public Text pontuacaoTxt;
    int pontos;
	bool estaNoChao;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		estaNoChao = true;
        pontos = 0;

	}
	
	// Update is called once per frame
	void Update () {
		Movimentacao ();
		Pulo();
	}


	void Movimentacao(){

		// Movimenta para a esquerda
		if(Input.GetKey(KeyCode.A)){
			sprite.flipX = true;
			rb.velocity = new Vector2 (-velocidade * Time.deltaTime, rb.velocity.y);
		}

		// Movimenta para a direita
		if(Input.GetKey(KeyCode.D)){
			sprite.flipX = false;
			rb.velocity = new Vector2 (velocidade * Time.deltaTime, rb.velocity.y);
		}


		// Verificando velocidade:
		if (Mathf.Abs(rb.velocity.x) > 0.10f) {

			anim.SetBool ("Andando", true);
		
		} else {
		
			anim.SetBool ("Andando", false);		
		}
	}


	void Pulo(){
		// Detectando a tecla de espaço para aplicar uma força para cima.
		if(Input.GetKeyDown(KeyCode.Space)){
			if(estaNoChao){
				rb.AddForce(new Vector2(0f, pulo*Time.deltaTime), ForceMode2D.Impulse);
			}
		}

	}


	void OnCollisionStay2D(Collision2D col){
		estaNoChao = true;
	}

	void OnCollisionExit2D(Collision2D col){
		if(estaNoChao){
			estaNoChao = false;
		}
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moeda") {

            pontos += 1;
            moedaSom.Play();
            pontuacaoTxt.text = pontos.ToString();
            Destroy(collision.gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Espinho")
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}
