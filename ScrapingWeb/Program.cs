using HtmlAgilityPack;  // Importa la biblioteca HtmlAgilityPack para trabajar con documentos HTML.
using OpenQA.Selenium;  // Importa la biblioteca Selenium para automatizar el navegador.
using OpenQA.Selenium.Chrome;  // Importa el controlador de Chrome para Selenium.
using System;  
using System.Collections.Generic;
using System.Threading; // Importa la librería para usar Thread.Sleep().

namespace ScrapingWeb  
{
    internal class Program  
    {
        static void Main(string[] args)  
        {
            var options = new ChromeOptions();  // Crea una nueva instancia de ChromeOptions.
            options.AddArgument("--headless");  // Añade un argumento para ejecutar Chrome en modo sin cabeza (sin interfaz gráfica).

            using (IWebDriver driver = new ChromeDriver(options))  // Crea una nueva instancia de ChromeDriver con las opciones especificadas.
            {
                driver.Navigate().GoToUrl("https://www.chiletrabajos.cl/encuentra-un-empleo?action=search&order_by=&ord=&within=25&2=programador&filterSearch=Buscar");  // Navega a la URL especificada.

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // Inicializa un ejecutor de JavaScript para interactuar con la página.
                int maxAttempts = 20;  // Establece un límite máximo de intentos para evitar un bucle infinito.
                int delay = 2000; // Define un tiempo de espera (2 segundos) para permitir la carga de contenido tras cada scroll.
                int attempts = 0; // Inicializa el contador de intentos.
                long lastHeight = 0; // Almacena la altura inicial de la página.

                while (attempts < maxAttempts) // Inicia un bucle que se ejecutará hasta alcanzar el límite de intentos.
                {
                    long newHeight = (long)js.ExecuteScript("return document.body.scrollHeight");
                    // Se obtiene la altura actual de la página después de cada intento de scroll.

                    if (newHeight == lastHeight) // Verifica si la altura de la página no ha cambiado.
                    {
                        Console.WriteLine("No hay más resultados para cargar.");
                        // Si la altura es la misma, significa que no se han cargado más resultados y se detiene el bucle.
                        break;
                    }

                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    // Se ejecuta un script de JavaScript para desplazar la página hasta el final.

                    Thread.Sleep(delay); // Se espera el tiempo definido (2 segundos) para permitir la carga de nuevos datos.

                    lastHeight = newHeight; // Actualiza la altura.
                    attempts++; // Incrementa el contador de intentos.
                }


                var pageSource = driver.PageSource;  // Obtiene el código fuente de la página.

                HtmlDocument doc = new HtmlDocument();  // Crea una nueva instancia de HtmlDocument.
                doc.LoadHtml(pageSource);  // Carga el código fuente de la página en el documento HTML.

                var empresaNodes = doc.DocumentNode.SelectNodes("//*[@id='buscador']//h3[1][contains(@class, 'meta')]");  // Selecciona los nodos que contienen las empresas usando XPath.

                if (empresaNodes == null)  // Verifica si no se encontraron nodos.
                {
                    Console.WriteLine("No se encontraron empresas.");  
                    return;  
                }

                List<string> empresas = new List<string>();  // Crea una nueva lista para almacenar los nombres de las empresas.

                foreach (var empresaNode in empresaNodes)  // Itera sobre cada nodo de empresa encontrado.
                {
                    empresas.Add(empresaNode.InnerText.Trim());  // Añade el texto del nodo a la lista, eliminando espacios en blanco.
                }

                Console.WriteLine("Empresas encontradas:");  // Imprime un mensaje.
                foreach (var empresa in empresas)  // Itera sobre la lista de empresas.
                {
                    Console.WriteLine($"- {empresa}");  // Imprime cada nombre de empresa.
                }
            }
        }
    }
}


