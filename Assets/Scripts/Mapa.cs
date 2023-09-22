using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour{

    public GameObject TetoRelativo;
    public GameObject ChaoRelativo;
    public GameObject Teto;
    public GameObject Chao;

    public GameObject Jogador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Jogador.transform.position.x > Chao.transform.position.x){
            var tempChao = ChaoRelativo;
            var tempTeto = TetoRelativo;
            
            TetoRelativo = Teto;
            ChaoRelativo = Chao;

            tempChao.transform.position += new Vector3(29.4f,0,0);
            tempTeto.transform.position += new Vector3(29.4f,0,0);

            Chao = tempChao;
            Teto = tempTeto;

        }
    }
}
