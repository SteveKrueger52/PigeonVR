using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDD : MonoBehaviour
{
    

    public Camera Player_cam;
    public GameObject trigger;
    public Transform pigeon;

    //put a gameobject on the greater edge of each area.
    public Transform city, town, wasteland, forest, snow, desert,volcano;
    private Transform pigeon_direction;
    private Vector3 north;

    float angle;
    private string zone = "nothing here";

   // public RectTransform north_layer, pigeon_direction_layer;

    private void shoot()
    {
        Pigeon_direction_detection();
        RaycastHit city;
        if (Physics.Raycast(Player_cam.transform.position, Player_cam.transform.forward, out city, 100000))
        {
           // Debug.Log(city.transform.name);
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
    


        if (city.position.x < pigeon_direction.position.x && desert.position.x > pigeon_direction.position.x)
        {
            if (city.position.y > pigeon_direction.position.y && desert.position.y < pigeon_direction.position.y)
            {
                zone = "DESERT";
                //score++ for desert
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else if (snow.position.x < pigeon_direction.position.x && city.position.x > pigeon_direction.position.x)
        {
            if (snow.position.y > pigeon_direction.position.y && city.position.y < pigeon_direction.position.y)
            {
                zone = "CITY";
                //score++ for city
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else if(town.position.x >pigeon_direction.position.x && snow.position.x < pigeon_direction.position.x)
        {  
            if(town.position.y>pigeon_direction.position.y && snow.position.y < pigeon_direction.position.y)
            {
                zone = "SNOW";
                //score++ for snow
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else if(forest.position.x > pigeon_direction.position.x && town.position.x < pigeon_direction.position.x)
        {
            if(forest.position.y < pigeon_direction.position.y && town.position.y > pigeon_direction.position.y)
            {
                zone = "TOWN";
                //score ++ for town
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else if(volcano.position.x < pigeon_direction.position.x && forest.position.x > pigeon_direction.position.x)
        {
            if(volcano.position.y < pigeon_direction.position.y && forest.position.y > pigeon_direction.position.y)
            {
                zone = "FOREST";
                //score ++ for forest
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else if(wasteland.position.x < pigeon_direction.position.x && volcano.position.x > pigeon_direction.position.x)
        {
            if(wasteland.position.y < pigeon_direction.position.y && volcano.position.y > pigeon_direction.position.y)
            {
                zone = "VOLCANO";
                //score ++ for volcano
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else if(desert.position.x < pigeon_direction.position.x && wasteland.position.x > pigeon_direction.position.x)
        {
            if(desert.position.y > pigeon_direction.position.y && wasteland.position.y < pigeon_direction.position.y)
            {
                zone = "WASTELAND";
                //score ++ for wasteland
                Debug.Log(zone);
                Debug.Log(pigeon_direction);
            }

        }
        else
        {
            zone = "nothing_here";
            //lose lives
        }
                Debug.Log(pigeon_direction);
    }


    private void OnTriggerEnter(Collider fly_pigeon)
    {
        pigeon_direction.position = pigeon.position;
        Pigeon_direction_detection();
    }
}