using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
    public interface IProdutoAppService
    {
        Produto Save(int? id, string codigo, string descricao, int UnidadeMedidaId, int topologiaId, int tipoEntidadeId);
    }
}
