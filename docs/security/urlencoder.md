# UrlEncoder

Codificación y decodificación URL-safe (variant of base64).

## EncodeFromBase64(string base64String)
- Elimina los padding `=` y sustituye `+` por `-` y `/` por `_`.
- Lanza `ArgumentNullException` si la entrada es null/empty.

## DecodeToBase64(string encodeBase64String)
- Reemplaza `-` → `+` y `_` → `/` y añade padding `=` en función de la longitud para devolver un string base64 válido.
