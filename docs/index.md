# René Utils — Documentación

Esta carpeta contiene la documentación del proyecto preparada para publicarse con GitHub Pages (sirve archivos desde `docs/`).

Contenido principal:

- Extensions
  - `docs/extensions/string-extensions.md` — Métodos de `StringExtensions` (ToGuid, ToInt, ToEnum, SplitTo, etc.)
  - `docs/extensions/string-base64.md` — Codificación/decodificación Base64
  - `docs/extensions/long-extensions.md` — Formato legible de tamaños en bytes
  - `docs/extensions/double-extensions.md` — Truncado de decimales
  - `docs/extensions/list-extensions.md` — Añadir si no existe en listas
  - `docs/extensions/enumerable-extensions.md` — Helpers para IEnumerable
  - `docs/extensions/dictionary-extensions.md` — Helpers para IDictionary
  - `docs/extensions/enum-extensions.md` — Obter display de enums
  - `docs/extensions/exception-extensions.md` — Mensaje completo de excepciones

- Validations
  - `docs/validations/format.md` — Validadores de email/URI

- SimpleCache
  - `docs/simplecache/simplecache.md` — `SimpleCacheEngine` y `CacheItem`

- Security
  - `docs/security/urlencoder.md` — URL-safe base64
  - `docs/security/cipher.md` — AES simple (Encrypt/Decrypt)

Cómo publicar

1. Asegúrate que GitHub Pages está configurado para servir desde la rama `gh-pages` o desde la carpeta `docs` en la rama por defecto.
2. Se incluye un workflow de GitHub Actions en `.github/workflows/pages.yml` que publica el contenido de `docs/` en la rama `gh-pages` automáticamente cuando se hace push a la rama default.

Si prefieres servir directamente desde la carpeta `docs` en la rama `main`, puedes desactivar el workflow y habilitar Pages en la configuración del repositorio.
