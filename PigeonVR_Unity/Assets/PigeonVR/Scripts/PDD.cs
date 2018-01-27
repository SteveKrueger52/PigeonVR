using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDD : MonoBehaviour
{
    

    public Camera Player_cam;
    public GameObject trigger;
    public Transform Player;

    //put a gameobject on the greater edge of each area.
    public Transform city, town, wasteland, forest, snow, desert,volcano;
    public Quaternion pigeon_direction;
    private Vector3 north;

    float angle;
    public Vector3 forward =  Vector3.forward;

   // public RectTransform north_layer, pigeon_direction_layer;

    private void shoot()
    {
        Pigeon_direction_detection();
        RaycastHit city;
        if (Physics.Raycast(Player_cam.transform.position, Player_cam.transform.forward, out city, 100000))
        {
            Debug.Log(city.transform.name);
        }
    }

    private void Update()
    {
     
        if(Input.GetMouseButtonDown(0))
        {
           shoot();
        }
    }

    void North_direction()
    {
        north = Vector3.forward;
       // north_layer.localEulerAngles = north;
    }

    void Pigeon_direction_detection()
    {
        pigeon_direction = Player.rotation;


        if (city.position.x > pigeon_direction.x && desert.position.x < pigeon_direction.x)
        { if (city.position.y > pigeon_direction.y && desert.position.y < pigeon_direction.y)
            //score++ for desert
            }
        else if (snow.position.x > pigeon_direction.x && city.position.x < pigeon_direction.x)
        { if (snow.position.y > pigeon_direction.y && city.position.y < pigeon_direction.y)
                //score++ for city
                }
        else if(town.position.x >pigeon_direction.x && snow.position.x < pigeon_direction.x)
        {  
            if(town.position.y>pigeon_direction.y && snow.position.y < pigeon_direction.y)
                //score++ for snow
        }
        else if(forest.position.x > pigeon_direction.x && town.position.x < pigeon_direction.x)
        {
            if(forest.position.y > pigeon_direction.y && town.position.y < pigeon_direction.y)
                //score ++ for town
        }
        else if(volcano.position.x > pigeon_direction.x && forest.position.x < pigeon_direction.x)
        {
            if(volcano.position.y >pigeon_direction.y && forest.position.y < pigeon_direction.y)
                //score ++ for forest
        }
        else if(wasteland.position.x > pigeon_direction.x && volcano.position.x < pigeon_direction.x)
        {
            if(wasteland.position.y > pigeon_direction.y && volcano.position.y < pigeon_direction.y)
                //score ++ for volcano
        }
        else if(desert.position.x > pigeon_direction.x && wasteland.position.x < pigeon_direction.x)
        {
            if(desert.position.y > pigeon_direction.y && wasteland.position.y < pigeon_direction.y)
                //score ++ for wasteland
        }
                Debug.Log(pigeon_direction);
    }

    private void OnTriggerEnter(Collider fly_pigeon)
    {
        Pigeon_direction_detection();
    }
}