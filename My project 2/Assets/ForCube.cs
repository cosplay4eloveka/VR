using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForCube : MonoBehaviour
{
    public int a = 0;
    public Text HPUI;
    public int HP = 100;
    public float Speed = 10f;
    public int SMTH = 1;

    void OnTriggerStay(Collider Other)
    {
        a = a + 1;
        Pushing();
        Debug.Log("Столкновение с объектом продолжается! Всего в контакте " + a + " кадров!");
    }
    void OnTriggerEnter(Collider Other)
    {
        a = a + 1;
        Pushing();
        Debug.Log("Столкновение с объектом! Всего в контакте " + a + " кадров!");
    }

    void Pushing()
    {
        HP = HP - 1;
        if (HP <= 0)
        {
            SMTH = 0;
            HP = 0;
        }
        HPUI.text = HP.ToString() + "%";
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * 10 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 10 * Speed * Time.deltaTime);
        }

    }

    void Start()
    {
        int b = 20, c = 60;
        int d = b + c;
        Debug.Log("Здравствуй, мир! Складываю переменную b, которая равна " + b + ", и переменную c, которая равна " + c + ". Ответ равен: " + d + ".");
    }
    public void Button()
    {
        if (SMTH == 1)
        {
            SMTH = 0;
            var renderer = this.gameObject.GetComponent<Renderer>();
            renderer.material.shader = Shader.Find("Transparent/Diffuse");
            renderer.material.color = Color.white * 0.25f;
            Speed = 0f;
            HP = 0;
        }
        else if (SMTH == 0)
        {
            HP = 100;
            SMTH = 1;
            var renderer = this.gameObject.GetComponent<Renderer>();
            renderer.material.shader = Shader.Find("Transparent/Diffuse");
            renderer.material.color = Color.white * 1.0f;
            Speed = 0f;
        }

    }
}
