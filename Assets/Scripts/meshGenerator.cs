using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class meshGenerator : MonoBehaviour
{
    Mesh mesh_;

    Vector3[] vertices;
    int[] triangles;

    
    void Start()
    {
        mesh_ = new Mesh(); // add this mesh to that we just created to mesh filter
        GetComponent<MeshFilter>().mesh=mesh_;
        gameObject.AddComponent<MeshRenderer>();
        MeshRenderer a = GetComponent<MeshRenderer>();
        a.material.renderQueue = 4001;
        CreateShape();
        //gameObject.AddComponent<BoxCollider2D>(); 
        //gameObject.AddComponent<PuzzlePiece>();

       
    }

    public void createTriangle()
    { 
        
    }
    // Update is called once per frame
    void Update()
    {
        updateMesh();
        CreateShape2();

    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            /*
            new Vector3(0,0,0),
            new Vector3(0,0.5f,0),
            new Vector3(0.5f,0,0),*/
            
            
            new Vector3(0,0.5f,0),
            new Vector3(0.5f,0.5f,0),
            new Vector3(0.5f,0,0)
        };

        triangles = new int[]
        {
            0, 1, 2    
        };

    }

    void CreateShape2()
    {
        vertices = new Vector3[]
        {
            
            new Vector3(0,0,0),
            new Vector3(0,0.5f,0),
            new Vector3(0.5f,0,0)
            
            /*
            new Vector3(0,0.5f,0),
            new Vector3(0.5f,0.5f,0),
            new Vector3(0.5f,0,0)*/
        };

        triangles = new int[]
        {
            0, 1, 2
        };

    }

    void updateMesh()
    {
        mesh_.Clear();
        mesh_.vertices = vertices;
        mesh_.triangles = triangles;
        
        mesh_.RecalculateBounds();
        
        
       // Renderer re = GetComponent<Renderer>();
        //re.sortingLayerName = "top";
    }
}
