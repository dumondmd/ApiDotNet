using Microsoft.EntityFrameworkCore;
using pessoa.Models;


namespace pessoa.Data
{
    public class DataContex : DbContex 
    {
        public DataContex(DbContexOptions<DataContex> options)
        : base(options)
        {

        }

        public DBSet<Pessoa> Pessoas {get; set;}
    }
}