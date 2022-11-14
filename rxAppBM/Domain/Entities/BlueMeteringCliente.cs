using rxAppBM.Models;
using System;
using System.Collections.Generic;

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
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public ICollection<BlueMeteringHidrometro> BlueMeteringHidrometros { get; set; }
        public ICollection<BlueMeteringHidrometroTipo> BlueMeteringHidrometroTipos { get; set; }
        public ICollection<BlueMeteringLigacao> BlueMeteringLigacoes { get; set; }
        public ICollection<BlueMeteringValvulaCorte> BlueMeteringValvulasCorte { get; set; }
        public ICollection<BlueMeteringConsumidor> BlueMeteringConsumidores { get; set; }
        public ICollection<BlueMeteringConsumidorTipo> BlueMeteringConsumidorTipos { get; set; }
        public ICollection<BlueMeteringUnidadeNegocio> BlueMeteringUnidadeNegocios { get; set; }
        public ICollection<BlueMeteringUnidadeGerenciamentoRegional> BlueMeteringUnidadeGerenciamentoRegionais { get; set; }
    }
}