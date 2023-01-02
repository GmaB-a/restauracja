using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngridientScript : MonoBehaviour
{
    public Canvas canvas;
    public bool HasToFollowCursor = true;

    void Update()
    {
        if (HasToFollowCursor)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                (Vector2)Input.mousePosition,
                canvas.worldCamera,
                out position);
            transform.position = canvas.transform.TransformPoint(position);
        }
    }
}
