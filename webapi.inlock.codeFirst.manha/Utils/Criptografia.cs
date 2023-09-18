namespace webApi.inlock.codeFirst.manha.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha"> Senha que receberá a Hash </param>
        /// <returns> Senha criptografada com a Hash </returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a Hash da senha informada é igual a Hash salva no banco
        /// </summary>
        /// <param name="senhaForm"> Senha informada pelo usuário </param>
        /// <param name="senhaBanco"> Senha cadastrada no banco </param>
        /// <returns> True ou False (senha é verdadeira?) </returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }


    }
}
