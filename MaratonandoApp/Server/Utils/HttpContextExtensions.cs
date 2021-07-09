﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Server.Utils
{
    public static class HttpContextExtensions
    {
        public async static Task InserirParametroEmPageResponse<T>(this HttpContext context, 
            IQueryable<T> queryable, int quantidadeTotalRegistrosAExibir)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double quantidadeRegistrosTotal = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(quantidadeRegistrosTotal / quantidadeTotalRegistrosAExibir);
            context.Response.Headers.Add("quantidadeRegistrosTotal", quantidadeRegistrosTotal.ToString());
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
        }

    }
}
