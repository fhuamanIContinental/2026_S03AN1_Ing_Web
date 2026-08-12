# Backend de la Solución S03AN1

Este documento proporciona una visión general de la arquitectura, configuración y despliegue del proyecto backend. La solución está desarrollada en C# con ASP.NET Core y sigue un enfoque de arquitectura en N-Capas.

## 1. Arquitectura de la Solución (N-Capas)

La solución está organizada en múltiples proyectos, cada uno representando una capa lógica con responsabilidades bien definidas. Esta separación de conceptos es fundamental para mantener un código limpio, escalable y fácil de mantener.

```
[Capa de Presentación]      S03AN1.Api
        |
        V
[Capa de Negocio]           S03AN1.Negocio
        |
        V
[Capa de Acceso a Datos]    S03AN1.Repositorio
        |
        V
[Capa de Modelo de Datos]   S03AN1.DbModel
```

### Descripción de las Capas

*   **`S03AN1.Api` (Capa de Presentación):**
    *   **Responsabilidad:** Exponer los endpoints de la API REST, manejar las solicitudes y respuestas HTTP y validar la entrada básica. Es la única capa que interactúa directamente con el cliente.
    *   **Componentes:** Controladores, configuración de servicios (`Program.cs`), middleware.

*   **`S03AN1.Negocio` (Capa de Lógica de Negocio):**
    *   **Responsabilidad:** Contiene toda la lógica de negocio, reglas de validación complejas y orquestación de operaciones. Actúa como intermediario entre la API y el acceso a datos.
    *   **Componentes:** Interfaces de negocio (`INombreNegocio`) y sus implementaciones.

*   **`S03AN1.Repositorio` (Capa de Acceso a Datos):**
    *   **Responsabilidad:** Abstraer y centralizar toda la lógica de acceso a la base de datos. Es el único lugar donde se interactúa con Entity Framework Core.
    *   **Componentes:** Interfaces de repositorio (`INombreRepositorio`) y sus implementaciones.

*   **`S03AN1.DbModel` (Capa de Modelo de Datos):**
    *   **Responsabilidad:** Contiene las clases (entidades) que mapean directamente la estructura de las tablas de la base de datos.
    *   **Componentes:** Entidades generadas por EF Core y el `DbContext`.

## 2. Tecnologías Utilizadas

*   **Framework:** .NET 6 / .NET 8
*   **Lenguaje:** C#
*   **ORM:** Entity Framework Core
*   **Proveedor de Base de Datos:** Pomelo.EntityFrameworkCore.MySql para la conectividad con MySQL.
*   **Documentación API:** Swagger (OpenAPI)

## 3. Configuración del Entorno de Desarrollo

Sigue estos pasos para configurar y ejecutar el proyecto en tu máquina local.

### Prerrequisitos

*   .NET SDK (versión 6 o superior)
*   Un servidor de base de datos MySQL.
*   Un IDE como Visual Studio 2022 o Visual Studio Code.

### Pasos de Instalación

1.  **Clonar el repositorio:**
    ```bash
    git clone <URL_DEL_REPOSITORIO>
    cd 2026_S03AN1_Ing_Web/BACKEND
    ```

2.  **Configurar la Cadena de Conexión:**
    Abre el archivo `S03AN1.Api/appsettings.Development.json` y modifica la cadena de conexión para que apunte a tu base de datos MySQL local.

3.  **Mapear la Base de Datos (Database-First):**
    Este proyecto utiliza el enfoque "Database-First". Si necesitas (re)generar los modelos a partir de la base de datos, abre la **Consola del Administrador de Paquetes** en Visual Studio, selecciona el proyecto `S03AN1.DbModel` como proyecto predeterminado y ejecuta el siguiente comando:

    ```powershell
    Scaffold-DbContext "Server=localhost;Port=3306;Database=2026_S03AN1;User=root;Password=tu_password;" Pomelo.EntityFrameworkCore.MySql -OutputDir "DbColegio" -DataAnnotations -Context "_dbContext" -NoPluralize -Force
    ```
    > **Nota:** Este comando sobrescribirá los modelos existentes en la carpeta `DbColegio` del proyecto `S03AN1.DbModel`.

4.  **Restaurar Dependencias:**
    Abre la solución en Visual Studio. Las dependencias (paquetes NuGet) deberían restaurarse automáticamente. Si no, haz clic derecho en la solución y selecciona "Restaurar paquetes NuGet".

5.  **Ejecutar la Aplicación:**
    Establece `S03AN1.Api` como proyecto de inicio y presiona `F5` o el botón de ejecución en Visual Studio.

## 4. Documentación de la API

Una vez que la aplicación esté en ejecución, puedes acceder a la documentación interactiva de la API generada por Swagger en la siguiente URL:

**`https://localhost:<PUERTO>/swagger`**

Desde esta interfaz, puedes explorar todos los endpoints disponibles, ver sus modelos de datos y probarlos directamente.

## 5. Principios de Diseño

La solución está construida sobre los principios de diseño **SOLID**, lo que garantiza un código desacoplado, mantenible y extensible.

*   **S - Responsabilidad Única:** Cada capa tiene una única y bien definida responsabilidad.
*   **O - Abierto/Cerrado:** Se pueden agregar nuevas funcionalidades sin modificar el código existente, gracias al uso de interfaces.
*   **L - Sustitución de Liskov:** Las implementaciones concretas pueden ser sustituidas por sus interfaces sin alterar el sistema.
*   **I - Segregación de Interfaces:** Se definen interfaces específicas para cada entidad, evitando que las clases dependan de métodos que no usan.
*   **D - Inversión de Dependencias:** Las capas de alto nivel dependen de abstracciones (interfaces), no de implementaciones de bajo nivel.

## 6. Despliegue

El objetivo de despliegue para esta aplicación es un servidor **Internet Information Services (IIS)** en un entorno Windows Server. La publicación se realizará como una aplicación autocontenida, utilizando el *ASP.NET Core Hosting Bundle* en el servidor de destino.