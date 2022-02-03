using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Globais
    {
       public static string versao ="1.0";
       public static Boolean logado = false;
       public static int nivel = 0; // 1 = CAIXA, 2 = GERENTE
       public static string caminho = System.Environment.CurrentDirectory;
       public static string nomeBanco = "banco teste.db";
       public static string caminhoBanco = caminho+@"\banco\"; 
    }
}
