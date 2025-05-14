using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    private Material objectMaterial;

    public Color highlightColor = new Color(0f, 1f, 0f, 0.5f); // Полупрозрачный зелёный
    public float highlightIntensity = 2f; // Интенсивность свечения

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            objectMaterial = objectRenderer.material;
            originalColor = objectMaterial.color;
            objectMaterial.EnableKeyword("_EMISSION"); // Включаем свечение

            // Устанавливаем режим рендеринга в Transparent
            objectMaterial.SetFloat("_Mode", 3);
            objectMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objectMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objectMaterial.SetInt("_ZWrite", 0);
            objectMaterial.DisableKeyword("_ALPHATEST_ON");
            objectMaterial.EnableKeyword("_ALPHABLEND_ON");
            objectMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objectMaterial.renderQueue = 3000;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что зашел игрок
        {
            if (objectMaterial != null)
            {
                Color newColor = highlightColor;
                newColor.a = 0.5f; // Полупрозрачность
                objectMaterial.color = newColor;
                objectMaterial.SetColor("_EmissionColor", highlightColor * highlightIntensity);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Когда игрок уходит
        {
            if (objectMaterial != null)
            {
                Color newColor = originalColor;
                newColor.a = 1f; // Возвращаем непрозрачность
                objectMaterial.color = newColor;
                objectMaterial.SetColor("_EmissionColor", originalColor * 0f);
            }
        }
    }
}
