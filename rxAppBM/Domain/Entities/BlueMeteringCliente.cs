using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringCliente
    {
        public Guid BlueMeteringClienteId { get; set; }
        public string IdCliente { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }

        public string PessoaContato { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? trackLastWriteTime { get; set; }
        public DateTime? trackCreationTime { get; set; }
    }
}