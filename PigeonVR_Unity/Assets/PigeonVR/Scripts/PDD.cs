using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDD : MonoBehaviour
{
    

    public Camera Player_cam;
    public Vector3 pigeon;

    private Transform pigeon_direction;
    private Vector3 forward;

    float angle_from_forward;
    private string zone = "nothing here";

    private Info.Location zone_location, letter_location;

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

    private void Start()
    {
        forward = Vector3.forward;
    }

    //find the direction of the pigeon thrown and set zone 
    void Pigeon_direction_detection()
    {
        Vector3 dir = (Player_cam.transform.position - pigeon).normalized;
        angle_from_forward = Vector3.Angle(dir, forward);

        if (angle_from_forward > -25.71 && angle_from_forward < 25.71)
        {
            //town
            zone = "TOWN";
            zone_location = Info.Location.TOWN;
        }
        else if (angle_from_forward > 25.71 && angle_from_forward < 77.13)
        {
            //forest
            zone = "FOREST";
            zone_location = Info.Location.FOREST;
        }
        else if (angle_from_forward > 77.13 && angle_from_forward < 128.55)
        {
            //volcano
            zone = "VOLCANO";
            zone_location = Info.Location.VOLCANO;
        }
        else if (angle_from_forward > 128.55 && angle_from_forward < 179.97)
        {
            //wasteland
            zone = "WASTELAND";
            zone_location = Info.Location.WASTELAND;
        }
        else if (angle_from_forward > -179.97 && angle_from_forward < -128.55)
        {
            //desert
            zone = "DESERT";
            zone_location = Info.Location.DESERT;
        }
        else if (angle_from_forward > -128.55 && angle_from_forward < -77.13)
        {
            //city
            zone = "CITY";
            zone_location = Info.Location.CITY;
        }
        else if (angle_from_forward > -77.13 && angle_from_forward < -25.71)
        {
            //snow
            zone = "SNOW";
            zone_location = Info.Location.SNOW;
        }
        else
        {
            zone = "nothing_here";
        }
    }

    //check if zone and letter destination is same
    void check_pigeon_letter_destination()
    {

    }


    private void OnCollisionExit(Collision collision)
    {
        pigeon = collision.transform.position;
        
        Pigeon_direction_detection();
    }
}