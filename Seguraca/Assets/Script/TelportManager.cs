using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelportManager : MonoBehaviour
{//nova
    public static TelportManager instace;
    public GameObject Player;
    private GameObject lasTeleportepoint;
    private void Awake()
    {
        if (instace != this && instace != null)
        {
            Destroy(this);
        }
        else
        {
            instace = this;
        }
    }
    public void OnPointerExit()
    {
    }
    public void DisableTeleportPoint(GameObject teleport)
    {
        if (teleport != null)
        {
            if (lasTeleportepoint != null)
            {
                lasTeleportepoint.SetActive(true);
            }
        }
        //teleport.SetActive(false);
        lasTeleportepoint = teleport;
#if UNITY_EDITOR
        Player.GetComponent<CardboardSimulator>().UpdatePlayerPositonSimulator();
#endif
    }
}
