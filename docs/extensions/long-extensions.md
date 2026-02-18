# LongExtensions

Convierte tamaños en bytes a una representación legible (Kb, Mb, Gb, Tb).

## ToReadableSize(this long sizeInBytes)
- Usa la cultura actual para formatear el número; invoca la sobrecarga que recibe `CultureInfo`.

## ToReadableSize(this long sizeInBytes, CultureInfo culture)
- Devuelve cadenas con 2 decimales y sufijos: `Tb`, `Gb`, `Mb`, `Kb` o `bytes`.
- Ejemplos:

```csharp
1024L.ToReadableSize(); // "1.00 Kb"
(1024L*1024).ToReadableSize(); // "1.00 Mb"
```
