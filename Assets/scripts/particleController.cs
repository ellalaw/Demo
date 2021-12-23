using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticle
{
    //粒子属性类，用于初始化每个粒子位置
    public float radius = 0f, angle = 0f, time = 0f;

    public MyParticle(float radius, float angle, float time)
    {
        this.radius = radius; //半径
        this.angle = angle; //角度
        this.time = time; //游离的起始时间
    }
}

public class particleController : MonoBehaviour
{
    private ParticleSystem psys; // 粒子系统
    private ParticleSystem.Particle[] particleArr; //粒子数组

    private MyParticle[] circle; //粒子属性类
    public int count = 200;
    public float size = 0.1f;
    public float minRadius = 5;
    public float maxRadius = 7;//运动半径范围
    public bool clockwise = true;
    public float speed = 2;
    public int part = 2;

    //public float m_Drift = 0.01f;
    //m_Particles[i].velocity += Vector3.up * m_Drift;

    public float pingPong = 0.03f; //游离范围

    // Start is called before the first frame update
    void Start()
    {
        particleArr = new ParticleSystem.Particle[count];
        circle = new MyParticle[count];

        //初始化粒子系统
        psys = GetComponent<ParticleSystem>();
        var main = psys.main;
        main.startSpeed = 0;
        main.startSize = size;
        main.loop = false;
        main.maxParticles = count;
        psys.Emit(count);
        psys.GetParticles(particleArr, count);

        for (int i = 0; i < count; i++)
        {
            // 随机每个粒子的角度
            float angle = Random.Range(0f, 360f);
            float Angle = angle / 180 * Mathf.PI; //角度angle对应的弧度

            // 随机每个粒子的游离起始时间
            float time = Random.Range(0f, 360f);

            // 随机每个粒子距离中心的半径，但集中在平均半径附近
            float mid = (maxRadius + minRadius) / 2;
            float minRate = Random.Range(1f, mid / minRadius);
            //Debug.Log(minRate); //大于1，比如1.2
            float maxRate = Random.Range(mid / maxRadius, 1f);
            //Debug.Log(maxRate); //小于1，比如0.9
            float radius = Random.Range(minRadius * minRate, maxRadius * maxRate);

            //这样的写法，粒子会比较均匀分散在半径值域之间，而上边的方法，中间密集，边缘稀疏，比较好看（正态分布？）
            //radius = Random.Range(minRadius, maxRadius);

            circle[i] = new MyParticle(radius, angle, time);
            particleArr[i].position = new Vector3(circle[i].radius * Mathf.Cos(angle), circle[i].radius * Mathf.Sin(angle), 0f);
        }
        psys.SetParticles(particleArr, particleArr.Length);
    }

    private void Update()
    {
        for (int i=0; i < count; i++)
        {
            if (i % 2 == 0) circle[i].angle += (i % part + 1) * speed;
            else circle[i].angle -= (i % part + 1) * speed;

            //circle[i].angle = circle[i].angle % 360;
            float Angle = circle[i].angle / 180 * Mathf.PI;
            //float Angle = circle[i].angle;
            particleArr[i].position = new Vector3(circle[i].radius * Mathf.Cos(Angle), circle[i].radius * Mathf.Sin(Angle), 0f);
        }
        psys.SetParticles(particleArr, particleArr.Length);
    }

    public void readyToShow()
    {
        gameObject.SetActive(true);
    }
}
