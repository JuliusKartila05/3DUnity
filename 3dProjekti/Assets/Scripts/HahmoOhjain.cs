using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmoOhjain : MonoBehaviour
{
     public float juoksuNopeus = 3.5f;
    public float hiirenNopeus = 3f;
    public float hyppyNopeus = 100f;
    public float painovoima = 10f;
    private float vertikaalinnenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private Vector3 liikesuunta = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vertikaalinnenPyorinta += Input.GetAxis("Mouse Y") * hiirenNopeus;
        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinnenPyorinta,horisontaalinenPyorinta,0);

    }
}
