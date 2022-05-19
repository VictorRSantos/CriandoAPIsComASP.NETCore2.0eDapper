using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        // FailFastValidation
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
     

        public bool Valid()
        {
           AddNotifications(new ValidationContract()                
                .HasMinLen("FirstName", 3, FirstName, "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen("FirstName", 40, FirstName, "O nome deve conter no máximo 40 caracteres")
                .HasMinLen("Lastname", 3, LastName, "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen("LastName", 40, LastName, "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O E-mail é inválido")
                .HasLen(Document, 11, "Document","CPF inválido"));

            return IsValid;
        }

    }
}
