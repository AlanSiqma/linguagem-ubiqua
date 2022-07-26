namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Dto
{
    public class DomainContextDto
    {   
        public string Id { get; set; }
        public string Organization { get; set; }
        public string Domain { get; set; }
        public string Context { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string UserRegister { get; set; }

        internal DomainContextDto SetEmail(string userRegister)
        {
            this.UserRegister = userRegister;
            return this;
        }
    }
}
