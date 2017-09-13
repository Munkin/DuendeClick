using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorRecurso : MonoBehaviour {

	private float tiempoPasado;

	private int oro;

	private int multiplicador;

	private int actualBoton;

	private float tiempoBarraVelocidad;

	private float tiempoVelocidadPasado;

	private bool estaConVelocidad;

	private float porcentajeVelocidad;

	private int semillaOro;

	public float tiempoParaGenerarRecursos;

	public Text textoRecursos;

	public Dropdown prueba;

	public GameObject[] botones;

	public Scrollbar barraMejora;

	

	

	// Use this for initialization
	void Start () {
		multiplicador = 1;
		tiempoBarraVelocidad = 5;
		porcentajeVelocidad = 0.5f;
		semillaOro = 100;
	}
	
	// Update is called once per frame
	void Update () {
		tiempoPasado += Time.deltaTime;
		if(tiempoPasado>tiempoParaGenerarRecursos)
		{
			tiempoPasado = 0;
			oro += (semillaOro*multiplicador);
			textoRecursos.text = "Oro " + oro;
		}
		TiempoMejora();
	}

	void TiempoMejora ()
	{	
		if(estaConVelocidad)
		{
			if(tiempoVelocidadPasado>0)
			{
				tiempoVelocidadPasado-=Time.deltaTime;
				LerpingScrollbar();
			}
			else
			{
				estaConVelocidad = false;
				barraMejora.gameObject.SetActive(false);
				tiempoParaGenerarRecursos /= porcentajeVelocidad;
			}
		}
	}

	void LerpingScrollbar()
	{
		float tempFloat = tiempoVelocidadPasado/tiempoBarraVelocidad;
		barraMejora.size = tempFloat;

	}

	public void ActivarSpeedPowerUp()
	{if(!estaConVelocidad)
	{
		estaConVelocidad = true;
		tiempoVelocidadPasado = tiempoBarraVelocidad;
		barraMejora.gameObject.SetActive(true);
		tiempoParaGenerarRecursos *= porcentajeVelocidad;
	}
	}

	public void AumentarMultiplicador()
	{
		multiplicador++;
	}

	public void Mejora1()
	{
		if(oro>=500)
		{
			oro-=500;
			textoRecursos.text = "Oro " + oro;
			semillaOro = 200;
			botones[actualBoton].SetActive(false);
			botones[actualBoton+1].GetComponent<Button>().interactable = true;
			actualBoton++;
		}
	}

	public void Mejora2()
	{
		if(oro>=1000)
		{
			oro-=1000;
			textoRecursos.text = "Oro " + oro;
			semillaOro = 400;
			botones[actualBoton].SetActive(false);
			botones[actualBoton+1].GetComponent<Button>().interactable = true;
			actualBoton++;
		}
	}

	public void Mejora3()
	{
		if(oro>=2000)
		{
			oro-=2000;
			textoRecursos.text = "Oro " + oro;
			semillaOro = 800;
			botones[actualBoton].SetActive(false);
			botones[actualBoton+1].GetComponent<Button>().interactable = true;
			actualBoton++;
		}
	}

	public void Mejora4()
	{
		if(oro>=4000)
		{
			oro-=4000;
			textoRecursos.text = "Oro " + oro;
			semillaOro = 1600;
			botones[actualBoton].SetActive(false);
		}
	}
}
