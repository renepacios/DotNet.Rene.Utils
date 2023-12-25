/*
												\||||||/
												 ( o o )
------------------------------------------- oooO---(_)---Oooo-------------------------------------------------------
Author: 	René Pacios
			https://www.webrene.es/	
			Copyright (c) 2012, René Pacios

Created: 2020, 2, 16, 10:11

 Permission is hereby granted, free of charge, to any person  obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without  restriction, including 
without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject 
to the following  conditions:
 
  	The above copyright notice and this permission notice shall be
	included in all copies or substantial portions of the Software.
 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.

										   oooO
										  (    )      Oooo
-------------------------------------------\  (------(    )----------------------------------------------------------------
											\_)       )  /
													  (_/

*/

namespace Rene.Utils.Core.CommonSources
{
    public static class Constants
    {
        public const string VOCALES_MAYUSCULAS_ACENTUADAS = "ÁÉÍÓÚ"; //"AEIOU"
        public const string VOCALES_MINUSCULAS_ACENTUADAS = "áéíóú"; //"AEIOU"
        public const string LETRAS_MAYUSCULAS = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        public const string LETRAS_MINUSCULAS = "abcdefghijklmnñopqrstuvwxyz";
        public const string LETRAS_MAYUSCULAS_INCLUYEACENTOS = LETRAS_MAYUSCULAS + VOCALES_MAYUSCULAS_ACENTUADAS;
        public const string LETRAS_MINUSCULAS_INCLUYEACENTOS = LETRAS_MINUSCULAS + VOCALES_MINUSCULAS_ACENTUADAS;
        public const string LETRAS = LETRAS_MAYUSCULAS + LETRAS_MINUSCULAS;
        public const string NUMEROS = "0123456789";

        public const string BASE64_CARS_PERMITIDOS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    }
}
