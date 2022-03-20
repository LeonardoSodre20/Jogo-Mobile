using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMenu : MonoBehaviour
{
    Renderer backgroundRenderer;
    Material materialBackground;
    float offset;
    public float increase;
    public float speed;
   
    void Start()
    {
        backgroundRenderer = GetComponent<MeshRenderer>();
        materialBackground = backgroundRenderer.material;

    
    }

    private void FixedUpdate()
    {
        offset += increase;
        materialBackground.SetTextureOffset("_MainTex", new Vector2(offset * speed / 1000, 0));
    }
}
