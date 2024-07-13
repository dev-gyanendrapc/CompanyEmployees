using static Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);
        Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges);
        CompanyDto CreateCompany(CompanyForCreationDto company);
        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);
        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges);
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);
        void DeleteCompany(Guid companyId, bool trackChanges);
        Task DeleteCompanyAsync(Guid companyId, bool trackChanges);
        void UpdateCompany(Guid companyid, CompanyForUpdateDto companyForUpdate, bool trackChanges);
        Task UpdateCompanyAsync(Guid companyid, CompanyForUpdateDto companyForUpdate, bool trackChanges);

    }
}
