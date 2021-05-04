using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmoOhjain : MonoBehaviour
{
     public float juoksuNopeus = 3.5f;
    public float hiirenNopeus = 3f;
    public float hyppyNopeus = 100f;
    public float painovoima = 10f;
    public float maxKaannosAsteet = 60;
    public float minKaannosAsteet = -70;
    public CursorLockMode haluttuMoodi;
    private float vertikaalinnenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private Vector3 liikesuunta = Vector3.zero;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = haluttuMoodi;
       Cursor.visible = (CursorLockMode.Locked != haluttuMoodi);
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vertikaalinnenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;
        vertikaalinnenPyorinta = Mathf.Clamp(vertikaalinnenPyorinta, minKaannosAsteet, maxKaannosAsteet);
        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinnenPyorinta,horisontaalinenPyorinta,0);
        float nopeusEteen = Input.GetAxis("Vertical");
        float nopeusSivulle = Input.GetAxis("Horizontal");
        Vector3 nopeus = new Vector3(nopeusSivulle * juoksuNopeus,0,nopeusEteen * juoksuNopeus);
        nopeus = transform.rotation * nopeus;
        controller.SimpleMove(nopeus);
        liikesuunta.y -= painovoima * Time.deltaTime;
        controller.Move(liikesuunta * Time.deltaTime);
        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            liikesuunta.y += hyppyNopeus;
        }
    }
}
