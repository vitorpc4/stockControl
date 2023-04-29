using Application.Domain.Models;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Commands.ProductsCommands
{
    public class UpdateProductCommand : IRequest<Result<Products>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public double UnitValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
