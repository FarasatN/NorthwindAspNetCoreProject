﻿using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidation
{
	public class ShippingDetailValidator: AbstractValidator<ShippingDetail>
	{
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.Address).NotEmpty();
            RuleFor(s=>s.City).NotEmpty().When(s=>s.Age<18);

            //custom rule
            //RuleFor(s => s.FirstName).Must(StartsWithA);
        }

        public bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }   
    }
}
