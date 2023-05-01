using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {

    private (Vector3 start, Vector3 end)[] lines = new (Vector3 start, Vector3 end)[] {
        (new Vector3(-1.5f,-5.7f,0f), new Vector3(-2.8f,-18.8f,0f)),
        (new Vector3(-2.8f,-18.8f,0f), new Vector3(2.6f,-11.5f,0f)),
        (new Vector3(2.6f,-11.5f,0f), new Vector3(7.67f,-12.45f,0f)),
        (new Vector3(7.67f,-12.45f,0f), new Vector3(3.35f,22.03f,0f))
    };


    [SerializeField] private List<GameObject> childPrefabs;
    private int totalOffspring;
    private List<float> birthPoints = new List<float>();
    [SerializeField] public float health;
    private float distanceTraveled = 0;
    public int numOfNutrients;
    public float goodNutrientChance;
    bool flag = true;
    float totalDistance;

    private void OnEnable(){
        totalOffspring = childPrefabs.Count;
        totalDistance = 0;
        for(int i = 0; i < lines.Length; i++){
            totalDistance += Vector3.Distance(lines[i].start, lines[i].end);
        }
        for(int i = 1; i <= totalOffspring; i++){
            birthPoints.Add(totalDistance*i/totalOffspring);
        }
    }
    public void emitNutirent(){
        
        GameObject child = ObjectPool.GetObject(childPrefabs[0]);
        childPrefabs.RemoveAt(0);
        birthPoints.RemoveAt(0);
        Nutrient nut = child.GetComponent<Nutrient>();
        nut.isGood = Random.value > health;
        nut.transform.position = new Vector3(-7.6f,-16.13f,0);
        if(childPrefabs.Count == 0){
            ObjectPool.ReleaseToPool(gameObject);
        }
        
    }

    private void Update(){
        if (transform.position.y > 15){
            ObjectPool.ReleaseToPool(gameObject);
            //add or subtract score depending on whether good or bad food
        }
        float distanceTravelled = percentTravelled();
        if(distanceTraveled > birthPoints[0]){
            Debug.Log("emitting!!!!!!!");
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
