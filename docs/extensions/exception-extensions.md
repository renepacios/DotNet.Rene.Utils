# ExceptionExtensions

## GetFullMessage(this Exception exception)
- Construye el mensaje completo concatenando `exception.Message` y los mensajes de `InnerException` en cadena hasta el final.
- Si `exception` es null devuelve string.Empty.
