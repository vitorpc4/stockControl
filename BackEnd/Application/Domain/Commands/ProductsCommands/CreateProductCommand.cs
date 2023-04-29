﻿using Application.Domain.Models;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Commands.ProductsCommands
{
    public class CreateProductCommand : IRequest<Result<Products>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public double UnitValue { get; set; }
    }
}
