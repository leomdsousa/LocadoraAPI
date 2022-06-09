﻿using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.DTOs
{
    public class LocacaoDTO
    {
        public int IdLocacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o id do filme.")]
        public int IdFilme { get; set; }
        public string Filme { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o id do cliente.")]
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string DataLocacao { get; set; }
        public string DataDevolucao { get; set; }
        public bool EmAtraso { get; set; }
        public bool Ativo { get; set; }
    }
}
