using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class TelportPoint : MonoBehaviour
{
    public GameObject objetoParaTrocar;

    public UnityEvent onteleportenter;
    public UnityEvent onteleport;
    public UnityEvent onteleportexit;


    public float TempoOBS;
    private float tempo;
    private bool isGazing = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnPointerEnter()
    {
        onteleportenter?.Invoke();
        isGazing = true;
        tempo = 0.0f;
    }

    public void OnPointerExit()
    {
        onteleportexit?.Invoke();
        isGazing = false;
        tempo = 0.0f;
    }

    private void Update()
    {
        if (isGazing)
        {
            tempo += Time.deltaTime;

            if (tempo >= TempoOBS)
            {
                TrocarPosicoes();
            }
        }
    }
    public void OnPointerClick()
    {
        // Implemente o que deseja fazer quando o objeto � clicado.
    }
    void TrocarPosicoes()
    {
        // Verifica se o objeto para trocar foi atribu�do
        if (objetoParaTrocar != null)
        {
            // Obt�m as posi��es atuais dos dois objetos
            Vector3 posicaoAtualObjetoScript = transform.position;
            Vector3 posicaoAtualObjetoParaTrocar = objetoParaTrocar.transform.position;

            // Mant�m a coordenada Y de cada objeto inalterada
            float yObjetoScript = posicaoAtualObjetoScript.y;
            float yObjetoParaTrocar = posicaoAtualObjetoParaTrocar.y;

            // Troca apenas as posi��es X e Z entre os dois objetos
            transform.position = new Vector3(posicaoAtualObjetoParaTrocar.x, yObjetoScript, posicaoAtualObjetoParaTrocar.z);
            objetoParaTrocar.transform.position = new Vector3(posicaoAtualObjetoScript.x, yObjetoParaTrocar, posicaoAtualObjetoScript.z);
        }
        else
        {
            Debug.LogWarning("Objeto para trocar n�o foi atribu�do.");
        }
    }

}

