using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] float speedx = 0.0f;
    [SerializeField] float speedy = 0.1f;

    private Renderer render;
    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        offset = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speedx * Time.deltaTime;
        offset.y += speedy * Time.deltaTime;
        render.material.mainTextureOffset = offset;
    }
}
