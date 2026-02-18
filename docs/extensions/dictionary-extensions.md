# DictionaryExtensions

Extensiones para `IDictionary`.

## AddIfNotExist<TK,T>(this IDictionary<TK,T> dictionary, TK key, T value, bool override = false)
- Añade la clave/valor si no existe la clave. Si existe y `override` es true la reemplaza.
- Lanza `NullReferenceException` si `dictionary` es null.

## AddToGroup<TK,T>(this IDictionary<TK,IList<T>> dictionary, TK key, T value)
- Gestiona colecciones agrupadas: añade `value` a la lista bajo `key`, creando la lista si no existe.
