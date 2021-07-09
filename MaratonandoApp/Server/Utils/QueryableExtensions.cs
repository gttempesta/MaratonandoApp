using MaratonandoApp.Shared.Models.Film;
using MaratonandoApp.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Server.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginacao paginacao)
        {
            return queryable
                .Skip((paginacao.Pagina - 1) * paginacao.QuantidadePorPagina)
                .Take(paginacao.QuantidadePorPagina);
        }
    }
}
