using System;
namespace vigalileo.DTOs.System.Users
{
    public class UserDTO
    {
        public int Entity_BitFileds { get; set; }
        public Guid Id
        {
            get { return this.Id; }
            set
            {
                if ((this.Id_BitFields & this.Entity_BitFileds) == this.Id_BitFields)
                {
                    this.Id = value;
                }
            }
        }
        private int Id_BitFields = 1;
        public string UserName
        {
            get { return this.UserName; }
            set
            {
                if ((this.UserName_BitFields & this.Entity_BitFileds) == this.UserName_BitFields)
                {
                    this.UserName = value;
                }
            }
        }

        private int UserName_BitFields = 2;
        public string FirstName
        {
            get { return this.FirstName; }
            set
            {
                if ((this.FirstName_BitFields & this.Entity_BitFileds) == this.FirstName_BitFields)
                {
                    this.FirstName = value;
                }
            }
        }
        private int FirstName_BitFields = 4;
    }
}