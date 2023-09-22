using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour{

    public GameObject TetoRelativo;
    public GameObject ChaoRelativo;
    public GameObject Teto;
    public GameObject Chao;

    public GameObject Jogador;

    public GameObject obstaculo1;
    public GameObject obstaculo2;
    public GameObject obstaculo3;
    public GameObject obstaculo4;

    public GameObject obstaculoPrefab;

    public float minObsY;
    public float maxObsY;

    public float minObsEspaco;
    public float maxObsEspaco;

    public float minObsTamY;
    public float maxObsTamY;

    // Start is called before the first frame update
    void Start(){
        obstaculo1 = GerarObstaculo(Jogador.transform.position.x + 10);
        obstaculo2 = GerarObstaculo(obstaculo1.transform.position.x);
        obstaculo3 = GerarObstaculo(obstaculo2.transform.position.x);
        obstaculo4 = GerarObstaculo(obstaculo3.transform.position.x);
        
    }

    GameObject GerarObstaculo(float referenceX){
        GameObject obstaculo = GameObject.Instantiate(obstaculoPrefab);
        SetTransform(obstaculo,referenceX);
        return obstaculo;
    }

    void SetTransform(GameObject obstaculo, float referenceX){
        obstaculo.transform.position = new Vector3(referenceX + Random.Range(minObsEspaco,maxObsEspaco), Random.Range(minObsY,maxObsY),0);
        obstaculo.transform.localScale = new Vector3(obstaculo.transform.localScale.x, Random.Range(minObsTamY, maxObsTamY), obstaculo.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Jogador.transform.position.x > Chao.transform.position.x){
            var tempChao = ChaoRelativo;
            var tempTeto = TetoRelativo;
            
            TetoRelativo = Teto;
            ChaoRelativo = Chao;

            tempChao.transform.position += new Vector3(89,0,0);
            tempTeto.transform.position += new Vector3(89,0,0);

            Chao = tempChao;
            Teto = tempTeto;
        }

        if(Jogador.transform.position.x > obstaculo2.transform.position.x){
            var tempObs = obstaculo1;
            obstaculo1 = obstaculo2;
            obstaculo2 = obstaculo3;
            obstaculo3 = obstaculo4;
            SetTransform(tempObs,obstaculo3.transform.position.x);
            obstaculo4=tempObs;
        }
    }
}
