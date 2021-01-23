using System.ComponentModel.DataAnnotations;

namespace Framework.Exception.DataAccessConfig
{
    public enum CudResultStatus
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 0,
        [Display(Name = "رکورد تکراری")]
        Duplicate = 1,
        [Display(Name = "خطای اعتبارسنجی")]
        ValidationError = 2,
        [Display(Name = "خطای کلی")]
        GeneralException = 3,
        [Display(Name = "خطای کلید خارجی")]
        ForiegnKeyException = 4,
        [Display(Name = "رکورد یافت نشد")]
        NotFound = 5
    }

    public enum ResultStatus
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 0,
        [Display(Name = "یافت نشد")]
        NotFound = 1,
        [Display(Name = "لیست خالی است")]
        ListEmpty = 2,
        [Display(Name = "خطای دسترسی")]
        UnAuthorized = 3,
        [Display(Name = "خطای کلی")]
        GeneralException = 4,
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