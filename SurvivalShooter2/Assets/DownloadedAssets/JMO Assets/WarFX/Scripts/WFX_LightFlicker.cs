using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	public float time = 0.05f;
	
	private float timer;

	public ParticleSystem muz;

	IEnumerator coroutineAtual;
	
	void Start()
	{
		timer = time;
	}

    private void Update()
    {
        if(muz.isPlaying && coroutineAtual == null)
        {

			coroutineAtual = Flicker();
			StartCoroutine(coroutineAtual);
		}

        if (muz.isStopped && coroutineAtual != null)
        {
			StopCoroutine(coroutineAtual);
			GetComponent<Light>().enabled = false;
			coroutineAtual = null;
        }
    }


    IEnumerator Flicker()
	{
		while(true)
		{
			GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
			
			do
			{
				timer -= Time.deltaTime;
				yield return null;
			}
			while(timer > 0);
			timer = time;


			yield return null;
		}
	}
}
