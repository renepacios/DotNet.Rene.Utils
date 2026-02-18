# SimpleCache

Implementación simple de cache en memoria.

## SimpleCacheEngine<TKey, TValue>
- Constructores:
  - `SimpleCacheEngine()` — usa 60s como expiración por defecto.
  - `SimpleCacheEngine(TimeSpan defaultExpiresTime)` — permite configurar la expiración por defecto.

## Store/ Get / GetOrCreate
- `Store(TKey key, TValue value)` / `Store(TKey key, TValue value, TimeSpan expiresAfter)` — guarda el elemento con tiempo de expiración.
- `Get(TKey key)` — devuelve el valor o `default(TValue)` si no existe o ha expirado.
- `GetOrCreate(TKey key, Func<TValue> createItem, TimeSpan? expiresAfter = null)` — devuelve el valor existente o crea uno vía `createItem`, lo almacena y lo devuelve. Lanza `NullReferenceException` si `createItem` es null.

## CacheItem<T>
- Contiene el valor, la fecha de creación y el TimeSpan de expiración.

Notas:
- Al comprobar expiración se compara `DateTimeOffset.Now - Created >= ExpiresAfter` y si está expirado se elimina la entrada.
