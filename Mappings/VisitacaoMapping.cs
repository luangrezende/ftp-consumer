using CsvHelper.Configuration;
using Ftp.Consumer.Models;

namespace Ftp.Consumer.Mappings
{
    public class VisitacaoMapping : ClassMap<VisitacaoModel>
    {
        public VisitacaoMapping() : base()
        {
            Map(m => m.Setor).Index(0);
            Map(m => m.UFCRM).Index(1);
            Map(m => m.CRM).Index(2);
            Map(m => m.Nome).Index(3);
            Map(m => m.Esp).Index(4);
            Map(m => m.Contatos).Index(5);
            Map(m => m.DataVisita).Index(6);
            Map(m => m.MotivoVisita).Index(7);
            Map(m => m.AcompanhamentoVisita).Index(8);
            Map(m => m.DataCadastroVisita).Index(9);
            Map(m => m.DataRevisita).Index(10);
            Map(m => m.MotivoRevisita).Index(11);
            Map(m => m.AcompanhamentoRevisita).Index(12);
            Map(m => m.DataCadastroRevisita).Index(13);
            Map(m => m.Endereco).Index(14);
            Map(m => m.Numero).Index(15);
            Map(m => m.Complemento).Index(16);
            Map(m => m.Bairro).Index(17);
            Map(m => m.Cep).Index(18);
            Map(m => m.Cidade).Index(19);
            Map(m => m.UF).Index(20);
            Map(m => m.PE).Index(21);
            Map(m => m.DDD).Index(22);
            Map(m => m.Telefone).Index(23);
            Map(m => m.Email).Index(24);
            Map(m => m.Aniversario).Index(25);
            Map(m => m.Sexo).Index(26);
            Map(m => m.DataInclusao).Index(27);
            Map(m => m.AceitaVisitaRemota).Index(28);
        }
    }
}