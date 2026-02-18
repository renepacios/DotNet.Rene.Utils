# Cipher

Clase `Cipher` para cifrar/descifrar texto con AES usando una clave de 16/24/32 caracteres.

Constructor:
- `Cipher(string keyString)` — requiere `keyString` no nulo y cuya longitud sea 16, 24 o 32; en caso contrario lanza `ArgumentNullException` o `ArgumentOutOfRangeException`.

## Encrypt(string text)
- Cifra el texto usando AES y devuelve el resultado codificado en Base64.
- Observación: la implementación actual crea `auxIV` de ceros y no concatena el IV al resultado — por tanto la función `Decrypt` espera el mismo comportamiento (usa IV de ceros). Esto funciona si ambas partes conocen la clave y el IV implícito.

## Decrypt(string cipherText)
- Decodifica el Base64 y descifra usando AES con el mismo tamaño de clave e IV de ceros.

Precaución de seguridad: usar IV fijo (ceros) reduce la seguridad; para entornos reales genere IV único por mensaje y préndalo al contenido cifrado.
