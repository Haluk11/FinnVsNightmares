using UnityEngine;

public class parallax : MonoBehaviour
{
    public float parallaxEffect;
    public float parallaxEffect2;

    private float length, startpos,length2, startpos2;
    public GameObject cam; 

    void Start()
    {
        startpos = transform.position.x;
        startpos2 = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        length2 = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    // Update is called once per frame
    void Update()
    {
        float temp =(cam.transform.position.x * (1-parallaxEffect));
        float dist =(cam.transform.position.x * parallaxEffect);
        
         if(temp<startpos-length) startpos  -=length;
        else if (temp>startpos+length) startpos += length;

        float temp2 =(cam.transform.position.y * (1-parallaxEffect2));
        float dist2 =(cam.transform.position.y * parallaxEffect2);

        transform.position = new Vector3(startpos+dist,startpos2+dist2,transform.position.z);
    }
}
