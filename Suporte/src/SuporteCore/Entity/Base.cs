using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuporteCore.Entity
{
    public class Base
    {
        public Base()
        {
        }
        public int Id { get; set; }
        /// <summary>
        /// Chave Unica da Transação
        /// </summary>
        [Required]
        public string Nsu { get; set; }
        /// <summary>
        /// Numero de Cartão do Cliente
        /// </summary>
        [Required]
        public string Card_number { get; set; }
        /// <summary>
        /// Numero Logico da Maquina
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// Data da Confirmação da Transação
        /// </summary>
        public string Confirmation_date { get; set; }
        /// <summary>
        /// Data que foi inserido na base
        /// </summary>
        public DateTime? Date_base { get; set; }
    }
}
