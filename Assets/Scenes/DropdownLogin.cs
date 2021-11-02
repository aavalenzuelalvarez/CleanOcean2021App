// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using MySql.Data.MySqlClient;
// using UnityEngine.SceneManagement;
// using System;
// using System.IO;
// using System.Text;

// public class DropdownLogin : MonoBehaviour
// {
//     public static String id_user;
//     public Dropdown colegio;
//     public Dropdown curso;
//     public Dropdown alumno;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // string _log = "SELECT DISTINCT p.colegio_id, c.nombre FROM pertenece p, colegio c where p.usuario_id = '" + Conexiones.id_user + "' and p.colegio_id = c.id;";
//         // Conexiones _conexion = GameObject.Find("Conexiones").GetComponent<Conexiones>();
//         // MySqlDataReader resultado = _conexion.Select(_log);
//         colegio.options.Clear();
//         colegio.options.Add(new Dropdown.OptionData("Seleccione Colegio"));
//         if (resultado.Read())
//         {
//             colegio.options.Add(new Dropdown.OptionData(resultado["nombre"].ToString()));
//             while (resultado.Read())
//             {
//                 colegio.options.Add(new Dropdown.OptionData(resultado["nombre"].ToString()));
//             }            
//         }
//     }

//     public void CargarCursos()
//     {
//         //Debug.Log("Cargando Cursos...");
//         string _log = "SELECT p.colegio_id, c.nombre, n.nombre as nivel, cr.nombre as curso FROM pertenece p, colegio c, nivel n, curso cr where p.usuario_id = '" + Conexiones.id_user + "' and p.colegio_id = c.id and n.id = p.nivel_id and cr.id = p.curso_id and c.nombre ='" + colegio.options[colegio.value].text + "';";
//         Conexiones _conexion = GameObject.Find("Conexiones").GetComponent<Conexiones>();
//         MySqlDataReader resultado = _conexion.Select(_log);

//         curso.options.Clear();
//         curso.options.Add(new Dropdown.OptionData("Seleccione Curso"));
//         if (resultado.Read())
//         {
            
//             curso.options.Add(new Dropdown.OptionData(resultado["nivel"].ToString()+ resultado["curso"].ToString()));
//             while (resultado.Read())
//             {
//                 curso.options.Add(new Dropdown.OptionData(resultado["nivel"].ToString() + resultado["curso"].ToString()));
//             }
//         }
//     }

//     public void CargarAlumnos()
//     {
//         //Debug.Log("Cargando Cursos...");
//         string _log = "SELECT u.nombres, u.apellido_paterno, u.apellido_materno FROM pertenece p, colegio c, nivel n, curso cr, usuario u where u.id = p.usuario_id and u.tipo_usuario_id = 3 and p.colegio_id = c.id and n.id = p.nivel_id and cr.id = p.curso_id and c.nombre ='" + colegio.options[colegio.value].text + "' and concat(n.nombre,cr.nombre) ='" + curso.options[curso.value].text + "';";
//         Conexiones _conexion = GameObject.Find("Conexiones").GetComponent<Conexiones>();
//         MySqlDataReader resultado = _conexion.Select(_log);

//         alumno.options.Clear();
//         alumno.options.Add(new Dropdown.OptionData("Seleccione Alumno"));
//         if (resultado.Read())
//         {

//             alumno.options.Add(new Dropdown.OptionData(resultado["nombres"].ToString() + resultado["apellido_paterno"].ToString() + resultado["apellido_materno"].ToString()));
//             while (resultado.Read())
//             {
//                 alumno.options.Add(new Dropdown.OptionData(resultado["nombres"].ToString() + resultado["apellido_paterno"].ToString() + resultado["apellido_materno"].ToString()));
//             }
//         }
//     }

//     public void Seleccionar()
//     {
//         string _log = "SELECT p.usuario_id, u.nombres, u.apellido_paterno, u.apellido_materno FROM pertenece p, colegio c, nivel n, curso cr, usuario u where u.id = p.usuario_id and u.tipo_usuario_id = 3 and p.colegio_id = c.id and n.id = p.nivel_id and cr.id = p.curso_id and c.nombre = '" + colegio.options[colegio.value].text + "' and concat(n.nombre, cr.nombre) = '" + curso.options[curso.value].text + "' and concat(u.nombres, u.apellido_paterno, u.apellido_materno) = '" + alumno.options[alumno.value].text + "';";
//         Conexiones _conexion = GameObject.Find("Conexiones").GetComponent<Conexiones>();
//         MySqlDataReader resultado = _conexion.Select(_log);

//         if (resultado.Read())
//         {
//             Conexiones.id_user = resultado["usuario_id"].ToString();
//             print(resultado["usuario_id"].ToString());
//             print("usuario" + Conexiones.id_user);
//             GameObject.Find("Conexiones").GetComponent<Conexiones>().GameStart();

//         }

//         SceneManager.LoadScene(2);

//     }

//         // Update is called once per frame
//         void Update()
//     {
        
//     }
// }
