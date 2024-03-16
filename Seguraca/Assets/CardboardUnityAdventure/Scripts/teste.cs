using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI;

public class teste : MonoBehaviour
{
    public TextMeshProUGUI textMeshProComponent;
    public float TempoOBS;

    public Renderer objectRenderer;

    private float tempo;
    private bool isGazing = false;

    public void Start()
    {
    }

    public void OnPointerEnter()
    {
        isGazing = true;
    }

    public void OnPointerExit()
    {
        isGazing = false;
        tempo = 0.0f;
    }

    public void OnPointerClick()
    {
    }

    private void Update()
    {
        if (isGazing)
        {
            tempo += Time.deltaTime;

            if (tempo >= TempoOBS )
            {
                isGazing = false;
                DisplayGreeting();
            }
        }
    }
    private void DisplayGreeting()
    {
        objectRenderer.material.color = Color.blue;
        textMeshProComponent.text = "Usando software como inventor podemos modelar o que quisermos.\nDepois temos que passar estes aquivos para impressoras.\nAgora olhe para a Impressoras.\n                    " + "/3";
    }
}
