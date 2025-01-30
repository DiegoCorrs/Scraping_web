# ScrapingWeb - Extracción de Datos de Empleo con Selenium y HtmlAgilityPack  

## 📌 Descripción  
ScrapingWeb es una aplicación en **C#** que automatiza la extracción de datos de ofertas laborales desde el portal [ChileTrabajos](https://www.chiletrabajos.cl/) utilizando **Selenium WebDriver** y **HtmlAgilityPack**.  

El script **realiza scrolling automático** hasta que no haya más resultados, asegurando la captura de todas las ofertas disponibles.  

## ⚙️ Tecnologías utilizadas  
- **C#**  
- **Selenium WebDriver**  
- **HtmlAgilityPack**  
- **ChromeDriver**  

## 📥 Instalación y configuración  

### 1️⃣ Instalar dependencias  
Ejecutar los siguientes comandos en la consola de **NuGet Package Manager** para instalar las bibliotecas necesarias:  

```sh
Install-Package Selenium.WebDriver
Install-Package Selenium.WebDriver.ChromeDriver
Install-Package HtmlAgilityPack
```

### 2️⃣ Configurar ChromeDriver  
Tener **Google Chrome** instalado y descargar la versión compatible de **ChromeDriver** desde:  
🔗 [https://chromedriver.chromium.org/downloads](https://chromedriver.chromium.org/downloads)  

Colocar el ejecutable `chromedriver.exe` en la misma carpeta del proyecto o en una ruta accesible.  

## 🚀 Uso del Proyecto  
Para ejecutar el programa, compilar y ejecutar el código. El scraper:  
✅ **Accede al sitio web de ChileTrabajos** con ofertas para programadores.  
✅ **Realiza scrolling dinámico** hasta que no haya más resultados.  
✅ **Extrae los nombres de las empresas** de las ofertas disponibles.  
✅ **Imprime los resultados en la consola**.  

## 🛠️ Mejoras y Extensiones Futuras  
🔹 Extraer más información como títulos de ofertas, ubicación y salarios.  
🔹 Guardar los resultados en un archivo **CSV o base de datos**.  
🔹 Integrar un sistema de **notificaciones automáticas** para nuevas ofertas.  
🔹 Implementar **manejo de errores** en caso de cambios en la estructura del sitio web.  

