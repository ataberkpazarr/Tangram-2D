using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor_,offsetColor_;
    [SerializeField] private SpriteRenderer renderer_;

    public void Init(bool isOffset) 
    {
        renderer_.color = isOffset ? offsetColor_ : baseColor_;
        //renderer_.color = offsetColor_;

    }
}
