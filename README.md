# TestApi

## instrucciones de uso
```
1. Decargar el repositorio y cuando lo descarguen de click a la solucion que estara el directorio raiz con el nombre de TestApi.sln.
2. crear la base de datos con el script testApi.sql que esta en directorio raiz del proyecto, ejecute en sql server la version es la que se recomendo (SqlServer:
https://go.microsoft.com/fwlink/?linkid=866658)
3. Dentro del proyecto en TestApi\Properties\launchSettings.json agregue la cadena de conexion de su base de datos en el perfil que vaya a usar de preferencia en TestApi
en la variable que se llama "DBString" si ejecuto el script solo sera necesario cambiar el nombre del server.
 "DBString": "Server=DESKTOP-2KQVE8N; Database=testApi; Trusted_Connection=true;"

TIPO DE JSON ESPERADO EN EL REQUEST BODY:
{
  "montoPrestamo": 0,
  "tasa": 0,
  "plazo": 0
}
endpoint: {tuHost}/api/Creditoes
de tipo post

De igual forma puede usar la implementacion de swagger
```
