using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Text;

public class Conexiones : MonoBehaviour
{
    Tiempoxactividad tiempoxactividad = new Tiempoxactividad();
    public static Conexiones conexion;
    // public static String connetionString = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password=KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pilotaje;";
    // public static MySqlConnection cnn = new MySqlConnection(connetionString);
    public static String id_per = "202102";
    public static String id_user = "1";
    public static String id_reim = "500";
    public static String correcto = "2";
    public static String sesion_id;
    public static String id_actividad="0";
    public static String id_elemento = "0";
    public static String nickname_user = "JugadorPlayer";
    public static int posx, posy;
    public int secondsToCount=60;
    public float secondsCounter = 0;
    public bool jugando = true;
    public Touch touch;
    public static string ahora;
    public static string termino;
    public static string inicio;
    TouchPhase touchPhase = TouchPhase.Ended;
    internal static string tipo_usuario;
//     // void Awake()
//     // {
//     //     if (conexion == null)
//     //     {
//     //         conexion = this;
//     //         DontDestroyOnLoad(gameObject);
//     //     }else if(conexion != this)
//     //     {
//     //         Destroy(gameObject);
//     //     }
//     // }
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         CrearConexion();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (jugando)
//         {
//             secondsCounter += Time.deltaTime;
//             if (secondsCounter >= secondsToCount)
//             {
//                 secondsCounter = 0;
//                 ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//                 MySqlCommand query = cnn.CreateCommand();
//                 query.CommandText = ("UPDATE `asigna_reim_alumno` SET `datetime_termino` = '" + ahora + "' WHERE `sesion_id` = '" + sesion_id + "';");
//                 if (SceneManager.GetActiveScene().name == "Progreso")
//                 {
//                     id_actividad = 3000.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "Actividad Tesoro")
//                 {
//                     id_actividad = 3005.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "Actividad Drag And Drop")
//                 {
//                     id_actividad = 3006.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "Actividad Laberinto")
//                 {
//                     id_actividad = 3004.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "Actividad Lancha")
//                 {
//                     id_actividad = 3002.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "Actividad suma")
//                 {
//                     id_actividad = 3003.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "MainMenu")
//                 {
//                     id_actividad = 1.ToString();
//                 }
//                 else if (SceneManager.GetActiveScene().name == "Actividad Destreza")
//                 {
//                     id_actividad = 3077.ToString();
//                 }
//                 // else if (SceneManager.GetActiveScene().name == "Actividad ")
//                 query.CommandText = ("UPDATE `ulearnet_reim_pilotaje`.`tiempoxactividad` SET `final` = '" + ahora + "' WHERE (`inicio` = '" + inicio + "' AND `usuario_id` =  '" + id_user + "' AND `reim_id` = '" + id_reim + "' AND `actividad_id` = '" + id_actividad + "');");
//                 //print(inicio);
//                 //print(ahora);
//                 query.ExecuteNonQuery();
//             }
//         }
        
//     }
//     public void CrearConexion()
//     {
//         string connetionString = null;
//         connetionString = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password=KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pilotaje;";
//         //"server=localhost;database=testDB;uid=root;pwd=abc123;";
//         cnn = new MySqlConnection(connetionString);
//         try
//         {
//             cnn.Open();
//             Debug.Log("Connection Open ! ");
//         }
//         catch (Exception ex)
//         {
//             Debug.Log("Can not open connection ! " + ex);
//         }
//     }

//     public void Boton()
//     {
//         print("Boton");
//         correcto = "2";
//         posx = 0;
//         posy = 0;
//         InsertQuery();
//     }

//     public void SetActividad(String act)
//     {
//         if (act=="" || act == null)
//         {
//                     if (SceneManager.GetActiveScene().name == "Progreso")
//                     {
//                         id_actividad = 3000.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "Actividad Tesoro")
//                     {
//                         id_actividad = 3005.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "Actividad Drag And Drop")
//                     {
//                         id_actividad = 3006.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "Actividad Laberinto")
//                     {
//                         id_actividad = 3004.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "Actividad Lancha")
//                     {
//                         id_actividad = 3002.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "Actividad suma")
//                     {
//                         id_actividad = 3003.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "MainMenu")
//                     {
//                         id_actividad = 3001.ToString();
//                     }
//                     else if (SceneManager.GetActiveScene().name == "Actividad Destreza")
//                     {
//                        id_actividad = 3077.ToString();
//                     }
//         }
//         id_actividad = act;
//     }

//     public void SetElemento(String elm)
//     {
//         id_elemento = elm;
//     }

//     public void AlmacenaCorrecto(string SceneActive, string respuesta="false")
//     {
//         if (SceneActive == "Actividad Tesoro")
//         {
//             id_actividad = 3005.ToString();
//             id_elemento = "3005";
//         }
//         else if (SceneActive == "Actividad Drag and Drop")
//         {
//             id_actividad = 3006.ToString();
//             id_elemento = "3059";
//         }
//         else if (SceneActive == "Actividad Laberinto")
//         {
//             id_actividad = 3004.ToString();
//             if (respuesta == "RocaE")
//             {
//                 id_elemento = 3052.ToString();
//             }
//             else if (respuesta == "Faro actLab")
//             {
//                 id_elemento = 3051.ToString();
//             }
//             else if (respuesta == "Isla actLab")
//             {
//                 id_elemento = 3050.ToString();
//             }
//         }
//         else if (SceneActive == "Actividad Lancha")
//         {
//             id_actividad = 3002.ToString();
//             id_elemento = "3059";
//         }
//         else if (SceneActive == "Actividad suma")
//         {
//             id_actividad = 3003.ToString();
//             if (respuesta == "Respuesta1")
//             {
//                 id_elemento = 3070.ToString();
//             }
//             else if (respuesta == "Respuesta2")
//             {
//                 id_elemento = 3071.ToString();
//             }
//             else if (respuesta == "Respuesta3")
//             {
//                 id_elemento = 3072.ToString();
//             }
//         }
//         else if (SceneActive == "Actividad Destreza")
//         {
//             id_actividad = 3007.ToString();
//             id_elemento = "3041";
//         }
//         else if(SceneActive == "Actividad Patrones")
//         {
//             id_actividad = "3008";
//             id_elemento = "3082";
//         }
//         correcto = "1";
//         posx = 0;
//         posy = 0;
//         InsertQuery();
//         //ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         //MySqlCommand query = cnn.CreateCommand();
//         //query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`alumno_respuesta_actividad` (`id_per`, `id_user`, `id_reim`, `id_actividad`, `id_elemento`, `datetime_touch`, `fila`, `columna`, `correcta`) VALUES ('" + id_per + "', '" + id_user + "', '" + id_reim + "', '" + id_actividad + "', '" + id_elemento + "', '" + ahora + "', '" + 0 + "', '" + 0 + "','1');";
//         //query.ExecuteNonQuery();
//         //print("REGISTRÉ CORRECTO");

//     }
//     public void AlmacenaIncorrecto(string SceneActive, string respuesta="false")
//     {
//         if (SceneActive == "Actividad Tesoro")
//         {
//             id_actividad = 3005.ToString();
//             id_elemento = "3059";
//         }
//         else if (SceneActive == "Actividad Drag and Drop")
//         {
//             id_actividad = 3006.ToString();
//             id_elemento = "3059";
//         }
//         else if (SceneActive == "Actividad Laberinto")
//         {
//             id_actividad = 3004.ToString();
//             id_elemento = 3049.ToString();
//         }
//         else if (SceneActive == "Actividad Lancha")
//         {
//             id_actividad = 3002.ToString();
//             id_elemento = "3059";
//         }
//         else if (SceneActive == "Actividad suma")
//         {
//             id_actividad = 3003.ToString();
//             if (respuesta == "Respuesta1")
//             {
//                 id_elemento = 3070.ToString();
//             }
//             else if (respuesta == "Respuesta2")
//             {
//                 id_elemento = 3071.ToString();
//             }
//             else if (respuesta == "Respuesta3")
//             {
//                 id_elemento = 3072.ToString();
//             }
//         }
//         else if (SceneActive == "Actividad Destreza")
//         {
//             id_actividad = 3007.ToString();
//             id_elemento = "3041";
//         }
//         else if(SceneActive == "Actividad Patrones")
//         {
//             id_actividad = "3008";
//             id_elemento = "3082";
//         }
//         correcto = "0";
//         posx = 0;
//         posy = 0;
//         InsertQuery();
//         // Debug.Log("Connection Open ! ");
//         // ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         // MySqlCommand query = cnn.CreateCommand();
//         // query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`alumno_respuesta_actividad` (`id_per`, `id_user`, `id_reim`, `id_actividad`, `id_elemento`, `datetime_touch`, `fila`, `columna`, `correcta`) VALUES ('" + id_per + "', '" + id_user + "', '" + id_reim + "', '" + id_actividad + "', '" + id_elemento + "', '" + ahora + "', '" + 0 + "', '" + 0 + "','0');";
//         // query.ExecuteNonQuery();

//     }

//     public void Colision(string SceneActive, string respuesta = "false")
//     {
//         if (SceneActive == "Actividad Drag and Drop")
//         {
//             id_elemento = 3066.ToString();
//             id_actividad = 3006.ToString();
//         }
//         else if (SceneActive == "Actividad Laberinto")
//         {
//             id_actividad = 3004.ToString();
//             id_elemento = "3048";
//         }
//         else if (SceneActive == "Actividad Lancha")
//         {
//             if (respuesta == "BasuraPrefab")
//             {
//                 id_elemento = 3041.ToString();
//             }
//             else if (respuesta == "RuedaPrefab")
//             {
//                 id_elemento = 3068.ToString();
//             }
//             else if (respuesta == "BarrilPrefab")
//             {
//                 id_elemento = 3019.ToString();
//             }
//             id_actividad = 3002.ToString();
//         }
//         correcto = "3";
//         posx = 0;
//         posy = 0;
//         InsertQuery();
//     }
//     public void Pasos()
//     {
//         correcto = "4";
//         posx = 0;
//         posy = 0;
//         id_actividad = "3005";
//         id_elemento = "3005";
//         InsertQuery();
//     }
//     public void Saltos()
//     {
//         correcto = "5";
//         posx = 0;
//         posy = 0;
//         id_actividad = "3005";
//         id_elemento = "3005";
//         InsertQuery();
//     }

//     //public MySqlDataReader Select(string _select)
//     //{
//     //    //String connetionString = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password=KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pruebas;";
//     //    MySqlCommand cmd = cnn.CreateCommand();
//     //    cmd.CommandText = _select;
//     //    MySqlDataReader resultado = cmd.ExecuteReader();
//     //    return resultado;

//     //}
//     public MySqlDataReader Select(string _select)
//     {
//         //String connetionString = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password=KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pruebas;";
//         MySqlConnection conexion = new MySqlConnection(connetionString);

//         conexion.Open();
//         MySqlCommand cmd = conexion.CreateCommand();
//         cmd.CommandText = _select;
//         MySqlDataReader resultado = cmd.ExecuteReader();
//         return resultado;

//     }
//     public void PlayTimeLancha()
//     {
//         // Tiempoxactividad tiempoxactividad = new Tiempoxactividad();
//         // tiempoxactividad.id_tiempoactividad = 0;    //Id inicializado en 0
//         // tiempoxactividad.inicio = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//         // //Debug.Log(tiempoxactividad.inicio);
//         // tiempoxactividad.final = tiempoxactividad.inicio;       // inicializamos con tiempo final = a inicial
//         // tiempoxactividad.causa = 0;                             //causa por defecto 0
//         // tiempoxactividad.usuario_id = Convert.ToInt16(id_user);
//         // tiempoxactividad.reim_id = Convert.ToInt16(id_reim);
//         // tiempoxactividad.actividad_id = 3002;
//         // SystemSave.SaveTiempoActividad(tiempoxactividad, this);
        
//         // ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         // inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         // MySqlCommand query = cnn.CreateCommand();
//         // ahora = inicio;
//         // //INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES('2019-12-07', '2019-12-07', '0', '1', '1', '1');
//         // query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES ('" + ahora + "', '" + ahora + "', '" + 0 + "', '" + id_user + "', '" + id_reim + "', '" + 3002 + "');";
//         // query.ExecuteNonQuery();
//     }
//     public void UpdateTimeActividad(int causa)
//     {
//         tiempoxactividad.final = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         tiempoxactividad.causa = causa;
//         SystemSave.UpdateTiempoActividad(tiempoxactividad, this);
//     }

//     public void PlayTimeSuma()
//     {
//         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         MySqlCommand query = cnn.CreateCommand();
//         print(ahora);
//         ahora = inicio;
//         print(inicio);
//         //INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES('2019-12-07', '2019-12-07', '0', '1', '1', '1');
//         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES ('" + ahora + "', '" + ahora + "', '" + 0 + "', '" + id_user + "', '" + id_reim + "', '" + 3003 + "');";
//         query.ExecuteNonQuery();
//     }

//     public void PlayTimeLaberinto()
//     {
//         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         MySqlCommand query = cnn.CreateCommand();
//         ahora = inicio;
//         //INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES('2019-12-07', '2019-12-07', '0', '1', '1', '1');
//         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES ('" + ahora + "', '" + ahora + "', '" + 0 + "', '" + id_user + "', '" + id_reim + "', '" + 3004 + "');";
//         query.ExecuteNonQuery();
//     }
//     public void PlayTimeTesoro()
//     {
//         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         MySqlCommand query = cnn.CreateCommand();
//         ahora = inicio;
//         //INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES('2019-12-07', '2019-12-07', '0', '1', '1', '1');
//         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES ('" + ahora + "', '" + ahora + "', '" + 0 + "', '" + id_user + "', '" + id_reim + "', '" + 3005 + "');";
//         query.ExecuteNonQuery();
//     }
//     public void PlayTimeArrastrar()
//     {
//         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         MySqlCommand query = cnn.CreateCommand();
//         ahora = inicio;
//         //INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES('2019-12-07', '2019-12-07', '0', '1', '1', '1');
//         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES ('" + ahora + "', '" + ahora + "', '" + 0 + "', '" + id_user + "', '" + id_reim + "', '" + 3006 + "');";
//         query.ExecuteNonQuery();
//     }
//     public void PlayTimeDestreza()
//     {
//         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//         MySqlCommand query = cnn.CreateCommand();
//         ahora = inicio;
//         print(inicio);
//         //INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES('2019-12-07', '2019-12-07', '0', '1', '1', '1');
//         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`tiempoxactividad` (`inicio`, `final`, `causa`, `usuario_id`, `reim_id`, `actividad_id`) VALUES ('" + ahora + "', '" + ahora + "', '" + 0 + "', '" + id_user + "', '" + id_reim + "', '" + 3007 + "');";
//         query.ExecuteNonQuery();
//     }

//     public void FTimeVolver()
//     {
//         if (SceneManager.GetActiveScene().name == "Actividad Tesoro")
//         {
//             //null
//             id_actividad = 3005.ToString();
//             print("tesoro");
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Drag and Drop")
//         {
//             //null
//             id_actividad = 3006.ToString();
//             print("Drag");
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Laberinto")
//         {
//             //null
//             id_actividad = 3004.ToString();
//             print("laberinto");
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Lancha")
//         {
//             //funciona
//             id_actividad = 3002.ToString();
//             print("lancha");
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad suma")
//         {
//             //funciona
//             id_actividad = 3003.ToString();
//             print("suma");
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Destreza")
//         {
            
//             id_actividad = 3007.ToString();
//             print("destreza");
//         }
//         else
//         {
//             print("chupalo");
//             print((SceneManager.GetActiveScene().name));
//         }
//         if (SceneManager.GetActiveScene().name != "Progreso" && SceneManager.GetActiveScene().name != "MainMenu")
//         {
//             termino = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//             MySqlCommand query = cnn.CreateCommand();
//             print("despues");

//             // query.CommandText = "UPDATE `ulearnet_reim_pilotaje`.`tiempoxactividad` SET `final` = '" + termino + "' , `causa` = '" + "1" + "' WHERE (`inicio` = '" + inicio + "' AND `usuario_id` =  '" + id_user + "' AND `reim_id` = '" + id_reim + "' AND `actividad_id` =  '" + id_actividad + "');";
//             // query.ExecuteNonQuery();
//             print(termino);
//         }

//     }

//     public void FTimeRecompensa()
//     {
//         //print(inicio);
        
//         if (SceneManager.GetActiveScene().name == "Actividad Tesoro")
//         {
//             id_actividad = 3005.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Drag and Drop")
//         {
//             id_actividad = 3006.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Laberinto")
//         {
//             id_actividad = 3004.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Lancha")
//         {
//             id_actividad = 3002.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad suma")
//         {
//             id_actividad = 3003.ToString();
//             print("alo");
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Destreza")
//         {
//             id_actividad = 3007.ToString();
//         }
//         if (SceneManager.GetActiveScene().name != "Progreso" && SceneManager.GetActiveScene().name != "MainMenu")
//         {
//             termino = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//             MySqlCommand query = cnn.CreateCommand();

//             query.CommandText = "UPDATE `ulearnet_reim_pilotaje`.`tiempoxactividad` SET `final` = '" + termino + "' , `causa` = '" + "2" + "' WHERE (`inicio` = '" + inicio + "' AND `usuario_id` =  '" + id_user + "' AND `reim_id` = '" + id_reim + "' AND `actividad_id` =  '" + id_actividad + "');";

//             //UPDATE ulearnet_reim_pilotaje.tiempoxactividad SET final = "2019-12-09 16:40:49.243728" , causa = '2'  WHERE inicio = '2019-12-09 17:05:26.984223' AND usuario_id = '1'  AND reim_id = '2'  AND actividad_id = '14';
//             //print(ahora);
//             //print(termino);
//             //


//             query.ExecuteNonQuery();
//         }

//     }
//     public void GameStart()
//     {
//         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//         MySqlCommand query = cnn.CreateCommand();
//         sesion_id = id_user + "-" + ahora;
//         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`asigna_reim_alumno` (`sesion_id`, `usuario_id`, `periodo_id`, `reim_id`, `datetime_inicio`, `datetime_termino`) VALUES ('"+ sesion_id +"', '" + id_user + "', '" + id_per+ "', '" + id_reim + "','" + ahora + "' , '" + ahora + "');";
//         print("USUARIO: " + id_user);
//         query.ExecuteNonQuery();
//     }
//     public void InsertQuery()
//     {
//         try
//         {
//             // comentar hasta var c para que no se caiga

//             //var a = 1;
//             //var b = 2;
//             //var c = a / (a - 1);
//             if (id_elemento!= "0" && id_actividad!="0")
//             {
//                 print("ELEMENTO: " + id_elemento + " ACTIVIDAD: " + id_actividad + " CORRECTO: " + correcto);
//                 ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//                 MySqlCommand query = cnn.CreateCommand();
//                 query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`alumno_respuesta_actividad` (`id_per`, `id_user`, `id_reim`, `id_actividad`, `id_elemento`, `datetime_touch`, `fila`, `columna`, `correcta`) VALUES ('" + id_per + "', '" + id_user + "', '" + id_reim + "', '" + id_actividad + "', '" + id_elemento + "', '" + ahora + "', '" + posx + "', '" + posy + "','" + correcto + "');";
//                 query.ExecuteNonQuery();
//                 id_elemento = "0";
//                 correcto = "2";
//                 id_actividad = "0";
//             }

//         }
//         catch(Exception ex)
//         {   
//             string path = @"E:\Escritorio\DatitaCleanOceancita/CleanOcean/Datos.txt";
//             //string path = @"C:/Users/Alberto/Desktop/Clean Ocean Datos.txt";
//             if (!File.Exists(path))
//             {
//                 if (id_elemento!= "0" && id_actividad!="0")
//                 {
//                     File.Create(path).Dispose();
//                     TextWriter tw = new StreamWriter(path);
//                     ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//                     MySqlCommand query = cnn.CreateCommand();
//                     query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`alumno_respuesta_actividad` (`id_per`, `id_user`, `id_reim`, `id_actividad`, `id_elemento`, `datetime_touch`, `fila`, `columna`, `correcta`) VALUES ('" + id_per + "', '" + id_user + "', '" + id_reim + "', '" + id_actividad + "', '" + id_elemento + "', '" + ahora + "', '" + posx + "', '" + posy + "','" + correcto + "');";
//                     tw.WriteLine(query.CommandText);
//                     tw.Close();
//                     correcto = "2";
//                     id_elemento = "0";
//                     id_actividad = "0";
//                 }

//             }
//             else if (File.Exists(path))
//             {
//                 if (id_elemento!= "0" && id_actividad!="0")
//                 {
//                     using(var tw = new StreamWriter(path, true))
//                     {
//                         ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
//                         MySqlCommand query = cnn.CreateCommand();
//                         query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`alumno_respuesta_actividad` (`id_per`, `id_user`, `id_reim`, `id_actividad`, `id_elemento`, `datetime_touch`, `fila`, `columna`, `correcta`) VALUES ('" + id_per + "', '" + id_user + "', '" + id_reim + "', '" + id_actividad + "', '" + id_elemento + "', '" + ahora + "', '" + posx + "', '" + posy + "','" + correcto + "');";
//                         tw.WriteLine(query.CommandText);
//                         id_elemento = "0";
//                         correcto = "2";
//                         id_actividad = "0";
//                     }
//                 }
//             }
//         }
//     }
}
