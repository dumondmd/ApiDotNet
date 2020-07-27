using System.ComponentModel.DataAnnotations;

namespace pessoa.Models
{
    public class Pessoa
    {
        [Key]
        
        public int codigo {get; set;}
        public string nome {get; set;}
        public string cpf {get; set;}
        public string uf {get; set;}
        public string data_nascimento {get; set;}
    }
}