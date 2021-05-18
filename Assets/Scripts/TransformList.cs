using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformList : MonoBehaviour
{
    public static List<Transform> transformToSpawn = new List<Transform>();
    public Rigidbody rb;
    public GameObject cubeToSpawn;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transformToSpawn.Add(collision.gameObject.transform);
        }
        if (collision.transform.tag == "Obstacle")
        {
            Player.currentSwipe = Vector2.zero;
            foreach (var item in transformToSpawn)
            {
                Instantiate(cubeToSpawn, item.position, Quaternion.identity);
            }
            transformToSpawn.Remove(transform);
        }
        
    }
}
