# Validations - Format

Contiene validadores para correos y URIs.

## IsValidEmailAddress(this string email)
- Utiliza una expresión regular robusta para validar emails.
- Devuelve `false` en caso de excepción o si la cadena es null/empty.

## IsValidUri(this Uri uri) y IsValidUri(this string url)
- La sobrecarga de string añade esquema por defecto `http://` si falta y valida con `Uri.IsWellFormedUriString`.
- Revisa que la cadena contenga al menos un `.`.
