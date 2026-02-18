# DoubleExtensions

## TruncateDecimals(this double numero, short nDecimales)
- Devuelve un `double` con `nDecimales` decimales truncados (sin redondear).
- Si `nDecimales > 15` devuelve el número original.

Ejemplo:

```csharp
3.14159.TruncateDecimals(2); // 3.14
```
