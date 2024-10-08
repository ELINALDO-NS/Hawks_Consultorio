﻿namespace HC.Core.Shared.ModelViews.Endereco
{
    public class NovoEndereco
    {
        /// <example>41000000</example>
        public int CEP { get; set; }
        public EstadoView Estado { get; set; }
        /// <example>Salvador</example>
        public string Cidade { get; set; }
        /// <example>Avenida abc</example>
        public string Logradouro { get; set; }
        /// <example>198</example>
        public string Numero { get; set; }
        /// <example>Ao lado do posto</example>
        public string Complemento { get; set; }


    }
}