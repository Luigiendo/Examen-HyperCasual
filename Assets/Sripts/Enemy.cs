using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Sprite[] spritesEnemigos;
    public int vidaMaxima = 10;
    public int dañoEnemigo = 1;
    public int dañoJugador = 2;
    public Button enemy;
    public Image imagen;
    public Image barraVida;
    public TextMeshProUGUI contadorEnemigos;
    public ParticleSystem derrotaEnemigo;

    [SerializeField]
    private int vidaEnemigo;
    private int enemigosMuertos;
    

    // Start is called before the first frame update
    void Start()
    {
        IniciarEnemigo();
        enemigosMuertos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = (float)vidaEnemigo / (float)vidaMaxima;
        contadorEnemigos.text = enemigosMuertos.ToString();
    }

    public void AplicarDaño()
    {
        vidaEnemigo -= dañoJugador;
        if (vidaEnemigo <= 0)
        {
            IniciarEnemigo();
            enemigosMuertos += 1;
            derrotaEnemigo.Play();
        }
    }

    private void IniciarEnemigo()
    {
        int imagenAleatoria = Random.Range(0, spritesEnemigos.Length);
        vidaEnemigo = vidaMaxima;
        imagen = enemy.gameObject.GetComponent<Image>();
        imagen.sprite = spritesEnemigos[imagenAleatoria];
    }
}
