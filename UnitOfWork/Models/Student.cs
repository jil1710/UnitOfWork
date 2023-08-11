using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
