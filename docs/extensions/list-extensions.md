# ListExtensions

Extensiones para `IList<T>`.

## AddIfNotExist<T>(this IList<T> list, T value, Func<T,T,bool> condition, bool override = false)
- Añade `value` si no existe un elemento que cumpla la `condition(value, existing)`.
- Si existe y `override` es true, reemplaza el elemento existente.
- Lanza `ArgumentException` si `list` o `condition` son null.

## AddIfNotExist<T>(this IList<T> list, IEnumerable<T> values, Func<T,T,bool> condition, bool override = false)
- Añade múltiples elementos usando la versión anterior; ignora `values` null.

Ejemplo:

```csharp
var list = new List<Item>();
list.AddIfNotExist(newItem, (newItem, existing) => newItem.Id==existing.Id);
```
