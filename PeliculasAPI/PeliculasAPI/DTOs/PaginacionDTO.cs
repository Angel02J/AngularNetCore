namespace PeliculasAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; }

        private int recordPorPagina = 10;

        private readonly int cantidadMaximaRecordsPorPagina = 50;

        public int RecordPorPagina { get { return recordPorPagina; } 
            set 
            {
                recordPorPagina = (value > cantidadMaximaRecordsPorPagina) ? cantidadMaximaRecordsPorPagina : value;
            }}
    }
}