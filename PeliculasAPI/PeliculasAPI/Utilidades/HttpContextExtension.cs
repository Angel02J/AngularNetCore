using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Utilidades
{
    public static class HttpContextExtension
    {
        public async static Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext context,
            IQueryable<T> queryable)
        {
            if(context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double cantidad = await queryable.CountAsync();
            context.Response.Headers.Append("cantidad-total-registros", cantidad.ToString());
        } 

    }
}
