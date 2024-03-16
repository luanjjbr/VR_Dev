using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class TelportPoint : MonoBehaviour
{
    public UnityEvent onteleportenter;
    public UnityEvent onteleport;
    public UnityEvent onteleportexit;
    public GameObject[] ponto;


    public float TempoOBS;
    private float tempo;
    private bool isGazing = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        ponto = GameObject.FindGameObjectsWithTag("ponto");
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
                foreach (GameObject objeto in ponto)
                {
                    //objeto.SetActive(true);
                    MeshRenderer meshRenderer1 = objeto.GetComponent<MeshRenderer>();
                    if (meshRenderer1 != null)
                        meshRenderer1.enabled = true;

                    BoxCollider boxCollider1 = objeto.GetComponent<BoxCollider>();
                    if (boxCollider1 != null)
                        boxCollider1.enabled = true;
                }
                isGazing = false;
                Execute();
                onteleport?.Invoke();
                
                if (TelportManager.instace != null)
                {
                    TelportManager.instace.DisableTeleportPoint(gameObject);
                }
                // Desativa o Mesh Renderer
                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }

                // Desativa o Box Collider
                BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }

                tempo = 0.0f;
            }
        }
    }
    public void OnPointerClick()
    {
        // Implemente o que deseja fazer quando o objeto é clicado.
    }

    private void Execute()
    {
        GameObject player = TelportManager.instace.Player;
        player.transform.position = transform.position;
        Camera camera = player.GetComponentInChildren<Camera>();
        float roty = transform.rotation.eulerAngles.y - camera.transform.localEulerAngles.y;
        player.transform.rotation = Quaternion.Euler(0, roty, 0);
    }
}

