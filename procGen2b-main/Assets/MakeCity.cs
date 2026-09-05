using UnityEngine;

public class MakeCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int scaleQ;
    void Start()

    {

        Perlin surface = new Perlin();

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;

        float scalex = this.transform.localScale.x;

        float scalez = this.transform.localScale.z;

        for (int v = 0; v < vertices.Length; v++)
        {
            if (Random.value > 0.5f) continue;
            float perlinValue = surface.Noise(vertices[v].x * 2 + 0.1365143f, vertices[v].z * 2 + 1.21688f)*56;

            perlinValue = Mathf.Round(Mathf.Clamp(perlinValue, 0, buildings.Length-1));

            Instantiate(buildings[(int)perlinValue], new Vector3(vertices[v].x * scalex, vertices[v].y, vertices[v].z * scalez), buildings[(int)perlinValue].transform.rotation);

        }

        mesh.vertices = vertices;

        mesh.RecalculateBounds();

        mesh.RecalculateNormals();

        gameObject.AddComponent<MeshCollider>();

    }
}