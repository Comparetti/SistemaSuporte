using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Util
{
    public class Constante
    {
        public const string UrlEndPoint = "https://phoebus.paystore.com.br/api/api/v1/";
        public const string Token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYmYiOjE1MjM0MTU2MDAsInN1Yl9hY3F1aXJlcl9zcGVjaWZpY19pZCI6IjIwIiwidHlwZSI6IjQ4OTQ2MTUiLCJleHAiOjI1MzM3NzcxOTksImlhdCI6MTUyMzQ3NzQ5NH0.kq_mGDXBI5EHjtTeI-St5ed2MXI1nPQw1o29s-6cL08";
        public const int FusoTransactions = -2;
        public const string str = "select top 300 * from TransacoesPos pos WITH (NOLOCK)" +
                  "inner join Pos ps on ps.Id = pos.PosId " +
                  "inner join NumerosLogicoPos nl on nl.Id = ps.NumeroLogicoId " +
                  "inner join Tokens tk on tk.id = pos.TokenId " +
                  "inner join Usuarios us on us.Id = tk.UsuarioId " +
                  "where pos.DataCadastro >= '";
        public const string _con = (@"Server=209.126.106.186\SQL2016;user ID=suporte1;password=inttec2018A;Database=API3");
        public const string strPos = "select * from Pos ps " +
                                      "inner join NumerosLogicoPos ns on ns.Id = ps.NumeroLogicoId " +
                                      "inner join Usuarios us on us.Id = ps.UsuarioId "+
                                      "where NumeroLogico = '";

        public const string strAluguelPos = "select us.NomeRazao, ps.Id, ps.modelo , ps.NumeroDeSerie, ps.Status, ps.VendidoAlugadoAlocado, ps.DesvinculadoPermanentemente, ap.DescontoAluguel, ap.DiaVencimento, ap.ValorAluguel, ap.DescontoEmFaturamento, ap.DescontoSaldoNegativo, ap.AluguelDesativado, ps.UsuarioId from Pos ps WITH (NOLOCK) inner join AlugueisPos ap on ps.id = ap.PosId inner join Usuarios us on us.id = ps.Usuarioid";

        public const string strDetalhePos = "select ps.DataCadastro, us.NomeRazao, us.cpfcnpj,ps.modelo , ps.NumeroDeSerie, ps.DesvinculadoPermanentemente, ap.DiaVencimento, ap.ValorAluguel, ap.DescontoEmFaturamento, ap.AluguelDesativado, np.NumeroLogico from Pos ps WITH (NOLOCK) inner join Usuarios us on us.id = ps.UsuarioId inner join AlugueisPos ap on ap.Posid = ps.id inner join NumerosLogicoPos np on np.id = ps.NumerologicoId";

        public const string strExtratoPos = "select* from ExtratosUsuarios eu inner join Usuarios us on eu.UsuarioId = us.id where eu.TipoTransacao = 'ALUGUEL-POS' and eu.DataCadastro >  '";
        
    }
}
