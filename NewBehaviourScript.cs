using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class NewBehaviourScript : MonoBehaviour 
{
SerialPort data_stream = new SerialPort("COM9", 19200);
public string receivedstring;
public GameObject test_data;
public Rigidbody2D rb;
public float sensitivity = 0.01f;

public string[] datas;

    // Start is called before the first frame update
    void Start()
    {
	data_stream.Open();
	InvokeRepeating("Serial_Data_Reading", 0f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        int recv_angl = Serial_Data_Reading();
	
	transform.rotation = Quaternion.Euler(new Vector3(0,0,- recv_angl * 5));
//	transform.position = new Vector3(float.Parse(datas[3]), 0, 0);
    }
	
    int Serial_Data_Reading()
    {
	receivedstring = data_stream.ReadLine();
	string[] datas = receivedstring.Split(',');
	int recv_angl_data = Mathf.RoundToInt(float.Parse(datas[2]));

	return recv_angl_data;
    }
}
