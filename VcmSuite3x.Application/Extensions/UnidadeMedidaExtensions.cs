using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x.Application.Extensions
{
    public static class UnidadeMedidaExtensions
    {
        private static readonly UnitOfWork unitOfw = new UnitOfWork();

        /// <summary>
        /// Localiza <see cref="VcmSuite3x_api.Core.Models.UnidadeMedida">UnidadeMedida</see> pelo nome de <see cref=" VcmSuite3x_api.Core.Models.TipoUnidade">TipoUnidade</see>.
        /// </summary>
        /// <param name="unidadesMedida">Coleção de <see cref=" VcmSuite3x_api.Core.Models.UnidadeMedida">UnidadeMedida</see> a pesquisar.</param>
        /// <param name="nomeTipoUnidade">Nome de <see cref=" VcmSuite3x_api.Core.Models.TipoUnidade">TipoUnidade</see>.</param>
        /// <returns><see cref=" VcmSuite3x_api.Core.Models.UnidadeMedida">UnidadeMedida</see> correspondente ao <see cref=" VcmSuite3x_api.Core.Models.TipoUnidade">TipoUnidade</see> informado.</returns>
        public static UnidadeMedida Find(this Collection<UnidadeMedida> unidadesMedida, String nomeTipoUnidade)
        {
            //TipoUnidade tipoUnidade = TipoUnidadeQuery.Create().Find(nomeTipoUnidade);
            TipoUnidade tipoUnidade = unitOfw.TipoUnidadeRepository.Get(y => y.Nome == nomeTipoUnidade).FirstOrDefault();
            if (tipoUnidade != null)
            {
                return unidadesMedida.FirstOrDefault(um => um.TipoUnidadeId == tipoUnidade.Id);
            }

            return null;
        }

        /// <summary>
        /// Localiza <see cref=" VcmSuite3x_api.Core.Models.UnidadeMedida">UnidadeMedida</see> pelo nome de <see cref=" VcmSuite3x_api.Core.Models.TipoUnidade">TipoUnidade</see>.
        /// </summary>
        /// <param name="unidadesMedida">Coleção de <see cref=" VcmSuite3x_api.Core.Models.UnidadeMedida">UnidadeMedida</see> a pesquisar.</param>
        /// <param name="nomeTipoUnidade">Nome de <see cref=" VcmSuite3x_api.Core.Models.TipoUnidade">TipoUnidade</see>.</param>
        /// <returns>Coleção de <see cref=" VcmSuite3x_api.Core.Models.UnidadeMedida">UnidadeMedida</see> correspondente ao <see cref=" VcmSuite3x_api.Core.Models.TipoUnidade">TipoUnidade</see> informado.</returns>
        public static List<UnidadeMedida> Select(this List<UnidadeMedida> unidadesMedida, String nomeTipoUnidade)
        {
            TipoUnidade tipoUnidade = unitOfw.TipoUnidadeRepository.Get(y => y.Nome == nomeTipoUnidade).FirstOrDefault();
            if (tipoUnidade != null)
            {
                return unidadesMedida.Where(um => um.TipoUnidadeId == tipoUnidade.Id).ToList();
            }

            return null;
        }
    }

}
