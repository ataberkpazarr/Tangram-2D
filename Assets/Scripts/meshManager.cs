using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshFilter))]
public class meshManager : MonoBehaviour
{
    [SerializeField] private GameObject subColliderPrefab;
    [SerializeField] private GameObject emptyGameObject;
    Mesh mesh_;

    Vector3[] vertices;
    int[] triangles;


    void Start()
    {
        /*
        mesh_ = new Mesh(); // add this mesh to that we just created to mesh filter
        GetComponent<MeshFilter>().mesh = mesh_;
        gameObject.AddComponent<MeshRenderer>();
        MeshRenderer a = GetComponent<MeshRenderer>();

        //GameObject renderingQueueObject_ =  GameObject.Find("puzzleInstance");
        //SpriteRenderer s = renderingQueueObject_.GetComponent<SpriteRenderer>();

        a.sortingLayerName = "top";
        a.material.renderQueue = 4000;

        //a.material.renderQueue = s.material.renderQueue;
        //CreateShape();

        //gameObject.AddComponent<BoxCollider2D>(); 
        //gameObject.AddComponent<PuzzlePiece>();
        */








    }

    public void createRequiredMesh(int x_, int y_)
    {
        vertices = new Vector3[]
       {
           new Vector3(x_,y_,0),
           new Vector3(x_-0.5f,y_+0.5f,0),
           new Vector3(x_,y_+0.5f,0),
           new Vector3(x_+0.5f,y_+0.5f,0),
           new Vector3(x_+0.5f,y_,0),
           new Vector3(x_+0.5f,y_-0.5f,0),
           new Vector3(x_,y_-0.5f,0),
           new Vector3(x_-0.5f,y_-0.5f,0),
           new Vector3(x_-0.5f,y_,0)

           /*
           new Vector3(0,0.5f,0),
           new Vector3(0,0,0),
           new Vector3(0.5f,0,0),
           new Vector3(0.5f,0.5f,0),
           new Vector3(1f,1f,0),
           new Vector3(1f,0.5f,0)
           */
       };

        triangles = new int[]
        {
            //0,2,1
            1,2,0
            //0,2,1,0,3,2 quad
            //0,2,1,0,3,2,4,5,3 weird shape but correct

            //2,1,0,3,5,4
            //1,0,3,4,5,2
            //2,1,0,3,4,5,1,2,3
           // 0,3,4,5,2,1
            //2,1,5,4,3,0
            //0,3,4,5,1,2
            //0, 1, 2,3,4,5    
        };



        GameObject gam_ = Instantiate(emptyGameObject, transform.position, Quaternion.identity);
        mesh_ = new Mesh();
        gam_.AddComponent<MeshFilter>();
        gam_.GetComponent<MeshFilter>().mesh = mesh_;
        gam_.AddComponent<MeshRenderer>();
        MeshRenderer a_ = GetComponent<MeshRenderer>();
        a_.sortingLayerName = "top";
        a_.material.renderQueue = 4000;
        gam_.AddComponent<PuzzlePiece>();
        gam_.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polCol = gam_.GetComponent<PolygonCollider2D>();
        polCol.pathCount = vertices.Length;
        List<Vector2> vec2Arr = new List<Vector2>();
        for (int i = 0; i < vertices.Length; i++)
        {
            vec2Arr.Add(vertices[i]);
            GameObject gam = Instantiate(subColliderPrefab, vertices[i], Quaternion.identity);
            gam.transform.SetParent(this.transform);
        }
        polCol.SetPath(0, vec2Arr);
        //gam_.transform.position = new Vector2(0,0);
        //polCol.isTrigger = true;



        /*
        gameObject.AddComponent<PuzzlePiece>();
        gameObject.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polCol = gameObject.GetComponent<PolygonCollider2D>();
        polCol.pathCount = vertices.Length;
        List<Vector2> vec2Arr = new List<Vector2>();
        for (int i = 0; i < vertices.Length; i++)
        {
            vec2Arr.Add(vertices[i]);
            GameObject gam = Instantiate(subColliderPrefab, vertices[i], Quaternion.identity);
            gam.transform.SetParent(this.transform);
        }
        polCol.SetPath(0, vec2Arr);
        //polCol.isTrigger = true;
        */

    }
    // Update is called once per frame
    void Update()
    {
        updateMesh();
        //CreateShape2();


    }

   

    void updateMesh()
    {
        if (mesh_!=null)
        {
            //mesh_.Clear();
            mesh_.vertices = vertices;
            mesh_.triangles = triangles;

            mesh_.RecalculateBounds();
        }
      


        // Renderer re = GetComponent<Renderer>();
        //re.sortingLayerName = "top";
    }
}
