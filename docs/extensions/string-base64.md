# String Base64

Documentación de las extensiones relacionadas con Base64.

## ToBase64(this string text)
- Convierte la cadena a bytes UTF-8 y devuelve su representación Base64.
- Ejemplo:

```csharp
var b64 = "hola".ToBase64();
```

## ToStringFromBase64(this string base64String)
- Convierte una cadena Base64 a texto UTF-8.

## ToByteArrayFromBase64(this string base64String)
- Extrae el contenido Base64 si la cadena tiene formato tipo `data:...;base64,AAAA` o si ya es solo Base64.
- Excepciones: lanza `ArgumentException` si la cadena es null/empty; lanza `FormatException` si la cadena no contiene `base64,` (según la implementación actual).
