using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {

    private (Vector3 start, Vector3 end)[] lines = new (Vector3 start, Vector3 end)[] {
        (new Vector3(-1.5f,-5.7f,0f), new Vector3(-2.8f,-18.8f,0f)),
        (new Vector3(-2.8f,-18.8f,0f), new Vector3(2.6f,-11.5f,0f)),
        (new Vector3(2.6f,-11.5f,0f), new Vector3(7.67f,-12.45f,0f)),
        (new Vector3(7.67f,-12.45f,0f), new Vector3(3.35f,-22.03f,0f))
    };


    [SerializeField] public int numOfNutrients;
    [SerializeField] List<float> birthPoints = new List<float>();
    [SerializeField] public GameObject nutrientPrefab;
    [SerializeField] float distanceTraveled = 0;
    [SerializeField] public float goodNutrientChance;
    public SpriteRenderer renderer;
    private Color32 startColor = new Color32(0xf2, 0xc7, 0x6a, 0xFF);
    private Color32 endColor = new Color32(0xad, 0x25, 0x00, 0xFF);
    bool flag = true;
    float totalDistance;

    private void OnEnable(){
        renderer = GetComponentInChildren<SpriteRenderer>();
        totalDistance = 0;
        distanceTraveled = 0f;
        renderer.color = startColor;
        for(int i = 0; i < lines.Length; i++){
            totalDistance += Vector3.Distance(lines[i].start, lines[i].end);
        }
        birthPoints = new List<float>();
        birthPoints.Add(5f/6f * totalDistance);
        // we only had one birthPoint due to a bug, but then it was actually more balanced so just hardcoding this for now
        /*
        for(int i = 5; i <= numOfNutrients + 1; i++){
            birthPoints.Add(totalDistance*i/(numOfNutrients+1));
        }*/
    }
    public void emitNutirent(){
        GameObject child = ObjectPool.GetObject(nutrientPrefab);
        birthPoints.RemoveAt(0);
        Nutrient nut = child.GetComponent<Nutrient>();
        nut.isGood = Random.value < goodNutrientChance;
        nut.transform.position = new Vector3(-7.8f,-18.3f,0) + new Vector3(Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.3f), 0);
        
    }

    private void Update(){
        if (transform.position.y < -25 || transform.position.y > 15){ // exited the screen, delete it
            ObjectPool.ReleaseToPool(gameObject);
            //add or subtract score depending on whether good or bad food
        }
        float distanceTravelled = percentTravelled();
        renderer.color = Color.Lerp(startColor, endColor, distanceTravelled);
        if(distanceTraveled > birthPoints[0]){
            emitNutirent();
        }

    }

    private float percentTravelled(){
        int minIndex = 0;
        float minDist = Vector3.Distance(transform.position, findNearestPoint(transform.position, lines[0].start, lines[0].end));
        Vector3 closestPoint = findNearestPoint(transform.position, lines[0].start, lines[0].end);
        for (int i = 1; i < lines.Length; i++){
            Vector3 nearestPoint = findNearestPoint(transform.position, lines[i].start, lines[i].end);
            float dist = Vector3.Distance(transform.position, nearestPoint);
            if(dist < minDist){
                closestPoint = nearestPoint;
                minDist = dist;
                minIndex = i;
            }
        }
        float newDistTraveled = 0;
        for(int i = 0; i < minIndex; i++){
            newDistTraveled += Vector3.Distance(lines[i].start, lines[i].end);
        }
        newDistTraveled += Vector3.Distance(lines[minIndex].start, closestPoint);
        distanceTraveled = Mathf.Max(distanceTraveled, newDistTraveled);
        return distanceTraveled / totalDistance;
    }

    private Vector3 findNearestPoint(Vector3 point, Vector3 origin, Vector3 end){
        //Get heading
        Vector3 heading = (end - origin);
        float magnitudeMax = heading.magnitude;
        heading.Normalize();

        //Do projection from the point but clamp it
        Vector3 lhs = point - origin;
        float dotP = Vector2.Dot(lhs, heading);
        dotP = Mathf.Clamp(dotP, 0f, magnitudeMax);
        return origin + heading * dotP;
    }

}