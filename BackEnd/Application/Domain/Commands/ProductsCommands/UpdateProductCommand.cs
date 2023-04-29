using Application.Domain.Models;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Commands.ProductsCommands
{
    public class UpdateProductCommand : IRequest<Result<Products>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3, ErrorMessage = "Name must be at least three letters long.")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3, ErrorMessage = "Description must be at least three characters long.")]
        public string? Description { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Type { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to one")]
        public int Quantity { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid unitValue")]
        public double UnitValue { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
