using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [Header("Get render to change own color")]
    [SerializeField] private Renderer myRenderer;

    private Material myMaterial;
    private float hue;

    void Awake()
    {
        myMaterial = myRenderer.material;
    }

    public void SetChangeColorPlayer()
    {
        hue = Random.Range(0f, 1f);
        myMaterial.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}
