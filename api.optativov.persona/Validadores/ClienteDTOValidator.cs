using FluentValidation;
using Repository.Modelos;

public class ClienteDTOValidator : AbstractValidator<ClienteDTO>
{
    public ClienteDTOValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es requerido.")
            .Length(3, 100).WithMessage("El nombre debe tener un mínimo de 3 caracteres.");

        RuleFor(x => x.Apellido)
            .NotEmpty().WithMessage("El apellido es requerido.")
            .Length(3, 100).WithMessage("El apellido debe tener un mínimo de 3 caracteres.");

        RuleFor(x => x.Documento)
            .NotEmpty().WithMessage("El documento es requerido.")
            .Length(7, 100).WithMessage("El documento debe tener un mínimo de 7 caracteres.");

        RuleFor(x => x.Celular)
            .NotEmpty().WithMessage("El número de celular es obligatorio.")
            .Matches("^[0-9]{10}$").WithMessage("El número de celular debe ser numérico y contener 10 dígitos.");

        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("El email es obligatorio.")
           .EmailAddress().WithMessage("Debe ser un email válido.");
    }
}