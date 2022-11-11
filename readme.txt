CMS para gestion de contenidos. Antes de que funcione, hay
que cambiar la cadena de conexion presente en appsettings.json,
y generar un initial migration segun la estrategia de code 
fist, usando la clase MyDBContext presente en la carpeta Models.

Tras esto la funcionalidad de la web es intuitiva, incluye
registro de cuentas, inicio de sesion, la pagina principal 
de cada usuario, donde subir archivos. Los archivos tienen
la particularidad de poder ser publicos, en cuyo caso se 
podran ver en la pestaña de buscar. Tambien se pueden compartir
archivos con otros usuarios, que les apareceran en su pagina 
principal. Los archivos se guardan en wwwroot/Files, carpeta 
que se creara automaticamente. Soporta imagen, video, pdf,
texto, y documentos genericos. Por defecto las cuentas de usuario
tienen impuesta una limitacion de archivos, tamaño de archivos, y 
tipo de archivos. Para probar las funciones avanzadas haga que el 
usuario se vuelva premium.