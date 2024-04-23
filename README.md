# API de Gestión de Horarios de Clases

Esta API de .NET Core 7.0 proporciona un backend para una aplicación que gestiona los horarios de clases de varios salones. Permite a los usuarios Leer sobre los horarios de clases, así como también consultar y filtrar la información según diferentes criterios.

## Características

- **CRUD de Horarios de Clases:** Permite crear, leer, actualizar y borrar horarios de clases.
- **Filtrado Avanzado:** Los usuarios pueden filtrar los horarios de clases por salón, día de la semana, hora, profesor, etc.
- **Seguridad:** La API implementa autenticación y autorización para garantizar que solo los usuarios autorizados puedan acceder y modificar los datos.
- **Documentación Interactiva:** Se utiliza Swagger para proporcionar una documentación interactiva de la API, lo que facilita su comprensión y uso por parte de los desarrolladores.

## Requisitos Previos

- .NET Core 7.0 SDK
- Visual Studio 2024 o Visual Studio Code (con las extensiones adecuadas)

## Instalación y Uso

1. Clona este repositorio en tu máquina local.
2. Abre el proyecto en tu entorno de desarrollo preferido.
3. Configura la cadena de conexión a tu base de datos en `appsettings.json`.
4. Ejecuta el proyecto.

```bash
dotnet run
```

5. Accede a la documentación interactiva de la API en https://localhost:{puerto}/swagger.

## Configuración Adicional

La API utiliza configuraciones básicas que pueden ser modificadas según las necesidades del entorno de despliegue. Algunos aspectos a considerar son:

   * Base de Datos: Se puede cambiar el proveedor de base de datos o configurar una conexión a una base de datos remota.
   * Autenticación y Autorización: Se pueden agregar otros proveedores de autenticación, como OAuth, y definir políticas de autorización más específicas.
   * Logging: Se puede configurar el sistema de logging para registrar eventos importantes o errores.

## Contribución

¡Las contribuciones son bienvenidas! Si encuentras errores, tienes ideas para nuevas características o mejoras, no dudes en abrir un issue o enviar un pull request.
## Autor

[Mario1525]

## Licencia

Este proyecto está bajo la Licencia [MIT](LICENSE).

---
Hecho con ❤️ por [mario1525](https://github.com/mario1525)