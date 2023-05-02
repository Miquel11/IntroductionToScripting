using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{

    public float movementSpeed;
    private float horizontalBoundary = 22;

    public GameObject heyBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    public float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }


     void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); //1
        
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) 
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if(horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }


    private void ShootHay()
    {
        Instantiate(heyBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }


    private void UpdateShooting(){
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
        shootTimer = shootInterval;
        ShootHay();
        }
 }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

   
}
