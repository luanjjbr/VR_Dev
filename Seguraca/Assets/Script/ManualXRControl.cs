using UnityEngine;
using UnityEngine.XR;

public class DesativarCardboardXR : MonoBehaviour
{
    void Start()
    {
        // Verificar se o Cardboard XR está atualmente habilitado
        if (XRSettings.loadedDeviceName == "cardboard")
        {
            // Desativar o Cardboard XR
            XRSettings.LoadDeviceByName("");
            Debug.Log("Cardboard XR desativado.");
        }
        else
        {
            Debug.Log("Cardboard XR não está atualmente habilitado.");
        }
    }
}
