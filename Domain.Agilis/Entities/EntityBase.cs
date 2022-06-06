namespace Domain.Agilis.Entities
{
    public class EntityBase
    {
        protected EntityBase() { }

        public EntityBase(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public bool Ativado { get; set; }
    }
}
