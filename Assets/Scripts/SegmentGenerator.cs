using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segments;
    int xpos = 0;
    int ypos = 0;
    int zpos = 0;
    bool creatingSegment = false;
    int segmentNum;

    // Update is called once per frame
    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segments.Length);
        Instantiate(segments[segmentNum], new Vector3(xpos, ypos, zpos), Quaternion.identity);
        //Need to set up something so x, y, and z are dependant on which segment is added
        xpos += 50;
        ypos += 50;
        zpos += 50;
        yield return new WaitForSeconds(5);
        creatingSegment = false;
    }
}
