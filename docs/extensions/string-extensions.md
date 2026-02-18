# StringExtensions

Documentación de los métodos de `StringExtensions` (extensiones sobre `string`). La documentación se ha generado analizando la implementación y los tests.

## ToGuid(this string s)
- Convierte una cadena con formato GUID a `System.Guid`.
- Excepciones: lanza `FormatException` si la cadena no es un GUID válido. (Ver tests `ToGuid_Detect_BadFormatGuid`)
- Ejemplo:

```csharp
var g = "DDADCD3F-A494-474C-87AA-D66D882879A0".ToGuid();
```

## ToGuidOrDefault(this string s)
- Intenta parsear; devuelve `Guid.Empty` si falla.
- Ejemplo:

```csharp
var g = "bad".ToGuidOrDefault(); // Guid.Empty
```

## ToGuidOrDefault(this string s, Guid defaultValue)
- Devuelve `defaultValue` cuando el parseo falla.

## ToInt(this string s)
- Convierte a `int`. Si la cadena es null/empty o no se puede parsear devuelve `0`.
- Ejemplos:

```csharp
"1".ToInt(); // 1
"a".ToInt(); // 0
string.Empty.ToInt(); // 0
```

## SplitTo<T>(this string s, params char[] separators)
- Separa la cadena por los separadores y convierte cada elemento al tipo `T` usando `IConvertible`.
- Si la cadena es null o vacía retorna una secuencia vacía.
- Ejemplo:

```csharp
var items = "1,2,3".SplitTo<int>(',').ToList(); // {1,2,3}
```

## ToEnum<T>(this string enumValue)
- Convierte una cadena al enum `T` usando `Enum.Parse` (ignora mayúsculas/minúsculas).
- Lanza `FormatException` si la cadena es null/empty (mensaje desde `ExceptionMessages.StringNullArgumentFormat`) y `ArgumentException` si el valor no corresponde a ninguna opción del enum.

## ToEnumOrDefault<T>(this string enumValue, T defaultValue)
- Devuelve `defaultValue` si la conversión falla o la cadena es null/empty.

## ToRandomString(this string chars, int length)
- Genera una cadena aleatoria de `length` caracteres usando los caracteres de `chars`.
- Excepciones/Comportamiento observado en tests:
  - Si `chars` es null o string.Empty lanza `FormatException`.
  - Si `length` es negativo lanza `ArgumentOutOfRangeException`.
  - Si `length` es 0 devuelve string vacío.
  - Si `chars` contiene sólo espacios, la salida será repetición de espacios.

## ContainsAny(this string element, string[] substringsToCheck)
- Devuelve `true` si `element` contiene al menos una de las cadenas del array.
- Si `element` es null/empty devuelve `false`.
- Si `substringsToCheck` es null o vacío lanza `ArgumentException`.

## AddSpacesToSentence(this string text)
- Inserta espacios antes de letras mayúsculas para separar palabras en camelCase/PascalCase.
- Comportamiento:
  - Si `text` es null/whitespace devuelve string.Empty.
  - Conserva espacios existentes y no elimina caracteres.
  - Trata acrónimos separando cada letra mayúscula (`HTMLParser` → `H T M L Parser`).
