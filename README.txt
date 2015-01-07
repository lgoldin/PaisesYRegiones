Este archivo contiene especificacion tecnica de la solucion planteada y algunas aclaraciones para la ejecucion.

Se utilizaron las siguientes tecnologias/frameworks:
	1. Framework .NET 4 (Visual Studio 2010, SP1, Framework 4)
	2. MVC4
	3. Ninject (IoC)
	4. Bootstrap, JQuery, Ajax (Views)
	5. NHibernate (Mapping By Code)
	6. SQL Server 2008 (Database)
	7. MSBuild, MSBuildCommunityTasks (Generate Database)
	8. StyleCop (Code analizer)
	9. Moq (Testing)
	10. NUnit (Testing)
	
Algunas aclaraciones:

- Se necesita instalar StyleCop y MSBuildCommunityTasks, los instaladores se encuentran en la carpeta Instaladores
- La solucion se encuentra en TestPractico\TestPractico.sln
- La carpeta con los Scripts para la creacion de la base de datos se encuentra en TestPractico\SQL. 
Dicha carpeta cuenta con 3 subcarpetas:
	1. DB, que contiene el script para generar la base de datos (Recordar modificar el path donde se crearan los .log y .mdf)
	2. Tables, contiene el script para crear las tablas
	3. Data, contiene el script para cargar los datos de prueba

Para generar la base se pueden ejecutar dichos scripts o entrar en TestPractico\Build, 
modificar el archivo connectionString.msbuild indicando el server y darle doble click al archivo CreateDatabase.bat (Esto creara la base TestPractico en el server indicado)

- Por decision propia no genere la tabla DetallePais. A mi entender no aportaba a la funcionalidad. 
- La solucion cuenta con UnitTests del HomeController pero por cuestiones de tiempo no contiene tests ni de los Repositories ni de las Views.
- Se separo el connectionStrings del Web.config y se usaron los transformations para tener la coneccion deseada dependiendo del ambiente.
- No puse los detalles en el diseño como el buscar y los simbolos que aparecen en la imagen de ejemplo, que no tienen funcionalidad detallada en la consigna.