using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class EditorSpriteRendererScaler : MonoBehaviour
{
    const float CHECK_DELAY = 0.5f; 

    SpriteRenderer thisSpriteRenderer;
    SpriteRenderer parentSpriteRenderer;
    float checkDelayer;

    public bool syncWidth;
    public bool syncHeight;
    public bool zeroTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > checkDelayer)
        {
            checkDelayer = Time.time + CHECK_DELAY;

            if (syncWidth && syncHeight)
                thisSpriteRenderer.size = parentSpriteRenderer.size;
            else if (syncWidth)
                thisSpriteRenderer.size = new Vector2(parentSpriteRenderer.size.x, thisSpriteRenderer.size.y);
            else if (syncHeight)
                thisSpriteRenderer.size = new Vector2(thisSpriteRenderer.size.x, parentSpriteRenderer.size.y);

            if (zeroTransform)
            {
                transform.localPosition = Vector3.zero;
                transform.localScale = Vector3.one;
            }
        }
    }
}
