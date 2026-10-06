using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Corroutines : MonoBehaviour
{

    delegate void MyAction();
    MyAction action1;
    MyAction action2;
    MyAction action3;
    MyAction action4;
    MyAction action5;

    Action<bool, int, float> myCallback;
    Func<float,float,bool> predicate;

    delegate bool MyDelegateFloats(float a, float b);

    delegate int MyFuncInt();
    MyFuncInt funcInt;

    delegate bool MyPredicate();
    MyPredicate predicate1;

    void Start()
    {



        StartCoroutine(WaitSecondsAndExecute());

        //StopCoroutine(cor);

        //List<GameObject> gos = new List<GameObject>();
        //foreach (var item in gos)
        //{

        //}

        StartCoroutine(InfiniteGenerator());

        //funcInt = Resultado;
        //funcInt.Invoke();

        //predicate1 = Query;
        //predicate1.Invoke();

        StartCoroutine(WaitForKey());

    }

    bool Query()
    {
        return true;
    }

    int Resultado()
    {
        return 2;
    }

    IEnumerator WaitSecondsAndExecute()
    {
        Debug.Log("Inicio");

        yield return new WaitForSeconds(2f);

        Debug.Log("Pasaron 2 segundos");

    }

    int cont = 0;
    IEnumerator InfiniteGenerator()
    {
        while (true)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = new Vector3(cont, 0,0);
            yield return new WaitForSeconds(2f);
            cont++;
        }
    }

    IEnumerator WaitForKey()
    {
        Debug.Log("Esperando a que se toque una tecla");

        //yield return new WaitUntil(GetKeyPressed);
        yield return new WaitUntil(() => Input.anyKeyDown);
        //yield return new WaitWhile(() => Input.anyKeyDown);

        Debug.Log("Se toco una tecla");
    }

    ///  () => { func return }

    bool GetKeyPressed()
    {
        return Input.anyKeyDown;
    }




    //IEnumerable myEnumerable()
    //{
    //    yield return null;
    //}
   
}




public class MyExamplenativeClass
{
    public void SendMono(GameObject go)
    {
        
    }
}
