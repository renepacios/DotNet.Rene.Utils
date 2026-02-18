# EnumerableExtensions

Helpers para `IEnumerable<T>`.

## ForEach<T>(this IEnumerable<T> source, Action<T,int> action)
- Itera llamando `action(item, index)`; lanza `NullReferenceException` si `source` es null.

## ForEachAsync<T>(this IEnumerable<T> source, Func<T,Task> action)
- Ejecuta secuencialmente `action` de forma asíncrona; lanza `NullReferenceException` si `source` es null y `ArgumentNullException` si `action` es null.

## SelectEach<T>(this IEnumerable<T> source, Func<T,T> where)
- Devuelve cada elemento transformado por la función `where`.

## Prepend<T>(this IEnumerable<T> source, T item)
- Retorna una secuencia que empieza con `item` seguido del contenido original.

## Append<T>(this IEnumerable<T> list, T item)
- Retorna una secuencia que termina en `item`.

## AnyNotNull<T>(this IEnumerable<T> source, Func<T,bool> predicate = null)
- Similar a `Any` pero acepta `source` nulo (devuelve false en ese caso).

## AsEnumerableWithIndex<T>(this IEnumerable<T> source)
- Convierte en `IEnumerable<(T item, int index)>`.

## ToDataTable<T>(this IEnumerable<T> data, string tableName = "")
- Convierte una colección de objetos en `DataTable` usando reflection y `DescriptionAttribute` para nombres de columna cuando exista.

## GetItemType<T>(this IEnumerable<T> _)
- Retorna el `Type` del elemento (`typeof(T)`).
