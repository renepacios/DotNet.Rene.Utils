# EnumExtensions

## ToDisplayValue(this Enum value)
- Devuelve el valor de la propiedad `DescriptionAttribute` aplicada al miembro del enum, si existe; en otro caso devuelve `value.ToString()`.
- Lanza `ArgumentNullException` si `value` es null.

Ejemplo:

```csharp
public enum MyEnum { [Description("Mi valor")] Value }
MyEnum.Value.ToDisplayValue(); // "Mi valor"
```
