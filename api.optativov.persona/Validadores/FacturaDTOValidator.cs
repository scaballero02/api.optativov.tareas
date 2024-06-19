using FluentValidation;
using Repository.Modelos;

public class FacturaDTOValidator : AbstractValidator<FacturaDTO>
{
    public FacturaDTOValidator()
    {
        RuleFor(x => x.NroFactura)
            .NotEmpty().WithMessage("El número de factura es obligatorio.")
            .Matches("^[0-9]{3}-[0-9]{3}-[0-9]{6}$").WithMessage("El número de factura debe seguir el patrón 000-000-000000.");


        RuleFor(x => x.FechaHora)
            .NotNull().WithMessage("La fecha y hora son obligatorias.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha y hora no pueden ser en el futuro.");

        RuleFor(x => x.Total)
            .GreaterThanOrEqualTo(0).WithMessage("El total debe ser mayor o igual a cero.");

        RuleFor(x => x.TotalIvaCinco)
            .GreaterThanOrEqualTo(0).WithMessage("El total del IVA del 5% debe ser mayor o igual a cero.");

        RuleFor(x => x.TotalIvaDiez)
            .GreaterThanOrEqualTo(0).WithMessage("El total del IVA del 10% debe ser mayor o igual a cero.");

        RuleFor(x => x.TotalIva)
            .GreaterThanOrEqualTo(0).WithMessage("El total del IVA debe ser mayor o igual a cero.");

        RuleFor(x => x.TotalLetras)
            .NotEmpty().WithMessage("El total en letras es obligatorio.")
            .Length(6, 500).WithMessage("El total en letras debe tener entre 6 y 500 caracteres.");

        RuleFor(x => x.Sucursal)
            .NotEmpty().WithMessage("La sucursal es obligatoria.")
            .Length(1, 100).WithMessage("La sucursal debe tener entre 1 y 100 caracteres.");
    }
}