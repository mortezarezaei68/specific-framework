using System.ComponentModel.DataAnnotations;

namespace Framework.Exception.DataAccessConfig
{
    public enum ResultStatus
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 0,
        [Display(Name = "رکورد تکراری")]
        Duplicate = 1,
        [Display(Name = "رکورد یافت نشد")]
        NotFound = 5
    }
    

    public enum SortOrder
    {
        Unsorted = 0,
        Ascending = 1,
        Descending = 2,
    }
    public enum DisplayProperty
    {
        Name = 0
    }
}