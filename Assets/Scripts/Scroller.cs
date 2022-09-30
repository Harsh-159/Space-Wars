using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float bckSpeed = 0.5f;
    Material myMaterial;
    Vector2 offset;

    private void Start()
    {
        myMaterial = gameObject.GetComponent<Renderer>().materials[0];
        offset = new Vector2(0, bckSpeed);
    }

    private void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
