using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    enum StateMachine
    {
        LoadQuestion,
        WaitAnswer,
        GoodAnswer,
        FinishGame
    }

    public Tecla[] teclado;
    Tecla teclaWena;
    string[] preguntas = {  "Australia", "Egipto", "Jap�n", "Oceania", "America",                                       // Estrofa 1
                            "Ghana", "Islas Salom�n", "Alemania", "Espa�a", "Argentina", "Serbia", "Samoa", "Brasil",   // Estrofa 2
                            "Nueva Zelanda", "Libia", "Nepal", "Palaos", "Canad�",                                      // Estrofa 3
                            "Egipto", "Kiribati", "Rep�blica Checa", "Guatemala", "Austria", "Nauru", "Estados Unidos" };

    string[] respuestas = { "oc", "af", "as", "oc", "am",                   // Estrofa 1
                            "af", "oc", "eu", "eu", "am", "eu", "oc", "am", // Estrofa 2
                            "oc", "af", "as", "oc", "am",                   // Estrofa 3
                            "af", "oc", "eu", "am", "eu", "oc", "am"};      // Estrofa 4

    public AudioSource altavos;
    StateMachine state;
    int preguntaActual;
    public Text preguntaEnPantalla;

    // Start is called before the first frame update
    void Start()
    {
        state = StateMachine.LoadQuestion;
        preguntaActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case StateMachine.LoadQuestion:
                //Cargar nuevo texto pregunta[i]
                preguntaEnPantalla.text = preguntas[preguntaActual];
                //Chekear respuesta correcta
                foreach (Tecla t in teclado)
                {
                    if (respuestas[preguntaActual] == t.respuesta)
                    {
                        teclaWena = t;
                        //Reproducir nota correcta
                        altavos.clip = t.nota;
                        altavos.Play();
                    }
                }


                state = StateMachine.WaitAnswer;
                break;
            case StateMachine.WaitAnswer:
                
                if (Input.GetKeyUp(teclaWena.tecla) && respuestas[preguntaActual] == teclaWena.respuesta)
                {
                    state = StateMachine.GoodAnswer;
                }
             
                break;
            case StateMachine.GoodAnswer:
                // Sale un mensaje en pantalla y pasa a la siguiente pregunta
                if (preguntas.Length < preguntaActual)
                {
                    state = StateMachine.FinishGame;
                }
                else
                {
                    ++preguntaActual;
                    state = StateMachine.LoadQuestion;
                }
                break;
            case StateMachine.FinishGame:
                //Se acabo
                break;
            default:
                break;
        }
    }
}
