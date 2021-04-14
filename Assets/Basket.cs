using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //Получить ссылку на игровой обьект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        //Получить компонент Text  этого игрового обьекта
        scoreGT = scoreGO.GetComponent<Text>();

        //Установить начальное число очков равным 0
        scoreGT.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        //Получить текущие координаты
        Vector3 mousePose2D = Input.mousePosition;

        //Координата Z камеры определяет, как далеко находится указатель мыши
        mousePose2D.z = -Camera.main.transform.position.z;

        //Преобразовать точку на двумерной плоскости в трехмерные
        Vector3 mousePose3D = Camera.main.ScreenToWorldPoint(mousePose2D);

        //Переместить корзину вдоль оси Х в координату Х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePose3D.x;
        this.transform.position = pos;
        
    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if ( collidedWith.tag == "Apple") {
            Destroy(collidedWith);

            //Преобразовать текст в scoreGT в целое число
            int score = int.Parse(scoreGT.text);
            //Добавить очки за пойманное яблоко
            score += 100;
            //Преобразовать число очков обратно в строку и вывести ее на экран
            scoreGT.text = score.ToString();

            //Запомнить лучший счет
            if (score > HighScore.score) {
                HighScore.score = score;
            }
        }
    }
}
