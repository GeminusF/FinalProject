﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {   // bu kurallar ctor icine yazilir
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Urunler A harfi ile baslamali");
        }

        //Oz Qaydamizi yaziriq Mustdan istifade olunur

        // arg gonderdiyim nesnedi p.ProductName
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
