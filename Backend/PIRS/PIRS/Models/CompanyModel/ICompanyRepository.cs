namespace PIRS.Models.CompanyModel
{
    public interface ICompanyRepository
    {
        public Company add();
        public Company edit(Company company);
        public Company delete(int id);
        public List<Company> GetAll();
    }
}
