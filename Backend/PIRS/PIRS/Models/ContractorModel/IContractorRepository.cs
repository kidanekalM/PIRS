namespace PIRS.Models.ContractorModel
{
    public interface IContractorRepository
    {
        public Contractor add();
        public Contractor edit(Contractor contractor);
        public Contractor delete(int id);
        public List<Contractor> GetAll();

    }

}
