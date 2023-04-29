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
    public class DeleteProductCommand : IRequest<Result<Products>>
    {
        [Required]
        public int Id { get; set; }
    }
}
