using UnityEngine;

// Sets block color to same layer order as parent
public class BlockColor : MonoBehaviour
{
    void Start()
    {
        if (transform.parent.GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = transform.parent.GetComponent<SpriteRenderer>().sortingLayerName;
            GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
        }
    }
}
