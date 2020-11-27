using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnakeScript : MonoBehaviour
{

    private AudioSource audioEat;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartGame;
    public Button menuGame;
    public bool isGame;
    public List<Transform> Tails;
    [Range(0, 3)]
    public float BonesDistance;
    public GameObject BonesPrefab;
    private float score = 0;

    [Range(0,4)]
    public float speed;
    private Transform _transform;

    private void Start()
    {
        isGame = true;
        _transform = GetComponent<Transform>();
        audioEat = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isGame) 
        {
            MoveSnake(_transform.position + _transform.forward * speed);

            float angel = Input.GetAxis("Horizontal") * 3;
            _transform.Rotate(0, angel, 0);
        }
       
    }
    private void MoveSnake(Vector3 newPositions)
    {
        
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previosPosition = _transform.position;

        foreach(var bone in Tails)
        {
            if((bone.position - previosPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = previosPosition;
                previosPosition = temp;
            }
            else
            {
                break;
            }
        }

        transform.position = newPositions;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(BonesPrefab, new Vector3(0,-2,0), Tails[0].transform.rotation);
            Tails.Add(bone.transform);
            speed += 0.01f;
            audioEat.Play();

            score += 1;
            scoreText.text = ("Score: " + score);
        }

        if(collision.gameObject.tag == "Wall")
        {
            isGame = false;
            gameOverText.gameObject.SetActive(true);
            restartGame.gameObject.SetActive(true);
            menuGame.gameObject.SetActive(true);
        }
    }
}
